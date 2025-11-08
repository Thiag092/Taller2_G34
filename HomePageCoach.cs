using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; // Necesario para ConfigurationManager
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
        // 🚀 CORRECCIÓN 1: Centralizar la cadena de conexión
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

        private string vistaActual = "";

        public homePageCoach()
        {
            InitializeComponent();
            // Aseguramos que el evento está asignado
            dataGridView.CellContentClick += dataGridView_CellContentClick;
        }

        // --- Eventos de Formulario y Controles (Sin Cambios) ---

        private void homePageCoach_Load(object sender, EventArgs e)
        {
            // Lógica de carga del formulario si es necesaria
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
                f.Show();        // vuelve al formulario de login
                this.Close();
            }
        }

        // Métodos de navegación
        private void BVerAlumnos_Click(object sender, EventArgs e)
        {
            MostrarVista("alumnos");
        }

        private void BVerRutinas_Click(object sender, EventArgs e)
        {
            MostrarVista("rutinas");
        }

        // --- Lógica de Vistas ---

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
            // ⭐️ CORRECCIÓN 2: NO limpiar las columnas aquí si usamos AutoGenerateColumns=true
            // dataGridView.Columns.Clear(); // <-- COMENTADO O ELIMINADO para evitar conflictos

            // Si el DataGridView tiene AutoGenerateColumns=true, las columnas se recrearán 
            // automáticamente a partir del DataTable.


            if (tipo == "alumnos")
            {
                labelTitulo.Text = "Alumnos";
                CargarAlumnosDesdeBD(); // Separamos la lógica de carga para mayor limpieza

                // Los botones de acciones de rutinas deben estar ocultos en la vista alumnos
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
            }

            if (tipo == "rutinas")
            {
                labelTitulo.Text = "Plantillas de Entrenamiento";
                BRefresh.Visible = true;
                btnAgregar.Visible = true;
                btnEliminar.Visible = true;
                CargarRutinasDesdeBD();
            }

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarAlumnosDesdeBD()
        {
            // ⭐️ Creamos la columna del botón una sola vez antes de añadirla a la grilla
            DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn();
            btnDetalles.HeaderText = "Detalles";
            btnDetalles.Text = "Ver más";
            btnDetalles.Name = "Detalles";
            btnDetalles.UseColumnTextForButtonValue = true;

            // Limpiar columnas *solo si* se cargaron antes con AutoGenerateColumns,
            // pero es más seguro si usamos un DataTable.

            // Resetear columnas para asegurar que solo tengamos las del SELECT más el botón Detalles
            dataGridView.Columns.Clear();

            string query = @"
            SELECT 
                dni AS DNI,
                nombre AS Nombre,
                apellido AS Apellido,
                CONVERT(varchar(10), fecha_nacimiento, 103) AS [Fecha de nacimiento],
                email AS Email,
                telefono AS Teléfono,
                LEFT(sexo, 1) AS Sexo,
                CASE WHEN estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado,
                -- Columna dummy para mantener el orden, ya que AutoGenerateColumns es true
                NULL AS DetallesDummy 
            FROM Alumno
            ORDER BY apellido, nombre;";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView.AutoGenerateColumns = true;
                    dataGridView.DataSource = dt;

                    // Agregar columna del botón Detalles
                    // Si AutoGenerateColumns es true, añadimos el botón después de enlazar los datos.
                    if (!dataGridView.Columns.Contains("Detalles"))
                    {
                        dataGridView.Columns.Add(btnDetalles);
                    }

                    // Ocultar la columna Dummy si es necesario
                    if (dataGridView.Columns.Contains("DetallesDummy"))
                    {
                        dataGridView.Columns["DetallesDummy"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar alumnos: " + ex.Message);
            }
        }


        private void CargarRutinasDesdeBD()
        {
            // ⭐️ Creamos la columna del botón para rutinas
            DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn();
            btnDetalles.HeaderText = "Detalles";
            btnDetalles.Text = "Ver más";
            btnDetalles.Name = "Detalles";
            btnDetalles.UseColumnTextForButtonValue = true;

            // Resetear columnas para la nueva vista
            dataGridView.Columns.Clear();

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
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView.AutoGenerateColumns = true;
                    dataGridView.DataSource = dt;

                    // Agregar columna de botón si aún no existe
                    if (!dataGridView.Columns.Contains("Detalles"))
                    {
                        dataGridView.Columns.Add(btnDetalles);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar plantillas de entrenamiento: " + ex.Message);
            }
        }


        // --- Búsqueda y Eventos del DataGridView ---

        private void BuscarUsuario()
        {
            string filtro = textBoxBusqueda.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
            {
                // Vuelve a cargar la vista completa de "Alumnos" si el filtro está vacío
                MostrarVista("alumnos");
                return;
            }

            // La lógica de búsqueda se mantiene sin cambios (asumiendo que buscas alumnos)
            string query = @"
            SELECT 
                a.dni AS DNI, 
                a.nombre AS Nombre, 
                a.apellido AS Apellido, 
                a.email AS Email, 
                tp.descripcion AS TipoUsuario  
            FROM Alumno a
            INNER JOIN PlanEntrenamiento p ON a.id_plan = p.id_plan
            INNER JOIN TipoPlan tp ON p.id_tipoPlan = tp.id_tipoPlan
            WHERE a.estado = 1
            AND (
                  a.dni LIKE @filtro
                OR a.nombre LIKE @filtro
                OR a.apellido LIKE @filtro
                OR tp.descripcion LIKE @filtro 
            )";

            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            // Limpiar DataGridView y llenar con resultados de la búsqueda
            // NOTA: Para la búsqueda, es más fácil limpiar y rellenar si trabajamos con AutoGenerateColumns=false
            // pero mantendré tu lógica original de limpiar Rows y luego añadir
            dataGridView.Columns.Clear(); // Limpia columnas para que AutoGenerateColumns funcione correctamente con el nuevo set de datos.
            dataGridView.DataSource = tabla;

            // Re-agrego la columna de detalles después de la búsqueda si no existe
            if (!dataGridView.Columns.Contains("Detalles"))
            {
                DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn();
                btnDetalles.HeaderText = "Detalles";
                btnDetalles.Text = "Ver más";
                btnDetalles.Name = "Detalles";
                btnDetalles.UseColumnTextForButtonValue = true;
                dataGridView.Columns.Add(btnDetalles);
            }
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void BBuscar_Click(object sender, EventArgs e)
        {
            BuscarUsuario();
        }

        private void BRefresh_Click(object sender, EventArgs e)
        {
            // Recarga la vista que esté activa actualmente
            if (vistaActual == "alumnos")
            {
                MostrarVista("alumnos");
            }
            else if (vistaActual == "rutinas")
            {
                CargarRutinasDesdeBD(); 
            }

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
                    // EditAlumno debe existir en el proyecto.
                    // El segundo parámetro "true" indica modo solo lectura (no editable)
                    EditAlumno formDetalles = new EditAlumno(dniAlumno, true);
                    formDetalles.ShowDialog();
                    
                }
                else if (vistaActual == "rutinas")
                {
                    // Obtener ID del plan de entrenamiento
                    int idPlan = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["ID"].Value);

                    // Mostrar detalles del plan (Formulario FormEditarPlan)
                    // FormEditarPlan debe existir en el proyecto.
                    FormEditarPlan formPlan = new FormEditarPlan(idPlan);
                    formPlan.ShowDialog();
                    
                }
            }
        }

        // --- Métodos de Evento Auxiliares ---

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VerPlanPlantilla formulario = new VerPlanPlantilla();
            formulario.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void textBoxBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BBuscar.PerformClick();  // Ejecuta exactamente lo mismo que el botón Buscar
                e.SuppressKeyPress = true; // evita el sonido y que aparezca un salto de línea
            }
        }

        private void dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}