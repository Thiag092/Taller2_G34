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

            // Guardamos los datos del formulario en memoria
            string nombre = txtNombreAlumno.Text.Trim();
            string apellido = txtApellidoAlumno.Text.Trim();
            string nombreCompleto = $"{nombre} {apellido}";
            string dni = txtDNI.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string correo = txtEmail.Text.Trim();
            DateTime fechaNac = datePickerNacimiento.Value.Date;
            string sexo = comboBoxSexo.SelectedItem.ToString();
            int idMembresia = Convert.ToInt32(comboBoxMembresia.SelectedValue);
            string nombreMembresia = comboBoxMembresia.Text;
            int idPlan = Convert.ToInt32(comboBoxPlan.SelectedValue);
            string nombrePlan = comboBoxPlan.Text;
            int idCoach = Convert.ToInt32(comboBoxCoach.SelectedValue);
            string contactoEmergencia = txtContactoEmergencia.Text.Trim();
            string observaciones = textBoxObservaciones.Text.Trim();

            //Abrimos FormPagos, pasando los datos (no insertamos todavía)
            FormPagos formPagos = new FormPagos(
              nombreCompleto, dni, telefono, correo,
               fechaNac, sexo,
               idMembresia, nombreMembresia,
               idPlan, nombrePlan,
              idCoach, contactoEmergencia, observaciones
            );

            // Si el pago se completa correctamente, cerramos el formulario actual
            if (formPagos.ShowDialog() == DialogResult.OK)
            {
                this.Close();
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
            if (datePickerNacimiento.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser hoy o en el futuro.");
                return false;
            }
            if (txtDNI.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 dígitos.");
                return false;
            }

            return true;

        }

        private void txtNombreAlumno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreAlumno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Ignorar el caracter si no es letra, control o espacio
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter si no es dígito
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Ignorar el caracter si no es dígito
            }
        }

        private void txtApellidoAlumno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Ignorar el caracter si no es letra, control o espacio
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            // Si el campo está vacío, no mostrar error todavía
            if (string.IsNullOrEmpty(email))
                return;

            // Validar formato de correo electrónico
            if (!EsEmailValido(email))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Devolver el foco al TextBox para que el usuario corrija
                txtEmail.Focus();
            }
        }

        // Método auxiliar reutilizable
        private bool EsEmailValido(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return mail.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
