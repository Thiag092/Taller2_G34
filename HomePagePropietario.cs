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
            // Oculto el label de bienvenida porque ya no corresponde mostrarlo
            labelTextoBienvenida.Visible = false;

            // Hago visible el panel donde va el DataGridView con los datos
            contentPanel.Visible = true;

            // Limpio el DataGridView antes de cargar nuevos datos (importante para que no se acumulen)
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            // Creo una columna de botones que irá en cada fila para ver más detalles del usuario
            DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn();
            btnDetalles.HeaderText = "Detalles";            // Texto en el encabezado de la columna
            btnDetalles.Text = "Ver más";                   // Texto que aparecerá en cada botón
            btnDetalles.Name = "Detalles";                  // Nombre interno de la columna
            btnDetalles.UseColumnTextForButtonValue = true; // Para que todos los botones tengan el mismo texto

            // Creo las columnas del DataGridView
            dataGridView.Columns.Add("DNI", "DNI");
            dataGridView.Columns.Add("Nombre", "Nombre");
            dataGridView.Columns.Add("Apellido", "Apellido");
            dataGridView.Columns.Add("Email", "Email");
            dataGridView.Columns.Add("TipoUsuario", "Tipo de usuario");
            dataGridView.Columns.Add(btnDetalles); // Agrego la columna de botones al final

            // Cadena de conexión a SQL Server
            //   - Server: tu instancia de SQL Server (ej: localhost o .\SQLEXPRESS)
            //   - Database: el nombre de tu base (ej: GimnasioDB)
            //   - Trusted_Connection=True: usa autenticación de Windows
            string connectionString = "Server=YAGO_DELL\\SQLEXPRESS01;Database=EnerGym;Trusted_Connection=True;";

            // 📄 Consulta SQL para traer usuarios junto con su rol y que estos esten activos
            string query = @"
    SELECT u.dni, u.nombre, u.apellido, u.email, r.descripcion
    FROM Usuario u
    INNER JOIN Rol r ON u.id_rol = r.id_rol
    WHERE u.estado = 1"; // Solo usuarios activos

            // Abro la conexión con la base de datos
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Abro la conexión

                // Creo un comando SQL con la consulta
                SqlCommand cmd = new SqlCommand(query, conn);

                // Ejecuto el comando y obtengo un "lector" de filas
                SqlDataReader reader = cmd.ExecuteReader();

                // Recorro cada fila devuelta por la consulta
                while (reader.Read())
                {
                    // Voy agregando las filas al DataGridView
                    dataGridView.Rows.Add(
                        reader["dni"],         // Columna DNI
                        reader["nombre"],      // Columna Nombre
                        reader["apellido"],    // Columna Apellido
                        reader["email"],       // Columna Email
                        reader["descripcion"]  // Columna Tipo de usuario (rol)
                    );
                }
            }

            // Ajusto las columnas para que ocupen todo el ancho disponible
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Actualizo los textos de los botones y etiquetas del formulario
            labelTitulo.Text = "Personal";
            btnAgregar.Text = "Agregar Usuario";
            btnEliminar.Text = "Eliminar Usuario";
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
                            MessageBox.Show("Usuario dado de baja correctamente ✅");
                            MostrarVista("Personal"); // refresca la grilla
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el usuario ❌");
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

    }
}

