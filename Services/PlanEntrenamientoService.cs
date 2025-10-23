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

        public int GuardarPlanCompleto(string nombrePlan, int idTipoPlan, List<EjercicioTemporal> ejercicios)
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

                        // 2. Agrupar ejercicios por día y crear días únicos
                        var diasUnicos = ejercicios.GroupBy(e => e.IdDia)
                                                  .Select(g => new { IdDia = g.Key, NombreDia = g.First().NombreDia })
                                                  .ToList();

                        // 3. Insertar días del plan
                        foreach (var dia in diasUnicos)
                        {
                            var queryDia = @"INSERT INTO Plan_Dia (id_plan, nombreDia) 
                                       VALUES (@idPlan, @nombreDia)";
                            var cmdDia = new SqlCommand(queryDia, conn, transaction);
                            cmdDia.Parameters.AddWithValue("@idPlan", idNuevoPlan);
                            cmdDia.Parameters.AddWithValue("@nombreDia", dia.NombreDia);
                            cmdDia.ExecuteNonQuery();
                        }

                        // 4. Obtener IDs de días recién creados
                        var cmdGetDias = new SqlCommand("SELECT id_dia, nombreDia FROM Plan_Dia WHERE id_plan = @idPlan", conn, transaction);
                        cmdGetDias.Parameters.AddWithValue("@idPlan", idNuevoPlan);
                        var da = new SqlDataAdapter(cmdGetDias);
                        var dtDias = new DataTable();
                        da.Fill(dtDias);

                        // 5. Insertar ejercicios para cada día
                        foreach (var ejercicio in ejercicios)
                        {
                            var idDiaCorrespondiente = dtDias.AsEnumerable()
                                .Where(row => row.Field<string>("nombreDia") == ejercicio.NombreDia)
                                .Select(row => row.Field<int>("id_dia"))
                                .FirstOrDefault();

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

                        transaction.Commit();
                        return idNuevoPlan;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
