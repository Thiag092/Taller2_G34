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

                string query = @"SELECT nombre, apellido, email, telefono, dni, fecha_nacimiento, contrasena, id_rol 
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
                        textBox1.Text = reader["nombre"].ToString();
                        textBox2.Text = reader["apellido"].ToString();
                        textBox4.Text = reader["email"].ToString();
                        textBox5.Text = reader["telefono"].ToString();
                        textBox3.Text = reader["dni"].ToString();
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
    }

}
