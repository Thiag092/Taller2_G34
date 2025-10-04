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
            // Guardar el plan en la base
            int idPlanCreado = GuardarPlan(TBNombrePlan.Text, "");


            if (idPlanCreado > 0)
            {
                NuevoEjercicio formEjercicio = new NuevoEjercicio(idPlanCreado);
                if (formEjercicio.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Ejercicio agregado al plan.");
                }
            }
        }

        private int GuardarPlan(string nombre, string descripcion)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO PlanEntrenamiento (nombre, estado)
                         VALUES (@nombre, 1);
                         SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }


        private void CargarEjercicios()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
            string query = "SELECT nombre, repeticiones, tiempo FROM Ejercicio"; // ya sin WHERE

            DataTable dt = new DataTable(); // ✅ mover acá (antes del try)

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.Fill(dt);

                    dataGridEjercicios.AutoGenerateColumns = false;

                    dataGridEjercicios.Columns["ColNombre"].DataPropertyName = "nombre";
                    dataGridEjercicios.Columns["ColRep"].DataPropertyName = "repeticiones";
                    dataGridEjercicios.Columns["ColTiempo"].DataPropertyName = "tiempo";

                    dataGridEjercicios.DataSource = dt;
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ejercicios: " + ex.Message);
            }
        }





        private void CargarCoaches()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
            string query = @"
    SELECT 
    u.nombre,
    u.apellido,
    u.dni,
    u.email,
    u.fecha_nacimiento,
    u.telefono
FROM Usuario u
INNER JOIN Rol r ON u.id_rol = r.id_rol
WHERE r.descripcion = 'Coach' AND u.estado = 1";


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridCoaches.AutoGenerateColumns = false;

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
            CargarCoaches(); // 🔹 ahora también carga los coaches activos
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

    }
}
