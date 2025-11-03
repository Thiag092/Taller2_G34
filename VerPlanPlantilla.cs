using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Taller2_G34.Services;

namespace Taller2_G34
{
    public partial class VerPlanPlantilla : Form
    {
        private readonly PlanEntrenamientoService _planService;
        private readonly List<EjercicioTemporal> _ejerciciosTemporales;

        //HashSet para guardar los (ID_Ejercicio, ID_Dia) de los ejercicios originales de la plantilla.
        // para saber qué ejercicios no provienen de la plantilla.
        private readonly HashSet<(int IdEjercicio, int IdDia)> _ejerciciosDePlantillaOriginal;

        private string Cn => ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

        public VerPlanPlantilla()
        {
            InitializeComponent();
            _planService = new PlanEntrenamientoService(Cn);
            _ejerciciosTemporales = new List<EjercicioTemporal>();
            _ejerciciosDePlantillaOriginal = new HashSet<(int, int)>(); // Inicialización del rastreador.
        }

        private void VerPlanPlantilla_Load(object sender, EventArgs e)
        {
            InicializarDataGridView();
            CargarComboTipoPlan();
            CargarEjerciciosCatalogo();

            // Ocultar el DataGridView al cargar el formulario.
            dgvEjercicios.Visible = false;
        }

        // --- MÉTODOS DE CARGA E INICIALIZACIÓN ---

