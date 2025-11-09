using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        // CONEXIÓN CENTRALIZADA
        private const string ConnectionStringEnerGym = "Server=alcachofio\\SQLEXPRESS;Database=EnerGym_BD_V9;Trusted_Connection=True;";
        private const string ConnectionStringMaster = "Server=alcachofio\\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        // private const string ConnectionStringEnerGym_Alt = "Server=YAGO_DELL\\SQLEXPRESS01;Database=EnerGym_BD_V9;Trusted_Connection=True;";
        // private const string ConnectionStringEnerGym_Alt = "Server=YAGO_DELL\\SQLEXPRESS01;Database=master;Trusted_Connection=True;";


        public HomePagePropietario()
        {
            InitializeComponent();
            dataGridPagos.Visible = false;
            chartPagos.Visible = false;
            lblMensaje.Visible = true;
            BEstadisticas.Visible = false;
            BPagos.Visible = false;
            BProfesores.Visible = false;
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
                f.Show();        // vuelve al formulario de login
                this.Close();
            }
        }

        private void BUsuarios_Click(object sender, EventArgs e)
        {
            MostrarVista("Personal");

        }

        // MÉTODO MOSTRAR VISTA PARA MEJORAR LA LEGIBILIDAD
        private void MostrarVista(string tipo)
        {
            // Ocultar todo por defecto
            OcultarTodosLosControles();

            // Usamos switch para seleccionar la lógica específica de la vista
            switch (tipo.ToLower())
            {
                case "pagos":
                    ConfigurarVistaPagos();
                    break;

                case "historialbackup":
                    ConfigurarVistaHistorialBackup();
                    break;

                case "profesores":
                    ConfigurarVistaProfesores();
                    break;

                case "estadisticas":
                    // Mostrar los botones de sub-sección
                    BEstadisticas.Visible = true;
                    BPagos.Visible = true;
                    BProfesores.Visible = true;

                    // Configura la sub-vista predeterminada (lblMensaje)
                    ConfigurarVistaEstadisticas();
                    break;

                // Las vistas de Usuario (Personal, alumnos, entrenadores)
                case "personal":
                case "entrenadores":
                case "alumnos":
                default:
                    ConfigurarVistaUsuarios(tipo);
                    break;
            }
        }

        // MÉTODOS PRIVADOS AUXILIARES PARA ENCAPSULAR LA LÓGICA DE VISTA

        private void OcultarTodosLosControles()
        {
            // Ocultar todo por defecto
            labelTextoBienvenida.Visible = false;
            picBoxEstadisticas.Visible = false;
            dataGridView.Visible = false;
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
            BRefresh.Visible = false;
            chartInscriptos.Visible = false;
            contentPanel.Visible = true;
            chartPagos.Visible = false;
            labelTotalAlumnos.Visible = false;
            dataGridBackup.Visible = false;
            BBackUp.Visible = false;
            chartProfesores.Visible = false;
            dataGridAlumnosProfesor.Visible = false;
            dataGridPagos.Visible = false;
            textBoxBusqueda.Visible = false;
            BBuscar.Visible = false;

            // Ocultar siempre los botones de sub-estadísticas por defecto
            BEstadisticas.Visible = false;
            BPagos.Visible = false;
            BProfesores.Visible = false;

            // Ocultar el mensaje, se mostrará solo si es la vista predeterminada de Estadísticas
            lblMensaje.Visible = false;
        }

        private void ConfigurarVistaPagos()
        {
            labelTitulo.Text = "Estadísticas de facturación";

            // Ocultar elementos no necesarios
            chartInscriptos.Visible = false;
            dataGridView.Visible = false;
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
            BRefresh.Visible = false;

            // Mostrar elementos de Pagos
            chartPagos.Visible = true;
            dataGridPagos.Visible = true;

            chartPagos.BringToFront();

            CargarGraficoPagos();
            CargarTablaPagos();
        }

        private void ConfigurarVistaHistorialBackup()
        {
            labelTitulo.Text = "Historial de copias de seguridad";
            chartInscriptos.Visible = false;
            chartPagos.Visible = false;
            dataGridView.Visible = false;
            labelTotalAlumnos.Visible = false;
            dataGridBackup.Visible = true;

            BBackUp.Visible = true;

            CargarHistorialBackup();
        }

        private void ConfigurarVistaProfesores()
        {
            labelTitulo.Text = "Distribución de alumnos por profesor";

            // Asegurar que solo el chart de Profesores y su tabla están visibles
            chartProfesores.Visible = true;
            chartPagos.Visible = false;
            chartInscriptos.Visible = false;
            dataGridPagos.Visible = false;
            dataGridAlumnosProfesor.Visible = false;

            CargarGraficoProfesores();
        }

        private void ConfigurarVistaEstadisticas()
        {
            labelTitulo.Text = "Estadísticas del gimnasio";

            // Ocultar todos los charts/grillas y mostrar solo el mensaje
            chartPagos.Visible = false;
            chartProfesores.Visible = false;
            chartInscriptos.Visible = false;
            dataGridPagos.Visible = false;
            dataGridAlumnosProfesor.Visible = false;

            // Muestra el mensaje de bienvenida/instrucción
            lblMensaje.Visible = true;
            labelTotalAlumnos.Visible = false;
        }

        private void ConfigurarVistaUsuarios(string tipo)
        {
            // Lógica original para cargar el DataGridView (Personal, Entrenadores, Alumnos)

            // 1. Limpiar y preparar DataGridView
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            // 2. Definir Columnas
            DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn
            {
                HeaderText = "Detalles",
                Text = "Ver más",
                Name = "Detalles",
                UseColumnTextForButtonValue = true
            };

            dataGridView.Columns.Add("DNI", "DNI");
            dataGridView.Columns.Add("Nombre", "Nombre");
            dataGridView.Columns.Add("Apellido", "Apellido");
            dataGridView.Columns.Add("Email", "Email");
            dataGridView.Columns.Add("TipoUsuario", "Tipo de usuario");
            dataGridView.Columns.Add(btnDetalles);

            // 3. Conexión y carga de datos
            string query = @"
            SELECT u.dni, u.nombre, u.apellido, u.email, r.descripcion
            FROM Usuario u
            INNER JOIN Rol r ON u.id_rol = r.id_rol
            WHERE u.estado = 1";

            using (SqlConnection conn = new SqlConnection(ConnectionStringEnerGym))
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

            // 4. Configuración visual y de botones
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Visible = true;

            if (tipo.ToLower() == "personal")
            {
                labelTitulo.Text = "Personal";
                btnAgregar.Text = "Agregar Usuario";
                btnEliminar.Text = "Eliminar Usuario";
                btnAgregar.Visible = true;
                btnEliminar.Visible = true;
                textBoxBusqueda.Visible = true;
                BBuscar.Visible = true;
            }
            else if (tipo.ToLower() == "entrenadores")
            {
                labelTitulo.Text = "Entrenadores";
            }
        }

        // MÉTODOS DE EVENTO 
        private void BEstadisticas_Click(object sender, EventArgs e)
        {
            // Ocultar el mensaje y otros gráficos/grillas
            lblMensaje.Visible = false;
            chartPagos.Visible = false;
            chartProfesores.Visible = false;
            dataGridPagos.Visible = false;
            dataGridAlumnosProfesor.Visible = false;
            picBoxEstadisticas.Visible = false;

            // Configurar la vista de Inscriptos
            labelTitulo.Text = "Estadísticas del gimnasio - Distribución de planes";
            chartInscriptos.Visible = true;
            labelTotalAlumnos.Visible = true;
            CargarGraficoInscriptos();
            CargarTotalAlumnosActivos();
        }

        private void BPagos_Click(object sender, EventArgs e)
        {
            // Ocultar el mensaje y otros gráficos/grillas
            lblMensaje.Visible = false;
            chartInscriptos.Visible = false;
            chartProfesores.Visible = false;
            dataGridAlumnosProfesor.Visible = false;
            picBoxEstadisticas.Visible = false;
            labelTotalAlumnos.Visible = false;

            // Configurar la vista de Pagos
            ConfigurarVistaPagos();
        }

        private void BProfesores_Click(object sender, EventArgs e)
        {
            // Ocultar el mensaje y otros gráficos/grillas
            lblMensaje.Visible = false;
            chartInscriptos.Visible = false;
            chartPagos.Visible = false;
            dataGridPagos.Visible = false;
            dataGridAlumnosProfesor.Visible = false;
            picBoxEstadisticas.Visible = false;
            labelTotalAlumnos.Visible = false;

            // Configurar la vista de Profesores
            ConfigurarVistaProfesores();
        }

        private void BCharts_Click(object sender, EventArgs e)
        {
            // Este botón abre la sección principal de Estadísticas, mostrando el mensaje
            MostrarVista("Estadisticas");
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
                    // *** USO DE CONEXIÓN CENTRALIZADA ***
                    string query = "UPDATE Usuario SET estado = 0 WHERE dni = @dni"; // Baja lógica

                    using (SqlConnection connection = new SqlConnection(ConnectionStringEnerGym))
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


        private void BGraficoInscriptos_Click(object sender, EventArgs e)
        {
            picBoxEstadisticas.Visible = true;
            // picBoxEstadisticas.Image = Properties.Resources.inscriptos_mockup; 
        }

        private void BGraficoPagos_Click(object sender, EventArgs e)
        {
            picBoxEstadisticas.Visible = true;
            // picBoxEstadisticas.Image = Properties.Resources.metodos_pago; 
        }


        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CargarGraficoInscriptos(string filtro = "Todos")
        {
            // Ocultar mensaje si se carga el gráfico
            lblMensaje.Visible = false;

            chartInscriptos.Visible = true;
            labelTotalAlumnos.Visible = true;
            chartInscriptos.Series.Clear();
            chartInscriptos.ChartAreas.Clear();
            chartInscriptos.Titles.Clear();

            ChartArea area = new ChartArea("Area1");
            chartInscriptos.ChartAreas.Add(area);

            // *** USO DE CONEXIÓN CENTRALIZADA ***
            string query = @"
            SELECT tp.descripcion AS TipoPlan, COUNT(a.id_alumno) AS Cantidad
            FROM Alumno a
            INNER JOIN PlanEntrenamiento p ON a.id_plan = p.id_plan
            INNER JOIN TipoPlan tp ON p.id_tipoPlan = tp.id_tipoPlan
            WHERE a.estado = 1 {0}
            GROUP BY tp.descripcion;";

            //Si hay filtro, lo agregamos dinámicamente
            string filtroSQL = "";
            if (filtro != "Todos")
                filtroSQL = $"AND tp.descripcion = '{filtro}'";

            query = string.Format(query, filtroSQL);

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionStringEnerGym))
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

                //Desexplota todas las porciones
                foreach (DataPoint p in serie.Points)
                    p["Exploded"] = "false";

                //Explota solo la clickeada
                DataPoint puntoSeleccionado = serie.Points[index];
                puntoSeleccionado["Exploded"] = "true";

                // Calcula la información
                string tipo = puntoSeleccionado.AxisLabel;
                int cantidad = (int)puntoSeleccionado.YValues[0];
                double porcentaje = puntoSeleccionado.YValues[0] / serie.Points.Sum(p => p.YValues[0]) * 100;

                string mensaje = $"{tipo}: {cantidad} alumno{(cantidad != 1 ? "s" : "")} ({porcentaje:0.0}%)";

                // Cierra cualquier tooltip anterior
                tooltipActivo.Hide(chartInscriptos);

                //Configura el tooltip global
                tooltipActivo.IsBalloon = true;
                tooltipActivo.ToolTipIcon = ToolTipIcon.Info;
                tooltipActivo.ToolTipTitle = "Detalle del grupo";
                tooltipActivo.AutoPopDelay = 4000;
                tooltipActivo.InitialDelay = 100;
                tooltipActivo.ReshowDelay = 100;

                // Muestra el nuevo tooltip
                tooltipActivo.Show(mensaje, chartInscriptos, e.Location.X + 10, e.Location.Y - 20);
            }
            else
            {
                //Si se hace clic fuera de una porción, se oculta el tooltip
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
            using (SqlConnection conn = new SqlConnection(ConnectionStringEnerGym))
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
                LabelFormat = "C0"    // formateo de etiquetas de cada barra como moneda
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


            // Enlazamos los datos normalmente
            chartPagos.DataSource = dt;
            chartPagos.DataBind();

            //Forzamos el formato manualmente
            foreach (var p in chartPagos.Series["Recaudación"].Points)
            {
                p.Label = "$" + p.YValues[0].ToString("N0"); // etiqueta sobre cada barra
            }

            // Cambiamos el formato del eje Y también
            chartPagos.ChartAreas["Area1"].AxisY.LabelStyle.Format = "N0"; // números simples
            chartPagos.ChartAreas["Area1"].AxisY.LabelStyle.ForeColor = Color.Black;

            // Dibujamos el símbolo $ en el título del eje Y
            chartPagos.ChartAreas["Area1"].AxisY.Title = "Total recaudado ($)";


        }


        private void CargarTablaPagos()
        {
            string query = @"
            SELECT 
                p.id_pago,
                p.fecha,
                CONCAT(a.nombre, ' ', a.apellido) AS Alumno,
                p.total AS Monto,
                m.nombre AS MedioPago,
                p.ruta_pdf
            FROM Pago p
            INNER JOIN Alumno a ON p.id_alumno = a.id_alumno
            INNER JOIN MedioDePago m ON p.id_medioPago = m.id_medioPago
            WHERE p.ruta_pdf IS NOT NULL
                AND p.ruta_pdf LIKE '%Factura_%'
            ORDER BY p.fecha DESC;
            ";

            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(ConnectionStringEnerGym))
            using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
            {
                da.Fill(dt);
            }

            // Insertamos columna de enumeración en la posición 0
            dt.Columns.Add("N°", typeof(int));
            int index = 1;
            foreach (DataRow row in dt.Rows)
                row["N°"] = index++;

            // Reordenamos la columna al principio
            dt.Columns["N°"].SetOrdinal(0);

            dataGridPagos.DataSource = dt;

            // ocultamos columnas internas
            if (dataGridPagos.Columns.Contains("id_pago"))
                dataGridPagos.Columns["id_pago"].Visible = false;
            if (dataGridPagos.Columns.Contains("ruta_pdf"))
                dataGridPagos.Columns["ruta_pdf"].Visible = false;

            // botón de abrir PDF
            if (!dataGridPagos.Columns.Contains("VerComprobante"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "VerComprobante";
                btn.HeaderText = "Comprobante";
                btn.Text = "Abrir PDF";
                btn.UseColumnTextForButtonValue = true;
                dataGridPagos.Columns.Add(btn);
            }

            dataGridPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void CargarTotalAlumnosActivos()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Alumno WHERE estado = 1";

                using (SqlConnection conn = new SqlConnection(ConnectionStringEnerGym))
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

                        // CreaR una carpeta temporal segura
                        string rutaTemporal = Path.Combine(@"C:\BackupsTemp", Path.GetFileName(rutaDestinoFinal));
                        Directory.CreateDirectory(@"C:\BackupsTemp");

                        string query = $@"
                    BACKUP DATABASE EnerGym_BD_V9
                    TO DISK = '{rutaTemporal}'
                    WITH FORMAT, MEDIANAME = 'EnerGymBackup', NAME = 'Copia de seguridad EnerGym';";

                        using (SqlConnection conn = new SqlConnection(ConnectionStringMaster))
                        {
                            conn.Open();

                            // EjecutaR el BACKUP en la ruta temporal
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                                cmd.ExecuteNonQuery();

                            // Registrar el backup en la base
                            string registrarBackup = "INSERT INTO EnerGym_BD_V9.dbo.HistorialBackup (ruta) VALUES (@ruta)";
                            using (SqlCommand logCmd = new SqlCommand(ConnectionStringEnerGym))
                            {
                                logCmd.Parameters.AddWithValue("@ruta", rutaDestinoFinal);
                                // CREAR una nueva conexión a EnerGym, ya que la actual es a Master.
                                using (SqlConnection connLog = new SqlConnection(ConnectionStringEnerGym))
                                {
                                    connLog.Open();
                                    logCmd.Connection = connLog;
                                    logCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        // Mover el backup desde la ruta temporal a la seleccionada por el usuario
                        File.Copy(rutaTemporal, rutaDestinoFinal, overwrite: true);
                        File.Delete(rutaTemporal); 

                        // Confirmación visual
                        MessageBox.Show(
                            $"Copia de seguridad creada exitosamente.\n\nRuta:\n{rutaDestinoFinal}",
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
                    " Ocurrió un error al generar el backup:\n\n" + ex.Message,
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
                string query = "SELECT fecha AS [Fecha del Backup], ruta AS [Ubicación del Archivo] FROM HistorialBackup ORDER BY fecha DESC;";

                using (SqlConnection conn = new SqlConnection(ConnectionStringEnerGym))
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
        private void CargarGraficoProfesores()
        {
            chartProfesores.Series.Clear();
            chartProfesores.ChartAreas.Clear();
            chartProfesores.Titles.Clear();

            ChartArea area = new ChartArea("Area1");
            chartProfesores.ChartAreas.Add(area);

            string query = @"
            SELECT 
                CONCAT(u.nombre, ' ', u.apellido) AS Profesor,
                COUNT(a.id_alumno) AS CantidadAlumnos
            FROM Alumno a
            INNER JOIN Usuario u ON a.id_coach = u.id_usuario
            WHERE a.estado = 1 AND u.estado = 1 AND u.id_rol = 3
            GROUP BY u.nombre, u.apellido
            ORDER BY CantidadAlumnos DESC;";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionStringEnerGym))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            Series serie = new Series("Alumnos por profesor")
            {
                ChartType = SeriesChartType.Bar,
                XValueMember = "Profesor",
                YValueMembers = "CantidadAlumnos",
                IsValueShownAsLabel = true,
                LabelForeColor = Color.Black,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            chartProfesores.Series.Add(serie);
            chartProfesores.DataSource = dt;
            chartProfesores.DataBind();

            chartProfesores.Titles.Add("Cantidad de alumnos activos por profesor");

            var area1 = chartProfesores.ChartAreas["Area1"];
            area1.AxisX.Title = "Cantidad de alumnos";
            area1.AxisY.Title = "Profesores";
            area1.AxisX.LabelStyle.Format = "N0";
            area1.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            area1.AxisX.MajorGrid.LineColor = Color.LightGray;
            area1.AxisY.MajorGrid.Enabled = false;
        }
        private void chartProfesores_MouseMove(object sender, MouseEventArgs e)
        {
            var result = chartProfesores.HitTest(e.X, e.Y);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                var punto = result.Series.Points[result.PointIndex];
                string profesor = punto.AxisLabel;
                int cantidad = (int)punto.YValues[0];
                chartProfesores.Series[0].ToolTip = $"{profesor}: {cantidad} alumno{(cantidad != 1 ? "s" : "")}";
            }
        }

        private void CargarAlumnosDeProfesor(string nombreProfesor)
        {
            // Limpiar y preparar la grilla
            dataGridAlumnosProfesor.DataSource = null;  // limpia el origen anterior
            dataGridAlumnosProfesor.Visible = true;

            string query = @"
            SELECT a.nombre AS Nombre, a.apellido AS Apellido, a.dni AS DNI
            FROM Alumno a
            INNER JOIN Usuario u ON a.id_coach = u.id_usuario
            WHERE u.estado = 1 AND a.estado = 1
              AND CONCAT(u.nombre, ' ', u.apellido) = @nombreProfesor;";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionStringEnerGym))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombreProfesor", nombreProfesor);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            // Configuración visual
            dataGridAlumnosProfesor.DataSource = dt;
            dataGridAlumnosProfesor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAlumnosProfesor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridAlumnosProfesor.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void chartProfesores_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = chartProfesores.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                string profesor = result.Series.Points[result.PointIndex].AxisLabel;

                // Llamar al método para mostrar los alumnos
                CargarAlumnosDeProfesor(profesor);


            }
        }

        private void dataGridPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridPagos.Columns[e.ColumnIndex].Name == "VerComprobante")
            {
                string ruta = dataGridPagos.Rows[e.RowIndex].Cells["ruta_pdf"].Value.ToString();

                if (File.Exists(ruta))
                {
                    System.Diagnostics.Process.Start("explorer.exe", ruta);
                }
                else
                {
                    MessageBox.Show("No se encontró el comprobante en:\n" + ruta,
                        "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void BuscarUsuario()
        {
            string filtro = textBoxBusqueda.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
            {
                // vuelvo a cargar todos los usuarios
                MostrarVista("Personal");
                return;
            }
            string query = @"
            SELECT u.dni, u.nombre, u.apellido, u.email, r.descripcion
            FROM Usuario u
            INNER JOIN Rol r ON u.id_rol = r.id_rol
            WHERE u.estado = 1
            AND (
                  u.dni LIKE @filtro
                OR u.nombre LIKE @filtro
                OR u.apellido LIKE @filtro
                OR r.descripcion LIKE @filtro  
            )";


            DataTable tabla = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConnectionStringEnerGym))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            dataGridView.Rows.Clear();

            foreach (DataRow row in tabla.Rows)
            {
                dataGridView.Rows.Add(
                    row["dni"],
                    row["nombre"],
                    row["apellido"],
                    row["email"],
                    row["descripcion"]
                );
            }
        }



        private void BBuscar_Click(object sender, EventArgs e)
        {
            BuscarUsuario();

        }

        private void textBoxBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BBuscar.PerformClick();  // Ejecuta exactamente lo mismo que el botón Buscar
                e.SuppressKeyPress = true; // evita el sonido y que aparezca un salto de línea
            }
        }

        private void contentContainer_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}