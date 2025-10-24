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

        public int GuardarPlanCompleto(string nombrePlan, int idTipoPlan, List<EjercicioTemporal> ejerciciosNuevos, int? idPlanOriginal = null)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar el plan principal
                        var queryPlan = @"INSERT INTO PlanEntrenamiento (nombre, estado, id_tipoPlan) 
                                    VALUES (@nombre, 1, @idTipoPlan);
                                    SELECT SCOPE_IDENTITY();";

                        var cmdPlan = new SqlCommand(queryPlan, conn, transaction);
                        cmdPlan.Parameters.AddWithValue("@nombre", nombrePlan);
                        cmdPlan.Parameters.AddWithValue("@idTipoPlan", idTipoPlan);

                        int idNuevoPlan = Convert.ToInt32(cmdPlan.ExecuteScalar());

                        // 2. COPIAR EJERCICIOS DEL PLAN ORIGINAL (si se proporciona)
                        if (idPlanOriginal.HasValue)
                        {
                            var queryCopiarEjercicios = @"
                            -- Copiar días del plan original
                            INSERT INTO Plan_Dia (id_plan, nombreDia, descripcion)
                            SELECT @idNuevoPlan, nombreDia, descripcion 
                            FROM Plan_Dia 
                            WHERE id_plan = @idPlanOriginal;
                            
                            -- Copiar ejercicios del plan original
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

                        // 3. AGREGAR NUEVOS EJERCICIOS TEMPORALES (si hay)
                        if (ejerciciosNuevos != null && ejerciciosNuevos.Any())
                        {
                            // Para nuevos ejercicios, se crean días si aún no existen
                            var diasUnicos = ejerciciosNuevos.GroupBy(e => e.NombreDia)
                                                          .Select(g => g.First().NombreDia)
                                                          .ToList();

                            // Crear días que no existan
                            foreach (var nombreDia in diasUnicos)
                            {
                                var queryVerificarDia = "SELECT COUNT(*) FROM Plan_Dia WHERE id_plan = @idPlan AND nombreDia = @nombreDia";
                                var cmdVerificar = new SqlCommand(queryVerificarDia, conn, transaction);
                                cmdVerificar.Parameters.AddWithValue("@idPlan", idNuevoPlan);
                                cmdVerificar.Parameters.AddWithValue("@nombreDia", nombreDia);

                                int existeDia = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                                if (existeDia == 0)
                                {
                                    var queryCrearDia = @"INSERT INTO Plan_Dia (id_plan, nombreDia) 
                                                   VALUES (@idPlan, @nombreDia)";
                                    var cmdCrearDia = new SqlCommand(queryCrearDia, conn, transaction);
                                    cmdCrearDia.Parameters.AddWithValue("@idPlan", idNuevoPlan);
                                    cmdCrearDia.Parameters.AddWithValue("@nombreDia", nombreDia);
                                    cmdCrearDia.ExecuteNonQuery();
                                }
                            }

                            // Obtener IDs de días actualizados
                            var cmdGetDias = new SqlCommand("SELECT id_dia, nombreDia FROM Plan_Dia WHERE id_plan = @idPlan", conn, transaction);
                            cmdGetDias.Parameters.AddWithValue("@idPlan", idNuevoPlan);
                            var da = new SqlDataAdapter(cmdGetDias);
                            var dtDias = new DataTable();
                            da.Fill(dtDias);

                            // Insertar nuevos ejercicios
                            foreach (var ejercicio in ejerciciosNuevos)
                            {
                                var idDiaCorrespondiente = dtDias.AsEnumerable()
                                    .Where(row => row.Field<string>("nombreDia") == ejercicio.NombreDia)
                                    .Select(row => row.Field<int>("id_dia"))
                                    .FirstOrDefault();

                                if (idDiaCorrespondiente > 0)
                                {
                                    var queryEjercicio = @"INSERT INTO Plan_Ejercicio 
                                                    (id_plan, id_ejercicio, id_dia, cant_series, repeticiones, tiempo) 
                                                    VALUES (@idPlan, @idEjercicio, @idDia, @series, @repeticiones, @tiempo)";

                                    var cmdEjercicio = new SqlCommand(queryEjercicio, conn, transaction);
                                    cmdEjercicio.Parameters.AddWithValue("@idPlan", idNuevoPlan);
                                    cmdEjercicio.Parameters.AddWithValue("@idEjercicio", ejercicio.IdEjercicio);
                                    cmdEjercicio.Parameters.AddWithValue("@idDia", idDiaCorrespondiente);
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

        // Método adicional para obtener el ID del plan original basado en el tipo de plan
        public int? ObtenerIdPlanPorTipo(int idTipoPlan)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT TOP 1 id_plan FROM PlanEntrenamiento WHERE id_tipoPlan = @idTipoPlan AND estado = 1";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idTipoPlan", idTipoPlan);

                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : (int?)null;
            }
        }
    }
}
