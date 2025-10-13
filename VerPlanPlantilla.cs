using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Taller2_G34
{
    public partial class VerPlanPlantilla : Form
    {
        private readonly int _idPlan;
        private DataTable _dtDiaEjercicios;

        public VerPlanPlantilla(int idPlan)
        {
            InitializeComponent();
            _idPlan = idPlan;
        }

        private string Cn => ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

        private void VerPlanPlantilla_Load(object sender, EventArgs e)
        {
            dgvEjercicios.AutoGenerateColumns = false;
            dgvEjercicios.MultiSelect = true;
            dgvEjercicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CargarInfoPlan();
            CargarDias();
            CargarCatalogoEjercicios();

            cboDias.SelectedIndexChanged += cboDias_SelectedIndexChanged;
            if (cboDias.Items.Count > 0)
                cboDias.SelectedIndex = 0;
        }

        private void CargarInfoPlan()
        {
            string sql = @"
                SELECT p.nombre, t.descripcion AS Tipo
                FROM PlanEntrenamiento p
                INNER JOIN TipoPlan t ON t.id_tipoPlan = p.id_tipoPlan
                WHERE p.id_plan = @id";
            using (var cn = new SqlConnection(Cn))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", _idPlan);
                cn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                        labelTitulo.Text = $"{r["nombre"]} ({r["Tipo"]})";
                }
            }
        }

        private void CargarDias()
        {
            string sql = "SELECT id_dia, nombreDia FROM Plan_Dia WHERE id_plan = @id ORDER BY id_dia";
            using (var cn = new SqlConnection(Cn))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.AddWithValue("@id", _idPlan);
                var dt = new DataTable();
                da.Fill(dt);
                cboDias.DisplayMember = "nombreDia";
                cboDias.ValueMember = "id_dia";
                cboDias.DataSource = dt;
            }
        }

        private void CargarCatalogoEjercicios()
        {
            string sql = "SELECT id_ejercicio, nombre FROM Ejercicio ORDER BY nombre";
            using (var cn = new SqlConnection(Cn))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cboEjercicioCatalogo.DisplayMember = "nombre";
                cboEjercicioCatalogo.ValueMember = "id_ejercicio";
                cboEjercicioCatalogo.DataSource = dt;
            }
        }

        private void cboDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDias.SelectedValue is null) return;
            int idDia = Convert.ToInt32(cboDias.SelectedValue);
            CargarEjerciciosDia(idDia);
        }

        private void CargarEjerciciosDia(int idDia)
        {
            string sql = @"
                SELECT 
                    pe.id_ejercicio, 
                    e.nombre, 
                    pe.repeticiones, 
                    pe.tiempo,
                    pe.cant_series
                FROM Plan_Ejercicio pe
                INNER JOIN Ejercicio e ON e.id_ejercicio = pe.id_ejercicio
                WHERE pe.id_plan = @idPlan AND pe.id_dia = @idDia
                ORDER BY e.nombre";
            using (var cn = new SqlConnection(Cn))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.AddWithValue("@idPlan", _idPlan);
                da.SelectCommand.Parameters.AddWithValue("@idDia", idDia);
                _dtDiaEjercicios = new DataTable();
                da.Fill(_dtDiaEjercicios);
                dgvEjercicios.DataSource = _dtDiaEjercicios;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void btnNuevoEjercicio_Click(object sender, EventArgs e)
        {
            if (cboDias.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un día primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idDiaSeleccionado = Convert.ToInt32(cboDias.SelectedValue);

            using (var nuevoEjercicioForm = new NuevoEjercicio(_idPlan, idDiaSeleccionado))
            {
                var resultado = nuevoEjercicioForm.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    CargarEjerciciosDia(idDiaSeleccionado);
                    MessageBox.Show("Nuevo ejercicio creado y agregado al plan.", "Éxito");
                }
            }
        }

        private void RecargarDatos()
        {
            try
            {
                CargarCatalogoEjercicios();
                CargarDias();

                if (cboDias.Items.Count > 0)
                    cboDias.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recargar datos: {ex.Message}", "Error");
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvEjercicios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona al menos un ejercicio para quitar.", "Aviso");
                return;
            }

            foreach (DataGridViewRow row in dgvEjercicios.SelectedRows)
            {
                dgvEjercicios.Rows.Remove(row);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboDias.SelectedValue == null) return;
            int idDia = Convert.ToInt32(cboDias.SelectedValue);

            using (var cn = new SqlConnection(Cn))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = cn;
                cn.Open();
                var tx = cn.BeginTransaction();
                cmd.Transaction = tx;

                try
                {
                    // Eliminar ejercicios existentes para este día
                    cmd.CommandText = "DELETE FROM Plan_Ejercicio WHERE id_plan = @p AND id_dia = @d";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@p", _idPlan);
                    cmd.Parameters.AddWithValue("@d", idDia);
                    cmd.ExecuteNonQuery();

                    // Insertar nuevos ejercicios con todos los parámetros
                    cmd.CommandText = @"
                        INSERT INTO Plan_Ejercicio 
                        (id_plan, id_dia, id_ejercicio, cant_series, repeticiones, tiempo) 
                        VALUES (@p, @d, @e, @series, @reps, @tiempo)";

                    foreach (DataRow r in _dtDiaEjercicios.Rows)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@p", _idPlan);
                        cmd.Parameters.AddWithValue("@d", idDia);
                        cmd.Parameters.AddWithValue("@e", r.Field<int>("id_ejercicio"));
                        cmd.Parameters.AddWithValue("@series", r.Field<int>("cant_series"));
                        cmd.Parameters.AddWithValue("@reps", r.Field<int>("repeticiones"));
                        cmd.Parameters.AddWithValue("@tiempo", r.Field<int>("tiempo"));
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                    MessageBox.Show("Cambios guardados correctamente.");
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEjercicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Método vacío pero necesario para el evento
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosEjercicio())
                return;

            if (!AgregarEjercicioATabla())
                return;

            LimpiarYCerrarPanel();
        }

        private bool ValidarDatosEjercicio()
        {
            // Validar que haya un día seleccionado
            if (cboDias.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un día del plan.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que haya un ejercicio seleccionado
            if (cboEjercicioCatalogo.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un ejercicio del catálogo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que al menos repeticiones o tiempo tengan valor
            if (string.IsNullOrWhiteSpace(txtTiempo.Text) && cantRepeticiones.Value <= 0)
            {
                MessageBox.Show("Debes ingresar repeticiones o tiempo para el ejercicio.", "Campos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar tiempo si se ingresó
            if (!string.IsNullOrWhiteSpace(txtTiempo.Text) &&
                (!int.TryParse(txtTiempo.Text, out int tiempo) || tiempo <= 0))
            {
                MessageBox.Show("El tiempo debe ser un número positivo.", "Error de validación");
                return false;
            }

            // Validar series
            if (cantSeries.Value <= 0)
            {
                MessageBox.Show("La cantidad de series debe ser mayor que 0.", "Error de validación");
                return false;
            }

            // Validar repeticiones si se ingresaron
            if (cantRepeticiones.Value < 0)
            {
                MessageBox.Show("Las repeticiones no pueden ser negativas.", "Error de validación");
                return false;
            }

            return true;
        }

        private bool AgregarEjercicioATabla()
        {
            try
            {
                int idEjercicio = Convert.ToInt32(cboEjercicioCatalogo.SelectedValue);
                string nombreEjercicio = cboEjercicioCatalogo.Text;
                int repeticiones = (int)cantRepeticiones.Value;
                int series = (int)cantSeries.Value;
                int tiempo = string.IsNullOrWhiteSpace(txtTiempo.Text) ? 0 : int.Parse(txtTiempo.Text);

                // Evitar duplicados
                bool yaExiste = _dtDiaEjercicios.AsEnumerable()
                    .Any(r => r.Field<int>("id_ejercicio") == idEjercicio);

                if (yaExiste)
                {
                    MessageBox.Show("Este ejercicio ya está agregado en este día.", "Duplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                // Crear la nueva fila
                DataRow nuevaFila = _dtDiaEjercicios.NewRow();
                nuevaFila["id_ejercicio"] = idEjercicio;
                nuevaFila["nombre"] = nombreEjercicio;
                nuevaFila["repeticiones"] = repeticiones;
                nuevaFila["tiempo"] = tiempo;
                nuevaFila["cant_series"] = series;

                _dtDiaEjercicios.Rows.Add(nuevaFila);

                // Refrescar la vista
                dgvEjercicios.DataSource = _dtDiaEjercicios;
                dgvEjercicios.Refresh();

                MessageBox.Show($"Ejercicio '{nombreEjercicio}' agregado.\n" +
                                $"Series: {series}, Reps: {repeticiones}, Tiempo: {tiempo}",
                                "Ejercicio agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar ejercicio: {ex.Message}", "Error");
                return false;
            }
        }

        private void LimpiarYCerrarPanel()
        {
            cantSeries.Value = 1;
            cantRepeticiones.Value = 0;
            txtTiempo.Clear();
            panel1.Visible = false;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}