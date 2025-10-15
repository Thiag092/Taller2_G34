using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller2_G34
{
    public partial class FormPagos : Form
    {
        private readonly string Conexion = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
        private int idUsuarioActual;
        public FormPagos()
        {
            InitializeComponent();
        }

        private void FormPagos_Load(object sender, EventArgs e)
        {
            //CargarAlumnos();
           //CargarMediosDePago();
        }
    }
}
