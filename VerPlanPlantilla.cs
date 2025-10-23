using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Taller2_G34.Services;

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

                // Combinar ejercicios de BD con ejercicios temporales para este día
                var ejerciciosCombinados = _ejerciciosTemporales
                    .Where(e => e.IdDia == idDia)
                    .Select(e => new
                    {
                        e.NombreDia,
                        e.Nombre,
                        e.Series,
                        e.Repeticiones,
                        e.Tiempo
                    })
                    .ToList();

                // Agregar ejercicios de la base de datos
                foreach (DataRow row in ejerciciosBD.Rows)
                {
                    ejerciciosCombinados.Add(new
                    {
                        NombreDia = nombreDia,
                        Nombre = row["Ejercicio"].ToString(),
                        Series = Convert.ToInt32(row["Series"]),
                        Repeticiones = Convert.ToInt32(row["Repeticiones"]),
                        Tiempo = Convert.ToInt32(row["Tiempo"])
                    });
                }

                dgvEjercicios.DataSource = ejerciciosCombinados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ejercicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

                // Agregar a la lista temporal
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

                // CORRECCIÓN: En lugar de ActualizarDataGridViewCompleto(),
                // llamar a CargarEjerciciosDia para combinar temporales + BD
                if (comboBoxTipoPlan.SelectedValue != null && cboDias.SelectedValue != null)
                {
                    int idPlan = Convert.ToInt32(comboBoxTipoPlan.SelectedValue);
                    int currentIdDia = Convert.ToInt32(cboDias.SelectedValue);
                    CargarEjerciciosDia(idPlan, currentIdDia); // ← Esto combina ambos
                }

                // Limpiar controles
                cboEjercicioCatalogo.SelectedIndex = -1;
                cantSeries.Value = 0;
                cantRepeticiones.Value = 0;
                txtTiempo.Text = "";

                MessageBox.Show("Ejercicio agregado temporalmente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar ejercicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (!_ejerciciosTemporales.Any())
            {
                MessageBox.Show("Agregue al menos un ejercicio al plan.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                int idNuevoPlan = _planService.GuardarPlanCompleto(nombrePlan, idTipoPlan, _ejerciciosTemporales);

                MessageBox.Show($"Plan guardado exitosamente con ID: {idNuevoPlan}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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