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
                // Validar que se haya seleccionado un rol
                int idRol = 0;
                if (RBCoach.Checked) idRol = 3;
                else if (RBAdmin.Checked) idRol = 2;
                else if (RBPropietario.Checked) idRol = 1;

                if (idRol == 0)
                {
                    MessageBox.Show("Debe seleccionar un rol para el usuario.");
                    return;
                }

                // Validar campos obligatorios
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||  // Nombre
                    string.IsNullOrWhiteSpace(textBox2.Text) ||  // Apellido
                    string.IsNullOrWhiteSpace(textBox4.Text) ||  // Email
                    string.IsNullOrWhiteSpace(textBox5.Text) ||  // Teléfono
                    string.IsNullOrWhiteSpace(textBox3.Text) ||  // DNI
                    string.IsNullOrWhiteSpace(textBox6.Text))    // Contraseña
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
                        MessageBox.Show("Usuario agregado correctamente!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el usuario - Error");
                    }
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo números y tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo letras, espacio y retroceso
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Igual que para el nombre
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void chkVerClave_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkVerClave.Checked)
            {
                textBox6.UseSystemPasswordChar = false; // Muestra la contraseña
                textBox7.UseSystemPasswordChar = false; // También la confirmación
            }
            else
            {
                textBox6.UseSystemPasswordChar = true;  // Oculta la contraseña
                textBox7.UseSystemPasswordChar = true;  // También la confirmación
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
