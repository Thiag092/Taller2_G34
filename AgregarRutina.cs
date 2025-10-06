using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller2_G34
{
    public partial class AgregarRutina : Form
    {
        public AgregarRutina()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // cierra el form
        }


        private void BCrear_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(TBNombrePlan.Text))
            {
                MessageBox.Show("Por favor ingrese un nombre para el plan.");
                return;
            }

            if (dataGridCoaches.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un coach para el plan.");
                return;
            }

            if (dataGridEjercicios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un ejercicio para el plan.");
                return;
            }

            // 2. Obtener datos del formulario
            string nombrePlan = TBNombrePlan.Text.Trim();
            DateTime fechaInicio = DateTimeInicio.Value;
            DateTime fechaFin = DateTimeFin.Value;
            int cantSeries = 0;

            if (!int.TryParse(TBCantidadSeries.Text, out cantSeries))
                cantSeries = 0;

            // 3. Guardar el plan y obtener su ID
            int idPlanCreado = GuardarPlan(nombrePlan, fechaInicio, fechaFin, cantSeries);

            // 4. Guardar el coach asociado
            int idCoach = Convert.ToInt32(dataGridCoaches.SelectedRows[0].Cells["ColIDCoach"].Value);
            GuardarCoachEnPlan(idPlanCreado, idCoach);

            // 5. Guardar los ejercicios seleccionados (con CheckBox)
            bool algunoSeleccionado = false;

            foreach (DataGridViewRow fila in dataGridEjercicios.Rows)
            {
                bool seleccionado = Convert.ToBoolean(fila.Cells["Seleccionar"].Value ?? false);
                if (seleccionado)
                {
                    int idEjercicio = Convert.ToInt32(fila.Cells["ColID"].Value);
                    GuardarEjercicioEnPlan(idPlanCreado, idEjercicio);
                    algunoSeleccionado = true;
                }
            }

            if (!algunoSeleccionado)
            {
                MessageBox.Show("Debe seleccionar al menos un ejercicio para el plan.");
                return;
            }



            // 6. Confirmación
            MessageBox.Show("✅ Plan creado correctamente junto con sus ejercicios y coach asignado.");

            this.Close();
        }



        private int GuardarPlan(string nombre, DateTime fechaInicio, DateTime fechaFin, int cantSeries)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

            string query = @"INSERT INTO PlanEntrenamiento (nombre, fechaInicio, fechaFin, cantSeries, estado)
                     VALUES (@nombre, @fechaInicio, @fechaFin, @cantSeries, 1);
                     SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@cantSeries", cantSeries);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void GuardarEjercicioEnPlan(int idPlan, int idEjercicio)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
            string query = "INSERT INTO Plan_Ejercicio (id_plan, id_ejercicio) VALUES (@idPlan, @idEjercicio)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idPlan", idPlan);
                cmd.Parameters.AddWithValue("@idEjercicio", idEjercicio);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void GuardarCoachEnPlan(int idPlan, int idCoach)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
            string query = "INSERT INTO Usuario_Plan (id_usuario, id_plan) VALUES (@idCoach, @idPlan)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idCoach", idCoach);
                cmd.Parameters.AddWithValue("@idPlan", idPlan);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }





        private void CargarEjercicios()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
            string query = "SELECT id_ejercicio, nombre, repeticiones, tiempo FROM Ejercicio";

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.Fill(dt);

                    dataGridEjercicios.AutoGenerateColumns = false;
                    dataGridEjercicios.Columns.Clear(); // 🔹 limpiamos para evitar duplicados

                    // ✅ Columna CheckBox
                    DataGridViewCheckBoxColumn colSeleccionar = new DataGridViewCheckBoxColumn();
                    colSeleccionar.Name = "Seleccionar";
                    colSeleccionar.HeaderText = "✔";
                    colSeleccionar.Width = 40;
                    dataGridEjercicios.Columns.Add(colSeleccionar);

                    // ✅ Columna ID (oculta)
                    DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
                    colID.Name = "ColID";
                    colID.HeaderText = "ID Ejercicio";
                    colID.DataPropertyName = "id_ejercicio";
                    colID.Visible = false;
                    dataGridEjercicios.Columns.Add(colID);

                    // ✅ Nombre
                    DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
                    colNombre.Name = "ColNombre";
                    colNombre.HeaderText = "Nombre";
                    colNombre.DataPropertyName = "nombre";
                    dataGridEjercicios.Columns.Add(colNombre);

                    // ✅ Repeticiones
                    DataGridViewTextBoxColumn colRep = new DataGridViewTextBoxColumn();
                    colRep.Name = "ColRep";
                    colRep.HeaderText = "Repeticiones";
                    colRep.DataPropertyName = "repeticiones";
                    dataGridEjercicios.Columns.Add(colRep);

                    // ✅ Tiempo
                    DataGridViewTextBoxColumn colTiempo = new DataGridViewTextBoxColumn();
                    colTiempo.Name = "ColTiempo";
                    colTiempo.HeaderText = "Tiempo (seg)";
                    colTiempo.DataPropertyName = "tiempo";
                    dataGridEjercicios.Columns.Add(colTiempo);

                    // Cargar datos
                    dataGridEjercicios.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ejercicios: " + ex.Message);
            }

            // Ajustes visuales
            dataGridEjercicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridEjercicios.AllowUserToAddRows = false;
        }

        





        private void CargarCoaches()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
            string query = @"
