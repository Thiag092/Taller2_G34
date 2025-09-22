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
            // Oculto todo por defecto
            picBoxEstadisticas.Visible = false;
            BGraficoInscriptos.Visible = false;
            BGraficoPagos.Visible = false;
            dataGridView.Visible = false;
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
            BRefresh.Visible = false;
            PBPagos.Visible = false;



            if (tipo == "Pagos")
            {
                labelTitulo.Text = "Estadísticas de facturación";
                contentPanel.Visible = true;

                // Oculto la grilla
                dataGridView.Visible = false;

                // Muestro el PictureBox con la imagen
                PBPagos.Visible = true;
                PBPagos.Image = Properties.Resources.facturacion_gimnasio;
                // 👆 reemplazá "facturacion_mockup" por el nombre real del recurso
            }


            if (tipo == "Estadisticas")
            {
                labelTitulo.Text = "Estadísticas del gimnasio";
                picBoxEstadisticas.Visible = true;
                BGraficoInscriptos.Visible = true;
                BGraficoPagos.Visible = true;
            }
            else
            {
                // Oculto bienvenida
                labelTextoBienvenida.Visible = false;
                contentPanel.Visible = true;

                // Limpio la grilla
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

                // Columnas
                dataGridView.Columns.Add("DNI", "DNI");
                dataGridView.Columns.Add("Nombre", "Nombre");
                dataGridView.Columns.Add("Apellido", "Apellido");
                dataGridView.Columns.Add("Email", "Email");
                dataGridView.Columns.Add("TipoUsuario", "Tipo de usuario");
                dataGridView.Columns.Add(btnDetalles);

                // Conexión y carga de datos
                string connectionString = "Server=YAGO_DELL\\SQLEXPRESS01;Database=EnerGym;Trusted_Connection=True;";
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

                //  Configuro según tipo
                if (tipo == "entrenadores")
                {
                    labelTitulo.Text = "Entrenadores";
                    // botones ocultos
                    btnAgregar.Visible = false;
                    btnEliminar.Visible = false;
                }
                else if (tipo == "Personal")
                {
                    labelTitulo.Text = "Personal";
                    btnAgregar.Text = "Agregar Usuario";
                    btnEliminar.Text = "Eliminar Usuario";
                    btnAgregar.Visible = true;
                    btnEliminar.Visible = true;
                }
                else if (tipo == "alumnos")
                {
                    labelTitulo.Text = "Alumnos";
                    btnAgregar.Visible = false;
                    btnEliminar.Visible =false;
                }
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
                    string connectionString = "Data Source=YAGO_DELL\\SQLEXPRESS01;Initial Catalog=EnerGym;Integrated Security=True";
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
        }


        private void BEstadisticas_Click(object sender, EventArgs e)
        {
            MostrarVista("Estadisticas");
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

        private void PBPagos_Click(object sender, EventArgs e)
        {

        }
    }
}

