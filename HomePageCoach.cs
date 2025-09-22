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
    public partial class homePageCoach : Form
    {
       // private object verFicha;

        public homePageCoach()
        {
            InitializeComponent();
        }

        private void homePageCoach_Load(object sender, EventArgs e)
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

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
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
            //hago invisible los botones 
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
            BRefresh.Visible = false;
            // Limpio el DataGridView antes de cargar nuevos datos
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            // Columna de botón
            DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn();
            btnDetalles.HeaderText = "Detalles";
            btnDetalles.Text = "Ver más";
            btnDetalles.Name = "Detalles";

            if (tipo == "alumnos")
            {
                // Creo columnas
                dataGridView.Columns.Add("DNI", "DNI");
                dataGridView.Columns.Add("Nombre", "Nombre");
                dataGridView.Columns.Add("Apellido", "Apellido");
                dataGridView.Columns.Add("FechaNacimiento", "Fecha de nacimiento");
                dataGridView.Columns.Add("Email", "Email");
                dataGridView.Columns.Add("Telefono", "Teléfono");
                dataGridView.Columns.Add("Sexo", "Sexo");
                dataGridView.Columns.Add("Estado", "Estado");
                // importante para identificar la columna
                btnDetalles.UseColumnTextForButtonValue = true;
                dataGridView.Columns.Add(btnDetalles);
                // Agrego filas
                dataGridView.Rows.Add(12345678, "Juan", "Pérez", "22/10/2001", "juanitoperez@gmail.com", "+543794572343", "M", "Activo");
                dataGridView.Rows.Add(23456789, "Ana", "Fernández", "03/07/1992", "anafnandez@gmail.com", "+543704456200", "F", "Activo");

                // Configuro título y botones
                labelTitulo.Text = "Alumnos";
            }
            if (tipo == "rutinas")
            {
                dataGridView.Columns.Add("ID", "ID");
                dataGridView.Columns.Add("Nombre", "Nombre");
                dataGridView.Columns.Add("Estado","Estado");
                btnDetalles.UseColumnTextForButtonValue = true;
                dataGridView.Columns.Add(btnDetalles);
                dataGridView.Rows.Add(1, "Rutina de fuerza", "Activa");
                dataGridView.Rows.Add(2, "Rutina de resistencia", "Inactiva");

                // Configuro título y botones
                labelTitulo.Text = "Rutinas";
                btnAgregar.Visible = true;
                btnEliminar.Visible = true;
                BRefresh.Visible = true;
            }
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

        private void BBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarRutina formulario = new AgregarRutina();
            formulario.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void BRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
