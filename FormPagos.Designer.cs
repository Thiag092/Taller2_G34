namespace Taller2_G34
{
    partial class FormPagos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            this.lblAlumno = new System.Windows.Forms.Label();
            this.comboAlumno = new System.Windows.Forms.ComboBox();
            this.lblMembresia = new System.Windows.Forms.Label();
            this.comboMembresia = new System.Windows.Forms.ComboBox();
            this.lblMedioPago = new System.Windows.Forms.Label();
            this.comboMedioPago = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblRecargo = new System.Windows.Forms.Label();
            this.txtRecargo = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAlumno
            // 
            this.lblAlumno.AutoSize = true;
            this.lblAlumno.Location = new System.Drawing.Point(88, 83);
            this.lblAlumno.Name = "lblAlumno";
            this.lblAlumno.Size = new System.Drawing.Size(55, 16);
            this.lblAlumno.TabIndex = 0;
            this.lblAlumno.Text = "Alumno:";
            // 
            // comboAlumno
            // 
            this.comboAlumno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAlumno.FormattingEnabled = true;
            this.comboAlumno.Location = new System.Drawing.Point(208, 80);
            this.comboAlumno.Name = "comboAlumno";
            this.comboAlumno.Size = new System.Drawing.Size(250, 24);
            this.comboAlumno.TabIndex = 1;
            // 
            // lblMembresia
            // 
            this.lblMembresia.AutoSize = true;
            this.lblMembresia.Location = new System.Drawing.Point(88, 123);
            this.lblMembresia.Name = "lblMembresia";
            this.lblMembresia.Size = new System.Drawing.Size(78, 16);
            this.lblMembresia.TabIndex = 2;
            this.lblMembresia.Text = "Membresía:";
            // 
            // comboMembresia
            // 
            this.comboMembresia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMembresia.FormattingEnabled = true;
            this.comboMembresia.Location = new System.Drawing.Point(208, 120);
            this.comboMembresia.Name = "comboMembresia";
            this.comboMembresia.Size = new System.Drawing.Size(250, 24);
            this.comboMembresia.TabIndex = 3;
            // 
            // lblMedioPago
            // 
            this.lblMedioPago.AutoSize = true;
            this.lblMedioPago.Location = new System.Drawing.Point(88, 163);
            this.lblMedioPago.Name = "lblMedioPago";
            this.lblMedioPago.Size = new System.Drawing.Size(102, 16);
            this.lblMedioPago.TabIndex = 4;
            this.lblMedioPago.Text = "Medio de pago:";
            // 
            // comboMedioPago
            // 
            this.comboMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMedioPago.FormattingEnabled = true;
            this.comboMedioPago.Location = new System.Drawing.Point(208, 160);
            this.comboMedioPago.Name = "comboMedioPago";
            this.comboMedioPago.Size = new System.Drawing.Size(250, 24);
            this.comboMedioPago.TabIndex = 5;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(88, 203);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(64, 16);
            this.lblCantidad.TabIndex = 6;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(208, 200);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 22);
            this.txtCantidad.TabIndex = 7;
            // 
            // lblRecargo
            // 
            this.lblRecargo.AutoSize = true;
            this.lblRecargo.Location = new System.Drawing.Point(88, 243);
            this.lblRecargo.Name = "lblRecargo";
            this.lblRecargo.Size = new System.Drawing.Size(63, 16);
            this.lblRecargo.TabIndex = 8;
            this.lblRecargo.Text = "Recargo:";
            // 
            // txtRecargo
            // 
            this.txtRecargo.Location = new System.Drawing.Point(208, 240);
            this.txtRecargo.Name = "txtRecargo";
            this.txtRecargo.ReadOnly = true;
            this.txtRecargo.Size = new System.Drawing.Size(100, 22);
            this.txtRecargo.TabIndex = 9;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(88, 283);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 16);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(208, 280);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTotal.TabIndex = 11;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(328, 198);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(130, 27);
            this.btnCalcular.TabIndex = 12;
            this.btnCalcular.Text = "Calcular Total";
            this.btnCalcular.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.Location = new System.Drawing.Point(328, 325);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(130, 30);
            this.btnRegistrarPago.TabIndex = 13;
            this.btnRegistrarPago.Text = "Registrar Pago";
            this.btnRegistrarPago.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(208, 325);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 30);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormPagos
            // 
            this.ClientSize = new System.Drawing.Size(555, 446);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrarPago);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtRecargo);
            this.Controls.Add(this.lblRecargo);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.comboMedioPago);
            this.Controls.Add(this.lblMedioPago);
            this.Controls.Add(this.comboMembresia);
            this.Controls.Add(this.lblMembresia);
            this.Controls.Add(this.comboAlumno);
            this.Controls.Add(this.lblAlumno);
            this.Name = "FormPagos";
            this.Text = "Gestión de Pagos";
            this.Load += new System.EventHandler(this.FormPagos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAlumno;
        private System.Windows.Forms.ComboBox comboAlumno;
        private System.Windows.Forms.Label lblMembresia;
        private System.Windows.Forms.ComboBox comboMembresia;
        private System.Windows.Forms.Label lblMedioPago;
        private System.Windows.Forms.ComboBox comboMedioPago;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblRecargo;
        private System.Windows.Forms.TextBox txtRecargo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Button btnCancelar;
    }
}