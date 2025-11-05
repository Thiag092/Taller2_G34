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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelMembresia = new System.Windows.Forms.Label();
            this.labelAlumno = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtRecargo = new System.Windows.Forms.TextBox();
            this.lblRecargo = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.comboMedioPago = new System.Windows.Forms.ComboBox();
            this.lblMedioPago = new System.Windows.Forms.Label();
            this.lblMembresia = new System.Windows.Forms.Label();
            this.lblAlumno = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel1.Controls.Add(this.lblTitulo);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelMembresia);
            this.splitContainer1.Panel2.Controls.Add(this.labelAlumno);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btnRegistrarPago);
            this.splitContainer1.Panel2.Controls.Add(this.txtTotal);
            this.splitContainer1.Panel2.Controls.Add(this.lblTotal);
            this.splitContainer1.Panel2.Controls.Add(this.txtRecargo);
            this.splitContainer1.Panel2.Controls.Add(this.lblRecargo);
            this.splitContainer1.Panel2.Controls.Add(this.txtCantidad);
            this.splitContainer1.Panel2.Controls.Add(this.lblCantidad);
            this.splitContainer1.Panel2.Controls.Add(this.comboMedioPago);
            this.splitContainer1.Panel2.Controls.Add(this.lblMedioPago);
            this.splitContainer1.Panel2.Controls.Add(this.lblMembresia);
            this.splitContainer1.Panel2.Controls.Add(this.lblAlumno);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(617, 504);
            this.splitContainer1.SplitterDistance = 97;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblTitulo.Location = new System.Drawing.Point(38, 36);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(149, 24);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Gestion de pago";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Taller2_G34.Properties.Resources.ChatGPT_Image_1_sept_2025__17_46_04;
            this.pictureBox1.Location = new System.Drawing.Point(236, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // labelMembresia
            // 
            this.labelMembresia.AutoSize = true;
            this.labelMembresia.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMembresia.Location = new System.Drawing.Point(282, 68);
            this.labelMembresia.Name = "labelMembresia";
            this.labelMembresia.Size = new System.Drawing.Size(93, 19);
            this.labelMembresia.TabIndex = 30;
            this.labelMembresia.Text = "Membresia";
            // 
            // labelAlumno
            // 
            this.labelAlumno.AutoSize = true;
            this.labelAlumno.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlumno.Location = new System.Drawing.Point(282, 28);
            this.labelAlumno.Name = "labelAlumno";
            this.labelAlumno.Size = new System.Drawing.Size(69, 19);
            this.labelAlumno.TabIndex = 29;
            this.labelAlumno.Text = "Alumno";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Black;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Location = new System.Drawing.Point(286, 316);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 41);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.BackColor = System.Drawing.Color.Black;
            this.btnRegistrarPago.FlatAppearance.BorderSize = 0;
            this.btnRegistrarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarPago.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarPago.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistrarPago.Location = new System.Drawing.Point(406, 316);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(130, 41);
            this.btnRegistrarPago.TabIndex = 3;
            this.btnRegistrarPago.Text = "Registrar Pago";
            this.btnRegistrarPago.UseVisualStyleBackColor = false;
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(286, 225);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 27);
            this.txtTotal.TabIndex = 26;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(132, 228);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(112, 19);
            this.lblTotal.TabIndex = 25;
            this.lblTotal.Text = "Total a pagar:";
            // 
            // txtRecargo
            // 
            this.txtRecargo.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecargo.Location = new System.Drawing.Point(286, 185);
            this.txtRecargo.Name = "txtRecargo";
            this.txtRecargo.ReadOnly = true;
            this.txtRecargo.Size = new System.Drawing.Size(100, 27);
            this.txtRecargo.TabIndex = 24;
            // 
            // lblRecargo
            // 
            this.lblRecargo.AutoSize = true;
            this.lblRecargo.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecargo.Location = new System.Drawing.Point(132, 188);
            this.lblRecargo.Name = "lblRecargo";
            this.lblRecargo.Size = new System.Drawing.Size(75, 19);
            this.lblRecargo.TabIndex = 23;
            this.lblRecargo.Text = "Recargo:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(286, 140);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 27);
            this.txtCantidad.TabIndex = 22;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(132, 148);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(103, 19);
            this.lblCantidad.TabIndex = 21;
            this.lblCantidad.Text = "Monto base:";
            // 
            // comboMedioPago
            // 
            this.comboMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMedioPago.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMedioPago.FormattingEnabled = true;
            this.comboMedioPago.Location = new System.Drawing.Point(286, 100);
            this.comboMedioPago.Name = "comboMedioPago";
            this.comboMedioPago.Size = new System.Drawing.Size(250, 27);
            this.comboMedioPago.TabIndex = 1;
            // 
            // lblMedioPago
            // 
            this.lblMedioPago.AutoSize = true;
            this.lblMedioPago.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedioPago.Location = new System.Drawing.Point(132, 108);
            this.lblMedioPago.Name = "lblMedioPago";
            this.lblMedioPago.Size = new System.Drawing.Size(127, 19);
            this.lblMedioPago.TabIndex = 19;
            this.lblMedioPago.Text = "Medio de pago:";
            // 
            // lblMembresia
            // 
            this.lblMembresia.AutoSize = true;
            this.lblMembresia.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembresia.Location = new System.Drawing.Point(132, 68);
            this.lblMembresia.Name = "lblMembresia";
            this.lblMembresia.Size = new System.Drawing.Size(97, 19);
            this.lblMembresia.TabIndex = 18;
            this.lblMembresia.Text = "Membresía:";
            // 
            // lblAlumno
            // 
            this.lblAlumno.AutoSize = true;
            this.lblAlumno.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumno.Location = new System.Drawing.Point(132, 28);
            this.lblAlumno.Name = "lblAlumno";
            this.lblAlumno.Size = new System.Drawing.Size(73, 19);
            this.lblAlumno.TabIndex = 17;
            this.lblAlumno.Text = "Alumno:";
            // 
            // FormPagos
            // 
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(617, 504);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormPagos";
            this.Text = "Gestión de Pagos";
            this.Load += new System.EventHandler(this.FormPagos_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelMembresia;
        private System.Windows.Forms.Label labelAlumno;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtRecargo;
        private System.Windows.Forms.Label lblRecargo;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.ComboBox comboMedioPago;
        private System.Windows.Forms.Label lblMedioPago;
        private System.Windows.Forms.Label lblMembresia;
        private System.Windows.Forms.Label lblAlumno;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
    }
}