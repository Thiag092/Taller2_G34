using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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
            DeshabilitarCampos();
        }
        private void CargarDatosAlumno()
        {
            

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
                string query = @"
SELECT 
    A.id_alumno,
    A.nombre,
    A.apellido,
    A.telefono,
    A.dni,
    A.sexo,
    A.contacto_emergencia,
    A.observaciones,
    A.fecha_nacimiento,
    A.email,
    P.nombre AS nombre_plan,
    M.nombre AS nombre_membresia
FROM Alumno A
LEFT JOIN PlanEntrenamiento P ON A.id_plan = P.id_plan
LEFT JOIN Membresia M ON A.id_membresia = M.id_membresia
WHERE A.dni = @dni;
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

                        // Teléfono
                        txtTelefono.Text = reader["telefono"] != DBNull.Value ? reader["telefono"].ToString() : "";

                        // Email
                        txtEmail.Text = reader["email"] != DBNull.Value ? reader["email"].ToString() : "";

                        // Contacto de emergencia
                        txtContactoEmergencia.Text = reader["contacto_emergencia"] != DBNull.Value
                            ? reader["contacto_emergencia"].ToString() : "";

                        // Sexo
                        txtSexo.Text = reader["sexo"] != DBNull.Value ? reader["sexo"].ToString() : "";

                        // Fecha de nacimiento
                        if (reader["fecha_nacimiento"] != DBNull.Value)
                            datePickerNacimiento.Value = Convert.ToDateTime(reader["fecha_nacimiento"]);
                        else
                            datePickerNacimiento.Value = DateTime.Today;

                        // Observaciones
                        if (textBoxObservaciones != null)
                            textBoxObservaciones.Text = reader["observaciones"] != DBNull.Value
                                ? reader["observaciones"].ToString() : "";

                        // Tipo de plan y membresía (combobox o textbox)
                        if (comboBoxPlan != null)
                            comboBoxPlan.Text = reader["nombre_plan"] != DBNull.Value ? reader["nombre_plan"].ToString() : "";

                        if (comboBoxMembresia != null)
                            comboBoxMembresia.Text = reader["nombre_membresia"] != DBNull.Value ? reader["nombre_membresia"].ToString() : "";
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
        private void DeshabilitarCampos()
        {
            // --- TextBox ---
            txtDniAlumno.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtContactoEmergencia.ReadOnly = true;

            // --- Observaciones ---
            if (textBoxObservaciones != null)
                textBoxObservaciones.ReadOnly = true;

            // --- Sexo ---
            if (txtSexo != null)
                txtSexo.Enabled = false;   // si es ComboBox
                                           // o txtSexo.ReadOnly = true; // si es TextBox

            // --- Fecha de nacimiento ---
            datePickerNacimiento.Enabled = false;

            // --- Tipo de plan / Membresía ---
            if (comboBoxPlan != null)
                comboBoxPlan.Enabled = false;
            if (comboBoxMembresia != null)
                comboBoxMembresia.Enabled = false;

            
        }

        private void textBoxObservaciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
