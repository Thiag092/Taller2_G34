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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

                        // ⚠️ Cambiá este nombre por el real que tengas en tu formulario
                        textBox6.Text = reader["contrasena"].ToString();

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
            if (chkVerClave.Checked)
                textBox6.UseSystemPasswordChar = false; // mostrar texto
            else
                textBox6.UseSystemPasswordChar = true;  // ocultar texto
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }

}
