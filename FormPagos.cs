using iTextSharp.text;
using iTextSharp.text.pdf;
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

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
                    //Insertar el alumno y obtener su ID
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

                    // Insertar el pago y obtener su ID
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

                    // Insertar el detalle del pago
                    SqlCommand cmdDetalle = new SqlCommand(@"
                INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
                VALUES (@idPago, @idMembresia, @periodo, @monto);", cn, tran);

                    cmdDetalle.Parameters.AddWithValue("@idPago", idPagoInsertado);
                    cmdDetalle.Parameters.AddWithValue("@idMembresia", idMembresia);
                    cmdDetalle.Parameters.AddWithValue("@periodo", ObtenerDuracionMembresia(idMembresia, cn, tran));
                    cmdDetalle.Parameters.AddWithValue("@monto", decimal.Parse(txtCantidad.Text));

                    cmdDetalle.ExecuteNonQuery();

                    //Confirmar transacción
                    tran.Commit();

                    //Generar y abrir el comprobante
                    GenerarComprobantePDF(nombreAlumno, membresia, plan,
                        decimal.Parse(txtCantidad.Text),
                        decimal.Parse(txtRecargo.Text),
                        decimal.Parse(txtTotal.Text),
                        comboMedioPago.Text);

                    MessageBox.Show("Pago con éxito. Generando comprobante, aguarde...");
                    this.DialogResult = DialogResult.OK;
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
            // 🧩 Carpeta Comprobantes en raíz del proyecto
            string carpetaProyecto = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\Comprobantes"));
            if (!Directory.Exists(carpetaProyecto))
                Directory.CreateDirectory(carpetaProyecto);

            // 🧮 Generar número de factura correlativo
            string contadorPath = Path.Combine(carpetaProyecto, "contador.txt");
            int numeroFactura = 1;
            if (File.Exists(contadorPath))
            {
                int.TryParse(File.ReadAllText(contadorPath), out numeroFactura);
                numeroFactura++;
            }
            File.WriteAllText(contadorPath, numeroFactura.ToString());

            string numeroFormateado = $"0001-{numeroFactura.ToString("D7")}";

            // 🧾 Nombre del archivo
            string nombreArchivo = $"Factura_{alumno.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
            string ruta = Path.Combine(carpetaProyecto, nombreArchivo);

            // 🎨 Crear el documento
            using (var doc = new Document(PageSize.A4, 50, 50, 40, 40))
            {
                PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();

                // Fuentes
                var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
                var fuenteTexto = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                var fuenteTablaHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
                var fuenteTablaTexto = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);

                // === Encabezado con logo ===
                string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo_taller2.png");
                if (File.Exists(logoPath))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.ScaleAbsolute(100, 100);
                    logo.Alignment = Element.ALIGN_LEFT;
                    doc.Add(logo);
                }

                Paragraph encabezado = new Paragraph("ENERGYM FITNESS CLUB", fuenteTitulo);
                encabezado.Alignment = Element.ALIGN_RIGHT;
                doc.Add(encabezado);
                doc.Add(new Paragraph("CUIT: 30-99999999-7", fuenteTexto) { Alignment = Element.ALIGN_RIGHT });
                doc.Add(new Paragraph("Av. Sarmiento 2345, Resistencia, Chaco", fuenteTexto) { Alignment = Element.ALIGN_RIGHT });
                doc.Add(new Paragraph("Tel: (362) 444-1234 | contacto@energygym.com", fuenteTexto) { Alignment = Element.ALIGN_RIGHT });
                doc.Add(new Paragraph("\n"));

                // Línea divisoria
                doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.GRAY, Element.ALIGN_CENTER, -1)));

                // Info de factura
                PdfPTable tablaFactura = new PdfPTable(2) { WidthPercentage = 100 };
                tablaFactura.SpacingBefore = 10;
                tablaFactura.AddCell(new PdfPCell(new Phrase($"Factura Nº {numeroFormateado}", fuenteTexto)) { Border = 0 });
                tablaFactura.AddCell(new PdfPCell(new Phrase($"Fecha de emisión: {DateTime.Now:dd/MM/yyyy}", fuenteTexto)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tablaFactura.AddCell(new PdfPCell(new Phrase("Tipo: B", fuenteTexto)) { Border = 0 });
                tablaFactura.AddCell(new PdfPCell(new Phrase("", fuenteTexto)) { Border = 0 });
                doc.Add(tablaFactura);
                doc.Add(new Paragraph("\n"));

                // === Datos del cliente ===
                PdfPTable tablaCliente = new PdfPTable(2) { WidthPercentage = 100 };
                tablaCliente.AddCell(new PdfPCell(new Phrase("Alumno:", fuenteTexto)) { Border = 0 });
                tablaCliente.AddCell(new PdfPCell(new Phrase(alumno, fuenteTexto)) { Border = 0 });
                tablaCliente.AddCell(new PdfPCell(new Phrase("DNI:", fuenteTexto)) { Border = 0 });
                tablaCliente.AddCell(new PdfPCell(new Phrase(dni, fuenteTexto)) { Border = 0 });
                tablaCliente.AddCell(new PdfPCell(new Phrase("Membresía:", fuenteTexto)) { Border = 0 });
                tablaCliente.AddCell(new PdfPCell(new Phrase(membresia, fuenteTexto)) { Border = 0 });
                tablaCliente.AddCell(new PdfPCell(new Phrase("Plan:", fuenteTexto)) { Border = 0 });
                tablaCliente.AddCell(new PdfPCell(new Phrase(plan, fuenteTexto)) { Border = 0 });
                tablaCliente.AddCell(new PdfPCell(new Phrase("Medio de pago:", fuenteTexto)) { Border = 0 });
                tablaCliente.AddCell(new PdfPCell(new Phrase(medioPago, fuenteTexto)) { Border = 0 });
                doc.Add(tablaCliente);
                doc.Add(new Paragraph("\n"));

                // === Detalle de factura ===
                PdfPTable tablaDetalle = new PdfPTable(5);
                tablaDetalle.WidthPercentage = 100;
                tablaDetalle.SetWidths(new float[] { 3, 1, 2, 2, 2 });

                string[] headers = { "Concepto", "Cant.", "Precio Unit.", "Recargo", "Total" };
                foreach (var h in headers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(h, fuenteTablaHeader))
                    {
                        BackgroundColor = BaseColor.DARK_GRAY,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5
                    };
                    tablaDetalle.AddCell(cell);
                }

                tablaDetalle.AddCell(new PdfPCell(new Phrase("Cuota mensual del plan seleccionado", fuenteTablaTexto)) { Padding = 5 });
                tablaDetalle.AddCell(new PdfPCell(new Phrase("1", fuenteTablaTexto)) { Padding = 5, HorizontalAlignment = Element.ALIGN_CENTER });
                tablaDetalle.AddCell(new PdfPCell(new Phrase($"${monto:0.00}", fuenteTablaTexto)) { Padding = 5, HorizontalAlignment = Element.ALIGN_RIGHT });
                tablaDetalle.AddCell(new PdfPCell(new Phrase($"${recargo:0.00}", fuenteTablaTexto)) { Padding = 5, HorizontalAlignment = Element.ALIGN_RIGHT });
                tablaDetalle.AddCell(new PdfPCell(new Phrase($"${total:0.00}", fuenteTablaTexto)) { Padding = 5, HorizontalAlignment = Element.ALIGN_RIGHT });

                doc.Add(tablaDetalle);
                doc.Add(new Paragraph("\n"));

                // === Totales ===
                PdfPTable tablaTotales = new PdfPTable(2) { WidthPercentage = 40, HorizontalAlignment = Element.ALIGN_RIGHT };
                tablaTotales.AddCell(new PdfPCell(new Phrase("Subtotal:", fuenteTexto)) { Border = 0 });
                tablaTotales.AddCell(new PdfPCell(new Phrase($"${monto:0.00}", fuenteTexto)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tablaTotales.AddCell(new PdfPCell(new Phrase("Recargo:", fuenteTexto)) { Border = 0 });
                tablaTotales.AddCell(new PdfPCell(new Phrase($"${recargo:0.00}", fuenteTexto)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tablaTotales.AddCell(new PdfPCell(new Phrase("TOTAL:", fuenteTitulo)) { Border = 0 });
                tablaTotales.AddCell(new PdfPCell(new Phrase($"${total:0.00}", fuenteTitulo)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                doc.Add(tablaTotales);

                doc.Add(new Paragraph("\n"));
                doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.GRAY, Element.ALIGN_CENTER, -1)));

                // === Pie ===
                Paragraph pie = new Paragraph("Comprobante no válido como factura fiscal.\nConstancia de pago emitida por EnerGym Fitness Club.\n\n¡Gracias por elegirnos!", fuenteTexto)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingBefore = 15f
                };
                doc.Add(pie);

                doc.Close();
            }

            // Abrir automáticamente el PDF generado
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