SELECT 
    u.id_usuario,
    u.nombre,
    u.apellido,
    u.dni,
    u.email,
    u.fecha_nacimiento,
    u.telefono
FROM Usuario u
INNER JOIN Rol r ON u.id_rol = r.id_rol
WHERE r.descripcion = 'Coach' AND u.estado = 1";

            // 👇 agregado nuevo
            if (dataGridCoaches.Columns["ColIDCoach"] == null)
            {
                DataGridViewTextBoxColumn colIDCoach = new DataGridViewTextBoxColumn();
                colIDCoach.Name = "ColIDCoach";
                colIDCoach.HeaderText = "ID Coach";
                colIDCoach.Visible = false;
                dataGridCoaches.Columns.Add(colIDCoach);
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridCoaches.AutoGenerateColumns = false;
                    dataGridCoaches.Columns["ColIDCoach"].DataPropertyName = "id_usuario";
                    dataGridCoaches.Columns["ColNombreCoach"].DataPropertyName = "nombre";
                    dataGridCoaches.Columns["ColApellido"].DataPropertyName = "apellido";
                    dataGridCoaches.Columns["ColDNI"].DataPropertyName = "dni";
                    dataGridCoaches.Columns["ColMail"].DataPropertyName = "email";
                    dataGridCoaches.Columns["ColFechaNac"].DataPropertyName = "fecha_nacimiento";
                    dataGridCoaches.Columns["ColTel"].DataPropertyName = "telefono";

                    dataGridCoaches.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar coaches: " + ex.Message);
            }
        }






        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {

        }

        private void AgregarRutina_Click(object sender, EventArgs e)
        {

        }

        private void AgregarRutina_Load(object sender, EventArgs e)
        {
            CargarEjercicios();
            CargarCoaches();

            // ✅ Hace que los checkbox se marquen al instante
            dataGridEjercicios.CurrentCellDirtyStateChanged += dataGridEjercicios_CurrentCellDirtyStateChanged;
        }



        private void dataGridEjercicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridCoaches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }


        private void DatgridEjercicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BAgregarEjercicio_Click(object sender, EventArgs e)
        {
            // Crear instancia del formulario de ejercicios
            AgregarEjercicio formEjercicio = new AgregarEjercicio();

            // Mostrarlo como diálogo modal
            formEjercicio.ShowDialog();

            // Después de cerrarse, recargar el DataGrid de ejercicios
            CargarEjercicios();
        }

        private void dataGridCoaches_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridEjercicios_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridEjercicios.IsCurrentCellDirty)
            {
                dataGridEjercicios.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

    }
}
