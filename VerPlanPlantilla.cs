using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Taller2_G34
{
    public partial class VerPlanPlantilla : Form
    {
        private string Cn => ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

        public VerPlanPlantilla()
        {
            InitializeComponent();
        }

        private void VerPlanPlantilla_Load(object sender, EventArgs e)
        {
            InicializarDataGridView();
            CargarTiposPlan();
        }
        private void InicializarDataGridView()
        {
            if (dgvEjercicios.Columns.Count == 0)
            {
                // Columnas ocultas
                dgvEjercicios.Columns.Add("id_dia", "id_dia");
                dgvEjercicios.Columns["id_dia"].Visible = false;

                dgvEjercicios.Columns.Add("id_ejercicio", "id_ejercicio");
                dgvEjercicios.Columns["id_ejercicio"].Visible = false;

                // Columnas visibles
                dgvEjercicios.Columns.Add("nombreEjercicio", "Ejercicio");
                dgvEjercicios.Columns.Add("cant_series", "Series");
                dgvEjercicios.Columns.Add("repeticiones", "Repeticiones");
                dgvEjercicios.Columns.Add("tiempo", "Tiempo (segundos)");
            }
        }
        // Cargar tipos de plan
        private void CargarTiposPlan()
        {
            comboBoxTipoPlan.Items.Clear();

            using (var cn = new SqlConnection(Cn))
            {
                cn.Open();
                string sql = "SELECT id_tipoPlan, descripcion FROM TipoPlan ORDER BY id_tipoPlan";
                using (var cmd = new SqlCommand(sql, cn))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        comboBoxTipoPlan.Items.Add(new
                        {
                            Id = dr.GetInt32(0),
                            Nombre = dr.GetString(1)
                        });
                    }
                }
            }

            comboBoxTipoPlan.DisplayMember = "Nombre";
            comboBoxTipoPlan.ValueMember = "Id";

            if (comboBoxTipoPlan.Items.Count > 0)
                comboBoxTipoPlan.SelectedIndex = 0;
        }

        // Cargar días según el tipo de plan seleccionado
        private void CargarDias(int idTipoPlan)
        {
            cboDias.Items.Clear();

            using (var cn = new SqlConnection(Cn))
            {
                cn.Open();
                string sql = @"
                    SELECT pd.id_dia, pd.nombreDia
                    FROM PlanEntrenamiento p
                    INNER JOIN Plan_Dia pd ON pd.id_plan = p.id_plan
                    WHERE p.id_tipoPlan = @idTipoPlan
                    ORDER BY pd.id_dia";
                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idTipoPlan", idTipoPlan);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cboDias.Items.Add(new
                            {
                                Id = dr.GetInt32(0),
                                Nombre = dr.GetString(1)
                            });
                        }
                    }
                }
            }

            cboDias.DisplayMember = "Nombre";
            cboDias.ValueMember = "Id";

            if (cboDias.Items.Count > 0)
                cboDias.SelectedIndex = 0;
        }

        // Cargar ejercicios filtrados por tipo de plan y día
        private void CargarEjercicios(int idTipoPlan, int? idDia = null)
        {
            dgvEjercicios.Columns.Clear();

            // Columnas ocultas
            dgvEjercicios.Columns.Add("id_dia", "id_dia");
            dgvEjercicios.Columns["id_dia"].Visible = false;

            dgvEjercicios.Columns.Add("id_ejercicio", "id_ejercicio");
            dgvEjercicios.Columns["id_ejercicio"].Visible = false;

            // Columnas visibles
            dgvEjercicios.Columns.Add("nombreEjercicio", "Ejercicio");
            dgvEjercicios.Columns.Add("cant_series", "Series");
            dgvEjercicios.Columns.Add("repeticiones", "Repeticiones");
            dgvEjercicios.Columns.Add("tiempo", "Tiempo (segundos)");

            using (var cn = new SqlConnection(Cn))
            {
                cn.Open();
                string sql = @"
                    SELECT pe.id_dia, e.id_ejercicio, e.nombre, pe.cant_series, pe.repeticiones, pe.tiempo
                    FROM PlanEntrenamiento p
                    INNER JOIN Plan_Dia pd ON pd.id_plan = p.id_plan
                    INNER JOIN Plan_Ejercicio pe ON pe.id_plan = p.id_plan AND pe.id_dia = pd.id_dia
                    INNER JOIN Ejercicio e ON e.id_ejercicio = pe.id_ejercicio
                    WHERE p.id_tipoPlan = @idTipoPlan";

                if (idDia.HasValue)
                    sql += " AND pd.id_dia = @idDia";

                sql += " ORDER BY pd.id_dia, e.id_ejercicio";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idTipoPlan", idTipoPlan);
                    if (idDia.HasValue)
                        cmd.Parameters.AddWithValue("@idDia", idDia.Value);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dgvEjercicios.Rows.Add(
                                dr.GetInt32(0),  // id_dia
                                dr.GetInt32(1),  // id_ejercicio
                                dr.GetString(2), // nombre ejercicio
                                dr.GetInt32(3),  // series
                                dr.GetInt32(4),  // repeticiones
                                dr.GetInt32(5)   // tiempo
                            );
                        }
                    }
                }
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        // Evento: cambio de tipo de plan
        private void ComboBoxTipoPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoPlan.SelectedItem == null) return;

            dynamic tipo = comboBoxTipoPlan.SelectedItem;
            CargarDias(tipo.Id);
            CargarEjercicios(tipo.Id); // Mostrar todos los ejercicios de ese tipo
        }

        // Evento: cambio de día
        private void cboDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDias.SelectedItem == null || comboBoxTipoPlan.SelectedItem == null) return;

            dynamic dia = cboDias.SelectedItem;
            dynamic tipo = comboBoxTipoPlan.SelectedItem;

            CargarEjercicios(tipo.Id, dia.Id); // Filtrar por día
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //agrega el ejercicio al datagrid pero aun no confirma su insercion en la base de datos
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //aqui se deberia insertar en la base de datos el o los nuevos ejercicios agregados
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            //elimina el ejercicio seleccionado del datagrid y no permite su insercion en la base de datos
        }

    }
}
