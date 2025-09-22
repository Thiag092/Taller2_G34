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
        private void CargarDatosAlumno() //NO VA A MOSTRAR LOS DAATOS PORQUE FUERON HARDCODEADOS EN LA TABLA. NO VIENEN DE LA BASE DE DATOS
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

                string query = @"SELECT A.id_alumno, 
                                U.nombre, U.apellido, U.email, 
                                U.telefono, U.dni, 
                                U.fecha_nacimiento, U.contrasena
                         FROM Alumno A
                         INNER JOIN Usuario U ON A.id_usuario = U.id_usuario
                         WHERE U.dni = @dni";

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
                        txtEmail.Text = reader["email"].ToString();

                        if (reader["fecha_nacimiento"] != DBNull.Value)
                        {
                            dateTimePicker1.Value = Convert.ToDateTime(reader["fecha_nacimiento"]);
                        }
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
    }
}
