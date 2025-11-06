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
                //  VALIDAR ROL
                int idRol = 0;
                if (RBCoach.Checked) idRol = 3;
                else if (RBAdmin.Checked) idRol = 2;
                else if (RBPropietario.Checked) idRol = 1;

                if (idRol == 0)
                {
                    MessageBox.Show("Debe seleccionar un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // VALIDAR CAMPOS VACÍOS
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||   // Nombre
                    string.IsNullOrWhiteSpace(textBox2.Text) ||   // Apellido
                    string.IsNullOrWhiteSpace(textBox4.Text) ||   // Email
                    string.IsNullOrWhiteSpace(textBox5.Text) ||   // Teléfono
                    string.IsNullOrWhiteSpace(textBox3.Text) ||   // DNI
                    string.IsNullOrWhiteSpace(textBox6.Text) ||   // Contraseña
                    string.IsNullOrWhiteSpace(textBox7.Text))     // Repetir contraseña
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // VALIDAR EMAIL
                if (!textBox4.Text.Contains("@") || !textBox4.Text.Contains("."))
                {
                    MessageBox.Show("Debe ingresar un e-mail válido.", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //  VALIDAR DNI — SOLO NÚMEROS Y 8 DÍGITOS
                if (!textBox3.Text.All(char.IsDigit) || textBox3.Text.Length != 8)
                {
                    MessageBox.Show("El DNI debe ser numérico y tener 8 dígitos.", "DNI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //  VALIDAR TELÉFONO
                if (!textBox5.Text.All(char.IsDigit) || textBox5.Text.Length < 7)
                {
                    MessageBox.Show("El teléfono debe contener solo números y tener al menos 7 dígitos.", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //  VALIDAR FECHA FUTURA
                if (dateTimePicker1.Value.Date > DateTime.Today)
                {
                    MessageBox.Show("La fecha de nacimiento no puede ser futura.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //  (Opcional) VALIDAR EDAD MÍNIMA 18 AÑOS
                int edad = DateTime.Today.Year - dateTimePicker1.Value.Year;
                if (dateTimePicker1.Value.Date > DateTime.Today.AddYears(-edad)) edad--;

                if (edad < 18)
                {
                    MessageBox.Show("El usuario debe tener al menos 18 años.", "Edad insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // VALIDAR CONTRASEÑA
                if (textBox6.Text.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Contraseña débil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBox6.Text != textBox7.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //  INSERT A LA BD
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
                    int filas = command.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        MessageBox.Show("Usuario agregado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                e.Handled = true;

            if (!char.IsControl(e.KeyChar) && textBox3.Text.Length >= 8)
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo letras, espacio y retroceso
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Igual que para el nombre
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
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
