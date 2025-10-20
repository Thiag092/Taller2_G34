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

        private string vistaActual = "";

        public homePageCoach()
        {
            InitializeComponent();
            dataGridView.CellContentClick += dataGridView_CellContentClick;
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

            vistaActual = tipo; // Guarda si estamos mostrando alumnos o rutinas

            // Oculto el label de bienvenida
            labelTextoBienvenida.Visible = false;
            contentPanel.Visible = true;
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
            BRefresh.Visible = false;

            // Limpio el DataGridView antes de cargar nuevos datos
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();


            // ✅ Declarar el botón UNA SOLA VEZ
            DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn();
            btnDetalles.HeaderText = "Detalles";
            btnDetalles.Text = "Ver más";
            btnDetalles.Name = "Detalles";
            btnDetalles.UseColumnTextForButtonValue = true;

            if (tipo == "alumnos")
            {
                labelTitulo.Text = "Alumnos";

                string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

                string query = @"
            SELECT 
                dni AS DNI,
                nombre AS Nombre,
                apellido AS Apellido,
                CONVERT(varchar(10), fecha_nacimiento, 103) AS [Fecha de nacimiento],
                email AS Email,
                telefono AS Teléfono,
                LEFT(sexo, 1) AS Sexo,
                CASE WHEN estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado
            FROM Alumno
            ORDER BY apellido, nombre;";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView.AutoGenerateColumns = true;
                        dataGridView.DataSource = dt;

                        // ✅ Agregar columna del botón una sola vez
                        if (!dataGridView.Columns.Contains("Detalles"))
                        {
                            dataGridView.Columns.Add(btnDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar alumnos: " + ex.Message);
                }

                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            if (tipo == "rutinas")
            {
                labelTitulo.Text = "Plantillas de Entrenamiento";
                BRefresh.Visible = true;
                CargarRutinasDesdeBD();
            }
        }



        private void CargarRutinasDesdeBD()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

            string query = @"
            SELECT 
                p.id_plan AS ID,
                p.nombre AS [Nombre del Plan],
                t.descripcion AS [Tipo],
                COUNT(DISTINCT d.id_dia) AS [Días],
                COUNT(DISTINCT pe.id_ejercicio) AS [Ejercicios Totales]
            FROM PlanEntrenamiento p
            INNER JOIN TipoPlan t ON p.id_tipoPlan = t.id_tipoPlan
            LEFT JOIN Plan_Dia d ON p.id_plan = d.id_plan
            LEFT JOIN Plan_Ejercicio pe ON pe.id_plan = p.id_plan
            WHERE p.estado = 1
            GROUP BY p.id_plan, p.nombre, t.descripcion
            ORDER BY p.id_plan;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView.AutoGenerateColumns = true;
                    dataGridView.DataSource = dt;

                    // Agregar columna de botón si aún no existe
                    if (!dataGridView.Columns.Contains("Detalles"))
                    {
                        DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn();
                        btnDetalles.HeaderText = "Detalles";
                        btnDetalles.Text = "Ver más";
                        btnDetalles.Name = "Detalles";
                        btnDetalles.UseColumnTextForButtonValue = true;
                        dataGridView.Columns.Add(btnDetalles);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar plantillas de entrenamiento: " + ex.Message);
            }
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
            VerPlanPlantilla formulario = new VerPlanPlantilla();
            formulario.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void BRefresh_Click(object sender, EventArgs e)
        {
            CargarRutinasDesdeBD(); // Recarga los datos desde la base
        }


        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView.Columns[e.ColumnIndex].Name == "Detalles")
            {
                if (vistaActual == "alumnos")
                {
                    // Obtener DNI del alumno
                    string dniAlumno = dataGridView.Rows[e.RowIndex].Cells["DNI"].Value.ToString();

                    // Mostrar detalles del alumno
                    // 👇 El segundo parámetro "true" indica modo solo lectura (no editable)
                    EditAlumno formDetalles = new EditAlumno(dniAlumno, true);
                    formDetalles.ShowDialog();

                }
                else if (vistaActual == "rutinas")
                {
                    // Obtener ID del plan de entrenamiento
                    int idPlan = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["ID"].Value);

                    // Mostrar detalles del plan (tu formulario VerPlanPlantilla)
                    VerPlanPlantilla formPlan = new VerPlanPlantilla(idPlan);
                    formPlan.ShowDialog();
                }
            }
        }




        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
