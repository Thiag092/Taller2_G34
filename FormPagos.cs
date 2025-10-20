using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // para el pdf
using System.Diagnostics;



namespace Taller2_G34
{

    


    public partial class FormPagos : Form
    {

        private string nombreAlumno, membresia, plan;
        private string dni, telefono, correo, sexo, contactoEmergencia, observaciones;
        private DateTime fechaNac;
        private int idMembresia, idPlan, idCoach;

        private void lblCantidad_Click(object sender, EventArgs e)
        {

        }

        private void comboAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private readonly string Conexion = ConfigurationManager.ConnectionStrings["EnerGymDB"].ConnectionString;



        public FormPagos(
    string nombreCompleto, string dni, string telefono, string correo,
    DateTime fechaNac, string sexo,
    int idMembresia, string nombreMembresia,
    int idPlan, string nombrePlan,
    int idCoach, string contactoEmergencia, string observaciones)
        {
            InitializeComponent();
            this.nombreAlumno = nombreCompleto;
            this.membresia = nombreMembresia;
            this.plan = nombrePlan;

            this.dni = dni;
            this.telefono = telefono;
            this.correo = correo;
            this.fechaNac = fechaNac;
            this.sexo = sexo;
            this.idMembresia = idMembresia;
            this.idPlan = idPlan;
            this.idCoach = idCoach;
            this.contactoEmergencia = contactoEmergencia;
            this.observaciones = observaciones;

            this.Load += FormPagos_Load;
        }



