using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Taller2_G34
{
    public partial class AgregarAlumno : Form
    {
        private string Cn => ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

        public AgregarAlumno()
        {
            InitializeComponent();
            CargarCombos();
        }

        // Carga inicial de los ComboBox
        private void CargarCombos()
        {
            // 1️⃣ Combo de sexo (valores fijos)
            comboBoxSexo.Items.Add("Masculino");
            comboBoxSexo.Items.Add("Femenino");
            comboBoxSexo.Items.Add("Otro");
            comboBoxSexo.SelectedIndex = 0;

            // 2️⃣ Combo de Coachs (Usuarios con rol = 3)
            using (SqlConnection cn = new SqlConnection(Cn))
            {
                cn.Open();
                SqlDataAdapter daCoach = new SqlDataAdapter(
                    "SELECT id_usuario, nombre + ' ' + apellido AS nombreCompleto FROM Usuario WHERE id_rol = 3 AND estado = 1",
                    cn);
                DataTable dtCoach = new DataTable();
                daCoach.Fill(dtCoach);
                comboBoxCoach.DataSource = dtCoach;
                comboBoxCoach.DisplayMember = "nombreCompleto";
                comboBoxCoach.ValueMember = "id_usuario";
            }

            // 3️⃣ Combo de Planes de entrenamiento
            using (SqlConnection cn = new SqlConnection(Cn))
            {
                cn.Open();
                SqlDataAdapter daPlan = new SqlDataAdapter(
                    "SELECT id_plan, nombre FROM PlanEntrenamiento WHERE estado = 1",
                    cn);
                DataTable dtPlan = new DataTable();
                daPlan.Fill(dtPlan);
                comboBoxPlan.DataSource = dtPlan;
                comboBoxPlan.DisplayMember = "nombre";
                comboBoxPlan.ValueMember = "id_plan";
            }

            // 4️⃣ Combo de Membresías
            using (SqlConnection cn = new SqlConnection(Cn))
            {
                cn.Open();
                SqlDataAdapter daMem = new SqlDataAdapter(
                    "SELECT id_membresia, nombre FROM Membresia",
                    cn);
                DataTable dtMem = new DataTable();
                daMem.Fill(dtMem);
                comboBoxMembresia.DataSource = dtMem;
                comboBoxMembresia.DisplayMember = "nombre";
                comboBoxMembresia.ValueMember = "id_membresia";
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Botón Confirmar y Pagar
        private void BConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                using (SqlConnection cn = new SqlConnection(Cn))
                using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Alumno (
                        nombre, apellido, dni, telefono, email, fecha_nacimiento,
                        sexo, id_membresia, id_plan, id_coach,
                        contacto_emergencia, observaciones, estado
                    )
                    VALUES (
                        @nombre, @apellido, @dni, @telefono, @correo, @fechaNac,
                        @sexo, @idMembresia, @idPlan, @idCoach,
                        @contactoEmergencia, @observaciones, 1
                    )", cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", txtNombreAlumno.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", txtApellidoAlumno.Text.Trim());
                    cmd.Parameters.AddWithValue("@dni", txtDNI.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@fechaNac", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@sexo", comboBoxSexo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@idMembresia", comboBoxMembresia.SelectedValue);
                    cmd.Parameters.AddWithValue("@idPlan", comboBoxPlan.SelectedValue);
                    cmd.Parameters.AddWithValue("@idCoach", comboBoxCoach.SelectedValue);
                    cmd.Parameters.AddWithValue("@contactoEmergencia", DBNull.Value);
                    cmd.Parameters.AddWithValue("@observaciones", textBoxObservaciones.Text.Trim());

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("✅ Alumno registrado exitosamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al registrar alumno: " + ex.Message);
            }
        }

        // Validación de campos obligatorios
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreAlumno.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoAlumno.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Por favor, completá todos los campos obligatorios (*).");
                return false;
            }

            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text, patronEmail))
            {
                MessageBox.Show("El correo electrónico no tiene un formato válido.");
                return false;
            }

            return true;
        }
    }
}
