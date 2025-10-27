using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Taller2_G34.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Taller2_G34
{
    public partial class VerPlanPlantilla : Form
    {
        private readonly PlanEntrenamientoService _planService;
        private readonly List<EjercicioTemporal> _ejerciciosTemporales;

        private string Cn => ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

        public VerPlanPlantilla()
        {
            InitializeComponent();
            _planService = new PlanEntrenamientoService(Cn);
            _ejerciciosTemporales = new List<EjercicioTemporal>();
        }

        private void VerPlanPlantilla_Load(object sender, EventArgs e)
        {
            InicializarDataGridView();
            CargarComboTipoPlan();
            CargarEjerciciosCatalogo();
        }

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
                int idPlan = Convert.ToInt32(comboBoxTipoPlan.SelectedValue);

                // Cargar ejercicios existentes de la base de datos para este día
                CargarEjerciciosDia(idPlan, idDia);
            }
        }

        private void CargarEjerciciosDia(int idPlan, int idDia)
        {
            try
            {
                var ejerciciosBD = _planService.ObtenerEjerciciosPlanDia(idPlan, idDia);
                var nombreDia = cboDias.Text;

                // Limpiar ejercicios anteriores de este día (mantener ejercicios de otros días)
                _ejerciciosTemporales.RemoveAll(e => e.IdDia == idDia && !e.EsTemporal);

                // Agregar ejercicios de la base de datos para este día
                foreach (DataRow row in ejerciciosBD.Rows)
                {
                    _ejerciciosTemporales.Add(new EjercicioTemporal
                    {
                        IdEjercicio = Convert.ToInt32(row["id_ejercicio"]),
                        Nombre = row["Ejercicio"].ToString(),
                        IdDia = idDia,
                        NombreDia = nombreDia,
                        Series = Convert.ToInt32(row["Series"]),
                        Repeticiones = Convert.ToInt32(row["Repeticiones"]),
                        Tiempo = Convert.ToInt32(row["Tiempo"]),
                        EsTemporal = false
                    });
                }

                // Actualizar DataGridView con todos los ejercicios del día seleccionado
                ActualizarDataGridViewPorDia(idDia);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ejercicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarDataGridViewPorDia(int idDia)
        {
            var ejerciciosDelDia = _ejerciciosTemporales
                .Where(e => e.IdDia == idDia)
                .Select(e => new
                {
                    e.NombreDia,
                    e.Nombre,
                    e.Series,
                    e.Repeticiones,
                    e.Tiempo,
                    Origen = e.EsTemporal ? "Nuevo" : "Plantilla" // Para mostrar de dónde viene
                })
                .ToList();

            dgvEjercicios.DataSource = ejerciciosDelDia;
        }

        //agregar validaciones otra vez
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
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

                int series = cantSeries.Value == 0 ? 3 : (int)cantSeries.Value;
                int repeticiones = cantRepeticiones.Value == 0 ? 10 : (int)cantRepeticiones.Value;
                int tiempo = string.IsNullOrEmpty(txtTiempo.Text) ? 30 : int.Parse(txtTiempo.Text);

                // Agregar a la lista completa como ejercicio temporal
                var ejercicio = new EjercicioTemporal
                {
                    IdEjercicio = idEjercicio,
                    Nombre = nombreEjercicio,
                    IdDia = idDia,
                    NombreDia = nombreDia,
                    Series = series,
                    Repeticiones = repeticiones,
                    Tiempo = tiempo,
                    EsTemporal = true
                };

                _ejerciciosTemporales.Add(ejercicio);
                ActualizarDataGridViewPorDia(idDia);

                // Limpiar controles
                cboEjercicioCatalogo.SelectedIndex = -1;
                cantSeries.Value = 0;
                cantRepeticiones.Value = 0;
                txtTiempo.Text = "";

                MessageBox.Show("Ejercicio agregado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar ejercicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboEjercicioCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEjercicioCatalogo.SelectedValue != null && cboDias.SelectedValue != null)
            {
                int idEjercicio = Convert.ToInt32(cboEjercicioCatalogo.SelectedValue);
                string nombreEjercicio = cboEjercicioCatalogo.Text;
                int idDia = Convert.ToInt32(cboDias.SelectedValue);

                // Verificar si ya existe
                bool existeDuplicado = _ejerciciosTemporales
                    .Any(eje => (eje.IdEjercicio == idEjercicio ||
                              eje.Nombre.Equals(nombreEjercicio, StringComparison.OrdinalIgnoreCase)) &&
                             eje.IdDia == idDia);

                if (existeDuplicado)
                {
                    btnConfirmar.Enabled = false;
                    toolTip1.SetToolTip(btnConfirmar, "Este ejercicio ya existe para el día seleccionado");
                }
                else
                {
                    btnConfirmar.Enabled = true;
                    toolTip1.RemoveAll();
                }
            }
        }

        private void ActualizarDataGridViewCompleto()
        {
            var datosMostrar = _ejerciciosTemporales.Select(e => new
            {
                e.NombreDia,
                e.Nombre,
                e.Series,
                e.Repeticiones,
                e.Tiempo
            }).ToList();

            dgvEjercicios.DataSource = datosMostrar;
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

                // Obtener el ID del plan original para copiar la plantilla base
                int? idPlanOriginal = _planService.ObtenerIdPlanPorTipo(idTipoPlan);

                // Solo los ejercicios temporales (nuevos que agregó el usuario)
                var ejerciciosNuevos = _ejerciciosTemporales;

                int idNuevoPlan = _planService.GuardarPlanCompleto(nombrePlan, idTipoPlan, ejerciciosNuevos, idPlanOriginal);

                MessageBox.Show($"Plan guardado exitosamente con ID: {idNuevoPlan}\n" +
                               $"Se copió la plantilla base + {ejerciciosNuevos.Count} ejercicios nuevos.",
                               "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar todo después de guardar
                _ejerciciosTemporales.Clear();
                dgvEjercicios.DataSource = null;
                txtNombrePlan.Text = "";
                comboBoxTipoPlan.SelectedIndex = -1;
                cboDias.DataSource = null;
                panel1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //modificar para que se puedan eliminar ejercicios que vienen de la plantilla también
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvEjercicios.CurrentRow != null)
            {
                int index = dgvEjercicios.CurrentRow.Index;
                if (index < _ejerciciosTemporales.Count)
                {
                    _ejerciciosTemporales.RemoveAt(index);
                    ActualizarDataGridViewCompleto();
                }
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
        private void txtNombrePlan_TextChanged(object sender, EventArgs e)
        {
        }
    }
}