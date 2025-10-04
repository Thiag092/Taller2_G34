using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Taller2_G34
{
    public partial class AgregarEjercicio : Form
    {
        public AgregarEjercicio()
        {
            InitializeComponent();
        }

        private void AgregarEjercicio_Load(object sender, EventArgs e)
        {
            CargarEjercicios();
            ConfigurarColumnasBotones();
        }



        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void CargarEjercicios()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
            string query = "SELECT id_ejercicio, nombre, repeticiones, tiempo FROM Ejercicio";

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.Fill(dt);
                }

                dataGridEjercicios.DataSource = null;
                dataGridEjercicios.Columns.Clear(); // ✅ limpia columnas antes de recargar
                dataGridEjercicios.AutoGenerateColumns = true;
                dataGridEjercicios.DataSource = dt;

                ConfigurarColumnasBotones(); // ✅ mover acá, después de asignar el DataSource
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ejercicios: " + ex.Message);
            }
        }




        private void ConfigurarColumnasBotones()
        {
            if (dataGridEjercicios.Columns["btnEditar"] == null)
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.HeaderText = "Editar";
                btnEditar.Text = "Editar";
                btnEditar.Name = "btnEditar";
                btnEditar.UseColumnTextForButtonValue = true;
                dataGridEjercicios.Columns.Add(btnEditar);
            }

            if (dataGridEjercicios.Columns["btnEliminar"] == null)
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.Name = "btnEliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                dataGridEjercicios.Columns.Add(btnEliminar);
            }
        }


        private void dataGridEjercicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignorar encabezados

            int id = Convert.ToInt32(dataGridEjercicios.Rows[e.RowIndex].Cells["id_ejercicio"].Value);
            string nombre = dataGridEjercicios.Rows[e.RowIndex].Cells["nombre"].Value.ToString();

            if (dataGridEjercicios.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                int repeticiones = Convert.ToInt32(dataGridEjercicios.Rows[e.RowIndex].Cells["repeticiones"].Value);
                int tiempo = Convert.ToInt32(dataGridEjercicios.Rows[e.RowIndex].Cells["tiempo"].Value);

                EditEjercicio formEdit = new EditEjercicio(id, nombre, repeticiones, tiempo);
                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    CargarEjercicios(); // refrescar grilla después de editar
                }
            }

            else if (dataGridEjercicios.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                DialogResult confirm = MessageBox.Show($"¿Desea eliminar '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    EliminarEjercicio(id);
                    CargarEjercicios(); // refrescar
                }
            }
        }


        private void EliminarEjercicio(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
            string query = "DELETE FROM Ejercicio WHERE id_ejercicio = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Ejercicio eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void BConfirmar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtRepeticiones.Text) ||
                string.IsNullOrWhiteSpace(txtTiempo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.");
                return;
            }

            // Obtener los valores
            string nombre = txtNombre.Text.Trim();
            int repeticiones;
            int tiempo;

            if (!int.TryParse(txtRepeticiones.Text.Trim(), out repeticiones))
            {
                MessageBox.Show("Las repeticiones deben ser un número entero.");
                return;
            }

            if (!int.TryParse(txtTiempo.Text.Trim(), out tiempo))
            {
                MessageBox.Show("El tiempo debe ser un número entero (en segundos).");
                return;
            }

            // Insertar en la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
            string query = "INSERT INTO Ejercicio (nombre, repeticiones, tiempo) VALUES (@nombre, @repeticiones, @tiempo)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@repeticiones", repeticiones);
                    cmd.Parameters.AddWithValue("@tiempo", tiempo);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Ejercicio agregado correctamente.");
                CargarEjercicios(); // Refresca el DataGridView
                LimpiarCampos();    // Limpia los TextBox
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el ejercicio: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtRepeticiones.Clear();
            txtTiempo.Clear();
        }


    }

}
