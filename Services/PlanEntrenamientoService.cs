using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;


namespace Taller2_G34.Services
{

    public class PlanEntrenamientoService
    {
        private readonly string _connectionString;

        public PlanEntrenamientoService(string connectionString)
        {
            _connectionString = connectionString;
        }

        // --- MÉTODOS DE CONSULTA (DATA TABLE) ---

        public DataTable ObtenerTiposPlan()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT id_tipoPlan, descripcion FROM TipoPlan";
                var da = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ObtenerDiasPorPlan(int idPlan)
        {
            //Se usa el ID de Plan/Plantilla para traer los días asociados.
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT id_dia, nombreDia FROM Plan_Dia WHERE id_plan = @id_plan";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_plan", idPlan);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ObtenerEjerciciosCatalogo()
        {
            // Catálogo general de ejercicios para los Combobox.
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT id_ejercicio, nombre FROM Ejercicio";
                var da = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ObtenerEjerciciosPlanDia(int idPlan, int idDia)
        {
            // Trae los ejercicios específicos de un Plan/Plantilla para un dia concreto.
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"SELECT e.id_ejercicio, e.nombre AS Ejercicio, 
                               pe.cant_series AS Series, pe.repeticiones AS Repeticiones, 
                               pe.tiempo AS Tiempo
                               FROM Plan_Ejercicio pe 
                               INNER JOIN Ejercicio e ON pe.id_ejercicio = e.id_ejercicio
                               WHERE pe.id_plan = @idPlan AND pe.id_dia = @idDia";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPlan", idPlan);
                cmd.Parameters.AddWithValue("@idDia", idDia);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int? ObtenerIdPlanPorTipo(int idTipoPlan)
        {
            // Busca el ID del plan que sirve de plantilla para ese TipoPlan.
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                // Asume que el plan plantilla tiene estado = 1 o algún criterio de selección.
                string query = "SELECT TOP 1 id_plan FROM PlanEntrenamiento WHERE id_tipoPlan = @idTipoPlan AND estado = 1";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idTipoPlan", idTipoPlan);

                var result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value ? Convert.ToInt32(result) : (int?)null;
            }
        }

        // --- MÉTODOS TRANSACCIONALES (GUARDADO / ACTUALIZACIÓN) ---

