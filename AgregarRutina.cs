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
            int idPlanCreado = GuardarPlan(txtNombrePlan.Text, txtDescripcion.Text);

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
            string connectionString = ConfigurationManager
                                        .ConnectionStrings["EnerGymDB"]
                                        .ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO PlanEntrenamiento (nombre, descripcion, estado)
                         VALUES (@nombre, @descripcion, 1);
                         SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);

                    connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()); // devuelve id_plan creado
                }
            }
        }
    }
}
