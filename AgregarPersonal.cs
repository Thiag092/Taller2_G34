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
    public partial class AgregarPersonal : Form
    {
        public AgregarPersonal()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
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
                // Validar que se haya seleccionado un rol
                int idRol = 0;
                if (RBCoach.Checked) idRol = 3;       // Coach
                else if (RBAdmin.Checked) idRol = 2;  // Administrador

                if (idRol == 0)
                {
                    MessageBox.Show("Debe seleccionar un rol (Coach o Administrador).");
                    return;
                }

                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||  // Nombre
                    string.IsNullOrWhiteSpace(textBox2.Text) ||  // Apellido
                    string.IsNullOrWhiteSpace(textBox4.Text) ||  // Email
                    string.IsNullOrWhiteSpace(textBox5.Text) ||  // Teléfono
                    string.IsNullOrWhiteSpace(textBox3.Text) ||  // DNI
                    string.IsNullOrWhiteSpace(textBox6.Text) ||  // Contraseña
                    string.IsNullOrWhiteSpace(textBox7.Text))    // Repetir contraseña
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                // Validar formato de email
                if (!textBox4.Text.Contains("@"))
                {
                    MessageBox.Show("El correo ingresado no es válido.");
                    return;
                }


                // Validar que el DNI y Teléfono sean numéricos
                if (!long.TryParse(textBox3.Text, out _))
                {
                    MessageBox.Show("El DNI debe ser numérico.");
                    return;
                }
                //se valida la longitud de la contraseña
                if (textBox3.Text.Length < 6)
                {
                    MessageBox.Show("El DNI debe tener 8 caracteres.");
                    return;
                }

                if (!long.TryParse(textBox5.Text, out _))
                {
                    MessageBox.Show("El Teléfono debe ser numérico.");
                    return;
                }

                // Validar longitud de contraseña
                if (textBox6.Text.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres.");
                    return;
                }


                // Validar que las contraseñas coincidan
                if (textBox6.Text != textBox7.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                    return;
                }

                // Si todo está ok, insertamos
                string connectionString = ConfigurationManager
                                            .ConnectionStrings["EnerGymDB"]
                                            .ConnectionString;

                string query = @"INSERT INTO Usuario 
                                (id_rol, nombre, apellido, email, telefono, dni, fecha_nacimiento, estado, contrasena)
                                VALUES (@id_rol, @nombre, @apellido, @correo, @telefono, @dni, @fecha, 1, @clave)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_rol", idRol);
                    command.Parameters.AddWithValue("@nombre", textBox1.Text.Trim());
                    command.Parameters.AddWithValue("@apellido", textBox2.Text.Trim());
                    command.Parameters.AddWithValue("@correo", textBox4.Text.Trim());
                    command.Parameters.AddWithValue("@telefono", textBox5.Text.Trim());
                    command.Parameters.AddWithValue("@dni", textBox3.Text.Trim());
                    command.Parameters.AddWithValue("@fecha", dateTimePicker1.Value.Date);
                    command.Parameters.AddWithValue("@clave", textBox6.Text.Trim());

                    connection.Open();
                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Usuario agregado correctamente ");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el usuario ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar usuario: " + ex.Message);
            }
        }

        private void chkVerClave_CheckStateChanged(object sender, EventArgs e)
        {
            // Mostrar u ocultar las contraseñas
            bool mostrar = chkVerClave.Checked;
            textBox6.UseSystemPasswordChar = !mostrar;
            textBox7.UseSystemPasswordChar = !mostrar;
        }

        private void BCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkVerClave_CheckStateChanged_1(object sender, EventArgs e)
        {
            bool mostrar = chkVerClave.Checked;

            // Si mostrar = true, desactiva el ocultamiento
            textBox6.UseSystemPasswordChar = !mostrar;
            textBox7.UseSystemPasswordChar = !mostrar;
        }
    }


}
    

