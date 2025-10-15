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
    public partial class FormPagos : Form
    {
        private readonly string Conexion = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
        private int idUsuarioActual;
        public FormPagos(int idUsuario)
        {
            InitializeComponent();
            idUsuarioActual = idUsuario;
            this.Load += new EventHandler(FormPagos_Load);
        }

        private void FormPagos_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
           
        }
        //Carga los alumnos activos en el ComboBox de alumnos
        private void CargarAlumnos()
        {
            using (SqlConnection cn = new SqlConnection(Conexion))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT id_alumno, nombre + ' ' + apellido AS nombreCompleto FROM Alumno WHERE estado = 1", cn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboAlumno.DataSource = dt;
                comboAlumno.DisplayMember = "nombreCompleto";
                comboAlumno.ValueMember = "id_alumno";
            }
        }
        
    }
}