        public DataTable ObtenerDatosPlanPorId(int idPlan)
        {
            // Este método es nuevo para FormEditarPlan, trae datos principales del plan.
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                SELECT 
                    p.id_plan, p.nombre, p.estado, p.id_tipoPlan,
                    tp.descripcion as TipoPlan
                FROM PlanEntrenamiento p
                LEFT JOIN TipoPlan tp ON p.id_tipoPlan = tp.id_tipoPlan
                WHERE p.id_plan = @idPlan";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idPlan", idPlan);
                    var dt = new DataTable();
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                    return dt;
                }
            }
        }

        public DataTable ObtenerDetallePlanCompleto(int idPlan)
        {
            //Trae todos los ejercicios de un plan para una edición inicial.
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                 SELECT 
                    pd.id_dia, pd.nombreDia, e.id_ejercicio, e.nombre as nombre_ejercicio,
                    pe.cant_series, pe.repeticiones, pe.tiempo
                 FROM Plan_Ejercicio pe
                 INNER JOIN Ejercicio e ON pe.id_ejercicio = e.id_ejercicio
                 INNER JOIN Plan_Dia pd ON pe.id_dia = pd.id_dia
                 WHERE pe.id_plan = @idPlan
                 ORDER BY pd.id_dia, e.nombre";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idPlan", idPlan);
                    var dt = new DataTable();
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                    return dt;
                }
            }
        }

        public int GuardarPlanCompleto(string nombrePlan, int idTipoPlan, List<EjercicioTemporal> ejerciciosNuevos, int? idPlanOriginal = null)
        {

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar el plan principal y obtener su nuevo ID
                        var queryPlan = @"INSERT INTO PlanEntrenamiento (nombre, estado, id_tipoPlan) 
                                        VALUES (@nombre, 1, @idTipoPlan);
                                        SELECT SCOPE_IDENTITY();";

                        var cmdPlan = new SqlCommand(queryPlan, conn, transaction);
                        cmdPlan.Parameters.AddWithValue("@nombre", nombrePlan);
                        cmdPlan.Parameters.AddWithValue("@idTipoPlan", idTipoPlan);

                        int idNuevoPlan = Convert.ToInt32(cmdPlan.ExecuteScalar());

                        // 2. COPIAR EJERCICIOS DEL PLAN ORIGINAL (la plantilla)
                        if (idPlanOriginal.HasValue)
                        {
                            // Copiar Plan_Dia y Plan_Ejercicio del plan original al nuevo.
                            var queryCopiarEjercicios = @"
                            -- Copiar días del plan original
                            INSERT INTO Plan_Dia (id_plan, nombreDia, descripcion)
                            SELECT @idNuevoPlan, nombreDia, descripcion 
                            FROM Plan_Dia 
                            WHERE id_plan = @idPlanOriginal;
                            
                            -- Copiar ejercicios del plan original, mapeando días viejos a días nuevos
                            INSERT INTO Plan_Ejercicio (id_plan, id_ejercicio, id_dia, cant_series, repeticiones, tiempo)
                            SELECT @idNuevoPlan, pe.id_ejercicio, pd_new.id_dia, pe.cant_series, pe.repeticiones, pe.tiempo
                            FROM Plan_Ejercicio pe
                            INNER JOIN Plan_Dia pd_old ON pe.id_dia = pd_old.id_dia AND pe.id_plan = pd_old.id_plan
                            INNER JOIN Plan_Dia pd_new ON pd_old.nombreDia = pd_new.nombreDia AND pd_new.id_plan = @idNuevoPlan
                            WHERE pe.id_plan = @idPlanOriginal;";

                            var cmdCopiar = new SqlCommand(queryCopiarEjercicios, conn, transaction);
                            cmdCopiar.Parameters.AddWithValue("@idNuevoPlan", idNuevoPlan);
                            cmdCopiar.Parameters.AddWithValue("@idPlanOriginal", idPlanOriginal.Value);
                            cmdCopiar.ExecuteNonQuery();
                        }

                        // 3. AGREGAR NUEVOS EJERCICIOS TEMPORALES (añadidos por el usuario)
                        if (ejerciciosNuevos != null && ejerciciosNuevos.Any())
                        {
                            // A) Obtener todos los días del NUEVO plan (plantilla copiada + días nuevos si aplica)
                            var cmdGetDias = new SqlCommand("SELECT id_dia, nombreDia FROM Plan_Dia WHERE id_plan = @idPlan", conn, transaction);
                            cmdGetDias.Parameters.AddWithValue("@idPlan", idNuevoPlan);
                            var da = new SqlDataAdapter(cmdGetDias);
                            var dtDias = new DataTable();
                            da.Fill(dtDias);

                            // B) Identificar los días nuevos de la lista que faltan en la DB
                            var diasExistentes = dtDias.AsEnumerable().Select(r => r.Field<string>("nombreDia")).ToHashSet();
                            var diasFaltantes = ejerciciosNuevos
                                .Select(e => e.NombreDia)
                                .Distinct()
                                .Where(nombreDia => !diasExistentes.Contains(nombreDia))
                                .ToList();

                            // C) Crear días que no existan aún en el nuevo plan
                            foreach (var nombreDia in diasFaltantes)
                            {
                                var queryCrearDia = @"INSERT INTO Plan_Dia (id_plan, nombreDia) 
                                                      VALUES (@idPlan, @nombreDia)";
                                var cmdCrearDia = new SqlCommand(queryCrearDia, conn, transaction);
                                cmdCrearDia.Parameters.AddWithValue("@idPlan", idNuevoPlan);
                                cmdCrearDia.Parameters.AddWithValue("@nombreDia", nombreDia);
                                cmdCrearDia.ExecuteNonQuery();

                                // Volver a cargar los días para obtener el nuevo ID
                                // Simplificamos recargando la tabla para obtener el nuevo ID.
                                dtDias.Clear();
                                da.Fill(dtDias);
                            }

                            // D) Insertar nuevos ejercicios
                            foreach (var ejercicio in ejerciciosNuevos)
                            {
                                var idDiaCorrespondiente = dtDias.AsEnumerable()
                                    .Where(row => row.Field<string>("nombreDia") == ejercicio.NombreDia)
                                    .Select(row => row.Field<int>("id_dia"))
                                    .FirstOrDefault();

                                // Solo inserta si el día existe (o se acaba de crear)
                                if (idDiaCorrespondiente > 0)
                                {
                                    var queryEjercicio = @"INSERT INTO Plan_Ejercicio 
                                                         (id_plan, id_ejercicio, id_dia, cant_series, repeticiones, tiempo) 
                                                         VALUES (@idPlan, @idEjercicio, @idDia, @series, @repeticiones, @tiempo)";

                                    var cmdEjercicio = new SqlCommand(queryEjercicio, conn, transaction);
                                    cmdEjercicio.Parameters.AddWithValue("@idPlan", idNuevoPlan);
                                    cmdEjercicio.Parameters.AddWithValue("@idEjercicio", ejercicio.IdEjercicio);
                                    cmdEjercicio.Parameters.AddWithValue("@idDia", idDiaCorrespondiente); // Usar el ID mapeado
                                    cmdEjercicio.Parameters.AddWithValue("@series", ejercicio.Series);
                                    cmdEjercicio.Parameters.AddWithValue("@repeticiones", ejercicio.Repeticiones);
                                    cmdEjercicio.Parameters.AddWithValue("@tiempo", ejercicio.Tiempo);
                                    cmdEjercicio.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        return idNuevoPlan;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error al guardar plan completo: {ex.Message}", ex);
                    }
                }
            }
        }

        public bool ActualizarPlan(int idPlan, string nombre, int? idTipoPlan, List<EjercicioTemporal> ejerciciosNuevos)
        {
            //Este método es para FormEditarPlan, solo actualiza datos básicos e inserta NUEVOS ejercicios.
            // La lógica de eliminación de ejercicios se maneja directamente en el FormEditarPlan.
            using (var connection = new SqlConnection(_connectionString))
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
                            cmd.Parameters.AddWithValue("@idPlan", idPlan);
                            cmd.Parameters.AddWithValue("@idTipoPlan", idTipoPlan ?? (object)DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Agregar nuevos ejercicios (el FormEditarPlan ya se encarga de verificar duplicados)
                        foreach (var ejercicio in ejerciciosNuevos)
                        {
                            string insertEjercicio = @"
                            INSERT INTO Plan_Ejercicio (id_plan, id_ejercicio, id_dia, cant_series, repeticiones, tiempo)
                            VALUES (@idPlan, @idEjercicio, @idDia, @series, @repeticiones, @tiempo)";

                            using (var cmd = new SqlCommand(insertEjercicio, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idPlan", idPlan);
                                cmd.Parameters.AddWithValue("@idEjercicio", ejercicio.IdEjercicio);
                                cmd.Parameters.AddWithValue("@idDia", ejercicio.IdDia);
                                cmd.Parameters.AddWithValue("@series", ejercicio.Series);
                                cmd.Parameters.AddWithValue("@repeticiones", ejercicio.Repeticiones);
                                cmd.Parameters.AddWithValue("@tiempo", ejercicio.Tiempo);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw; // Re-lanza la excepción para ser manejada en el formulario
                    }
                }
            }
        }
    }
}