        private void FormPagos_Load(object sender, EventArgs e)
        {
            CargarMediosDePago();

            // Mostrar datos del alumno recibido
            labelAlumno.Text = nombreAlumno;
            labelMembresia.Text = membresia;

            // 🔹 Obtener y mostrar el costo de la membresía
            decimal costoMembresia = ObtenerCostoMembresia(idMembresia);
            txtCantidad.Text = costoMembresia.ToString("0.00");

            // 🔹 Suscribir al evento de cambio del medio de pago
            comboMedioPago.SelectedIndexChanged += ComboMedioPago_SelectedIndexChanged;

            // 🔹 Calcular el total inicial (si ya hay medio seleccionado)
            CalcularTotalAutomatico();
        }



        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(Conexion))
            {
                cn.Open();
                SqlTransaction tran = cn.BeginTransaction();

                try
                {
                    // 1️⃣ Insertar el alumno y obtener su ID
                    SqlCommand cmdAlumno = new SqlCommand(@"
                INSERT INTO Alumno (
                    id_membresia, id_plan, id_coach, contacto_emergencia,
                    sexo, observaciones, estado, nombre, apellido, dni,
                    telefono, fecha_nacimiento, email
                )
                VALUES (
                    @idMembresia, @idPlan, @idCoach, @contactoEmergencia,
                    @sexo, @observaciones, 1, @nombre, @apellido, @dni,
                    @telefono, @fechaNac, @correo
                );
                SELECT SCOPE_IDENTITY();", cn, tran);

                    string[] partes = nombreAlumno.Split(' ');
                    string nombre = partes[0];
                    string apellido = partes.Length > 1 ? partes[1] : "";

                    cmdAlumno.Parameters.AddWithValue("@idMembresia", idMembresia);
                    cmdAlumno.Parameters.AddWithValue("@idPlan", idPlan);
                    cmdAlumno.Parameters.AddWithValue("@idCoach", idCoach);
                    cmdAlumno.Parameters.AddWithValue("@contactoEmergencia", contactoEmergencia);
                    cmdAlumno.Parameters.AddWithValue("@sexo", sexo);
                    cmdAlumno.Parameters.AddWithValue("@observaciones", observaciones);
                    cmdAlumno.Parameters.AddWithValue("@nombre", nombre);
                    cmdAlumno.Parameters.AddWithValue("@apellido", apellido);
                    cmdAlumno.Parameters.AddWithValue("@dni", dni);
                    cmdAlumno.Parameters.AddWithValue("@telefono", telefono);
                    cmdAlumno.Parameters.AddWithValue("@fechaNac", fechaNac);
                    cmdAlumno.Parameters.AddWithValue("@correo", correo);

                    int idAlumnoInsertado = Convert.ToInt32(cmdAlumno.ExecuteScalar());

                    // 2️⃣ Insertar el pago y obtener su ID
                    SqlCommand cmdPago = new SqlCommand(@"
                INSERT INTO Pago (id_alumno, id_medioPago, cantidad, recargo, total, fecha)
                VALUES (@idAlumno, @idMedioPago, @cantidad, @recargo, @total, GETDATE());
                SELECT SCOPE_IDENTITY();", cn, tran);

                    cmdPago.Parameters.AddWithValue("@idAlumno", idAlumnoInsertado);
                    cmdPago.Parameters.AddWithValue("@idMedioPago", Convert.ToInt32(comboMedioPago.SelectedValue));
                    cmdPago.Parameters.AddWithValue("@cantidad", decimal.Parse(txtCantidad.Text));
                    cmdPago.Parameters.AddWithValue("@recargo", decimal.Parse(txtRecargo.Text));
                    cmdPago.Parameters.AddWithValue("@total", decimal.Parse(txtTotal.Text));

                    int idPagoInsertado = Convert.ToInt32(cmdPago.ExecuteScalar());

                    // 3️⃣ Insertar el detalle del pago
                    SqlCommand cmdDetalle = new SqlCommand(@"
                INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
                VALUES (@idPago, @idMembresia, @periodo, @monto);", cn, tran);

                    cmdDetalle.Parameters.AddWithValue("@idPago", idPagoInsertado);
                    cmdDetalle.Parameters.AddWithValue("@idMembresia", idMembresia);
                    cmdDetalle.Parameters.AddWithValue("@periodo", ObtenerDuracionMembresia(idMembresia, cn, tran));
                    cmdDetalle.Parameters.AddWithValue("@monto", decimal.Parse(txtCantidad.Text));

                    cmdDetalle.ExecuteNonQuery();

                    // 4️⃣ Confirmar transacción
                    tran.Commit();

                    // 5️⃣ Generar y abrir el comprobante
                    GenerarComprobantePDF(nombreAlumno, membresia, plan,
                        decimal.Parse(txtCantidad.Text),
                        decimal.Parse(txtRecargo.Text),
                        decimal.Parse(txtTotal.Text),
                        comboMedioPago.Text);

                    MessageBox.Show("Pago con éxito. Generando comprobante, aguarde...");
                    this.Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error al registrar pago: " + ex.Message);
                }
            }
        }




        private void CargarMediosDePago()
        {
            using (SqlConnection cn = new SqlConnection(Conexion))
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT id_medioPago, nombre, comision FROM MedioDePago WHERE estado = 1", cn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboMedioPago.DataSource = dt;
                comboMedioPago.DisplayMember = "nombre";
                comboMedioPago.ValueMember = "id_medioPago";
            }
        }

        private void btnCalcularTotal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Debe ingresar un monto base antes de calcular.");
                return;
            }

            decimal montoBase = decimal.Parse(txtCantidad.Text);
            DataRowView medioPago = (DataRowView)comboMedioPago.SelectedItem;
            decimal recargo = Convert.ToDecimal(medioPago["comision"]);

            txtRecargo.Text = recargo.ToString("0.00") + " %";
            txtTotal.Text = (montoBase * (1 + recargo / 100)).ToString("0.00");
        }

       

