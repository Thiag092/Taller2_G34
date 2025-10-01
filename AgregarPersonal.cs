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
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||  // Nombre
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||  // Apellido
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||  // Email
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||  // Teléfono
                    string.IsNullOrWhiteSpace(txtDNI.Text) ||  // DNI
                    string.IsNullOrWhiteSpace(txtPassword.Text) ||  // Contraseña
                    string.IsNullOrWhiteSpace(txtPasswordCheck.Text))    // Repetir contraseña
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                // Validar formato de email
                if (!txtEmail.Text.Contains("@"))
                {
                    MessageBox.Show("El correo ingresado no es válido.");
                    return;
                }


                // Validar que el DNI y Teléfono sean numéricos
                if (!long.TryParse(txtDNI.Text, out _))
                {
                    MessageBox.Show("El DNI debe ser numérico.");
                    return;
                }
                //se valida la longitud de la contraseña
                if (txtDNI.Text.Length < 6)
                {
                    MessageBox.Show("El DNI debe tener 8 caracteres.");
                    return;
                }

                if (!long.TryParse(txtTelefono.Text, out _))
                {
                    MessageBox.Show("El Teléfono debe ser numérico.");
                    return;
                }

                // Validar longitud de contraseña
                if (txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres.");
                    return;
                }


                // Validar que las contraseñas coincidan
                if (txtPassword.Text != txtPasswordCheck.Text)
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
                    command.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    command.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    command.Parameters.AddWithValue("@correo", txtEmail.Text.Trim());
                    command.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    command.Parameters.AddWithValue("@dni", txtDNI.Text.Trim());
                    command.Parameters.AddWithValue("@fecha", dateTimePicker1.Value.Date);
                    command.Parameters.AddWithValue("@clave", txtPassword.Text.Trim());

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
            txtPassword.UseSystemPasswordChar = !mostrar;
            txtPasswordCheck.UseSystemPasswordChar = !mostrar;
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacio y la tecla de retroceso
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Limita a 11 caracteres
            TextBox txt = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 11)
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacio y la tecla de retroceso
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Limita a 8 caracteres
            TextBox txt = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 8)
            {
                e.Handled = true;
            }
        }
    }


}
    

