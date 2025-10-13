using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller2_G34
{
    public partial class EditAlumno : Form
    {
        private string dniAlumno;
        public EditAlumno(string dni)
        {
            InitializeComponent();
            dniAlumno = dni;
            CargarDatosAlumno();
        }
        private void CargarDatosAlumno()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

                string query = @"
            SELECT 
                id_alumno,
                nombre,
                apellido,
                telefono,
                dni,
                sexo,
                contacto_emergencia,
                observaciones
            FROM Alumno
            WHERE dni = @dni;
        ";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", dniAlumno);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtDniAlumno.Text = reader["dni"].ToString();
                        txtNombre.Text = reader["nombre"].ToString();
                        txtApellido.Text = reader["apellido"].ToString();
                        txtTelefono.Text = reader["telefono"].ToString();

                        // Si tenés combobox o textbox para sexo, emergencia u observaciones:
                        if (reader["sexo"] != DBNull.Value)
                            txtSexo.Text = reader["sexo"].ToString();

                        if (reader["contacto_emergencia"] != DBNull.Value)
                            txtContactoEmergencia.Text = reader["contacto_emergencia"].ToString();

                        
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún alumno con el DNI especificado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar alumno: " + ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelAdmin_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BConfirmar_Click(object sender, EventArgs e)
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacio y la tecla de retroceso
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void txtDniAlumno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