private void GenerarComprobantePDF(string alumno, string membresia, string plan,
    decimal monto, decimal recargo, decimal total, string medioPago)
    {
        // 📁 Carpeta donde se guarda
        string carpeta = Path.Combine(Application.StartupPath, "Comprobantes");
        if (!Directory.Exists(carpeta))
            Directory.CreateDirectory(carpeta);

        // 📄 Nombre del archivo
        string nombreArchivo = $"Comprobante_{alumno.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
        string ruta = Path.Combine(carpeta, nombreArchivo);

        // 🧾 Crear el documento
        using (var doc = new iTextSharp.text.Document(PageSize.A4, 50, 50, 50, 50))
        {
            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            // Fuentes
            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
            var fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.DARK_GRAY);
            var fuenteTexto = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);

            // Encabezado centrado
            Paragraph titulo = new Paragraph("🏋️‍♂️ ENERGYM", fuenteTitulo)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 10f
            };
            doc.Add(titulo);

            Paragraph subtitulo = new Paragraph("Comprobante de Pago", fuenteSubtitulo)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            doc.Add(subtitulo);

            // Línea divisoria
            var linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -1)));
            doc.Add(linea);
            doc.Add(new Paragraph("\n"));

            // Fecha
            doc.Add(new Paragraph($"Fecha de emisión: {DateTime.Now:dd/MM/yyyy}", fuenteTexto));
            doc.Add(new Paragraph("\n"));

            // Tabla de información principal
            PdfPTable tabla = new PdfPTable(2)
            {
                WidthPercentage = 90,
                HorizontalAlignment = Element.ALIGN_CENTER
            };
            tabla.SpacingBefore = 10f;
            tabla.SpacingAfter = 20f;

            tabla.AddCell(new PdfPCell(new Phrase("Alumno:", fuenteSubtitulo)) { Border = 0 });
            tabla.AddCell(new PdfPCell(new Phrase(alumno, fuenteTexto)) { Border = 0 });

            tabla.AddCell(new PdfPCell(new Phrase("Membresía:", fuenteSubtitulo)) { Border = 0 });
            tabla.AddCell(new PdfPCell(new Phrase(membresia, fuenteTexto)) { Border = 0 });

            tabla.AddCell(new PdfPCell(new Phrase("Plan:", fuenteSubtitulo)) { Border = 0 });
            tabla.AddCell(new PdfPCell(new Phrase(plan, fuenteTexto)) { Border = 0 });

            tabla.AddCell(new PdfPCell(new Phrase("Medio de pago:", fuenteSubtitulo)) { Border = 0 });
            tabla.AddCell(new PdfPCell(new Phrase(medioPago, fuenteTexto)) { Border = 0 });

            tabla.AddCell(new PdfPCell(new Phrase("Monto base:", fuenteSubtitulo)) { Border = 0 });
            tabla.AddCell(new PdfPCell(new Phrase($"${monto:0.00}", fuenteTexto)) { Border = 0 });

            tabla.AddCell(new PdfPCell(new Phrase("Recargo aplicado:", fuenteSubtitulo)) { Border = 0 });
            tabla.AddCell(new PdfPCell(new Phrase($"${recargo:0.00}", fuenteTexto)) { Border = 0 });

            tabla.AddCell(new PdfPCell(new Phrase("TOTAL a pagar:", fuenteSubtitulo)) { Border = 0 });
            tabla.AddCell(new PdfPCell(new Phrase($"${total:0.00}", fuenteTexto)) { Border = 0 });

            doc.Add(tabla);

            // Línea divisoria inferior
            doc.Add(linea);

            // Mensaje final
            Paragraph agradecimiento = new Paragraph("¡Gracias por tu confianza en EnerGym!\n\nMantén este comprobante como constancia de pago.", fuenteTexto)
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(agradecimiento);

            doc.Close();
        }

        // 🔹 Abrir automáticamente el PDF generado
        System.Diagnostics.Process.Start("explorer.exe", ruta);
    }


    



        private decimal ObtenerCostoMembresia(int idMembresia)
        {
            decimal costo = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT costo FROM Membresia WHERE id_membresia = @id AND estado = 1", cn))
                {
                    cmd.Parameters.AddWithValue("@id", idMembresia);
                    cn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        costo = Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el costo de la membresía: " + ex.Message);
            }
            return costo;
        }


        private void ComboMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularTotalAutomatico();
        }

        private void CalcularTotalAutomatico()
        {
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
                return;

            decimal montoBase = decimal.Parse(txtCantidad.Text);
            DataRowView medioPago = comboMedioPago.SelectedItem as DataRowView;
            if (medioPago == null)
                return;

            decimal recargoPorcentaje = Convert.ToDecimal(medioPago["comision"]);
            decimal recargoMonto = montoBase * (recargoPorcentaje / 100);
            decimal total = montoBase + recargoMonto;

            txtRecargo.Text = recargoMonto.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");
        }

        private int ObtenerDuracionMembresia(int idMembresia, SqlConnection cn, SqlTransaction tran)
        {
            SqlCommand cmd = new SqlCommand("SELECT duracion FROM Membresia WHERE id_membresia = @id", cn, tran);
            cmd.Parameters.AddWithValue("@id", idMembresia);

            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }


    }



}
