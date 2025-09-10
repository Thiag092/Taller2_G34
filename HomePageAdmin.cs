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
    public partial class HomePageAdmin : Form
    {
        public HomePageAdmin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contentContainer_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BVerPersonal_Click(object sender, EventArgs e)
        {
            MostrarVista("Personal");
        }
        private void MostrarVista(string tipo)
        {
            // Oculto el label de bienvenida
            labelTextoBienvenida.Visible = false;
            // Hago visible el panel de contenido
            contentPanel.Visible = true;

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
                btnAgregar.Text = "Agregar Alumno";
                btnEliminar.Text = "Eliminar Alumno";
            }
            if (tipo == "Personal")
            {
                dataGridView.Columns.Add("DNI", "DNI");
                dataGridView.Columns.Add("Nombre", "Nombre");
                dataGridView.Columns.Add("Apellido", "Apellido");
                dataGridView.Columns.Add("Email", "Email");
                dataGridView.Columns.Add("TipoUsuario", "Tipo de usuario");
                // importante para identificar la columna
                btnDetalles.UseColumnTextForButtonValue = true;
                dataGridView.Columns.Add(btnDetalles);
                dataGridView.Rows.Add(11111111, "Carlos", "Gómez", "carlosgomez@gmail.com", "coach");
                dataGridView.Rows.Add(22222222, "María", "López", "marilo@outlook.com", "alumno");

                labelTitulo.Text = "Personal";
                btnAgregar.Text = "Agregar Usuario";
                btnEliminar.Text = "Eliminar Usuario";
            }
            if (tipo == "entrenadores")
            {
                dataGridView.Columns.Add("DNI", "DNI");
                dataGridView.Columns.Add("Nombre", "Nombre");
                dataGridView.Columns.Add("Apellido", "Apellido");
                dataGridView.Columns.Add("Email", "Email");
                dataGridView.Columns.Add("Telefono", "Teléfono");
                // importante para identificar la columna
                btnDetalles.UseColumnTextForButtonValue = true;
                dataGridView.Columns.Add(btnDetalles);

                dataGridView.Rows.Add(34567890, "Luis", "Martínez", "emimar@outlook.com", "+543794567890");

                labelTitulo.Text = "Entrenadores";
                btnAgregar.Text = "Agregar Entrenador";
                btnEliminar.Text = "Eliminar Entrenador";
            }
            if (tipo == "rutinas")
            {
                dataGridView.Columns.Add("ID", "ID");
                dataGridView.Columns.Add("Nombre", "Nombre");
                dataGridView.Columns.Add("Estado", "Estado");
                btnDetalles.UseColumnTextForButtonValue = true;
                dataGridView.Columns.Add(btnDetalles);
                dataGridView.Rows.Add(1, "Rutina de fuerza", "Activa");
                dataGridView.Rows.Add(2, "Rutina de resistencia", "Inactiva");

                labelTitulo.Text = "Rutinas";
                btnAgregar.Text = "Nueva Rutina";
                btnEliminar.Text = "Eliminar Rutina";
            }

            // Ajustes visuales opcionales
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnVerEntrenadores_Click(object sender, EventArgs e)
        {
            MostrarVista("entrenadores");
        }

        private void BVerAlumnos_Click(object sender, EventArgs e)
        {
            MostrarVista("alumnos");
        }


        private void BBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (btnAgregar.Text == "Agregar Usuario" || btnAgregar.Text == "Agregar Entrenador")
            {
                AgregarPersonal formulario = new AgregarPersonal();
                formulario.Show();
            }
            if(btnAgregar.Text == "Agregar Alumno")
            {
                AgregarAlumno formulario = new AgregarAlumno();
                formulario.Show();
            }
            if (btnAgregar.Text == "Nueva Rutina"){ 
                AgregarRutina formulario = new AgregarRutina();
                formulario.Show();
            }
        }

        private void BVerRutinas_Click(object sender, EventArgs e)
        {
            MostrarVista("rutinas");
        }
    }
}
