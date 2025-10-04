using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Taller2_G34
{
    public partial class EditEjercicio : Form
    {
        private int _idEjercicio;

        public EditEjercicio(int id, string nombre, int repeticiones, int tiempo)
        {
            InitializeComponent();
            _idEjercicio = id;

            // Cargar datos en los TextBox
            txtNombre.Text = nombre;
            txtRepeticiones.Text = repeticiones.ToString(); // ⚠️ Este lo vas a renombrar luego a txtRepeticiones
            txtTiempo.Text = tiempo.ToString();          // ⚠️ Este lo vas a renombrar luego a txtTiempo
        }

        private void BConfirmar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();

            if (!int.TryParse(txtRepeticiones.Text.Trim(), out int repeticiones) ||
                !int.TryParse(txtTiempo.Text.Trim(), out int tiempo))
            {
                MessageBox.Show("Repeticiones y tiempo deben ser números enteros.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
            string query = "UPDATE Ejercicio SET nombre = @nombre, repeticiones = @repeticiones, tiempo = @tiempo WHERE id_ejercicio = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@repeticiones", repeticiones);
                    cmd.Parameters.AddWithValue("@tiempo", tiempo);
                    cmd.Parameters.AddWithValue("@id", _idEjercicio);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Ejercicio actualizado correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el ejercicio: " + ex.Message);
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
