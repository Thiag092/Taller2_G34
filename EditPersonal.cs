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
    public partial class EditPersonal : Form
    {
        private string dniUsuario;

        public EditPersonal(string dni)
        {
            InitializeComponent();
            dniUsuario = dni;
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

                string query = @"SELECT nombre, apellido, email, telefono, dni, fecha_nacimiento, id_rol 
                 FROM Usuario
                 WHERE dni = @dni";


                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", dniUsuario);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Cargo los datos en los textBox
                        txtNombre.Text = reader["nombre"].ToString();
                        txtApellido.Text = reader["apellido"].ToString();
                        textBox4.Text = reader["email"].ToString();
                        txtTelefono.Text = reader["telefono"].ToString();
                        txtDNI.Text = reader["dni"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(reader["fecha_nacimiento"]);

                        // Selecciono el rol en el RadioButton
                        int idRol = Convert.ToInt32(reader["id_rol"]);
                        if (idRol == 2) RBAdmin.Checked = true;
                        else if (idRol == 3) RBCoach.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuario: " + ex.Message);
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                // Determinar el rol seleccionado
                int idRol = 0;
                if (RBAdmin.Checked) idRol = 2;
                else if (RBCoach.Checked) idRol = 3;

                // Cadena de conexión
                string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

                // Consulta UPDATE (sin incluir contraseña)
                string query = @"UPDATE Usuario 
                         SET nombre = @nombre, 
                             apellido = @apellido, 
                             email = @correo, 
                             telefono = @telefono, 
                             fecha_nacimiento = @fecha, 
                             id_rol = @rol,
                             dni = @dniNuevo 
                         WHERE dni = @dniOriginal";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Parámetros
                    cmd.Parameters.AddWithValue("@dniOriginal", dniUsuario);         // El que vino al abrir el form
                    cmd.Parameters.AddWithValue("@dniNuevo", txtDNI.Text.Trim()); // El que escribió el admin
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@rol", idRol);

                    // Ejecutar
                    conn.Open();
                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        MessageBox.Show("Usuario actualizado correctamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el usuario");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar usuario: " + ex.Message);
            }
        }

        private void labelAdmin_Click(object sender, EventArgs e)
        {

        }


        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

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

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacio y la tecla de retroceso
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

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
