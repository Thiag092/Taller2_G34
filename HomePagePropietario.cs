using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; // se agrego esta libreria para poder usar SQL
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; //para graficos



namespace Taller2_G34
{
    public partial class HomePagePropietario : Form
    {
        private ToolTip tooltipActivo = new ToolTip();

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
            dataGridBackup.Visible = false;
            BBackUp.Visible = false;  // OCULTA SIEMPRE POR DEFECTO


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

                return; 
            }

            // Si es BACKUPS
            if (tipo == "HistorialBackup")
            {
                labelTitulo.Text = "Historial de copias de seguridad";
                chartInscriptos.Visible = false;
                chartPagos.Visible = false;
                dataGridView.Visible = false;
                labelTotalAlumnos.Visible = false;
                dataGridBackup.Visible = true;

                // mostramos el botón para crear backup 👇
                BBackUp.Visible = true;

                CargarHistorialBackup();
                return;
            }



            //  Si es ESTADÍSTICAS
            if (tipo == "Estadisticas")
            {
                labelTitulo.Text = "Estadísticas del gimnasio";

                // mostramos el chart real (se carga desde el botón BEstadisticas)
                chartInscriptos.Visible = true;

                return; // salgo, no sigo abajo
            }

            //  Si no es ni pagos ni estadísticas hay que mostrar DataGridView (Usuarios)
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
                    string connectionString = "Data Source=YAGO_DELL\\SQLEXPRESS01;Initial Catalog=EnerGym_BD_V9;Integrated Security=True";
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

        private void CargarGraficoInscriptos(string filtro = "Todos")
        {
            chartInscriptos.Series.Clear();
            chartInscriptos.ChartAreas.Clear();
            chartInscriptos.Titles.Clear();

            ChartArea area = new ChartArea("Area1");
            chartInscriptos.ChartAreas.Add(area);

            string connectionString = "Server=YAGO_DELL\\SQLEXPRESS01;Database=EnerGym_BD_V9;Trusted_Connection=True;";
            string query = @"
        SELECT tp.descripcion AS TipoPlan, COUNT(a.id_alumno) AS Cantidad
        FROM Alumno a
        INNER JOIN PlanEntrenamiento p ON a.id_plan = p.id_plan
        INNER JOIN TipoPlan tp ON p.id_tipoPlan = tp.id_tipoPlan
        WHERE a.estado = 1 {0}
        GROUP BY tp.descripcion;";

            // 🔸 Si hay filtro, lo agregamos dinámicamente
            string filtroSQL = "";
            if (filtro != "Todos")
                filtroSQL = $"AND tp.descripcion = '{filtro}'";

            query = string.Format(query, filtroSQL);

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            Series serie = new Series("Distribución de alumnos activos")
            {
                ChartType = SeriesChartType.Pie,
                XValueMember = "TipoPlan",
                YValueMembers = "Cantidad",
                IsValueShownAsLabel = true,
                Label = "#PERCENT{P0}",
                LegendText = "#VALX"
            };

            chartInscriptos.Series.Add(serie);
            chartInscriptos.DataSource = dt;
            chartInscriptos.DataBind();

            chartInscriptos.Titles.Add("Distribución de alumnos activos por tipo de plan");
            chartInscriptos.ChartAreas["Area1"].Area3DStyle.Enable3D = true;
        }

        // Evento de clic sobre el gráfico de torta
        private void chartInscriptos_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = chartInscriptos.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int index = result.PointIndex;
                Series serie = result.Series;

                // 🔹 Desexplota todas las porciones
                foreach (DataPoint p in serie.Points)
                    p["Exploded"] = "false";

                // 🔹 Explota solo la clickeada
                DataPoint puntoSeleccionado = serie.Points[index];
                puntoSeleccionado["Exploded"] = "true";

                // 🔹 Calcula la información
                string tipo = puntoSeleccionado.AxisLabel;
                int cantidad = (int)puntoSeleccionado.YValues[0];
                double porcentaje = puntoSeleccionado.YValues[0] / serie.Points.Sum(p => p.YValues[0]) * 100;

                string mensaje = $"{tipo}: {cantidad} alumno{(cantidad != 1 ? "s" : "")} ({porcentaje:0.0}%)";

                // 🔹 Cierra cualquier tooltip anterior
                tooltipActivo.Hide(chartInscriptos);

                // 🔹 Configura el tooltip global
                tooltipActivo.IsBalloon = true;
                tooltipActivo.ToolTipIcon = ToolTipIcon.Info;
                tooltipActivo.ToolTipTitle = "Detalle del grupo";
                tooltipActivo.AutoPopDelay = 4000;
                tooltipActivo.InitialDelay = 100;
                tooltipActivo.ReshowDelay = 100;

