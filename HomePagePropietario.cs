using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; // se agrego esta libreria para poder usar SQL
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; //para graficos
using System.Globalization;
using System.Threading;



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

        private void BUsuarios_Click(object sender, EventArgs e)
        {
            MostrarVista("Personal");

        }

        /*************************************************************************************/
        /* Version anterior del metodo MostrarVista para mostrar los usuarios estaticos
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
            

            // Ajustes visuales opcionales
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        } */
        /*************************************************************************************/


        private void MostrarVista(string tipo)
        {
            // 🔸 Ocultar todo por defecto
            labelTextoBienvenida.Visible = false;
            picBoxEstadisticas.Visible = false;
            BGraficoInscriptos.Visible = false;
            BGraficoPagos.Visible = false;
            dataGridView.Visible = false;
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
            BRefresh.Visible = false;
            chartInscriptos.Visible = false; // importante
            contentPanel.Visible = true;
            chartPagos.Visible = false;
            labelTotalAlumnos.Visible = false;

            //  Si es PAGOS
            if (tipo == "Pagos")
            {
                labelTitulo.Text = "Estadísticas de facturación";
                chartInscriptos.Visible = false;
                dataGridView.Visible = false;
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
                BRefresh.Visible = false;

                // 🔸 aseguramos que el gráfico de pagos se vea encima del resto
                chartPagos.BringToFront();

                return; // ✅ Salimos aquí, sin que se cargue el DataGridView
            }



            //  Si es ESTADÍSTICAS
            if (tipo == "Estadisticas")
            {
                labelTitulo.Text = "Estadísticas del gimnasio";

                // mostramos el chart real (se carga desde el botón BEstadisticas)
                chartInscriptos.Visible = true;

                return; // salgo, no sigo abajo
            }

            //  Si no es ni pagos ni estadísticas → mostrar DataGridView (Usuarios)
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            // Botón de detalles
            DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn
            {
                HeaderText = "Detalles",
                Text = "Ver más",
                Name = "Detalles",
                UseColumnTextForButtonValue = true
            };

            // Columnas del listado
            dataGridView.Columns.Add("DNI", "DNI");
            dataGridView.Columns.Add("Nombre", "Nombre");
            dataGridView.Columns.Add("Apellido", "Apellido");
            dataGridView.Columns.Add("Email", "Email");
            dataGridView.Columns.Add("TipoUsuario", "Tipo de usuario");
            dataGridView.Columns.Add(btnDetalles);

            // Conexión y carga de datos
            string connectionString = "Server=YAGO_DELL\\SQLEXPRESS01;Database=EnerGym_BD_V9;Trusted_Connection=True;";
            string query = @"
        SELECT u.dni, u.nombre, u.apellido, u.email, r.descripcion
        FROM Usuario u
        INNER JOIN Rol r ON u.id_rol = r.id_rol
        WHERE u.estado = 1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView.Rows.Add(
                        reader["dni"],
                        reader["nombre"],
                        reader["apellido"],
                        reader["email"],
                        reader["descripcion"]
                    );
                }
            }

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Visible = true;

            //  Configurar según tipo
            if (tipo == "Personal")
            {
                labelTitulo.Text = "Personal";
                btnAgregar.Text = "Agregar Usuario";
                btnEliminar.Text = "Eliminar Usuario";
                btnAgregar.Visible = true;
                btnEliminar.Visible = true;
            }
            else if (tipo == "entrenadores")
            {
                labelTitulo.Text = "Entrenadores";
            }
            else if (tipo == "alumnos")
            {
                labelTitulo.Text = "Alumnos";
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                string dniUsuario = dataGridView.SelectedRows[0].Cells["DNI"].Value.ToString();

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro que desea dar de baja al usuario con DNI {dniUsuario}?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion == DialogResult.Yes)
                {
                    string connectionString = "Data Source=YAGO_DELL\\SQLEXPRESS01;Initial Catalog=EnerGym_BD_V2;Integrated Security=True";
                    string query = "UPDATE Usuario SET estado = 0 WHERE dni = @dni"; // Baja lógica

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dni", dniUsuario);

                        connection.Open();
                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Usuario dado de baja correctamente ");
                            MostrarVista("Personal"); // refresca la grilla
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el usuario ");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un usuario primero.");
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < dataGridView.Columns.Count &&
                dataGridView.Columns[e.ColumnIndex].Name == "Detalles")
            {
                string dni = dataGridView.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
                EditUser editForm = new EditUser(dni);
                editForm.ShowDialog();
            }
        }

        private void BRefresh_Click(object sender, EventArgs e)
        {
            MostrarVista("Personal");
        }

        private void BPagos_Click(object sender, EventArgs e)
        {
            MostrarVista("Pagos");

            // Ocultamos todo lo demás
            chartInscriptos.Visible = false;
            picBoxEstadisticas.Visible = false;

            // Mostramos el gráfico de pagos
            chartPagos.Visible = true;

            // Cargamos los datos
            CargarGraficoPagos();
        }


        private void BEstadisticas_Click(object sender, EventArgs e)
        {
            MostrarVista("Estadisticas");
            CargarGraficoInscriptos();
            // Mostrar la label
            labelTotalAlumnos.Visible = true;

            //  Cargar el total actual de alumnos activos
            CargarTotalAlumnosActivos();

        }


        private void BGraficoInscriptos_Click(object sender, EventArgs e)
        {
            picBoxEstadisticas.Visible = true;
            picBoxEstadisticas.Image = Properties.Resources.inscriptos_mockup;
        }

        private void BGraficoPagos_Click(object sender, EventArgs e)
        {
            picBoxEstadisticas.Visible = true;
            picBoxEstadisticas.Image = Properties.Resources.metodos_pago;
        }

        

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CargarGraficoInscriptos()
        {
            chartInscriptos.Series.Clear();
            chartInscriptos.ChartAreas.Clear();

            ChartArea area = new ChartArea("Area1");
            chartInscriptos.ChartAreas.Add(area);

            string connectionString = "Server=YAGO_DELL\\SQLEXPRESS01;Database=EnerGym_BD_V9;Trusted_Connection=True;";
            string query = @"
SELECT 
    DATENAME(MONTH, primerPago.PrimerPagoFecha) AS Mes,
    SUM(CASE WHEN tp.descripcion = 'Principiante' THEN 1 ELSE 0 END) AS Principiante,
    SUM(CASE WHEN tp.descripcion = 'Intermedio' THEN 1 ELSE 0 END) AS Intermedio,
    SUM(CASE WHEN tp.descripcion = 'Avanzado' THEN 1 ELSE 0 END) AS Avanzado
FROM (
    SELECT id_alumno, MIN(fecha) AS PrimerPagoFecha
    FROM Pago
    GROUP BY id_alumno
) AS primerPago
JOIN Alumno a ON primerPago.id_alumno = a.id_alumno
JOIN PlanEntrenamiento pl ON a.id_plan = pl.id_plan
JOIN TipoPlan tp ON pl.id_tipoPlan = tp.id_tipoPlan
WHERE a.estado = 1 AND YEAR(primerPago.PrimerPagoFecha) = YEAR(GETDATE())
GROUP BY DATENAME(MONTH, primerPago.PrimerPagoFecha), MONTH(primerPago.PrimerPagoFecha)
ORDER BY MONTH(primerPago.PrimerPagoFecha);";



            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            // Crear series
            string[] categorias = { "Principiante", "Intermedio", "Avanzado" };
            foreach (var cat in categorias)
            {
                Series serie = new Series(cat)
                {
                    ChartType = SeriesChartType.Column,
                    XValueMember = "Mes",
                    YValueMembers = cat,
                    IsValueShownAsLabel = true
                };
                chartInscriptos.Series.Add(serie);
            }

            chartInscriptos.DataSource = dt;
            chartInscriptos.DataBind();

            // Forzar a mostrar todos los meses, incluso los de valor 0
            chartInscriptos.ChartAreas["Area1"].AxisX.Interval = 1;
            chartInscriptos.ChartAreas["Area1"].RecalculateAxesScale();

            // Evita que colapse categorías sin valores
            chartInscriptos.ChartAreas["Area1"].AxisX.IsMarginVisible = true;
            chartInscriptos.ChartAreas["Area1"].AxisX.LabelStyle.IsStaggered = true;

        }

        private void CargarGraficoPagos()
        {
            chartPagos.Series.Clear();
            chartPagos.ChartAreas.Clear();
            chartPagos.Titles.Clear();

            ChartArea area = new ChartArea("Area1");
            chartPagos.ChartAreas.Add(area);

            string connectionString = "Server=YAGO_DELL\\SQLEXPRESS01;Database=EnerGym_BD_V9;Trusted_Connection=True;";
            string query = @"
        SELECT 
            DATENAME(MONTH, p.fecha) AS Mes,
            MONTH(p.fecha) AS MesN,
            SUM(pd.monto) AS TotalRecaudado
        FROM Pago p
        INNER JOIN PagoDetalle pd ON p.id_pago = pd.id_pago
        WHERE YEAR(p.fecha) = YEAR(GETDATE())
        GROUP BY DATENAME(MONTH, p.fecha), MONTH(p.fecha)
        ORDER BY MesN;";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            // Serie
            Series serie = new Series("Recaudación")
            {
                ChartType = SeriesChartType.Column,
                XValueMember = "Mes",
                YValueMembers = "TotalRecaudado",
                IsValueShownAsLabel = true,
                LabelFormat = "C0"   // ← formateo de etiquetas de cada barra como moneda
            };
            chartPagos.Series.Add(serie);

            // Títulos y ejes
            chartPagos.Titles.Add("Total recaudado por mes en el año actual");
            var area1 = chartPagos.ChartAreas["Area1"];
            area1.AxisX.Title = "Mes";
            area1.AxisY.Title = "Total recaudado";
            area1.AxisX.Interval = 1;
            area1.AxisX.LabelStyle.Angle = -45;
            area1.AxisY.LabelStyle.Format = "C0"; // ← formateo del eje Y como moneda

            if (chartPagos.Legends.Count == 0)
                chartPagos.Legends.Add(new Legend("Default"));
            chartPagos.Legends[0].Docking = Docking.Bottom;


            //  Enlazamos los datos normalmente
            chartPagos.DataSource = dt;
            chartPagos.DataBind();

            // 🔹 Forzamos el formato manualmente
            foreach (var p in chartPagos.Series["Recaudación"].Points)
            {
                p.Label = "$" + p.YValues[0].ToString("N0"); // etiqueta sobre cada barra
            }

            //  Cambiamos el formato del eje Y también
            chartPagos.ChartAreas["Area1"].AxisY.LabelStyle.Format = "N0"; // números simples
            chartPagos.ChartAreas["Area1"].AxisY.LabelStyle.ForeColor = Color.Black;

            //  Dibujamos el símbolo $ en el título del eje Y
            chartPagos.ChartAreas["Area1"].AxisY.Title = "Total recaudado ($)";


        }

        private void CargarTotalAlumnosActivos()
        {
            try
            {
                string connectionString = "Server=YAGO_DELL\\SQLEXPRESS01;Database=EnerGym_BD_V9;Trusted_Connection=True;";
                string query = "SELECT COUNT(*) FROM Alumno WHERE estado = 1";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int totalActivos = (int)cmd.ExecuteScalar();

                    // 🔹 Mostrar el resultado en la label
                    labelTotalAlumnos.Text = $"Total alumnos activos: {totalActivos}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar total de alumnos: " + ex.Message);
            }
        }



    }
}

