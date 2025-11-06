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

    public partial class EditUser : Form
    {
        private string dniUsuario;

        public EditUser(string dni)
        {
            InitializeComponent();
            dniUsuario = dni;
            CargarDatosUsuario();
            dateTimePicker1.MaxDate = DateTime.Today;

        }

        private void CargarDatosUsuario()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

                string query = @"SELECT U.id_usuario, U.nombre, U.apellido, U.email, U.telefono, 
                                U.dni, U.fecha_nacimiento, U.contrasena, U.id_rol
                         FROM Usuario U
                         INNER JOIN Rol R ON U.id_rol = R.id_rol
                         WHERE U.dni = @dni";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", dniUsuario);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Ahora sí: leo directo del reader
                        textBox3.Text = reader["dni"].ToString();
                        textBox1.Text = reader["nombre"].ToString();
                        textBox2.Text = reader["apellido"].ToString();
                        textBox5.Text = reader["telefono"].ToString();
                        textBox4.Text = reader["email"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(reader["fecha_nacimiento"]);

                       
                        // Marcar el rol correcto en los RadioButtons
                        int idRol = Convert.ToInt32(reader["id_rol"]);
                        if (idRol == 1) RBPropietario.Checked = true;
                        else if (idRol == 2) RBAdmin.Checked = true;
                        else if (idRol == 3) RBCoach.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuario: " + ex.Message);
            }
        }

        private void chkVerClave_CheckedChanged(object sender, EventArgs e)
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
                int idRol = 0;
                if (RBPropietario.Checked) idRol = 1;
                else if (RBAdmin.Checked) idRol = 2;
                else if (RBCoach.Checked) idRol = 3;

                string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;


                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //  Validar email correcto
                if (!EsEmailValido(textBox4.Text.Trim()))
                {
                    MessageBox.Show("Debe ingresar un e-mail válido que contenga '@' y '.'.",
                        "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //  Longitud de DNI
                if (textBox3.Text.Length != 8)
                {
                    MessageBox.Show("El DNI debe tener exactamente 8 números.",
                        "DNI incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //  Teléfono mínimo 7 dígitos
                if (textBox5.Text.Length < 7)
                {
                    MessageBox.Show("El teléfono debe tener al menos 7 números.",
                        "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //  Fecha futura NO permitida
                if (dateTimePicker1.Value.Date > DateTime.Today)
                {
                    MessageBox.Show("La fecha de nacimiento no puede ser futura.",
                        "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //  (Opcional) Edad mínima 18 años
                int edad = DateTime.Today.Year - dateTimePicker1.Value.Year;
                if (dateTimePicker1.Value.Date > DateTime.Today.AddYears(-edad))
                    edad--;

                if (edad < 18)
                {
                    MessageBox.Show("El usuario debe tener al menos 18 años.",
                        "Edad insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Si hay una nueva contraseña
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
                    cmd.Parameters.AddWithValue("@dniOriginal", dniUsuario);
                    cmd.Parameters.AddWithValue("@dniNuevo", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@rol", idRol);


                    

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

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        //validacion de nombre
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }


        //validacion apellido
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        //valida telefono
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }


        //validacion dni
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 8)
                e.Handled = true;
        }

        private bool EsEmailValido(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

    }

}