                // 🔹 Muestra el nuevo tooltip
                tooltipActivo.Show(mensaje, chartInscriptos, e.Location.X + 10, e.Location.Y - 20);
            }
            else
            {
                // 🔹 Si se hace clic fuera de una porción, se oculta el tooltip
                tooltipActivo.Hide(chartInscriptos);
            }
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
                LabelFormat = "C0"   // formateo de etiquetas de cada barra como moneda
            };
            chartPagos.Series.Add(serie);

            // Títulos y ejes
            chartPagos.Titles.Add("Total recaudado por mes en el año actual");
            var area1 = chartPagos.ChartAreas["Area1"];
            area1.AxisX.Title = "Mes";
            area1.AxisY.Title = "Total recaudado";
            area1.AxisX.Interval = 1;
            area1.AxisX.LabelStyle.Angle = -45;
            area1.AxisY.LabelStyle.Format = "C0"; // formateo del eje Y como moneda

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

                    //Mostrar el resultado en la label
                    labelTotalAlumnos.Text = $"Total alumnos activos: {totalActivos}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar total de alumnos: " + ex.Message);
            }
        }
        private void HomePagePropietario_Load(object sender, EventArgs e)
        {
            comboFiltroPlanes.Items.AddRange(new string[] { "Todos", "Principiante", "Intermedio", "Avanzado" });
            comboFiltroPlanes.SelectedIndex = 0;
        }

        private void comboFiltroPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = comboFiltroPlanes.SelectedItem.ToString();
            CargarGraficoInscriptos(filtro);
        }

        private void BBackUp_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show(
                "Usted va a descargar TODOS los datos de la aplicación en su computadora.\n\n" +
                "Se recomienda guardarlos en un lugar seguro.\n\n¿Desea continuar?",
                "Confirmación de copia de seguridad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Title = "Guardar copia de seguridad";
                    dialog.Filter = "Archivo de respaldo SQL Server (*.bak)|*.bak";
                    dialog.FileName = $"EnerGym_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string rutaDestinoFinal = dialog.FileName;

                        // 🔹 1. Creamos una carpeta temporal segura (donde SQL sí puede escribir)
                        string rutaTemporal = Path.Combine(@"C:\BackupsTemp", Path.GetFileName(rutaDestinoFinal));
                        Directory.CreateDirectory(@"C:\BackupsTemp");

                        string connectionString = "Server=YAGO_DELL\\SQLEXPRESS01;Database=master;Trusted_Connection=True;";
                        string query = $@"
                    BACKUP DATABASE EnerGym_BD_V9
                    TO DISK = '{rutaTemporal}'
                    WITH FORMAT, MEDIANAME = 'EnerGymBackup', NAME = 'Copia de seguridad EnerGym';";

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();

                            // Ejecuta el BACKUP en la ruta temporal
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                                cmd.ExecuteNonQuery();

                            // 🔹 Registrar el backup en la base
                            string registrarBackup = "INSERT INTO EnerGym_BD_V9.dbo.HistorialBackup (ruta) VALUES (@ruta)";
                            using (SqlCommand logCmd = new SqlCommand(registrarBackup, conn))
                            {
                                logCmd.Parameters.AddWithValue("@ruta", rutaDestinoFinal);
                                logCmd.ExecuteNonQuery();
                            }
                        }

                        // 🔹 2. Mover el backup desde la ruta temporal a la seleccionada por el usuario
                        File.Copy(rutaTemporal, rutaDestinoFinal, overwrite: true);
                        File.Delete(rutaTemporal); // opcional, limpia el temporal

                        // 🔹 3. Confirmación visual
                        MessageBox.Show(
                            $"✅ Copia de seguridad creada exitosamente.\n\nRuta:\n{rutaDestinoFinal}",
                            "Backup completado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "❌ Ocurrió un error al generar el backup:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void BHistorialBackup_Click(object sender, EventArgs e)
        {
            MostrarVista("HistorialBackup");

        }

        private void CargarHistorialBackup()
        {
            try
            {
                string connectionString = "Server=YAGO_DELL\\SQLEXPRESS01;Database=EnerGym_BD_V9;Trusted_Connection=True;";
                string query = "SELECT fecha AS [Fecha del Backup], ruta AS [Ubicación del Archivo] FROM HistorialBackup ORDER BY fecha DESC;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridBackup.DataSource = dt;
                }

                // formato visual
                dataGridBackup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridBackup.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridBackup.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial de backups: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

