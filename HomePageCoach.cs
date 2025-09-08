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
    public partial class homePageCoach : Form
    {
        public homePageCoach()
        {
            InitializeComponent();
        }

        private void homePageCoach_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GridAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void BVerAlumnos_Click(object sender, EventArgs e)
        {
            MostrarVista("alumnos");
        }
        private void MostrarVista(string tipo)
        {
            // Oculto el label de bienvenida
            labelTextoBienvenida.Visible = false;
            // Hago visible el panel de contenido
            contentPanel.Visible = true;
            // Limpio DataGridView antes de cargar nuevos datos
            dataGridView.DataSource = null;

            // Configuro el Label
            labelTitulo.Text = tipo == "alumnos" ? "Mis Alumnos" : "Mis Rutinas";

            // Configuro los botones
            btnAgregar.Text = tipo == "alumnos" ? "Agregar Alumno" : "Agregar Rutina";
            btnEliminar.Text = tipo == "alumnos" ? "Eliminar Alumno" : "Eliminar Rutina";

            // Creo la tabla de datos según tipo
            DataTable dataTable = new DataTable();

            if (tipo == "alumnos")
            {
                dataTable.Columns.Add("DNI");
                dataTable.Columns.Add("Nombre");
                dataTable.Columns.Add("Apellido");
                dataTable.Columns.Add("Fecha de nacimiento");
                dataTable.Columns.Add("Email");
                dataTable.Columns.Add("Teléfono");
                dataTable.Columns.Add("Sexo");
                dataTable.Columns.Add("Estado");

                dataTable.Rows.Add(12345678, "Juan", "Pérez", "22/10/2001", "juanitoperez@gmail.com", "+543794572343", "M", "Activo");
                dataTable.Rows.Add(23456789, "Ana", "Fernández", "03/07/1992", "anafnandez@gmail.com", "+543704456200", "F", "Activo");
            }
            else
            {
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("Rutina");
                dataTable.Columns.Add("Duración (min)");

                dataTable.Rows.Add(1, "Piernas", 45);
                dataTable.Rows.Add(2, "Espalda", 50);
            }

            // Asigno la fuente de datos
            dataGridView.DataSource = dataTable;

            // Ajustes visuales opcionales
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ContainerAlumnos_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contentContainer_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }

        private void BVerRutinas_Click(object sender, EventArgs e)
        {
            MostrarVista("rutinas");
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarUsuario f = new AgregarUsuario();
            f.Show();
        }
    }
}
