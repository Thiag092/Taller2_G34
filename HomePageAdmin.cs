using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Taller2_G34
{
    public partial class HomePageAdmin : Form
    {
        // El botón de detalles debe ser un campo a nivel de clase para ser reutilizable
        private DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn();

        // Cadena de conexión centralizada
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

        public HomePageAdmin()
        {
            InitializeComponent();
            btnVerEntrenadores.Visible = false;
            btnVerAdministradores.Visible = false;
            btnVerPrincipiantes.Visible = false;
            btnVerIntermedio.Visible = false;
        }

        // --- MÉTODOS DE CONEXIÓN Y ACCESO A DATOS --

        private SqlDataReader EjecutarConsultaYDevolverDatos(string query, string tipo, out SqlConnection connection)
        {
            connection = new SqlConnection(ConnectionString);

            try
            
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                // CommandBehavior.CloseConnection asegura que la conexión se cierre
                // cuando el DataReader sea cerrado o descartado.
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar {tipo}: {ex.Message}", "Error de Base de Datos");
                connection.Dispose();
                return null;
            }
        }

        private DataTable EjecutarConsultaYDevolverTabla(string query, string filtro)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    conn.Open();
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar: {ex.Message}", "Error de Base de Datos");
                }
            }
            return tabla;
        }

        // --- MÉTODOS DE CONFIGURACIÓN Y POBLACIÓN DE VISTAS ---

        private void DefinirColumnas(string tipo)
        {
            // ⭐️ CORRECCIÓN 1: Desvincular antes de limpiar (Resuelve el ArgumentException)
            dataGridView.DataSource = null;

            // Limpiar y preparar las columnas
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            dataGridView.AutoGenerateColumns = false;

            // Re-inicializamos el botón de detalles
            btnDetalles = new DataGridViewButtonColumn();
            btnDetalles.HeaderText = "Detalles";
            btnDetalles.Text = "Ver más";
            btnDetalles.UseColumnTextForButtonValue = true;

            switch (tipo)
            {
                case "alumnos":
                    // Definición de columnas
                    dataGridView.Columns.Add("DNI", "DNI");
                    dataGridView.Columns.Add("Nombre", "Nombre");
                    dataGridView.Columns.Add("Apellido", "Apellido");
                    dataGridView.Columns.Add("Telefono", "Teléfono");
                    dataGridView.Columns.Add("Sexo", "Sexo");
                    dataGridView.Columns.Add("Membresia", "Membresía");
                    dataGridView.Columns.Add("Plan", "Plan");
                    dataGridView.Columns.Add("Coach", "Coach");
                    btnDetalles.Name = "btnDetallesAlumnos";
                    break;

                case "Personal":
                    dataGridView.Columns.Add("DNI", "DNI");
                    dataGridView.Columns.Add("Nombre", "Nombre");
                    dataGridView.Columns.Add("Apellido", "Apellido");
                    dataGridView.Columns.Add("Email", "Email");
                    dataGridView.Columns.Add("TipoUsuario", "Tipo de usuario");
                    btnDetalles.Name = "btnDetallesUsuario";
                    break;

                case "Administradores":
                case "entrenadores":
                    dataGridView.Columns.Add("DNI", "DNI");
                    dataGridView.Columns.Add("Nombre", "Nombre");
                    dataGridView.Columns.Add("Apellido", "Apellido");
                    dataGridView.Columns.Add("Email", "Email");
                    dataGridView.Columns.Add("Telefono", "Teléfono");
                    btnDetalles.Name = "btnDetallesUsuario";
                    break;

                case "rutinas":
                case "Avanzados":
                case "Principiante":
                case "Intermedio":
                    dataGridView.Columns.Add("ID", "ID");
                    dataGridView.Columns.Add("Nombre", "Nombre");
                    btnDetalles.Name = "btnDetallesRutina";
                    break;
            }

            dataGridView.Columns.Add(btnDetalles);
        }

        private void PoblarDatos(string tipo, SqlDataReader reader)
        {
            if (reader == null) return;

            // ⭐️ CORRECCIÓN: Si PoblarDatos se llama después de DefinirColumnas, 
            // el DataSource NO debe estar asignado (ya lo maneja DefinirColumnas).
            // Usamos Rows.Add, que requiere que DataGridView.DataSource sea null.

            using (reader)
            {
                while (reader.Read())
                {
                    switch (tipo)
                    {
                        case "alumnos":
                            dataGridView.Rows.Add(
                                reader["dni"].ToString(),
                                reader["nombre"].ToString(),
                                reader["apellido"].ToString(),
                                reader["telefono"].ToString(),
                                reader["sexo"].ToString(),
                                reader["Membresia"].ToString(),
                                reader["Plan"].ToString(),
                                reader["Coach"].ToString()
                            );
                            break;

                        case "Personal":
                            dataGridView.Rows.Add(
                                reader["dni"].ToString(),
                                reader["nombre"].ToString(),
                                reader["apellido"].ToString(),
                                reader["email"].ToString(),
                                reader["descripcion"].ToString()
                            );
                            break;

                        case "Administradores":
                        case "entrenadores":
                            dataGridView.Rows.Add(
                                reader["dni"].ToString(),
                                reader["nombre"].ToString(),
                                reader["apellido"].ToString(),
                                reader["email"].ToString(),
                                reader["telefono"].ToString()
                            );
                            break;

                        case "rutinas":
                        case "Avanzados":
                        case "Principiante":
                        case "Intermedio":
                            dataGridView.Rows.Add(
                                reader["id_plan"],
                                reader["nombre"]
                            );
                            break;
                    }
                }
            }
        }

        // --- ORQUESTADOR PRINCIPAL (MostrarVista) ---

        private void MostrarVista(string tipo)
        {
            // Configuración de UI común
            labelTextoBienvenida.Visible = false;
            contentPanel.Visible = true;
            btnAgregar.Visible = true;
            btnEliminar.Visible = true;

            // Configuración de botones de sub-menú (Personal y Rutinas)
            bool isRutinasSubmenu = (tipo == "rutinas" || tipo == "Avanzados" || tipo == "Principiante" || tipo == "Intermedio");
            bool isPersonalSubmenu = (tipo == "Personal" || tipo == "entrenadores" || tipo == "Administradores");

            btnVerEntrenadores.Visible = isPersonalSubmenu;
            btnVerAdministradores.Visible = isPersonalSubmenu;
            btnVerTodos.Visible = (isPersonalSubmenu || isRutinasSubmenu);
            btnVerAvanzados.Visible = isRutinasSubmenu;

            string query = "";
            string filtroRutina = "";

            // 1. Obtener Consulta y Títulos
            switch (tipo)
            {
                case "alumnos":
                    labelTitulo.Text = "Alumnos";
                    btnAgregar.Text = "Agregar Alumno";
                    btnEliminar.Text = "Eliminar Alumno";
                    btnVerAdministradores.Visible = false;
                    btnVerEntrenadores.Visible = false;
                    btnVerPrincipiantes.Visible = false;
                    btnVerIntermedio.Visible = false;
                    btnVerAvanzados.Visible = false;
                    query = @"SELECT a.dni, a.nombre, a.apellido, a.telefono, a.sexo, m.nombre AS Membresia, 
                              p.nombre AS [Plan], u.nombre + ' ' + u.apellido AS Coach
                              FROM Alumno a
                              INNER JOIN Membresia m ON a.id_membresia = m.id_membresia
                              INNER JOIN PlanEntrenamiento p ON a.id_plan = p.id_plan
                              INNER JOIN Usuario u ON a.id_coach = u.id_usuario
                              WHERE a.estado = 1;";
                    break;

                case "Personal":
                    labelTitulo.Text = "Personal";
                    btnAgregar.Text = "Agregar Usuario";
                    btnEliminar.Text = "Eliminar Usuario";
                    btnVerAdministradores.Visible = true;
                    btnVerEntrenadores.Visible = true;
                    btnVerPrincipiantes.Visible = false;
                    btnVerIntermedio.Visible = false;
                    btnVerAvanzados.Visible = false;
                    query = @"SELECT U.dni, U.nombre, U.apellido, U.email, U.telefono, R.descripcion AS descripcion
                              FROM Usuario U INNER JOIN Rol R ON U.id_rol = R.id_rol
                              WHERE U.id_rol IN (2, 3) AND U.estado = 1";
                    break;

                case "Administradores":
                    labelTitulo.Text = "Administradores";
                    btnAgregar.Visible = false;
                    btnEliminar.Visible = false;
                    btnVerAdministradores.Visible = true;
                    btnVerEntrenadores.Visible = true;
                    btnVerPrincipiantes.Visible = false;
                    btnVerIntermedio.Visible = false;
                    btnVerAvanzados.Visible = false;
                    query = @"SELECT U.dni, U.nombre, U.apellido, U.email, U.telefono 
                              FROM Usuario U INNER JOIN Rol R ON U.id_rol = R.id_rol
                              WHERE U.id_rol = 2 AND U.estado = 1";
                    break;

                case "entrenadores":
                    labelTitulo.Text = "Entrenadores";
                    btnAgregar.Visible = false;
                    btnEliminar.Visible = false;
                    query = @"SELECT U.dni, U.nombre, U.apellido, U.email, U.telefono
                              FROM Usuario U INNER JOIN Rol R ON U.id_rol = R.id_rol
                              WHERE U.id_rol = 3 AND U.estado = 1";
                    break;

                case "rutinas":
                    labelTitulo.Text = "Rutinas";
                    btnAgregar.Text = "Nueva Rutina";
                    btnEliminar.Text = "Eliminar Rutina";
                    btnVerAdministradores.Visible = false;
                    btnVerEntrenadores.Visible = false;
                    btnVerPrincipiantes.Visible = true;
                    btnVerIntermedio.Visible = true;
                    btnVerAvanzados.Visible = true;
                    // Consulta base sin filtro de tipo
                    query = "SELECT id_plan, nombre FROM PlanEntrenamiento WHERE estado = 1";
                    break;

                case "Avanzados":
                    labelTitulo.Text = "Avanzados";
                    btnAgregar.Text = "Nueva Rutina";
                    btnEliminar.Text = "Eliminar Rutina";
                    btnVerAdministradores.Visible = false;
                    btnVerEntrenadores.Visible = false;
                    btnVerPrincipiantes.Visible = true;
                    btnVerIntermedio.Visible = true;
                    btnVerAvanzados.Visible = true;
                    filtroRutina = " AND id_tipoPlan = 3";
                    break;

                case "Principiante":
                    labelTitulo.Text = "Principiante";
                    btnAgregar.Text = "Nueva Rutina";
                    btnEliminar.Text = "Eliminar Rutina";
                    btnVerAdministradores.Visible = false;
                    btnVerEntrenadores.Visible = false;
                    btnVerPrincipiantes.Visible = true;
                    btnVerIntermedio.Visible = true;
                    btnVerAvanzados.Visible = true;
                    filtroRutina = " AND id_tipoPlan = 1";
                    break;

                case "Intermedio":
                    labelTitulo.Text = "Intermedio";
                    btnAgregar.Text = "Nueva Rutina";
                    btnEliminar.Text = "Eliminar Rutina";
                    btnVerAdministradores.Visible = false;
                    btnVerEntrenadores.Visible = false;
                    btnVerPrincipiantes.Visible = true;
                    btnVerIntermedio.Visible = true;
                    btnVerAvanzados.Visible = true;
                    filtroRutina = " AND id_tipoPlan = 2";
                    break;


                default:
                    return;
            }

            // Aplicar filtro si estamos en una vista de rutina específica
            if (isRutinasSubmenu && tipo != "rutinas")
            {
                query = $"SELECT id_plan, nombre FROM PlanEntrenamiento WHERE estado = 1 {filtroRutina}";
            }


            // 2. Definir Columnas y Estilo
            DefinirColumnas(tipo);
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 3. Ejecutar Consulta y Poblar DataGridView
            SqlConnection conn;
            SqlDataReader reader = EjecutarConsultaYDevolverDatos(query, tipo, out conn);

            PoblarDatos(tipo, reader);
        }

        // --- MANEJO DE EVENTOS DE NAVEGACIÓN Y ACCIÓN ---

        private void btnVerPrincipiante_Click(object sender, EventArgs e)
        {
            MostrarVista("Principiante");
        }

        private void btnVerIntermedio_Click(object sender, EventArgs e)
        {
            MostrarVista("Intermedio");
        }

        private void btnVerAvanzados_Click(object sender, EventArgs e)
        {
            MostrarVista("Avanzados");
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
                f.Show();
                this.Close();
            }
        }

        private void BVerPersonal_Click(object sender, EventArgs e)
        {
            MostrarVista("Personal");
        }

        private void BVerAlumnos_Click(object sender, EventArgs e)
        {
            MostrarVista("alumnos");
        }

        private void BVerRutinas_Click(object sender, EventArgs e)
        {
            MostrarVista("rutinas");
        }

        private void btnVerEntrenadores_Click(object sender, EventArgs e)
        {
            MostrarVista("entrenadores");
        }

        private void btnVerAdministradores_Click(object sender, EventArgs e)
        {
            MostrarVista("Administradores");
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            if (labelTitulo.Text == "Personal" || labelTitulo.Text == "Entrenadores" || labelTitulo.Text == "Administradores")
            {
                MostrarVista("Personal");
            }
            if (labelTitulo.Text == "Rutinas" || labelTitulo.Text == "Avanzados" || labelTitulo.Text == "Principiante" || labelTitulo.Text == "Intermedio")
            {
                MostrarVista("rutinas");
            }
        }


        private void BRefresh_Click(object sender, EventArgs e)
        {
            string vistaActual = labelTitulo.Text;
            string tipoVista = null;


            if (vistaActual.Contains("Alumnos")) tipoVista = "alumnos";
            else if (vistaActual.Contains("Entrenadores")) tipoVista = "entrenadores";
            else if (vistaActual.Contains("Administradores")) tipoVista = "Administradores";
            else if (vistaActual.Contains("Personal")) tipoVista = "Personal";
            else if (vistaActual.Contains("Rutinas")) tipoVista = "rutinas";
            else if (vistaActual.Contains("Avanzados")) tipoVista = "Avanzados";
            else if (vistaActual.Contains("Principiante")) tipoVista = "Principiante";
            else if (vistaActual.Contains("Intermedio")) tipoVista = "Intermedio";

            if (tipoVista != null)
            {
                MostrarVista(tipoVista);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string btnText = btnAgregar.Text;

            if (btnText.Contains("Usuario"))
            {
                AgregarPersonal formulario = new AgregarPersonal();
                formulario.Show();
            }
            else if (btnText.Contains("Alumno"))
            {
                AgregarAlumno formulario = new AgregarAlumno();
                formulario.Show();
            }
            else if (btnText.Contains("Rutina"))
            {
                VerPlanPlantilla formulario = new VerPlanPlantilla();
                formulario.Show();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un registro primero.");
                return;
            }

            string vistaActual = labelTitulo.Text;
            string query = "";
            string valorClave = "";
            string mensajeExito = "";
            string mensajeError = "";
            string mensajeConfirmacion = "";

            bool isRutinaOrAvanzada = vistaActual.Contains("Rutina") || vistaActual.Contains("Avanzados") || vistaActual.Contains("Principiante") || vistaActual.Contains("Intermedio");

            switch (vistaActual)
            {
                case "Personal":
                case "Administradores":
                case "Entrenadores":
                    valorClave = dataGridView.SelectedRows[0].Cells["DNI"].Value.ToString();
                    query = "UPDATE Usuario SET estado = 0 WHERE dni = @dni";
                    mensajeExito = "El personal fue dado de baja correctamente.";
                    mensajeError = "No se encontró el registro del personal especificado.";
                    mensajeConfirmacion = $"¿Desea dar de baja al personal con DNI {valorClave}?";
                    break;

                case "Alumnos":
                    valorClave = dataGridView.SelectedRows[0].Cells["DNI"].Value.ToString();
                    query = "UPDATE Alumno SET estado = 0 WHERE dni = @dni";
                    mensajeExito = "El alumno fue dado de baja correctamente.";
                    mensajeError = "No se encontró el registro del alumno especificado.";
                    mensajeConfirmacion = $"¿Desea dar de baja al alumno con DNI {valorClave}?";
                    break;

                case "Rutinas":
                case "Avanzados":
                case "Principiante":
                case "Intermedio": // Maneja todas las sub-categorías de Rutinas
                    valorClave = dataGridView.SelectedRows[0].Cells["ID"].Value.ToString();
                    query = "UPDATE PlanEntrenamiento SET estado = 0 WHERE id_plan = @id";
                    mensajeExito = "La rutina fue desactivada correctamente.";
                    mensajeError = "No se encontró la rutina especificada.";
                    mensajeConfirmacion = $"¿Desea desactivar la rutina con ID {valorClave}?";
                    break;

                default:
                    MessageBox.Show("No hay una vista activa válida para eliminar.");
                    return;
            }

            DialogResult confirmacion = MessageBox.Show(
                mensajeConfirmacion,
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion != DialogResult.Yes)
                return;

            // Se utiliza la variable de clase ConnectionString
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (isRutinaOrAvanzada)
                    command.Parameters.AddWithValue("@id", valorClave);
                else
                    command.Parameters.AddWithValue("@dni", valorClave);

                try
                {
                    connection.Open();
                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar la vista actual basada en el título
                        if (vistaActual.Contains("Alumnos"))
                            MostrarVista("alumnos");
                        else if (vistaActual.Contains("Rutinas"))
                            MostrarVista("rutinas");
                        else if (vistaActual.Contains("Avanzados"))
                            MostrarVista("Avanzados");
                        else if (vistaActual.Contains("Principiante"))
                            MostrarVista("Principiante");
                        else if (vistaActual.Contains("Intermedio"))
                            MostrarVista("Intermedio");
                        else
                            MostrarVista("Personal");
                    }
                    else
                    {
                        MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar la baja: " + ex.Message);
                }
            }
        }

        private void dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dataGridView.Columns[e.ColumnIndex].Name;

            // ⭐️ CORRECCIÓN 3: El DataGridView ahora usa DataSource = tabla en Buscar(), 
            // pero el botón de Detalles es añadido manualmente en DefinirColumnas.
            // Si la columna es el botón, ejecutamos la lógica de edición.

            if (colName.Contains("btnDetalles"))
            {
                string valorClave = null;
                string vista = colName.Replace("btnDetalles", "").ToLower();

                // Determinar la clave (DNI o ID)

                try
                {
                    if (dataGridView.Columns.Contains("DNI"))
                    {
                        valorClave = dataGridView.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
                    }
                    else if (dataGridView.Columns.Contains("ID"))
                    {
                        valorClave = dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Si falla al obtener la celda, es probable que la grilla no se haya poblado con las columnas correctas
                    MessageBox.Show("Error al obtener la clave para detalles: " + ex.Message, "Error de Datos");
                    return;
                }


                if (string.IsNullOrEmpty(valorClave)) return;

                // Enrutar al formulario de edición correcto
                if (vista.Contains("alumnos"))
                {
                    EditAlumno frm = new EditAlumno(valorClave);
                    frm.ShowDialog();
                }
                else if (vista.Contains("rutina")) // Captura rutinas y avanzados, principiante, intermedio
                {
                    int idPlan = Convert.ToInt32(valorClave);
                    FormEditarPlan frm = new FormEditarPlan(idPlan);
                    frm.ShowDialog();
                }
                else // Personal / Administradores / Entrenadores
                {
                    EditPersonal frm = new EditPersonal(valorClave);
                    frm.ShowDialog();
                }
            }
        }


        private void Buscar()
        {
            string filtro = textBoxBusqueda.Text.Trim();
            string query = "";

            // 1. Si el filtro está vacío, recarga la vista actual
            if (string.IsNullOrEmpty(filtro))
            {
                string tipoVista = labelTitulo.Text;
                if (tipoVista.Contains("Rutinas")) MostrarVista("rutinas");
                else if (tipoVista.Contains("Avanzados")) MostrarVista("Avanzados");
                else if (tipoVista.Contains("Principiante")) MostrarVista("Principiante");
                else if (tipoVista.Contains("Intermedio")) MostrarVista("Intermedio");
                else if (tipoVista.Contains("Alumnos")) MostrarVista("alumnos");
                else MostrarVista("Personal");
                return;
            }

            // 2. Determinar la consulta SQL basada en la vista actual (labelTitulo.Text)
            string vistaActual = labelTitulo.Text;

            if (vistaActual.Contains("Rutinas") || vistaActual.Contains("Avanzados") || vistaActual.Contains("Principiante") || vistaActual.Contains("Intermedio"))
            {
                // Búsqueda de Rutinas
                query = @"
                SELECT 
                    p.id_plan AS ID,
                    p.nombre AS [Nombre del Plan]
                FROM PlanEntrenamiento p
                INNER JOIN TipoPlan t ON p.id_tipoPlan = t.id_tipoPlan
                WHERE p.estado = 1
                AND (
                      CAST(p.id_plan AS NVARCHAR) LIKE @filtro  
                    OR p.nombre LIKE @filtro                    
                )";

                // Aplicar filtro de tipo si no es la vista general "Rutinas"
                if (vistaActual.Contains("Avanzados"))
                {
                    query += " AND p.id_tipoPlan = 3";
                }
                else if (vistaActual.Contains("Principiante"))
                {
                    query += " AND p.id_tipoPlan = 1";
                }
                else if (vistaActual.Contains("Intermedio"))
                {
                    query += " AND p.id_tipoPlan = 2";
                }

                query += " ORDER BY p.id_plan";
            }
            else if (vistaActual.Contains("Alumnos"))
            {
                // Búsqueda de Alumnos
                query = @"
                SELECT 
                    a.dni AS DNI, 
                    a.nombre AS Nombre, 
                    a.apellido AS Apellido, 
                    a.telefono, a.sexo, m.nombre AS Membresia, 
                    p.nombre AS [Plan], u.nombre + ' ' + u.apellido AS Coach
                FROM Alumno a
                INNER JOIN Membresia m ON a.id_membresia = m.id_membresia
                INNER JOIN PlanEntrenamiento p ON a.id_plan = p.id_plan
                INNER JOIN Usuario u ON a.id_coach = u.id_usuario
                WHERE a.estado = 1
                AND (
                      a.dni LIKE @filtro
                    OR a.nombre LIKE @filtro
                    OR a.apellido LIKE @filtro
                    OR m.nombre LIKE @filtro
                    OR p.nombre LIKE @filtro
                    OR u.nombre + ' ' + u.apellido LIKE @filtro
                )";
            }
            else // Personal, Entrenadores, Administradores
            {
                // Búsqueda de Personal
                string rolFilter = "";
                if (vistaActual.Contains("Administradores"))
                    rolFilter = "AND U.id_rol = 2";
                else if (vistaActual.Contains("Entrenadores"))
                    rolFilter = "AND U.id_rol = 3";
                else // Personal (Ambos: 2 y 3)
                    rolFilter = "AND U.id_rol IN (2, 3)";

                query = $@"
                    SELECT U.dni, U.nombre, U.apellido, U.email, U.telefono, R.descripcion AS TipoUsuario
                    FROM Usuario U INNER JOIN Rol R ON U.id_rol = R.id_rol
                    WHERE U.estado = 1 {rolFilter}
                    AND (
                          U.dni LIKE @filtro
                        OR U.nombre LIKE @filtro
                        OR U.apellido LIKE @filtro
                        OR U.email LIKE @filtro
                    )";
            }

            // 3. Ejecutar la consulta usando el patrón DataTable/SqlDataAdapter 
            DataTable tabla = EjecutarConsultaYDevolverTabla(query, filtro);

            // 4. Llenar DataGridView y re-agregar botón de Detalles

            // Desvincular antes de limpiar
            dataGridView.DataSource = null;
            dataGridView.Columns.Clear();

            // Determinar tipo base para redefinir las columnas antes de asignar el DataSource
            string tipoBase = vistaActual.Contains("Rutinas") || vistaActual.Contains("Avanzados") || vistaActual.Contains("Principiante") || vistaActual.Contains("Intermedio") ? "rutinas" :
                              vistaActual.Contains("Alumnos") ? "alumnos" : "Personal";

            // Definir columnas (se agregan las columnas esperadas, incluyendo el botón de detalles)
            DefinirColumnas(tipoBase);


            // Para la búsqueda, usaremos Rows.Add para mantener la coherencia con PoblarDatos:
            PoblarDatosDesdeTabla(tabla, tipoBase);

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        
        private void PoblarDatosDesdeTabla(DataTable tabla, string tipo)
        {
            dataGridView.Rows.Clear(); // Limpi las filas si ya existen

            foreach (DataRow row in tabla.Rows)
            {
                // Usamos la lógica del switch de PoblarDatos (adaptada para DataRow)
                switch (tipo)
                {
                    case "alumnos":
                        dataGridView.Rows.Add(
                            row["DNI"], row["Nombre"], row["Apellido"], row["telefono"], row["sexo"],
                            row["Membresia"], row["Plan"], row["Coach"]
                        );
                        break;

                    case "Personal":
                        dataGridView.Rows.Add(
                            row["DNI"], row["Nombre"], row["Apellido"], row["Email"], row["TipoUsuario"]
                        );
                        break;

                    case "Administradores":
                    case "entrenadores":
                        dataGridView.Rows.Add(
                            row["DNI"], row["Nombre"], row["Apellido"], row["Email"], row["telefono"]
                        );
                        break;

                    case "rutinas":
                    case "Avanzados":
                    case "Principiante":
                    case "Intermedio":
                        dataGridView.Rows.Add(
                            row["ID"], row["Nombre del Plan"]
                        );
                        break;
                }
            }
        }


        private void BBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void textBoxBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            // Sintaxis correcta para verificar la tecla Enter
            if (e.KeyCode == Keys.Enter)
            {
                BBuscar.PerformClick();  // Ejecuta exactamente lo mismo que el botón Buscar
                e.SuppressKeyPress = true; // Evitar el 'ding' y otros comportamientos no deseados
            }
        }

        private void BSalir_Click_1(object sender, EventArgs e)
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
                f.Show();
                this.Close();
            }
        }
    }
}