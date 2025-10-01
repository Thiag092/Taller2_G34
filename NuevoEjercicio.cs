using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller2_G34
{
    public partial class NuevoEjercicio : Form
    {
        public string NombreEjercicio { get; private set; }
        public string Repeticiones { get; private set; }
        public string Series { get; private set; }
        public string Objetivo { get; private set; }

        private int idPlan;
        public NuevoEjercicio(int planId)
        {
            InitializeComponent();
            idPlan = planId;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtRepeticiones.Text) ||
                    string.IsNullOrWhiteSpace(txtSeries.Text) ||
                    string.IsNullOrWhiteSpace(txtMusculoObjetivo.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que repeticiones y series sean números
                if (!int.TryParse(txtRepeticiones.Text, out int repeticiones))
                {
                    MessageBox.Show("Las repeticiones deben tener un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtSeries.Text, out int series))
                {
                    MessageBox.Show("Las series deben tener un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connectionString = ConfigurationManager
                                            .ConnectionStrings["EnerGymDB"]
                                            .ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 1️⃣ Insertar el ejercicio
                    string queryEjercicio = @"
                INSERT INTO Ejercicio (nombre, descripcion, musculo_objetivo)
                VALUES (@nombre, @descripcion, @musculo_objetivo);
                SELECT SCOPE_IDENTITY();";

                    int idEjercicio;
                    using (SqlCommand cmdEjercicio = new SqlCommand(queryEjercicio, connection))
                    {
                        cmdEjercicio.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmdEjercicio.Parameters.AddWithValue("@descripcion", ""); // opcional
                        cmdEjercicio.Parameters.AddWithValue("@musculo_objetivo", txtMusculoObjetivo.Text.Trim());

                        idEjercicio = Convert.ToInt32(cmdEjercicio.ExecuteScalar());
                    }

                    // 2️⃣ Insertar en Plan_Ejercicio
                    string queryPlanEjercicio = @"
                INSERT INTO Plan_Ejercicio (id_plan, id_ejercicio, repeticiones, series)
                VALUES (@id_plan, @id_ejercicio, @repeticiones, @series);";

                    using (SqlCommand cmdPlanEjercicio = new SqlCommand(queryPlanEjercicio, connection))
                    {
                        cmdPlanEjercicio.Parameters.AddWithValue("@id_plan", idPlan);
                        cmdPlanEjercicio.Parameters.AddWithValue("@id_ejercicio", idEjercicio);
                        cmdPlanEjercicio.Parameters.AddWithValue("@repeticiones", repeticiones);
                        cmdPlanEjercicio.Parameters.AddWithValue("@series", series);

                        int filasAfectadas = cmdPlanEjercicio.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Ejercicio agregado correctamente al plan.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el ejercicio al plan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el ejercicio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
