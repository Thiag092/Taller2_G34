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
        private readonly ModoPlan _modo;
        private int _idPlan;
        private DataTable _dtDiaEjercicios;

        // Enum para identificar el modo actual del formulario
        public enum ModoPlan
        {
            Nuevo,
            DesdePlantilla,
            Editar
        }

        private string Cn => ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

        // === Constructores ===

        // Crear un plan desde cero
        public VerPlanPlantilla()
        {
            InitializeComponent();
            _modo = ModoPlan.Nuevo;
        }

        // Crear un plan nuevo basado en otro existente (plantilla)
        public VerPlanPlantilla(int idPlan)
        {
            InitializeComponent();
            _modo = ModoPlan.DesdePlantilla;
            _idPlan = idPlan;
        }

        // Editar un plan existente
        public VerPlanPlantilla(int idPlan, bool editar)
        {
            InitializeComponent();
            _modo = ModoPlan.Editar;
            _idPlan = idPlan;
        }

        private void VerPlanPlantilla_Load(object sender, EventArgs e)
        {
            dgvEjercicios.AutoGenerateColumns = false;
            dgvEjercicios.MultiSelect = true;
            dgvEjercicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CargarTiposPlan();
            CargarCatalogoEjercicios();

            switch (_modo)
            {
                case ModoPlan.Nuevo:
                    PrepararNuevoPlan();
                    break;

                case ModoPlan.DesdePlantilla:
                    CargarInfoPlan();
                    CargarDias();
                    ClonarDatosPlantilla();
                    break;

                case ModoPlan.Editar:
                    CargarInfoPlan();
                    CargarDias();
                    break;
            }

            cboDias.SelectedIndexChanged += cboDias_SelectedIndexChanged;
            if (cboDias.Items.Count > 0)
                cboDias.SelectedIndex = 0;
        }

        private void CargarInfoPlan()
        {
            string sql = @"
        SELECT p.nombre, p.id_tipoPlan, t.descripcion AS Tipo
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
                    {
                        txtNombrePlan.Text = r["nombre"].ToString();
                        comboBoxTipoPlan.SelectedValue = Convert.ToInt32(r["id_tipoPlan"]);
                        labelTitulo.Text = $"Tipo de plan: {r["Tipo"]}";
                    }
                }
            }
        }
        private void ClonarDatosPlantilla()
        {
            try
            {
                using (var cn = new SqlConnection(Cn))
                using (var cmd = new SqlCommand("SELECT nombre FROM PlanEntrenamiento WHERE id_plan = @id", cn))
                {
                    cmd.Parameters.AddWithValue("@id", _idPlan);
                    cn.Open();
                    var nombreBase = cmd.ExecuteScalar()?.ToString();
                    txtNombrePlan.Text = $"{nombreBase}";
                }

                _dtDiaEjercicios = new DataTable();
                dgvEjercicios.DataSource = _dtDiaEjercicios;

                MessageBox.Show("Plantilla cargada. Personaliza el nombre y los ejercicios antes de guardar.",
                    "Plantilla cargada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al clonar plantilla: {ex.Message}", "Error");
            }
        }
        private void PrepararNuevoPlan()
        {
            labelTitulo.Text = "Nuevo plan de entrenamiento";
            txtNombrePlan.Text = string.Empty;
            comboBoxTipoPlan.SelectedIndex = -1;
            cboDias.DataSource = null;
            _dtDiaEjercicios = new DataTable();
            dgvEjercicios.DataSource = _dtDiaEjercicios;
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
        private void CargarTiposPlan()
        {
            string sql = "SELECT id_tipoPlan, descripcion FROM TipoPlan ORDER BY descripcion";

            try
            {
                using (var cn = new SqlConnection(Cn))
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);

                    comboBoxTipoPlan.DisplayMember = "descripcion";
                    comboBoxTipoPlan.ValueMember = "id_tipoPlan";
                    comboBoxTipoPlan.DataSource = dt;
                    comboBoxTipoPlan.SelectedIndex = -1; // Ninguno seleccionado al inicio
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de plan: " + ex.Message, "Error");
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
            switch (_modo)
            {
                case ModoPlan.Nuevo:
                    GuardarNuevoPlan();
                    break;
                case ModoPlan.DesdePlantilla:
                    GuardarPlanDesdePlantilla();
                    break;
                case ModoPlan.Editar:
                    GuardarCambiosPlanExistente();
                    break;
            }
        }

        private void GuardarNuevoPlan()
        {
            if (string.IsNullOrWhiteSpace(txtNombrePlan.Text) || comboBoxTipoPlan.SelectedIndex < 0)
            {
                MessageBox.Show("Debes ingresar un nombre y tipo de plan.", "Campos incompletos");
                return;
            }

            string sqlInsert = "INSERT INTO PlanEntrenamiento (nombre, estado, id_tipoPlan) OUTPUT INSERTED.id_plan VALUES (@n, @estado, @t)";

            try
            {
                using (var cn = new SqlConnection(Cn))
                using (var cmd = new SqlCommand(sqlInsert, cn))
                {
                    cmd.Parameters.AddWithValue("@n", txtNombrePlan.Text);
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = true;
                    cmd.Parameters.AddWithValue("@t", comboBoxTipoPlan.SelectedValue);
                    cn.Open();
                    int nuevoId = (int)cmd.ExecuteScalar();

                    MessageBox.Show($"Plan '{txtNombrePlan.Text}' creado correctamente (ID: {nuevoId})",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear plan: {ex.Message}");
            }
        }
        private void GuardarPlanDesdePlantilla()
        {
            try
            {
                using (var cn = new SqlConnection(Cn))
                {
                    cn.Open();
                    using (var tx = cn.BeginTransaction())
                    {
                        //Obtiene id_tipoPlan de la plantilla
                        int tipoPlan;
                        using (var cmdTipo = new SqlCommand(
                            "SELECT id_tipoPlan FROM PlanEntrenamiento WHERE id_plan = @plantilla", cn, tx))
                        {
                            cmdTipo.Parameters.Add("@plantilla", SqlDbType.Int).Value = _idPlan;
                            var result = cmdTipo.ExecuteScalar();
                            if (result == null)
                                throw new Exception("La plantilla seleccionada no existe.");
                            tipoPlan = Convert.ToInt32(result);
                        }

                        //Inserta nuevo plan
                        int nuevoId;
                        using (var cmdInsert = new SqlCommand(@"
                        INSERT INTO PlanEntrenamiento (nombre, estado, id_tipoPlan)
                        OUTPUT INSERTED.id_plan
                        VALUES (@nombre, @estado, @tipoPlan)", cn, tx))
                        {
                            cmdInsert.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = txtNombrePlan.Text;
                            cmdInsert.Parameters.Add("@estado", SqlDbType.Bit).Value = true; 
                            cmdInsert.Parameters.Add("@tipoPlan", SqlDbType.Int).Value = tipoPlan;

                            nuevoId = (int)cmdInsert.ExecuteScalar();
                        }

                        //Copia días
                        using (var cmdDias = new SqlCommand(@"
                        INSERT INTO Plan_Dia (id_plan, nombreDia)
                        SELECT @nuevoId, nombreDia
                        FROM Plan_Dia
                        WHERE id_plan = @plantilla", cn, tx))
                        {
                            cmdDias.Parameters.Add("@nuevoId", SqlDbType.Int).Value = nuevoId;
                            cmdDias.Parameters.Add("@plantilla", SqlDbType.Int).Value = _idPlan;
                            cmdDias.ExecuteNonQuery();
                        }

                        //Copia ejercicios
                        using (var cmdEjs = new SqlCommand(@"
                        INSERT INTO Plan_Ejercicio (id_plan, id_dia, id_ejercicio, cant_series, repeticiones, tiempo)
                        SELECT @nuevoId, d2.id_dia, pe.id_ejercicio, pe.cant_series, pe.repeticiones, pe.tiempo
                        FROM Plan_Ejercicio pe
                        INNER JOIN Plan_Dia d1 ON d1.id_dia = pe.id_dia
                        INNER JOIN Plan_Dia d2 ON d2.nombreDia = d1.nombreDia AND d2.id_plan = @nuevoId
                        WHERE pe.id_plan = @plantilla", cn, tx))
                        {
                            cmdEjs.Parameters.Add("@nuevoId", SqlDbType.Int).Value = nuevoId;
                            cmdEjs.Parameters.Add("@plantilla", SqlDbType.Int).Value = _idPlan;
                            cmdEjs.ExecuteNonQuery();
                        }
                        tx.Commit();

                        MessageBox.Show($"Nuevo plan creado en base a la plantilla (ID: {nuevoId})", "Éxito");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear plan desde plantilla: " + ex.Message, "Error");
            }
        }

        private void GuardarCambiosPlanExistente()
        {
            string sqlNombre = "UPDATE PlanEntrenamiento SET nombre = @n, id_tipoPlan = @t WHERE id_plan = @id";

            using (var cn = new SqlConnection(Cn))
            using (var cmd = new SqlCommand(sqlNombre, cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@n", txtNombrePlan.Text);
                cmd.Parameters.AddWithValue("@t", comboBoxTipoPlan.SelectedValue);
                cmd.Parameters.AddWithValue("@id", _idPlan);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cambios guardados correctamente.", "Éxito");
            this.Close();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxTipoPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoPlan.SelectedValue == null) return;

            int idTipoPlan = Convert.ToInt32(comboBoxTipoPlan.SelectedValue);
            CargarPlantillaPorTipo(idTipoPlan);
        }
        private void CargarPlantillaPorTipo(int idTipoPlan)
        {
            try
            {
                // Trae la plantilla predeterminada de ese tipo
                string sqlPlan = @"
                SELECT TOP 1 id_plan, nombre
                FROM PlanEntrenamiento
                WHERE id_tipoPlan = @idTipo
                ORDER BY id_plan";

                int idPlanPlantilla = 0;
                string nombrePlantilla = "";

                using (var cn = new SqlConnection(Cn))
                using (var cmd = new SqlCommand(sqlPlan, cn))
                {
                    cmd.Parameters.AddWithValue("@idTipo", idTipoPlan);
                    cn.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            idPlanPlantilla = Convert.ToInt32(r["id_plan"]);
                            nombrePlantilla = r["nombre"].ToString();
                        }
                    }
                }

                if (idPlanPlantilla == 0)
                {
                    MessageBox.Show("No hay plantillas predeterminadas para este tipo de plan.", "Aviso");
                    return;
                }

                //Cargar días y ejercicios del plan seleccionado
                _idPlan = idPlanPlantilla;
                CargarDias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la plantilla: {ex.Message}", "Error");
            }
        }
    }
}