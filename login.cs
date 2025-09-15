using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;//aca se agrega las librerias para el SQL
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;// aca tmb

namespace Taller2_G34
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            BCancelar.Click += BCancelar_Click;
            TxUsuario.KeyPress += TxUsuario_KeyPress;
            CBMostrarContraseña.CheckedChanged += CBMostrarContraseña_CheckedChanged;
            TxUsuario.KeyDown += TxCampos_KeyDown;
            TxContraseña.KeyDown += TxCampos_KeyDown;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /*
        private void BIngresar_Click(object sender, EventArgs e)
        {
            string usuario = TxUsuario.Text.Trim();
            string contraseña = TxContraseña.Text.Trim();

            // Validación de campos vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("No puede haber campos vacíos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usuario.Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 dígitos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usuario == "11111111" && contraseña == "coach")
            {
                homePageCoach f = new homePageCoach();
                f.Show();
                this.Hide();
            }
            else if (usuario == "22222222" && contraseña == "admin")
            {
                HomePageAdmin f = new HomePageAdmin();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/


        private void BIngresar_Click(object sender, EventArgs e)
        {
            string usuario = TxUsuario.Text.Trim();
            string contraseña = TxContraseña.Text.Trim();

            // Validación de campos vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("No puede haber campos vacíos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usuario.Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 dígitos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Consulta a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id_rol FROM Usuario WHERE dni = @dni AND contrasena = @contrasena AND estado = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contraseña);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int idRol = Convert.ToInt32(result);

                        // Abre el formulario según el rol
                        if (idRol == 1) // Propietario (falta pantalla)
                        {
                            HomePageAdmin f = new HomePageAdmin();
                            f.Show();
                            this.Hide();
                        }
                        else if (idRol == 2) // Administrador
                        {
                            HomePageAdmin f = new HomePageAdmin();
                            f.Show();
                            this.Hide();
                        }
                        else if (idRol == 3) // Coach
                        {
                            homePageCoach f = new homePageCoach();
                            f.Show();
                            this.Hide();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Dispara OnFormClosing y muestra el mismo aviso
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e) //esto es el aviso de confirmacion al apretar la X
        {
            DialogResult result = MessageBox.Show(
                "¿Seguro que desea cerrar salir?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true; // Cancela el cierre si el usuario elige "No"
            }
            base.OnFormClosing(e);
        }

        private void TxUsuario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CBMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            // Alterna la visibilidad de la contraseña
            TxContraseña.UseSystemPasswordChar = !CBMostrarContraseña.Checked;
        }

        private void TxCampos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BIngresar.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
