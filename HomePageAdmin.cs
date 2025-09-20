using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; // para leer la cadena de conexión del App.config
using System.Data.SqlClient; // para usar SqlConnection, SqlCommand, SqlDataReader


namespace Taller2_G34
{
    public partial class HomePageAdmin : Form
    {
        public HomePageAdmin()
        {
            InitializeComponent();
            // Suscribo el evento para detectar clicks en las celdas del DataGridView
            dataGridView.CellContentClick += dataGridView_CellContentClick;
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

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifico que la columna clickeada sea la de "Detalles"
            if (e.ColumnIndex >= 0 && dataGridView.Columns[e.ColumnIndex].Name == "Detalles" && e.RowIndex >= 0)
            {
                // Obtengo el DNI de la fila seleccionada
                string dniSeleccionado = dataGridView.Rows[e.RowIndex].Cells["DNI"].Value.ToString();

                // Abro el formulario de edición pasando el DNI
                EditPersonal formEditar = new EditPersonal(dniSeleccionado);
                formEditar.ShowDialog(); // ShowDialog para que sea modal
            }
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
                // Defino las columnas que quiero ver en la grilla
                dataGridView.Columns.Add("DNI", "DNI");
                dataGridView.Columns.Add("Nombre", "Nombre");
                dataGridView.Columns.Add("Apellido", "Apellido");
                dataGridView.Columns.Add("Email", "Email");
                dataGridView.Columns.Add("TipoUsuario", "Tipo de usuario");

                // Botón de detalles
                btnDetalles.UseColumnTextForButtonValue = true;
                dataGridView.Columns.Add(btnDetalles);

                // Leo la cadena de conexión "EnerGymDB" desde App.config
                string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;


                //Consulta que trae SOLO Administradores (2) y Coaches (3)
                //    Además hago JOIN con Rol para mostrar la descripción del rol.
                string query = @"SELECT U.dni, U.nombre, U.apellido, U.email, R.descripcion 
                 FROM Usuario U
                 INNER JOIN Rol R ON U.id_rol = R.id_rol
                 WHERE U.id_rol IN (2, 3) 
                   AND U.estado = 1";  // Solo admins y coaches ACTIVOS



                //  Abro la conexión y recorro cada fila con un DataReader
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();


                        // Por cada registro devuelto, agrego una fila al DataGridView
                        while (reader.Read())
                        {
                            dataGridView.Rows.Add(
                                reader["dni"].ToString(),
                                reader["nombre"].ToString(),
                                reader["apellido"].ToString(),
                                reader["email"].ToString(),
                                reader["descripcion"].ToString()
                            );
                        }
                    }

                    // Si algo falla (DB caída, cadena mal, etc.), muestro el error
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar personal: " + ex.Message);
                    }
                }

                // Ajusto títulos y botones específicos de esta vista
                labelTitulo.Text = "Personal";
                btnAgregar.Text = "Agregar Usuario";
                btnEliminar.Text = "Eliminar Usuario";
            }


            // ---------- ENTRENADORES / RUTINAS (tus otras vistas) ----------
            if (tipo == "entrenadores")
            {
                // Limpio columnas y filas del DataGridView
                dataGridView.Columns.Clear();
                dataGridView.Rows.Clear();

                // Defino las columnas a mostrar
                dataGridView.Columns.Add("DNI", "DNI");
                dataGridView.Columns.Add("Nombre", "Nombre");
                dataGridView.Columns.Add("Apellido", "Apellido");
                dataGridView.Columns.Add("Email", "Email");
                dataGridView.Columns.Add("Telefono", "Teléfono");

                // Agrego columna de botones "Ver más"
                btnDetalles = new DataGridViewButtonColumn();
                btnDetalles.HeaderText = "Detalles";
                btnDetalles.Text = "Ver más";
                btnDetalles.Name = "Detalles";
                btnDetalles.UseColumnTextForButtonValue = true;
                dataGridView.Columns.Add(btnDetalles);


                // Conexión a la BD (cadena del App.config)
                string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

                // Consulta SQL → solo usuarios con rol 3 (Coachs) y que estén activos
                string query = @"SELECT U.dni, U.nombre, U.apellido, U.email, U.telefono
                     FROM Usuario U
                     INNER JOIN Rol R ON U.id_rol = R.id_rol
                     WHERE U.id_rol = 3 AND U.estado = 1";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Cargo los datos en la grilla
                        while (reader.Read())
                        {
                            dataGridView.Rows.Add(
                                reader["dni"].ToString(),
                                reader["nombre"].ToString(),
                                reader["apellido"].ToString(),
                                reader["email"].ToString(),
                                reader["telefono"].ToString()
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar entrenadores: " + ex.Message);
                    }
                }

                // Ajusto título y botones específicos de esta vista
                labelTitulo.Text = "Entrenadores";
                btnAgregar.Text = "Agregar Entrenador";
                btnEliminar.Text = "Eliminar Entrenador";

                // Ajusto visual → que las columnas ocupen todo el ancho
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

            // Que las columnas ajusten el ancho automáticamente
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void homeContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void BVerUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void BVerAlumnos_Click_1(object sender, EventArgs e)
        {

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

        private void BRefresh_Click(object sender, EventArgs e)
        {
            MostrarVista("Personal"); //recarga la lista del personal

        }
    }
}
