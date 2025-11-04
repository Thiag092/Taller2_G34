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

        public HomePageAdmin()
        {
            InitializeComponent();
            btnVerEntrenadores.Visible = false;
            btnVerAdministradores.Visible = false;
            
        }

        // --- MÉTODOS DE CONEXIÓN Y ACCESO A DATOS (Lógica Central) ---

        private SqlDataReader EjecutarConsultaYDevolverDatos(string query, string tipo, out SqlConnection connection)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
            connection = new SqlConnection(connectionString);

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

        // --- MÉTODOS DE CONFIGURACIÓN Y POBLACIÓN DE VISTAS ---

        private void DefinirColumnas(string tipo)
        {
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
                case "Avanzados": // Misma estructura que Rutinas
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

            // Se asume que btnVerAvanzados existe en el Designer
            bool isRutinasSubmenu = (tipo == "rutinas" || tipo == "Avanzados");
            bool isPersonalSubmenu = (tipo == "Personal" || tipo == "entrenadores" || tipo == "Administradores");
            btnVerEntrenadores.Visible = isPersonalSubmenu;
            btnVerAdministradores.Visible = isPersonalSubmenu;
            btnVerTodos.Visible = (isPersonalSubmenu || isRutinasSubmenu);
            btnVerAvanzados.Visible = (isRutinasSubmenu); // Solo mostrar "Avanzados" cuando la vista principal es "Rutinas"

            string query;

            // 1. Obtener Consulta y Títulos
            switch (tipo)
            {
                case "alumnos":
                    labelTitulo.Text = "Alumnos";
                    btnAgregar.Text = "Agregar Alumno";
                    btnEliminar.Text = "Eliminar Alumno";
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
                    query = @"SELECT U.dni, U.nombre, U.apellido, U.email, U.telefono, R.descripcion 
                              FROM Usuario U INNER JOIN Rol R ON U.id_rol = R.id_rol
                              WHERE U.id_rol IN (2, 3) AND U.estado = 1";
                    break;

                case "Administradores":
                    labelTitulo.Text = "Administradores";
                    btnAgregar.Visible = false;
                    btnEliminar.Visible = false;
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
                    query = "SELECT id_plan, nombre FROM PlanEntrenamiento WHERE estado = 1";
                    break;

                case "Avanzados":
                    labelTitulo.Text = "Avanzados";
                    btnAgregar.Text = "Nueva Rutina";
                    btnEliminar.Text = "Eliminar Rutina";
                    //  Consulta específica para Plan Avanzado
                    query = "SELECT id_plan, nombre FROM PlanEntrenamiento WHERE id_tipoPlan = 3 AND estado = 1";
                    break;

                default:
                    return;
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
            if(labelTitulo.Text == "Rutinas" || labelTitulo.Text == "Avanzados")
            {
                MostrarVista("rutinas");
            }


        }

        private void btnVerAvanzados_Click(object sender, EventArgs e)
        {
            MostrarVista("Avanzados");
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

            bool isRutinaOrAvanzada = vistaActual.Contains("Rutina") || vistaActual.Contains("Avanzados");

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
                case "Avanzados": // Maneja Rutinas y Avanzados
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

            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
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

            if (colName.Contains("btnDetalles"))
            {
                string valorClave = null;
                string vista = colName.Replace("btnDetalles", "").ToLower();

                // Determinar la clave (DNI o ID)
                if (dataGridView.Columns.Contains("DNI"))
                {
                    valorClave = dataGridView.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
                }
                else if (dataGridView.Columns.Contains("ID"))
                {
                    valorClave = dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                }

                if (string.IsNullOrEmpty(valorClave)) return;

                // Enrutar al formulario de edición correcto
                if (vista.Contains("alumnos"))
                {
                     EditAlumno frm = new EditAlumno(valorClave);
                    frm.ShowDialog();
                }
                else if (vista.Contains("rutina")) // Captura rutinas y avanzados
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
                f.Show();          // vuelve al formulario de login
                this.Close();
            }
        }
    }
}