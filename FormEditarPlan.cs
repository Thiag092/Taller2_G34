using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Taller2_G34
{
    public partial class FormEditarPlan : Form
    {
        private string Cn => ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;
        private int _idPlanSeleccionado;
        private List<EjercicioTemporal> _ejerciciosTemporales;
        private DataTable _ejerciciosOriginales;

        public FormEditarPlan(int idPlan)
        {
            InitializeComponent();
            _idPlanSeleccionado = idPlan;
            _ejerciciosTemporales = new List<EjercicioTemporal>();
            _ejerciciosOriginales = new DataTable();
        }

        private void FormEditarPlan_Load(object sender, EventArgs e)
        {
            InicializarDataGridView();
            CargarComboTipoPlan();
            CargarEjerciciosCatalogo();
            CargarDatosPlan();
        }

        private void InicializarDataGridView()
        {
            dgvEjercicios.AutoGenerateColumns = false;
            dgvEjercicios.Columns.Clear();

            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Dia",
                HeaderText = "Día",
                DataPropertyName = "NombreDia",
                ReadOnly = true,
                Width = 120
            });

            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Ejercicio",
                HeaderText = "Ejercicio",
                DataPropertyName = "NombreEjercicio",
                ReadOnly = true,
                Width = 200
            });

            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Series",
                HeaderText = "Series",
                DataPropertyName = "Series"
            });

            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Repeticiones",
                HeaderText = "Repeticiones",
                DataPropertyName = "Repeticiones"
            });

            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Tiempo",
                HeaderText = "Tiempo (seg)",
                DataPropertyName = "Tiempo"
            });

            dgvEjercicios.AllowUserToAddRows = false;
        }

        private void CargarComboTipoPlan()
        {
            try
            {
                using (var connection = new SqlConnection(Cn))
                {
                    connection.Open();
                    string query = "SELECT id_tipoPlan, descripcion FROM TipoPlan WHERE id_tipoPlan IS NOT NULL";

                    using (var command = new SqlCommand(query, connection))
                    {
                        var dt = new DataTable();
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                        comboBoxTipoPlan.DataSource = dt;
                        comboBoxTipoPlan.ValueMember = "id_tipoPlan";
                        comboBoxTipoPlan.DisplayMember = "descripcion";
                        comboBoxTipoPlan.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEjerciciosCatalogo()
        {
            try
            {
                using (var connection = new SqlConnection(Cn))
                {
                    connection.Open();
                    string query = "SELECT id_ejercicio, nombre FROM Ejercicio ORDER BY nombre";

                    using (var command = new SqlCommand(query, connection))
                    {
                        var dt = new DataTable();
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                        cboEjercicioCatalogo.DataSource = dt;
                        cboEjercicioCatalogo.ValueMember = "id_ejercicio";
                        cboEjercicioCatalogo.DisplayMember = "nombre";
                        cboEjercicioCatalogo.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar catálogo de ejercicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosPlan()
        {
            try
            {
                using (var connection = new SqlConnection(Cn))
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            p.id_plan,
                            p.nombre,
                            p.estado,
                            p.id_tipoPlan,
                            tp.descripcion as TipoPlan
                        FROM PlanEntrenamiento p
                        LEFT JOIN TipoPlan tp ON p.id_tipoPlan = tp.id_tipoPlan
                        WHERE p.id_plan = @idPlan";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idPlan", _idPlanSeleccionado);
                        var dt = new DataTable();
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            DataRow plan = dt.Rows[0];

                            txtNombrePlan.Text = plan["nombre"].ToString();

                            if (plan["id_tipoPlan"] != DBNull.Value)
                            {
                                comboBoxTipoPlan.SelectedValue = Convert.ToInt32(plan["id_tipoPlan"]);
                            }

                            labelTitulo.Text = $"Editando Plan: {plan["nombre"]}";

                            CargarComboDias();
                            CargarEjerciciosPlan();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el plan seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboDias()
        {
            try
            {
                cboDias.SelectedIndexChanged -= cboDias_SelectedIndexChanged;

                using (var connection = new SqlConnection(Cn))
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            id_dia,
                            nombreDia
                        FROM Plan_Dia
                        WHERE id_plan = @idPlan
                        ORDER BY id_dia";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idPlan", _idPlanSeleccionado);
                        var dt = new DataTable();
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                        cboDias.DataSource = dt;
                        cboDias.ValueMember = "id_dia";
                        cboDias.DisplayMember = "nombreDia";
                        cboDias.SelectedIndex = 0;
                    }
                }

                cboDias.SelectedIndexChanged += cboDias_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar días: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEjerciciosPlan()
        {
            try
            {
                using (var connection = new SqlConnection(Cn))
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            pd.id_dia,
                            pd.nombreDia,
                            e.id_ejercicio,
                            e.nombre as nombre_ejercicio,
                            pe.cant_series,
                            pe.repeticiones,
                            pe.tiempo
                        FROM Plan_Ejercicio pe
                        INNER JOIN Ejercicio e ON pe.id_ejercicio = e.id_ejercicio
                        INNER JOIN Plan_Dia pd ON pe.id_dia = pd.id_dia
                        WHERE pe.id_plan = @idPlan
                        ORDER BY pd.id_dia, e.nombre";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idPlan", _idPlanSeleccionado);
                        _ejerciciosOriginales = new DataTable();
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(_ejerciciosOriginales);
                        }

                        if (_ejerciciosOriginales.Rows.Count > 0)
                        {
                            lblEstadisticas.Text = $"Total de ejercicios: {_ejerciciosOriginales.Rows.Count}";
                        }
                        else
                        {
                            lblEstadisticas.Text = "No hay ejercicios en este plan";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ejercicios del plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDias.SelectedValue != null)
            {
                int idDia = Convert.ToInt32(cboDias.SelectedValue);
                FiltrarEjerciciosPorDia(idDia);
            }
        }

        private void FiltrarEjerciciosPorDia(int idDia)
        {
            try
            {
                var vistaFiltrada = new DataView(_ejerciciosOriginales);
                vistaFiltrada.RowFilter = $"id_dia = {idDia}";

                var ejerciciosCombinados = new List<object>();

                foreach (var ejercicio in _ejerciciosTemporales)
                {
                    if (ejercicio.IdDia == idDia)
                    {
                        ejerciciosCombinados.Add(new
                        {
                            ejercicio.NombreDia,
                            NombreEjercicio = ejercicio.Nombre,
                            ejercicio.Series,
                            ejercicio.Repeticiones,
                            ejercicio.Tiempo
                        });
                    }
                }

                foreach (DataRowView row in vistaFiltrada)
                {
                    ejerciciosCombinados.Add(new
                    {
                        NombreDia = row["nombreDia"].ToString(),
                        NombreEjercicio = row["nombre_ejercicio"].ToString(),
                        Series = Convert.ToInt32(row["cant_series"]),
                        Repeticiones = Convert.ToInt32(row["repeticiones"]),
                        Tiempo = Convert.ToInt32(row["tiempo"])
                    });
                }

                dgvEjercicios.DataSource = ejerciciosCombinados;
                lblEstadisticas.Text = $"Ejercicios del día: {ejerciciosCombinados.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar ejercicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cboEjercicioCatalogo.SelectedValue == null || cboDias.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un ejercicio y un día primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int idEjercicio = Convert.ToInt32(cboEjercicioCatalogo.SelectedValue);
                string nombreEjercicio = cboEjercicioCatalogo.Text;
                int idDia = Convert.ToInt32(cboDias.SelectedValue);
                string nombreDia = cboDias.Text;

                // **1. VALIDACIÓN DE DUPLICADOS**
                if (EsEjercicioDuplicado(idEjercicio, idDia))
                {
                    MessageBox.Show("Este ejercicio ya existe para el día seleccionado, ya sea en el plan original o añadido temporalmente.", "Ejercicio Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Obtención y validación de parámetros
                int series = cantSeries.Value == 0 ? 3 : (int)cantSeries.Value;
                int repeticiones = cantRepeticiones.Value == 0 ? 10 : (int)cantRepeticiones.Value;

                int tiempo = 0;
                if (!string.IsNullOrEmpty(txtTiempo.Text) && int.TryParse(txtTiempo.Text, out int t) && t >= 0)
                {
                    tiempo = t;
                }
                else if (string.IsNullOrEmpty(txtTiempo.Text))
                {
                    tiempo = 30; // Valor por defecto
                }
                else
                {
                    MessageBox.Show("El tiempo debe ser un número entero válido (segundos).", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Crear y agregar el ejercicio temporal
                var ejercicio = new EjercicioTemporal
                {
                    IdEjercicio = idEjercicio,
                    Nombre = nombreEjercicio,
                    IdDia = idDia,
                    NombreDia = nombreDia,
                    Series = series,
                    Repeticiones = repeticiones,
                    Tiempo = tiempo
                };

                _ejerciciosTemporales.Add(ejercicio);

                // 4. Refrescar la vista filtrada
                if (cboDias.SelectedValue != null)
                {
                    int currentIdDia = Convert.ToInt32(cboDias.SelectedValue);
                    FiltrarEjerciciosPorDia(currentIdDia);
                }

                // 5. Limpieza de UI
                cboEjercicioCatalogo.SelectedIndex = -1;
                cantSeries.Value = 0;
                cantRepeticiones.Value = 0;
                txtTiempo.Text = "";
                panel1.Visible = false;

                MessageBox.Show("Ejercicio agregado al plan", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar ejercicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool EsEjercicioDuplicado(int idEjercicio, int idDia)
        {
            // 1. Verificar en la lista temporal (ejercicios nuevos no guardados)
            if (_ejerciciosTemporales.Any(et => et.IdEjercicio == idEjercicio && et.IdDia == idDia))
            {
                return true;
            }

            // 2. Verificar en la lista original (ejercicios ya existentes en la DB)
            if (_ejerciciosOriginales != null && _ejerciciosOriginales.Columns.Contains("id_ejercicio") && _ejerciciosOriginales.Columns.Contains("id_dia"))
            {
                string filter = $"id_ejercicio = {idEjercicio} AND id_dia = {idDia}";
                if (_ejerciciosOriginales.Select(filter).Length > 0)
                {
                    return true;
                }
            }

            return false;
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvEjercicios.CurrentRow != null && dgvEjercicios.CurrentRow.DataBoundItem != null)
            {
                try
                {
                    var selectedRow = dgvEjercicios.CurrentRow;
                    string nombreEjercicio = selectedRow.Cells["Ejercicio"].Value.ToString();
                    string dia = selectedRow.Cells["Dia"].Value.ToString();

                    DialogResult result = MessageBox.Show(
                        $"¿Está seguro que desea eliminar el ejercicio '{nombreEjercicio}' del día '{dia}'?",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        int idDia = 0;
                        foreach (DataRowView item in cboDias.Items)
                        {
                            if (item["nombreDia"].ToString() == dia)
                            {
                                idDia = Convert.ToInt32(item["id_dia"]);
                                break;
                            }
                        }

                        int idEjercicio = 0;
                        foreach (DataRowView item in cboEjercicioCatalogo.Items)
                        {
                            if (item["nombre"].ToString() == nombreEjercicio)
                            {
                                idEjercicio = Convert.ToInt32(item["id_ejercicio"]);
                                break;
                            }
                        }

                        if (idDia > 0 && idEjercicio > 0)
                        {
                            bool eliminado = EliminarEjercicioPlan(idEjercicio, idDia);

                            if (eliminado)
                            {
                                MessageBox.Show("Ejercicio eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarEjerciciosPlan();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el ejercicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar ejercicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un ejercicio para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool EliminarEjercicioPlan(int idEjercicio, int idDia)
        {
            try
            {
                using (var connection = new SqlConnection(Cn))
                {
                    connection.Open();
                    string query = @"
                        DELETE FROM Plan_Ejercicio 
                        WHERE id_plan = @idPlan AND id_ejercicio = @idEjercicio AND id_dia = @idDia";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idPlan", _idPlanSeleccionado);
                        command.Parameters.AddWithValue("@idEjercicio", idEjercicio);
                        command.Parameters.AddWithValue("@idDia", idDia);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar ejercicio: {ex.Message}", ex);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombrePlan.Text))
            {
                MessageBox.Show("Ingrese un nombre para el plan.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombrePlan = txtNombrePlan.Text;
                int? idTipoPlan = comboBoxTipoPlan.SelectedValue != null ?
                    Convert.ToInt32(comboBoxTipoPlan.SelectedValue) : (int?)null;

                bool resultado = ActualizarPlan(nombrePlan, idTipoPlan);

                if (resultado)
                {
                    MessageBox.Show("Plan actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el plan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ActualizarPlan(string nombre, int? idTipoPlan)
        {
            using (var connection = new SqlConnection(Cn))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Actualizar datos básicos del plan
                        string updatePlan = @"
                    UPDATE PlanEntrenamiento 
                    SET nombre = @nombre, id_tipoPlan = @idTipoPlan 
                    WHERE id_plan = @idPlan";

                        using (var cmd = new SqlCommand(updatePlan, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@idPlan", _idPlanSeleccionado);
                            cmd.Parameters.AddWithValue("@idTipoPlan", idTipoPlan ?? (object)DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Agregar nuevos ejercicios temporales (solo si no existen)
                        foreach (var ejercicio in _ejerciciosTemporales)
                        {
                            // Verificar si el ejercicio ya existe en Plan_Ejercicio
                            string checkQuery = @"
                        SELECT COUNT(*) FROM Plan_Ejercicio 
                        WHERE id_plan = @idPlan AND id_ejercicio = @idEjercicio AND id_dia = @idDia";

                            using (var checkCmd = new SqlCommand(checkQuery, connection, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@idPlan", _idPlanSeleccionado);
                                checkCmd.Parameters.AddWithValue("@idEjercicio", ejercicio.IdEjercicio);
                                checkCmd.Parameters.AddWithValue("@idDia", ejercicio.IdDia);

                                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                                if (exists == 0)
                                {
                                    // Insertar solo si no existe
                                    string insertEjercicio = @"
                                INSERT INTO Plan_Ejercicio (id_plan, id_ejercicio, id_dia, cant_series, repeticiones, tiempo)
                                VALUES (@idPlan, @idEjercicio, @idDia, @series, @repeticiones, @tiempo)";

                                    using (var insertCmd = new SqlCommand(insertEjercicio, connection, transaction))
                                    {
                                        insertCmd.Parameters.AddWithValue("@idPlan", _idPlanSeleccionado);
                                        insertCmd.Parameters.AddWithValue("@idEjercicio", ejercicio.IdEjercicio);
                                        insertCmd.Parameters.AddWithValue("@idDia", ejercicio.IdDia);
                                        insertCmd.Parameters.AddWithValue("@series", ejercicio.Series);
                                        insertCmd.Parameters.AddWithValue("@repeticiones", ejercicio.Repeticiones);
                                        insertCmd.Parameters.AddWithValue("@tiempo", ejercicio.Tiempo);
                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        // 3. Limpiar la lista temporal después de un guardado exitoso
                        _ejerciciosTemporales.Clear();

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error al actualizar el plan: {ex.Message}", ex);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnNuevoEjercicio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad para agregar nuevo ejercicio al catálogo en desarrollo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}