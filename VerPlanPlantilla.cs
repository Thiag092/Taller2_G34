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

        public enum ModoPlan { Nuevo, DesdePlantilla, Editar }

        private string Cn => ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;

        // === Constructores ===
        public VerPlanPlantilla() { InitializeComponent(); _modo = ModoPlan.Nuevo; }
        public VerPlanPlantilla(int idPlan) { InitializeComponent(); _modo = ModoPlan.DesdePlantilla; _idPlan = idPlan; }
        public VerPlanPlantilla(int idPlan, bool editar) { InitializeComponent(); _modo = ModoPlan.Editar; _idPlan = idPlan; }


        //metodo auxiliar para ejecutar consultas y devolver un datatable
        private DataTable EjecutarConsulta(string sql, params (string, object)[] parametros)
        {
            // Solo para SELECT
            DataTable dt = new DataTable();
            using (var cn = new SqlConnection(Cn))
            using (var cmd = new SqlCommand(sql, cn))
            {
                foreach (var p in parametros)
                    cmd.Parameters.AddWithValue(p.Item1, p.Item2);
                using (var da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
            }
            return dt;
        }

        // === Load ===
        private void VerPlanPlantilla_Load(object sender, EventArgs e)
        {
            dgvEjercicios.AutoGenerateColumns = false;
            dgvEjercicios.MultiSelect = true;
            dgvEjercicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CargarTiposPlan();
            CargarCatalogoEjercicios();

            switch (_modo)
            {
                case ModoPlan.Nuevo: PrepararNuevoPlan(); break;
                case ModoPlan.DesdePlantilla: CargarPlanDesdePlantilla(); break;
                case ModoPlan.Editar: CargarPlanSeleccionado(); break;
            }
        }

        // === Carga tipos y catálogo ===
        private void CargarTiposPlan()
        {
            string sql = "SELECT id_tipoPlan, descripcion FROM TipoPlan ORDER BY descripcion";
            DataTable dt = EjecutarConsulta(sql);
            comboBoxTipoPlan.DisplayMember = "descripcion";
            comboBoxTipoPlan.ValueMember = "id_tipoPlan";
            comboBoxTipoPlan.DataSource = dt;
            comboBoxTipoPlan.SelectedIndex = -1;
            comboBoxTipoPlan.SelectedIndexChanged += ComboBoxTipoPlan_SelectedIndexChanged;
        }

        private void CargarCatalogoEjercicios()
        {
            string sql = "SELECT id_ejercicio, nombre FROM Ejercicio ORDER BY nombre";
            DataTable dt = EjecutarConsulta(sql);
            cboEjercicioCatalogo.DisplayMember = "nombre";
            cboEjercicioCatalogo.ValueMember = "id_ejercicio";
            cboEjercicioCatalogo.DataSource = dt;
        }

        // === Manejo de días y ejercicios ===
        private void CargarDias(int idPlan)
        {
            string sql = "SELECT id_dia, nombreDia FROM Plan_Dia WHERE id_plan=@idPlan ORDER BY id_dia";
            DataTable dt = EjecutarConsulta(sql, ("@idPlan", idPlan));
            cboDias.DisplayMember = "nombreDia";
            cboDias.ValueMember = "id_dia";
            cboDias.DataSource = dt;
            if (dt.Rows.Count > 0) cboDias.SelectedIndex = 0;
        }

        private void CargarEjerciciosDelPlan(int idPlan, int? idDia = null)
        {
            if (idDia == null && cboDias.SelectedValue != null)
                idDia = Convert.ToInt32(cboDias.SelectedValue);
            if (idDia == null) return;

            string sql = @"
                SELECT e.id_ejercicio, e.nombre, pe.cant_series, pe.repeticiones, pe.tiempo
                FROM Plan_Ejercicio pe
                INNER JOIN Ejercicio e ON pe.id_ejercicio = e.id_ejercicio
                WHERE pe.id_plan=@idPlan AND pe.id_dia=@idDia ORDER BY e.nombre";

            _dtDiaEjercicios = EjecutarConsulta(sql, ("@idPlan", idPlan), ("@idDia", idDia.Value));
            dgvEjercicios.DataSource = _dtDiaEjercicios;
        }

        // === Eventos ===
        private void cboDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_idPlan > 0) CargarEjerciciosDelPlan(_idPlan);
        }

        private void ComboBoxTipoPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoPlan.SelectedValue == null) return;
            int tipoPlanId = Convert.ToInt32(comboBoxTipoPlan.SelectedValue);
            CargarPlanPorTipo(tipoPlanId);
        }

        // === Métodos reutilizables ===
        private void PrepararNuevoPlan()
        {
            txtNombrePlan.Clear();
            comboBoxTipoPlan.SelectedIndex = -1;
            cboDias.DataSource = null;
            _dtDiaEjercicios = new DataTable();
            dgvEjercicios.DataSource = _dtDiaEjercicios;
        }

        private void CargarPlanDesdePlantilla()
        {
            CargarInfoPlan();
            CargarDias(_idPlan);
            _dtDiaEjercicios = new DataTable();
            dgvEjercicios.DataSource = _dtDiaEjercicios;
        }

        private void CargarPlanSeleccionado()
        {
            if (_idPlan <= 0) return;
            CargarInfoPlan();
            CargarDias(_idPlan);
            CargarEjerciciosDelPlan(_idPlan);
        }

        private void CargarInfoPlan()
        {
            string sql = "SELECT nombre, id_tipoPlan FROM PlanEntrenamiento WHERE id_plan=@idPlan";
            DataTable dt = EjecutarConsulta(sql, ("@idPlan", _idPlan));
            if (dt.Rows.Count > 0)
            {
                txtNombrePlan.Text = dt.Rows[0]["nombre"].ToString();
                comboBoxTipoPlan.SelectedValue = Convert.ToInt32(dt.Rows[0]["id_tipoPlan"]);
            }
        }

        private void CargarPlanPorTipo(int idTipoPlan)
        {
            // Tomar la primera plantilla del tipo seleccionado
            string sql = "SELECT TOP 1 id_plan, nombre FROM PlanEntrenamiento WHERE id_tipoPlan=@tipo ORDER BY id_plan";
            DataTable dt = EjecutarConsulta(sql, ("@tipo", idTipoPlan));
            if (dt.Rows.Count == 0) { cboDias.DataSource = null; _dtDiaEjercicios = new DataTable(); dgvEjercicios.DataSource = _dtDiaEjercicios; return; }

            _idPlan = Convert.ToInt32(dt.Rows[0]["id_plan"]);
            txtNombrePlan.Text = dt.Rows[0]["nombre"].ToString();

            CargarDias(_idPlan);
            CargarEjerciciosDelPlan(_idPlan);
        }

        // === Guardar ===
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombrePlan.Text) || comboBoxTipoPlan.SelectedIndex < 0)
            {
                MessageBox.Show("Debes ingresar nombre y tipo de plan.", "Aviso");
                return;
            }

            switch (_modo)
            {
                case ModoPlan.Nuevo: GuardarNuevoPlan(); break;
                case ModoPlan.DesdePlantilla: GuardarNuevoPlanDesdePlantilla(); break;
                case ModoPlan.Editar: GuardarCambiosPlanExistente(); break;
            }
        }
        private void GuardarNuevoPlan()
        {
            int nuevoId;
            using (var cn = new SqlConnection(Cn))
            using (var cmd = new SqlCommand(
                "INSERT INTO PlanEntrenamiento (nombre, estado, id_tipoPlan) OUTPUT INSERTED.id_plan VALUES (@n, @estado, @t)",
                cn))
            {
                cmd.Parameters.AddWithValue("@n", txtNombrePlan.Text);
                cmd.Parameters.AddWithValue("@estado", true);
                cmd.Parameters.AddWithValue("@t", comboBoxTipoPlan.SelectedValue);
                cn.Open();
                nuevoId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            MessageBox.Show($"Plan creado correctamente (ID: {nuevoId})", "Éxito");
            this.Close();
        }


        private void GuardarNuevoPlanDesdePlantilla()
        {
            try
            {
                using (var cn = new SqlConnection(Cn))
                {
                    cn.Open();
                    using (var tx = cn.BeginTransaction())
                    {
                        int tipoPlan = Convert.ToInt32(comboBoxTipoPlan.SelectedValue);

                        // Insertar plan
                        int nuevoId;
                        using (var cmd = new SqlCommand(
                            "INSERT INTO PlanEntrenamiento (nombre, estado, id_tipoPlan) OUTPUT INSERTED.id_plan VALUES (@nombre,@estado,@tipoPlan)",
                            cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@nombre", txtNombrePlan.Text);
                            cmd.Parameters.AddWithValue("@estado", true);
                            cmd.Parameters.AddWithValue("@tipoPlan", tipoPlan);
                            nuevoId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Copiar días
                        using (var cmd = new SqlCommand(
                            @"INSERT INTO Plan_Dia (id_plan, nombreDia)
                      SELECT @nuevoId, nombreDia FROM Plan_Dia WHERE id_plan=@plantilla",
                            cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@nuevoId", nuevoId);
                            cmd.Parameters.AddWithValue("@plantilla", _idPlan);
                            cmd.ExecuteNonQuery();
                        }

                        // Copiar ejercicios
                        using (var cmd = new SqlCommand(
                            @"INSERT INTO Plan_Ejercicio (id_plan, id_dia, id_ejercicio, cant_series, repeticiones, tiempo)
                          SELECT @nuevoId, d2.id_dia, pe.id_ejercicio, pe.cant_series, pe.repeticiones, pe.tiempo
                          FROM Plan_Ejercicio pe
                          INNER JOIN Plan_Dia d1 ON d1.id_dia = pe.id_dia
                          INNER JOIN Plan_Dia d2 ON d2.nombreDia = d1.nombreDia AND d2.id_plan=@nuevoId
                          WHERE pe.id_plan=@plantilla",
                            cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@nuevoId", nuevoId);
                            cmd.Parameters.AddWithValue("@plantilla", _idPlan);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                        MessageBox.Show($"Nuevo plan creado en base a la plantilla (ID: {nuevoId})", "Éxito");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear plan: {ex.Message}", "Error");
            }
        }
        private void GuardarCambiosPlanExistente()
        {
            using (var cn = new SqlConnection(Cn))
            using (var cmd = new SqlCommand(
                "UPDATE PlanEntrenamiento SET nombre=@n, id_tipoPlan=@t WHERE id_plan=@id",
                cn))
            {
                cmd.Parameters.AddWithValue("@n", txtNombrePlan.Text);
                cmd.Parameters.AddWithValue("@t", comboBoxTipoPlan.SelectedValue);
                cmd.Parameters.AddWithValue("@id", _idPlan);
                cn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cambios guardados correctamente.", "Éxito");
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
               panel1.Visible = true;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnNuevoEjercicio_Click(object sender, EventArgs e)
        {
            if (cboDias.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un día primero.", "Aviso");
                return;
            }

            int idDia = Convert.ToInt32(cboDias.SelectedValue);
            int idEjercicio = Convert.ToInt32(cboEjercicioCatalogo.SelectedValue);

            // Verificar si ya está agregado en la tabla temporal
            if (_dtDiaEjercicios != null && _dtDiaEjercicios.AsEnumerable().Any(r => r.Field<int>("id_ejercicio") == idEjercicio))
            {
                MessageBox.Show("Este ejercicio ya está agregado.", "Duplicado");
                return;
            }

            // Crear nueva fila en la DataTable temporal
            if (_dtDiaEjercicios == null)
                _dtDiaEjercicios = new DataTable();

            if (!_dtDiaEjercicios.Columns.Contains("id_ejercicio"))
            {
                _dtDiaEjercicios.Columns.Add("id_ejercicio", typeof(int));
                _dtDiaEjercicios.Columns.Add("nombre", typeof(string));
                _dtDiaEjercicios.Columns.Add("repeticiones", typeof(int));
                _dtDiaEjercicios.Columns.Add("tiempo", typeof(int));
                _dtDiaEjercicios.Columns.Add("cant_series", typeof(int));
            }

            DataRow fila = _dtDiaEjercicios.NewRow();
            fila["id_ejercicio"] = idEjercicio;
            fila["nombre"] = cboEjercicioCatalogo.Text;
            fila["repeticiones"] = (int)cantRepeticiones.Value;
            fila["tiempo"] = string.IsNullOrWhiteSpace(txtTiempo.Text) ? 0 : int.Parse(txtTiempo.Text);
            fila["cant_series"] = (int)cantSeries.Value;

            _dtDiaEjercicios.Rows.Add(fila);
            dgvEjercicios.DataSource = _dtDiaEjercicios;

            this.Close();
        }
    }
}
