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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Taller2_G34
{
    public partial class AgregarU_Prop : Form
    {
        public AgregarU_Prop()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BConfirmar_Click(object sender, EventArgs e)
        {

            try
            {
                // 1. Obtener la cadena de conexión desde App.config
                string connectionString = ConfigurationManager
                                            .ConnectionStrings["EnerGymDB"]
                                            .ConnectionString;

                // 2. Determinar el rol elegido según el RadioButton
                int idRol = 0;
                if (RBCoach.Checked) idRol = 3; // Coach
                else if (RBAdmin.Checked) idRol = 2; // Administrador
                else if (RBPropietario.Checked) idRol = 1; // Propietario

                // 3. Consulta SQL con parámetros
                string query = @"INSERT INTO Usuario 
                                (id_rol, nombre, apellido, email, telefono, dni, fecha_nacimiento, estado, contrasena)
                                VALUES (@id_rol, @nombre, @apellido, @correo, @telefono, @dni, @fecha, 1, @clave)";

                // 4. Usar conexión y comando
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros
                    command.Parameters.AddWithValue("@id_rol", idRol);
                    command.Parameters.AddWithValue("@nombre", textBox1.Text.Trim());
                    command.Parameters.AddWithValue("@apellido", textBox2.Text.Trim());
                    command.Parameters.AddWithValue("@correo", textBox3.Text.Trim());
                    command.Parameters.AddWithValue("@telefono", textBox4.Text.Trim());
                    command.Parameters.AddWithValue("@dni", textBox5.Text.Trim());
                    command.Parameters.AddWithValue("@fecha", dateTimePicker1.Value.Date);
                    command.Parameters.AddWithValue("@clave", textBox6.Text.Trim());

                    // Abrir conexión e insertar
                    connection.Open();
                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                        MessageBox.Show("Usuario agregado correctamente ✅");
                    else
                        MessageBox.Show("No se pudo agregar el usuario ❌");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar usuario: " + ex.Message);
            }
        }




        

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
