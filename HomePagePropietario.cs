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
    public partial class HomePagePropietario : Form
    {
        public HomePagePropietario()
        {
            InitializeComponent();
        }

        private void contentContainer_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void labelAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarU_Prop formulario = new AgregarU_Prop();
            formulario.Show();
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
              "¿Está seguro que desea cerrar la sesión?",
              "Confirmación",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question
          );

            if (respuesta == DialogResult.Yes)
            {
                login f = new login();
                f.Show();          // vuelve al formulario de login
                this.Close();
            }
        }
    }
}
