using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Taller2_G34
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            BCancelar.Click += BCancelar_Click;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BIngresar_Click(object sender, EventArgs e)
        {
            homePageCoach f = new homePageCoach();
            f.Show();          // abre el nuevo formulario
            this.Hide();
        }

        private void BCancelar_Click(object sender, EventArgs e)//aca se agrega el aviso al oprimir "cancelar"
        {
            DialogResult result = MessageBox.Show(
                "¿Seguro que desea salir?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
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
                "¿Seguro que desea cerrar el programa?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true; // Cancela el cierre si el usuario elige "No"
            }
            base.OnFormClosing(e);
        }
    }
}
