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
        private bool modoSoloLectura; // Nuevo campo que indica si se puede editar o no

        public EditAlumno(string dni, bool soloLectura = false)
        {
            InitializeComponent();
            dniAlumno = dni;
            modoSoloLectura = soloLectura; // guarda si está en modo lectura o edición

            if (!modoSoloLectura)
                CargarCombos(); //carga listas solo si se puede editar

            CargarDatosAlumno();

            // Si está en modo lectura (coach), bloquea los campos
            if (modoSoloLectura)
                DeshabilitarCampos();
            else
            {
                BConfirmar.Visible = true; //cuando lo abre un admin o propietario, el botón Confirmar sí aparece y funciona.
                BConfirmar.Enabled = true;
            }

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
                    A.id_plan,
                    A.id_membresia,
                    P.nombre AS nombre_plan,
                    M.nombre AS nombre_membresia
                FROM Alumno A
                LEFT JOIN PlanEntrenamiento P ON A.id_plan = P.id_plan
                LEFT JOIN Membresia M ON A.id_membresia = M.id_membresia
                WHERE A.dni = @dni;";



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
                        if (txtSexo != null)
                        {
                            var sexo = reader["sexo"] != DBNull.Value ? reader["sexo"].ToString() : null;
                            txtSexo.SelectedItem = sexo;  // coincidirá con los items cargados en CargarCombos()
                        }
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
                        if (comboBoxPlan != null && reader["id_plan"] != DBNull.Value)
                            comboBoxPlan.SelectedValue = Convert.ToInt32(reader["id_plan"]);

                        if (comboBoxMembresia != null && reader["id_membresia"] != DBNull.Value)
                            comboBoxMembresia.SelectedValue = Convert.ToInt32(reader["id_membresia"]);
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
                txtSexo.Enabled = false;

            // --- Fecha de nacimiento ---
            datePickerNacimiento.Enabled = false;

            // --- Tipo de plan / Membresía ---
            if (comboBoxPlan != null)
                comboBoxPlan.Enabled = false;
            if (comboBoxMembresia != null)
                comboBoxMembresia.Enabled = false;

            // --- Botón Confirmar ---
            BConfirmar.Visible = false;
            BConfirmar.Enabled = false;
        }

        private void CargarCombos()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // --- CARGAR PLANES ---
                    using (SqlCommand cmdPlan = new SqlCommand("SELECT id_plan, nombre FROM PlanEntrenamiento WHERE estado = 1", conn))
                    using (SqlDataReader readerPlan = cmdPlan.ExecuteReader())
                    {
                        DataTable dtPlan = new DataTable();
                        dtPlan.Load(readerPlan);

                        comboBoxPlan.DisplayMember = "nombre";
                        comboBoxPlan.ValueMember = "id_plan";
                        comboBoxPlan.DataSource = dtPlan;
                    }

                    // --- CARGAR MEMBRESÍAS ---
                    using (SqlCommand cmdMem = new SqlCommand("SELECT id_membresia, nombre FROM Membresia WHERE estado = 1", conn))
                    using (SqlDataReader readerMem = cmdMem.ExecuteReader())
                    {
                        DataTable dtMem = new DataTable();
                        dtMem.Load(readerMem);

                        comboBoxMembresia.DisplayMember = "nombre";
                        comboBoxMembresia.ValueMember = "id_membresia";
                        comboBoxMembresia.DataSource = dtMem;
                    }

                    // --- CARGAR SEXO ---
                    if (txtSexo != null)
                    {
                        txtSexo.Items.Clear();
                        txtSexo.Items.Add("Masculino");
                        txtSexo.Items.Add("Femenino");
                        txtSexo.Items.Add("Otro");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los combos: " + ex.Message);
            }
        }



        private void textBoxObservaciones_TextChanged(object sender, EventArgs e)
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
                // Validaciones simples
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtDniAlumno.Text))
                {
                    MessageBox.Show("Los campos Nombre, Apellido y DNI son obligatorios.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

                string query = @"
    UPDATE Alumno
    SET 
        nombre = @nombre,
        apellido = @apellido,
        telefono = @telefono,
        email = @correo,
        contacto_emergencia = @contacto,
        sexo = @sexo,
        fecha_nacimiento = @fecha,
        observaciones = @observaciones,
        id_plan = @id_plan,
        id_membresia = @id_membresia
    WHERE dni = @dni;
";



                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@contacto", txtContactoEmergencia.Text.Trim());
                    cmd.Parameters.AddWithValue("@sexo", txtSexo.Text.Trim());
                    cmd.Parameters.AddWithValue("@fecha", datePickerNacimiento.Value);
                    cmd.Parameters.AddWithValue("@observaciones", textBoxObservaciones.Text.Trim());
                    cmd.Parameters.AddWithValue("@id_plan", comboBoxPlan.SelectedValue ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_membresia", comboBoxMembresia.SelectedValue ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@dni", dniAlumno);

                    conn.Open();
                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        MessageBox.Show("Los datos del alumno fueron actualizados correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Cierra el formulario al guardar
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el alumno especificado o no hubo cambios.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos del alumno: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
