using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Taller2_G34
{
    public partial class NuevoEjercicio : Form
    {
        private readonly int _idPlan;
        private readonly int _idDia;
        private readonly string _connectionString;

        // Modificar el constructor para recibir el id_dia
        public NuevoEjercicio(int planId, int diaId)
        {
            InitializeComponent();
            _idPlan = planId;
            _idDia = diaId;
            _connectionString = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            if (!ProcesarEjercicio())
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidarCampos()
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del ejercicio es obligatorio.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que al menos uno de los campos (repeticiones o tiempo) tenga valor
            if (string.IsNullOrWhiteSpace(txtRepeticiones.Text) && string.IsNullOrWhiteSpace(txtTiempo.Text))
            {
                MessageBox.Show("Debe ingresar repeticiones o tiempo para el ejercicio.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que las series sean numéricas y mayores a 0
            if (!int.TryParse(txtSeries.Text, out int series) || series <= 0)
            {
                MessageBox.Show("Las series deben ser un número mayor a 0.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar repeticiones si se ingresaron
            if (!string.IsNullOrWhiteSpace(txtRepeticiones.Text))
            {
                if (!int.TryParse(txtRepeticiones.Text, out int repeticiones) || repeticiones <= 0)
                {
                    MessageBox.Show("Las repeticiones deben ser un número mayor a 0.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Validar tiempo si se ingresó
            if (!string.IsNullOrWhiteSpace(txtTiempo.Text))
            {
                if (!int.TryParse(txtTiempo.Text, out int tiempo) || tiempo <= 0)
                {
                    MessageBox.Show("El tiempo debe ser un número mayor a 0.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private bool ProcesarEjercicio()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 1️⃣ Insertar el ejercicio (solo nombre)
                            int idEjercicio = InsertarEjercicio(connection, transaction);

                            // 2️⃣ Insertar en Plan_Ejercicio con todos los parámetros
                            bool exito = InsertarEnPlanEjercicio(connection, transaction, idEjercicio);

                            if (exito)
                            {
                                transaction.Commit();
                                MessageBox.Show("Ejercicio creado y agregado al plan correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el ejercicio: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private int InsertarEjercicio(SqlConnection connection, SqlTransaction transaction)
        {
            string queryEjercicio = @"
                INSERT INTO Ejercicio (nombre)
                VALUES (@nombre);
                SELECT SCOPE_IDENTITY();";

            using (var cmd = new SqlCommand(queryEjercicio, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private bool InsertarEnPlanEjercicio(SqlConnection connection, SqlTransaction transaction, int idEjercicio)
        {
            string queryPlanEjercicio = @"
                INSERT INTO Plan_Ejercicio 
                (id_plan, id_ejercicio, id_dia, cant_series, repeticiones, tiempo) 
                VALUES (@id_plan, @id_ejercicio, @id_dia, @series, @repeticiones, @tiempo);";

            using (var cmd = new SqlCommand(queryPlanEjercicio, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@id_plan", _idPlan);
                cmd.Parameters.AddWithValue("@id_ejercicio", idEjercicio);
                cmd.Parameters.AddWithValue("@id_dia", _idDia); // Usar el día que viene del formulario padre
                cmd.Parameters.AddWithValue("@series", int.Parse(txtSeries.Text.Trim()));

                // Manejar repeticiones 
                if (int.TryParse(txtRepeticiones.Text, out int repeticiones))
                    cmd.Parameters.AddWithValue("@repeticiones", repeticiones);
                else
                    cmd.Parameters.AddWithValue("@repeticiones", DBNull.Value);

                // Manejar tiempo
                if (int.TryParse(txtTiempo.Text, out int tiempo))
                    cmd.Parameters.AddWithValue("@tiempo", tiempo);
                else
                    cmd.Parameters.AddWithValue("@tiempo", DBNull.Value);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        private void NuevoEjercicio_Load(object sender, EventArgs e)
        {
            // No necesitamos cargar días, ya tenemos el id_dia
        }
    }
}