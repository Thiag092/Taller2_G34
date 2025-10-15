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
        private string Conexion => ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

        public AgregarAlumno()
        {
            InitializeComponent();
            CargarCombos();
        }

        // Carga inicial de los ComboBox
        private void CargarCombos()
        {
            // Combo de sexo (valores fijos)
            comboBoxSexo.Items.Add("Masculino");
            comboBoxSexo.Items.Add("Femenino");
            comboBoxSexo.Items.Add("Otro");
            comboBoxSexo.SelectedIndex = 0;

            // Combo de Coachs (Usuarios con rol = 3)
            using (SqlConnection conexion = new SqlConnection(Conexion))
            {
                conexion.Open();
                SqlDataAdapter daCoach = new SqlDataAdapter(
                    "SELECT id_usuario, nombre + ' ' + apellido AS nombreCompleto FROM Usuario WHERE id_rol = 3 AND estado = 1",
                    conexion);
                DataTable dtCoach = new DataTable();
                daCoach.Fill(dtCoach);
                comboBoxCoach.DataSource = dtCoach;
                comboBoxCoach.DisplayMember = "nombreCompleto";
                comboBoxCoach.ValueMember = "id_usuario";
            }

            // Combo de Planes de entrenamiento
            using (SqlConnection cn = new SqlConnection(Conexion))
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

            // Combo de Membresías
            using (SqlConnection conexion = new SqlConnection(Conexion))
            {
                conexion.Open();
                SqlDataAdapter daMem = new SqlDataAdapter(
                    "SELECT id_membresia, nombre FROM Membresia",
                    conexion);
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
                using (SqlConnection conexion = new SqlConnection(Conexion))
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
            );
            SELECT SCOPE_IDENTITY();", conexion)) // devuelve el ID del nuevo alumno
                {
                    cmd.Parameters.AddWithValue("@nombre", txtNombreAlumno.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", txtApellidoAlumno.Text.Trim());
                    cmd.Parameters.AddWithValue("@dni", txtDNI.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@fechaNac", datePickerNacimiento.Value.Date);
                    cmd.Parameters.AddWithValue("@sexo", comboBoxSexo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@idMembresia", comboBoxMembresia.SelectedValue);
                    cmd.Parameters.AddWithValue("@idPlan", comboBoxPlan.SelectedValue);
                    cmd.Parameters.AddWithValue("@idCoach", comboBoxCoach.SelectedValue);
                    cmd.Parameters.AddWithValue("@contactoEmergencia", txtContactoEmergencia.Text.Trim());
                    cmd.Parameters.AddWithValue("@observaciones", textBoxObservaciones.Text.Trim());

                    conexion.Open();

                    // Ejecuta el INSERT y devuelve el id generado
                    int idAlumno = Convert.ToInt32(cmd.ExecuteScalar());

                    MessageBox.Show("Alumno registrado exitosamente.");

                    // Abrimos el formulario de pago pasándole el ID del alumno recién creado
                    //FormPagos formPagos = new FormPagos(idAlumno);
                    //formPagos.ShowDialog();
                }

                // Cerramos el formulario actual después de registrar y pagar
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar alumno: " + ex.Message);
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