        private void InicializarDataGridView()
        {
            dgvEjercicios.AutoGenerateColumns = false;
            dgvEjercicios.Columns.Clear();

            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Dia",
                HeaderText = "Día",
                DataPropertyName = "NombreDia",
                ReadOnly = true
            });

            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Ejercicio",
                HeaderText = "Ejercicio",
                DataPropertyName = "Nombre",
                ReadOnly = true
            });

            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Series",
                HeaderText = "Series",
                DataPropertyName = "Series"
            });

            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Repeticiones",
                HeaderText = "Repeticiones",
                DataPropertyName = "Repeticiones"
            });

            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Tiempo",
                HeaderText = "Tiempo (seg)",
                DataPropertyName = "Tiempo"
            });

            // Columna adicional para mostrar el origen (Plantilla/Nuevo)
            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Origen",
                HeaderText = "Origen",
                DataPropertyName = "Origen",
                ReadOnly = true
            });

            dgvEjercicios.AllowUserToAddRows = false;
            dgvEjercicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarComboTipoPlan()
        {
            try
            {
                var dt = _planService.ObtenerTiposPlan();
                comboBoxTipoPlan.DataSource = dt;
                comboBoxTipoPlan.ValueMember = "id_tipoPlan";
                comboBoxTipoPlan.DisplayMember = "descripcion";
                comboBoxTipoPlan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEjerciciosCatalogo()
        {
            try
            {
                var dt = _planService.ObtenerEjerciciosCatalogo();
                cboEjercicioCatalogo.DataSource = dt;
                cboEjercicioCatalogo.ValueMember = "id_ejercicio";
                cboEjercicioCatalogo.DisplayMember = "nombre";
                cboEjercicioCatalogo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar catálogo de ejercicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxTipoPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoPlan.SelectedValue != null && int.TryParse(comboBoxTipoPlan.SelectedValue.ToString(), out int idTipoPlan))
            {
                // Limpiar todo al cambiar de plantilla
                _ejerciciosTemporales.Clear();
                _ejerciciosDePlantillaOriginal.Clear();
                dgvEjercicios.DataSource = null;

                // Ocultar el DataGridView hasta que se escoja un día en el nuevo plan
                dgvEjercicios.Visible = false;
                lblMensaje.Visible = true;
                btnQuitar.Visible = false;

                CargarComboDias(idTipoPlan);
            }
        }

        private void CargarComboDias(int idTipoPlan)
        {
            try
            {
                cboDias.SelectedIndexChanged -= cboDias_SelectedIndexChanged;

                var dt = _planService.ObtenerDiasPorPlan(idTipoPlan);
                cboDias.DataSource = dt;
                cboDias.ValueMember = "id_dia";
                cboDias.DisplayMember = "nombreDia";
                cboDias.SelectedIndex = -1;

                cboDias.SelectedIndexChanged += cboDias_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar días: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDias.SelectedValue != null && comboBoxTipoPlan.SelectedValue != null)
            {
                int idDia = Convert.ToInt32(cboDias.SelectedValue);
                int idPlan = Convert.ToInt32(comboBoxTipoPlan.SelectedValue); // ID del TipoPlan 

                CargarEjerciciosDia(idPlan, idDia);

                // Hacer visible el DataGridView cuando se selecciona un día
                lblMensaje.Visible = false;
                dgvEjercicios.Visible = true;
                btnQuitar.Visible = true;
            }
            else
            {
                // Ocultar si la selección es nula
                dgvEjercicios.Visible = false;
            }
        }

        private void CargarEjerciciosDia(int idPlan, int idDia)
        {
            try
            {
                var ejerciciosBD = _planService.ObtenerEjerciciosPlanDia(idPlan, idDia);
                var nombreDia = cboDias.Text;

                // 1. Quitar todos los ejercicios de este día de la lista temporal antes de recargar.
                _ejerciciosTemporales.RemoveAll(e => e.IdDia == idDia);
                // 2. Limpiar los IDs de seguimiento de este día (se vuelven a añadir después).
                _ejerciciosDePlantillaOriginal.RemoveWhere(e => e.IdDia == idDia);

                // 3. Agregar ejercicios de la plantilla y rastrearlos
                foreach (DataRow row in ejerciciosBD.Rows)
                {
                    int currentIdEjercicio = Convert.ToInt32(row["id_ejercicio"]);

                    // ⭐ Rastrear el ejercicio de la plantilla
                    _ejerciciosDePlantillaOriginal.Add((currentIdEjercicio, idDia));

                    _ejerciciosTemporales.Add(new EjercicioTemporal
                    {
                        IdEjercicio = currentIdEjercicio,
                        Nombre = row["Ejercicio"].ToString(),
                        IdDia = idDia,
                        NombreDia = nombreDia,
                        Series = Convert.ToInt32(row["Series"]),
                        Repeticiones = Convert.ToInt32(row["Repeticiones"]),
                        Tiempo = Convert.ToInt32(row["Tiempo"]),
                    });
                }

                // 4. Actualizar DataGridView con todos los ejercicios del día seleccionado
                ActualizarDataGridViewPorDia(idDia);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ejercicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarDataGridViewPorDia(int idDia)
        {
            //Proyección del DataGridView. Incluye el ID de Ejercicio, es VITAL para el botón Quitar.
            var ejerciciosDelDia = _ejerciciosTemporales
                .Where(e => e.IdDia == idDia)
                .Select(e => new
                {
                    e.IdEjercicio, //Necesario para eliminar
                    e.NombreDia,
                    e.Nombre,
                    e.Series,
                    e.Repeticiones,
                    e.Tiempo,
                    //rastreador externo para mostrar el origen
                    Origen = _ejerciciosDePlantillaOriginal.Contains((e.IdEjercicio, e.IdDia)) ? "Plantilla" : "Nuevo"
                })
                .ToList();

            dgvEjercicios.DataSource = ejerciciosDelDia.OrderBy(e => e.Nombre).ToList();
        }

        // --- VALIDACIÓN Y ACCIONES ---

        // Adaptación de validación de duplicados
        private bool EsEjercicioDuplicado(int idEjercicio, int idDia)
        {
            // Verificamos si la combinación de ID de Ejercicio e ID de Día ya existe en la lista temporal.
            return _ejerciciosTemporales
                .Any(e => e.IdEjercicio == idEjercicio && e.IdDia == idDia);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // 1. Validar selección
            if (cboEjercicioCatalogo.SelectedValue == null || cboDias.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un ejercicio y un día primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idEjercicio = Convert.ToInt32(cboEjercicioCatalogo.SelectedValue);
                string nombreEjercicio = cboEjercicioCatalogo.Text;
                int idDia = Convert.ToInt32(cboDias.SelectedValue);
                string nombreDia = cboDias.Text;

                // 2. Validación de Duplicados
                if (EsEjercicioDuplicado(idEjercicio, idDia))
                {
                    MessageBox.Show("Este ejercicio ya existe para el día seleccionado en el plan.", "Ejercicio Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Obtención y validación de parámetros (Series, Repeticiones, Tiempo)
                int series = cantSeries.Value == 0 ? 3 : (int)cantSeries.Value;
                int repeticiones = cantRepeticiones.Value == 0 ? 10 : (int)cantRepeticiones.Value;

                int tiempo = 0;
                if (!string.IsNullOrEmpty(txtTiempo.Text) && int.TryParse(txtTiempo.Text, out int t) && t >= 0)
                {
                    tiempo = t;
                }
                else if (string.IsNullOrEmpty(txtTiempo.Text))
                {
                    tiempo = 30; // Valor por defecto
                }
                else
                {
                    MessageBox.Show("El tiempo debe ser un número entero válido (segundos).", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4. Crear y agregar el ejercicio temporal (No es necesario EsTemporal)
                var ejercicio = new EjercicioTemporal
                {
                    IdEjercicio = idEjercicio,
                    Nombre = nombreEjercicio,
                    IdDia = idDia,
                    NombreDia = nombreDia,
                    Series = series,
                    Repeticiones = repeticiones,
                    Tiempo = tiempo
                };

                _ejerciciosTemporales.Add(ejercicio);

                // Refrescar la vista
                ActualizarDataGridViewPorDia(idDia);

                // 5. Limpiar controles
                cboEjercicioCatalogo.SelectedIndex = -1;
                cantSeries.Value = 0;
                cantRepeticiones.Value = 0;
                txtTiempo.Text = "";

                MessageBox.Show("Ejercicio agregado al plan.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar ejercicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ahora obtiene el ID_Ejercicio del objeto seleccionado (gracias a la proyección)
        // y lo usa para buscar y eliminar de la lista completa _ejerciciosTemporales.
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvEjercicios.CurrentRow != null && cboDias.SelectedValue != null)
            {
                // El objeto ligado contiene IdEjercicio y NombreDia
                dynamic selectedItem = dgvEjercicios.CurrentRow.DataBoundItem;

                int idDiaActual = Convert.ToInt32(cboDias.SelectedValue);
                int idEjercicioSeleccionado = selectedItem.IdEjercicio;
                string nombreEjercicio = selectedItem.Nombre;

                DialogResult result = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el ejercicio '{nombreEjercicio}' del día '{selectedItem.NombreDia}'?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Buscar y eliminar el objeto exacto de la lista completa
                    var ejercicioAEliminar = _ejerciciosTemporales
                        .FirstOrDefault(ejercicio => ejercicio.IdDia == idDiaActual &&
                                                     ejercicio.IdEjercicio == idEjercicioSeleccionado);

                    if (ejercicioAEliminar != null)
                    {
                        _ejerciciosTemporales.Remove(ejercicioAEliminar);

                        // Si se eliminó un ejercicio de la plantilla, lo saco del rastreador
                        _ejerciciosDePlantillaOriginal.Remove((idEjercicioSeleccionado, idDiaActual));

                        // Refrescar solo el día actual
                        ActualizarDataGridViewPorDia(idDiaActual);

                        MessageBox.Show("Ejercicio eliminado correctamente del plan.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar el ejercicio para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un ejercicio para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombrePlan.Text))
            {
                MessageBox.Show("Ingrese un nombre para el plan.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxTipoPlan.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un tipo de plan.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idTipoPlan = Convert.ToInt32(comboBoxTipoPlan.SelectedValue);
                string nombrePlan = txtNombrePlan.Text;
                int? idPlanOriginal = _planService.ObtenerIdPlanPorTipo(idTipoPlan);

                // Obtenemos solo los ejercicios que son NUEVOS, excluyendo a los de la Plantilla Original
                // que quedaron después de las eliminaciones.
                var ejerciciosNuevos = _ejerciciosTemporales
                    .Where(ejercicio => !_ejerciciosDePlantillaOriginal.Contains((ejercicio.IdEjercicio, ejercicio.IdDia)))
                    .ToList();

                // 1. Copiar la estructura base de la plantilla (usando idPlanOriginal).
                // 2. Insertar los ejercicios de la lista ejerciciosNuevos.
                // 3. Omitir los ejercicios que fueron eliminados
                int idNuevoPlan = _planService.GuardarPlanCompleto(nombrePlan, idTipoPlan, ejerciciosNuevos, idPlanOriginal);

                MessageBox.Show($"Plan guardado exitosamente con ID: {idNuevoPlan}",
                                 "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar todo después de guardar
                _ejerciciosTemporales.Clear();
                _ejerciciosDePlantillaOriginal.Clear();
                dgvEjercicios.DataSource = null;
                txtNombrePlan.Text = "";
                comboBoxTipoPlan.SelectedIndex = -1;
                cboDias.DataSource = null;
                panel1.Visible = false;
                dgvEjercicios.Visible = false; // Ocultar después de guardar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboEjercicioCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEjercicioCatalogo.SelectedValue != null && cboDias.SelectedValue != null)
            {
                int idEjercicio = Convert.ToInt32(cboEjercicioCatalogo.SelectedValue);
                int idDia = Convert.ToInt32(cboDias.SelectedValue);

                bool existeDuplicado = EsEjercicioDuplicado(idEjercicio, idDia);

                if (existeDuplicado)
                {
                    btnConfirmar.Enabled = false;
                    // toolTip1.SetToolTip(btnConfirmar, "Este ejercicio ya existe para el día seleccionado");
                }
                else
                {
                    btnConfirmar.Enabled = true;
                    // toolTip1.RemoveAll();
                }
            }
        }
        private void txtNombrePlan_TextChanged(object sender, EventArgs e) { }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) { }
    }
}