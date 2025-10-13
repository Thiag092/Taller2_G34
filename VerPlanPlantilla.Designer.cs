namespace Taller2_G34
{
    partial class VerPlanPlantilla
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitulo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNuevoEjercicio = new System.Windows.Forms.Button();
            this.cboEjercicioCatalogo = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvEjercicios = new System.Windows.Forms.DataGridView();
            this.ColIdEjercicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboDias = new System.Windows.Forms.ComboBox();
            this.labelDia = new System.Windows.Forms.Label();
            this.cantRepeticiones = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cantSeries = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantRepeticiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            this.labelTitulo.Location = new System.Drawing.Point(12, 42);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(93, 29);
            this.labelTitulo.TabIndex = 56;
            this.labelTitulo.Text = "Planes";
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.labelTitulo);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Gold;
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1373, 697);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.MenuText;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(1151, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 50);
            this.button2.TabIndex = 52;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Taller2_G34.Properties.Resources.ChatGPT_Image_1_sept_2025__17_46_04;
            this.pictureBox1.Location = new System.Drawing.Point(543, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btnAgregar);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Controls.Add(this.dgvEjercicios);
            this.panel2.Controls.Add(this.cboDias);
            this.panel2.Controls.Add(this.labelDia);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1373, 569);
            this.panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTiempo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cantSeries);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cantRepeticiones);
            this.panel1.Controls.Add(this.btnConfirmar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnNuevoEjercicio);
            this.panel1.Controls.Add(this.cboEjercicioCatalogo);
            this.panel1.Location = new System.Drawing.Point(55, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 261);
            this.panel1.TabIndex = 55;
            this.panel1.Visible = false;
            this.panel1.VisibleChanged += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConfirmar.Location = new System.Drawing.Point(70, 216);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(99, 30);
            this.btnConfirmar.TabIndex = 64;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 16);
            this.label3.TabIndex = 63;
            this.label3.Text = "Agregar ejercicio existente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 16);
            this.label2.TabIndex = 62;
            this.label2.Text = "Agregar ejercicio nuevo";
            // 
            // btnNuevoEjercicio
            // 
            this.btnNuevoEjercicio.BackColor = System.Drawing.Color.Green;
            this.btnNuevoEjercicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoEjercicio.FlatAppearance.BorderSize = 0;
            this.btnNuevoEjercicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoEjercicio.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoEjercicio.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNuevoEjercicio.Location = new System.Drawing.Point(171, 18);
            this.btnNuevoEjercicio.Name = "btnNuevoEjercicio";
            this.btnNuevoEjercicio.Size = new System.Drawing.Size(31, 31);
            this.btnNuevoEjercicio.TabIndex = 61;
            this.btnNuevoEjercicio.Text = "+";
            this.btnNuevoEjercicio.UseVisualStyleBackColor = false;
            this.btnNuevoEjercicio.Click += new System.EventHandler(this.btnNuevoEjercicio_Click);
            // 
            // cboEjercicioCatalogo
            // 
            this.cboEjercicioCatalogo.FormattingEnabled = true;
            this.cboEjercicioCatalogo.Location = new System.Drawing.Point(6, 91);
            this.cboEjercicioCatalogo.Name = "cboEjercicioCatalogo";
            this.cboEjercicioCatalogo.Size = new System.Drawing.Size(211, 24);
            this.cboEjercicioCatalogo.TabIndex = 60;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Location = new System.Drawing.Point(55, 136);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(253, 36);
            this.btnAgregar.TabIndex = 54;
            this.btnAgregar.Text = "Agregar ejercicios";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(55, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(253, 22);
            this.textBox1.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 51;
            this.label1.Text = "Nombre del Plan";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.SystemColors.MenuText;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Location = new System.Drawing.Point(885, 385);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(157, 45);
            this.btnGuardar.TabIndex = 50;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // dgvEjercicios
            // 
            this.dgvEjercicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEjercicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIdEjercicio,
            this.ColNombre,
            this.ColReps,
            this.ColTiempo});
            this.dgvEjercicios.Location = new System.Drawing.Point(400, 31);
            this.dgvEjercicios.Name = "dgvEjercicios";
            this.dgvEjercicios.ReadOnly = true;
            this.dgvEjercicios.RowHeadersWidth = 51;
            this.dgvEjercicios.RowTemplate.Height = 24;
            this.dgvEjercicios.Size = new System.Drawing.Size(642, 320);
            this.dgvEjercicios.TabIndex = 46;
            this.dgvEjercicios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEjercicios_CellContentClick);
            // 
            // ColIdEjercicio
            // 
            this.ColIdEjercicio.DataPropertyName = "id_ejercicio";
            this.ColIdEjercicio.HeaderText = "ID";
            this.ColIdEjercicio.MinimumWidth = 6;
            this.ColIdEjercicio.Name = "ColIdEjercicio";
            this.ColIdEjercicio.ReadOnly = true;
            this.ColIdEjercicio.Visible = false;
            this.ColIdEjercicio.Width = 125;
            // 
            // ColNombre
            // 
            this.ColNombre.DataPropertyName = "nombre";
            this.ColNombre.HeaderText = "Ejercicio";
            this.ColNombre.MinimumWidth = 6;
            this.ColNombre.Name = "ColNombre";
            this.ColNombre.ReadOnly = true;
            this.ColNombre.Width = 125;
            // 
            // ColReps
            // 
            this.ColReps.DataPropertyName = "repeticiones";
            this.ColReps.HeaderText = "Repeticiones";
            this.ColReps.MinimumWidth = 6;
            this.ColReps.Name = "ColReps";
            this.ColReps.ReadOnly = true;
            this.ColReps.Width = 125;
            // 
            // ColTiempo
            // 
            this.ColTiempo.DataPropertyName = "tiempo";
            this.ColTiempo.HeaderText = "Tiempo (Seg)";
            this.ColTiempo.MinimumWidth = 6;
            this.ColTiempo.Name = "ColTiempo";
            this.ColTiempo.ReadOnly = true;
            this.ColTiempo.Width = 125;
            // 
            // cboDias
            // 
            this.cboDias.FormattingEnabled = true;
            this.cboDias.Location = new System.Drawing.Point(55, 92);
            this.cboDias.Name = "cboDias";
            this.cboDias.Size = new System.Drawing.Size(253, 24);
            this.cboDias.TabIndex = 45;
            this.cboDias.SelectedIndexChanged += new System.EventHandler(this.cboDias_SelectedIndexChanged);
            // 
            // labelDia
            // 
            this.labelDia.AutoSize = true;
            this.labelDia.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDia.Location = new System.Drawing.Point(50, 64);
            this.labelDia.Name = "labelDia";
            this.labelDia.Size = new System.Drawing.Size(117, 25);
            this.labelDia.TabIndex = 36;
            this.labelDia.Text = "Dia del Plan";
            // 
            // cantRepeticiones
            // 
            this.cantRepeticiones.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cantRepeticiones.Location = new System.Drawing.Point(173, 123);
            this.cantRepeticiones.Name = "cantRepeticiones";
            this.cantRepeticiones.Size = new System.Drawing.Size(44, 22);
            this.cantRepeticiones.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 66;
            this.label4.Text = "Repeticiones";
            // 
            // cantSeries
            // 
            this.cantSeries.Location = new System.Drawing.Point(171, 153);
            this.cantSeries.Name = "cantSeries";
            this.cantSeries.Size = new System.Drawing.Size(46, 22);
            this.cantSeries.TabIndex = 67;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 68;
            this.label5.Text = "Series";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 16);
            this.label6.TabIndex = 69;
            this.label6.Text = "Tiempo en segundos";
            // 
            // txtTiempo
            // 
            this.txtTiempo.Location = new System.Drawing.Point(147, 182);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(70, 22);
            this.txtTiempo.TabIndex = 70;
            // 
            // VerPlanPlantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 697);
            this.Controls.Add(this.splitContainer1);
            this.Name = "VerPlanPlantilla";
            this.Text = "VerPlanPlantilla";
            this.Load += new System.EventHandler(this.VerPlanPlantilla_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantRepeticiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantSeries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelDia;
        private System.Windows.Forms.ComboBox cboDias;
        private System.Windows.Forms.DataGridView dgvEjercicios;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdEjercicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReps;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTiempo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNuevoEjercicio;
        private System.Windows.Forms.ComboBox cboEjercicioCatalogo;
        private System.Windows.Forms.NumericUpDown cantSeries;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown cantRepeticiones;
        private System.Windows.Forms.TextBox txtTiempo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}