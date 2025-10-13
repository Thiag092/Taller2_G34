using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Taller2_G34
{
    public partial class VerPlanPlantilla : Form
    {
        private readonly int _idPlan;
        private DataTable _dtDiaEjercicios;


        public VerPlanPlantilla(int idPlan)
        {
            InitializeComponent();
            _idPlan = idPlan;
        }

        private string Cn => ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

        private void VerPlanPlantilla_Load(object sender, EventArgs e)
        {
            dgvEjercicios.AutoGenerateColumns = true;
            dgvEjercicios.MultiSelect = true;
            dgvEjercicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CargarInfoPlan();
            CargarDias();
            CargarCatalogoEjercicios();

            cboDias.SelectedIndexChanged += cboDias_SelectedIndexChanged;
            if (cboDias.Items.Count > 0)
                cboDias.SelectedIndex = 0;
        }

        private void CargarInfoPlan()
        {
            string sql = @"
                SELECT p.nombre, t.descripcion AS Tipo
                FROM PlanEntrenamiento p
                INNER JOIN TipoPlan t ON t.id_tipoPlan = p.id_tipoPlan
                WHERE p.id_plan = @id";
            using (var cn = new SqlConnection(Cn))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", _idPlan);
                cn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                        labelTitulo.Text = $"{r["nombre"]} ({r["Tipo"]})";
                }
            }
        }

        private void CargarDias()
        {
            string sql = "SELECT id_dia, nombreDia FROM Plan_Dia WHERE id_plan = @id ORDER BY id_dia";
            using (var cn = new SqlConnection(Cn))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.AddWithValue("@id", _idPlan);
                var dt = new DataTable();
                da.Fill(dt);
                cboDias.DisplayMember = "nombreDia";
                cboDias.ValueMember = "id_dia";
                cboDias.DataSource = dt;
            }
        }

        private void CargarCatalogoEjercicios()
        {
            string sql = "SELECT id_ejercicio, nombre FROM Ejercicio ORDER BY nombre";
            using (var cn = new SqlConnection(Cn))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cboEjercicioCatalogo.DisplayMember = "nombre";
                cboEjercicioCatalogo.ValueMember = "id_ejercicio";
                cboEjercicioCatalogo.DataSource = dt;
            }
        }

        private void cboDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDias.SelectedValue is null) return;
            int idDia = Convert.ToInt32(cboDias.SelectedValue);
            CargarEjerciciosDia(idDia);
        }

        private void CargarEjerciciosDia(int idDia)
        {
            string sql = @"
                SELECT e.id_ejercicio, e.nombre, e.repeticiones, e.tiempo
                FROM Plan_Ejercicio pe
                INNER JOIN Ejercicio e ON e.id_ejercicio = pe.id_ejercicio
                WHERE pe.id_plan = @idPlan AND pe.id_dia = @idDia
                ORDER BY e.nombre";
            using (var cn = new SqlConnection(Cn))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.AddWithValue("@idPlan", _idPlan);
                da.SelectCommand.Parameters.AddWithValue("@idDia", idDia);
                _dtDiaEjercicios = new DataTable();
                da.Fill(_dtDiaEjercicios);
                dgvEjercicios.DataSource = _dtDiaEjercicios;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }


        // Método separado para crear nuevo ejercicio
        private void btnNuevoEjercicio_Click(object sender, EventArgs e)
        {
            using (var nuevoEjercicioForm = new NuevoEjercicio(_idPlan))
            {
                var resultado = nuevoEjercicioForm.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    // Recargar los datos después de agregar nuevo ejercicio
                    RecargarDatos();
                    MessageBox.Show("Nuevo ejercicio creado y agregado al plan.", "Éxito");
                }
            }
        }

        // Método para recargar todos los datos
        private void RecargarDatos()
        {
            try
            {
                CargarCatalogoEjercicios();
                CargarDias();

                if (cboDias.Items.Count > 0)
                    cboDias.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recargar datos: {ex.Message}", "Error");
            }
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvEjercicios.SelectedRows)
            {
                dgvEjercicios.Rows.Remove(row);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboDias.SelectedValue == null) return;
            int idDia = Convert.ToInt32(cboDias.SelectedValue);

            using (var cn = new SqlConnection(Cn))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = cn;
                cn.Open();
                var tx = cn.BeginTransaction();
                cmd.Transaction = tx;

                try
                {
                    cmd.CommandText = "DELETE FROM Plan_Ejercicio WHERE id_plan=@p AND id_dia=@d";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@p", _idPlan);
                    cmd.Parameters.AddWithValue("@d", idDia);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO Plan_Ejercicio (id_plan, id_dia, id_ejercicio) VALUES (@p,@d,@e)";
                    foreach (DataRow r in _dtDiaEjercicios.Rows)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@p", _idPlan);
                        cmd.Parameters.AddWithValue("@d", idDia);
                        cmd.Parameters.AddWithValue("@e", r.Field<int>("id_ejercicio"));
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                    MessageBox.Show("✅ Cambios guardados correctamente.");
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgvEjercicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
