namespace Taller2_G34
{
    partial class AgregarRutina
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BAgregarEjercicio = new System.Windows.Forms.Button();
            this.LCoachs = new System.Windows.Forms.Label();
            this.LEjercicios = new System.Windows.Forms.Label();
            this.dataGridEjercicios = new System.Windows.Forms.DataGridView();
            this.ColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridCoaches = new System.Windows.Forms.DataGridView();
            this.ColNombreCoach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFechaNac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTimeInicio = new System.Windows.Forms.DateTimePicker();
            this.DateTimeFin = new System.Windows.Forms.DateTimePicker();
            this.TBCantidadSeries = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LFFin = new System.Windows.Forms.Label();
            this.LFInicio = new System.Windows.Forms.Label();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.TBNombrePlan = new System.Windows.Forms.TextBox();
            this.BGuardarPlan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjercicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCoaches)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1181, 845);
            this.panel1.TabIndex = 6;
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
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1181, 845);
            this.splitContainer1.SplitterDistance = 226;
            this.splitContainer1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Taller2_G34.Properties.Resources.ChatGPT_Image_1_sept_2025__17_46_04;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1181, 226);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(188)))), ((int)(((byte)(41)))));
            this.panel2.Controls.Add(this.BAgregarEjercicio);
            this.panel2.Controls.Add(this.LCoachs);
            this.panel2.Controls.Add(this.LEjercicios);
            this.panel2.Controls.Add(this.dataGridEjercicios);
            this.panel2.Controls.Add(this.dataGridCoaches);
            this.panel2.Controls.Add(this.DateTimeInicio);
            this.panel2.Controls.Add(this.DateTimeFin);
            this.panel2.Controls.Add(this.TBCantidadSeries);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.LFFin);
            this.panel2.Controls.Add(this.LFInicio);
            this.panel2.Controls.Add(this.BLimpiar);
            this.panel2.Controls.Add(this.TBNombrePlan);
            this.panel2.Controls.Add(this.BGuardarPlan);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1181, 615);
            this.panel2.TabIndex = 2;
            // 
            // BAgregarEjercicio
            // 
            this.BAgregarEjercicio.BackColor = System.Drawing.Color.Green;
            this.BAgregarEjercicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAgregarEjercicio.FlatAppearance.BorderSize = 0;
            this.BAgregarEjercicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarEjercicio.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarEjercicio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BAgregarEjercicio.Location = new System.Drawing.Point(781, 264);
            this.BAgregarEjercicio.Name = "BAgregarEjercicio";
            this.BAgregarEjercicio.Size = new System.Drawing.Size(228, 40);
            this.BAgregarEjercicio.TabIndex = 26;
            this.BAgregarEjercicio.Text = "Agregar Ejercicio";
            this.BAgregarEjercicio.UseVisualStyleBackColor = false;
            this.BAgregarEjercicio.Click += new System.EventHandler(this.BAgregarEjercicio_Click);
            // 
            // LCoachs
            // 
            this.LCoachs.AutoSize = true;
            this.LCoachs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCoachs.Location = new System.Drawing.Point(70, 299);
            this.LCoachs.Name = "LCoachs";
            this.LCoachs.Size = new System.Drawing.Size(173, 20);
            this.LCoachs.TabIndex = 22;
            this.LCoachs.Text = "Coachs disponibles";
            this.LCoachs.Click += new System.EventHandler(this.label3_Click);
            // 
            // LEjercicios
            // 
            this.LEjercicios.AutoSize = true;
            this.LEjercicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEjercicios.Location = new System.Drawing.Point(61, 68);
            this.LEjercicios.Name = "LEjercicios";
            this.LEjercicios.Size = new System.Drawing.Size(93, 20);
            this.LEjercicios.TabIndex = 21;
            this.LEjercicios.Text = "Ejercicios";
            // 
            // dataGridEjercicios
            // 
            this.dataGridEjercicios.AllowUserToAddRows = false;
            this.dataGridEjercicios.AllowUserToDeleteRows = false;
            this.dataGridEjercicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridEjercicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEjercicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNombre,
            this.ColRep,
            this.ColTiempo});
            this.dataGridEjercicios.Location = new System.Drawing.Point(65, 100);
            this.dataGridEjercicios.Name = "dataGridEjercicios";
            this.dataGridEjercicios.RowHeadersWidth = 51;
            this.dataGridEjercicios.RowTemplate.Height = 24;
            this.dataGridEjercicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEjercicios.Size = new System.Drawing.Size(944, 158);
            this.dataGridEjercicios.TabIndex = 20;
            this.dataGridEjercicios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatgridEjercicios_CellContentClick);
            // 
            // ColNombre
            // 
            this.ColNombre.DataPropertyName = "nombre";
            this.ColNombre.HeaderText = "Nombre";
            this.ColNombre.MinimumWidth = 6;
            this.ColNombre.Name = "ColNombre";
            this.ColNombre.ReadOnly = true;
            // 
            // ColRep
            // 
            this.ColRep.DataPropertyName = "repeticiones";
            this.ColRep.HeaderText = "Repeticiones";
            this.ColRep.MinimumWidth = 6;
            this.ColRep.Name = "ColRep";
            this.ColRep.ReadOnly = true;
            // 
            // ColTiempo
            // 
            this.ColTiempo.DataPropertyName = "tiempo";
            this.ColTiempo.HeaderText = "Tiempo en segundos";
            this.ColTiempo.MinimumWidth = 6;
            this.ColTiempo.Name = "ColTiempo";
            this.ColTiempo.ReadOnly = true;
            // 
            // dataGridCoaches
            // 
            this.dataGridCoaches.AllowUserToAddRows = false;
            this.dataGridCoaches.AllowUserToDeleteRows = false;
            this.dataGridCoaches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCoaches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCoaches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNombreCoach,
            this.ColApellido,
            this.ColDNI,
            this.ColMail,
            this.ColFechaNac,
            this.ColTel});
            this.dataGridCoaches.Location = new System.Drawing.Point(65, 322);
            this.dataGridCoaches.Name = "dataGridCoaches";
            this.dataGridCoaches.ReadOnly = true;
            this.dataGridCoaches.RowHeadersWidth = 51;
            this.dataGridCoaches.RowTemplate.Height = 24;
            this.dataGridCoaches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCoaches.Size = new System.Drawing.Size(944, 158);
            this.dataGridCoaches.TabIndex = 19;
            this.dataGridCoaches.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCoaches_CellContentClick_1);
            // 
            // ColNombreCoach
            // 
            this.ColNombreCoach.DataPropertyName = "nombre";
            this.ColNombreCoach.HeaderText = "Nombre";
            this.ColNombreCoach.MinimumWidth = 6;
            this.ColNombreCoach.Name = "ColNombreCoach";
            this.ColNombreCoach.ReadOnly = true;
            // 
            // ColApellido
            // 
            this.ColApellido.DataPropertyName = "apellido";
            this.ColApellido.HeaderText = "Apellido";
            this.ColApellido.MinimumWidth = 6;
            this.ColApellido.Name = "ColApellido";
            this.ColApellido.ReadOnly = true;
            // 
            // ColDNI
            // 
            this.ColDNI.DataPropertyName = "dni";
            this.ColDNI.HeaderText = "DNI";
            this.ColDNI.MinimumWidth = 6;
            this.ColDNI.Name = "ColDNI";
            this.ColDNI.ReadOnly = true;
            // 
            // ColMail
            // 
            this.ColMail.DataPropertyName = "email";
            this.ColMail.HeaderText = "E-mail";
            this.ColMail.MinimumWidth = 6;
            this.ColMail.Name = "ColMail";
            this.ColMail.ReadOnly = true;
            // 
            // ColFechaNac
            // 
            this.ColFechaNac.DataPropertyName = "fecha_nacimiento";
            this.ColFechaNac.HeaderText = "Fecha nacimiento";
            this.ColFechaNac.MinimumWidth = 6;
            this.ColFechaNac.Name = "ColFechaNac";
            this.ColFechaNac.ReadOnly = true;
            // 
            // ColTel
            // 
            this.ColTel.DataPropertyName = "telefono";
            this.ColTel.HeaderText = "Telefono";
            this.ColTel.MinimumWidth = 6;
            this.ColTel.Name = "ColTel";
            this.ColTel.ReadOnly = true;
            // 
            // DateTimeInicio
            // 
            this.DateTimeInicio.Location = new System.Drawing.Point(317, 33);
            this.DateTimeInicio.Name = "DateTimeInicio";
            this.DateTimeInicio.Size = new System.Drawing.Size(182, 22);
            this.DateTimeInicio.TabIndex = 18;
            // 
            // DateTimeFin
            // 
            this.DateTimeFin.Location = new System.Drawing.Point(554, 33);
            this.DateTimeFin.Name = "DateTimeFin";
            this.DateTimeFin.Size = new System.Drawing.Size(182, 22);
            this.DateTimeFin.TabIndex = 17;
            // 
            // TBCantidadSeries
            // 
            this.TBCantidadSeries.Location = new System.Drawing.Point(770, 33);
            this.TBCantidadSeries.Name = "TBCantidadSeries";
            this.TBCantidadSeries.Size = new System.Drawing.Size(152, 22);
            this.TBCantidadSeries.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(767, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cantidad repeticiones";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // LFFin
            // 
            this.LFFin.AutoSize = true;
            this.LFFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFFin.Location = new System.Drawing.Point(551, 14);
            this.LFFin.Name = "LFFin";
            this.LFFin.Size = new System.Drawing.Size(70, 16);
            this.LFFin.TabIndex = 12;
            this.LFFin.Text = "Fecha fin";
            // 
            // LFInicio
            // 
            this.LFInicio.AutoSize = true;
            this.LFInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFInicio.Location = new System.Drawing.Point(314, 14);
            this.LFInicio.Name = "LFInicio";
            this.LFInicio.Size = new System.Drawing.Size(91, 16);
            this.LFInicio.TabIndex = 10;
            this.LFInicio.Text = "Fecha inicio";
            // 
            // BLimpiar
            // 
            this.BLimpiar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLimpiar.FlatAppearance.BorderSize = 0;
            this.BLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiar.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BLimpiar.Location = new System.Drawing.Point(714, 537);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(147, 40);
            this.BLimpiar.TabIndex = 0;
            this.BLimpiar.Text = "Limpiar";
            this.BLimpiar.UseVisualStyleBackColor = false;
            this.BLimpiar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // TBNombrePlan
            // 
            this.TBNombrePlan.Location = new System.Drawing.Point(65, 33);
            this.TBNombrePlan.Name = "TBNombrePlan";
            this.TBNombrePlan.Size = new System.Drawing.Size(152, 22);
            this.TBNombrePlan.TabIndex = 3;
            // 
            // BGuardarPlan
            // 
            this.BGuardarPlan.BackColor = System.Drawing.Color.Green;
            this.BGuardarPlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGuardarPlan.FlatAppearance.BorderSize = 0;
            this.BGuardarPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardarPlan.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardarPlan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BGuardarPlan.Location = new System.Drawing.Point(886, 537);
            this.BGuardarPlan.Name = "BGuardarPlan";
            this.BGuardarPlan.Size = new System.Drawing.Size(132, 40);
            this.BGuardarPlan.TabIndex = 1;
            this.BGuardarPlan.Text = "Guardar Plan";
            this.BGuardarPlan.UseVisualStyleBackColor = false;
            this.BGuardarPlan.Click += new System.EventHandler(this.BCrear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre del plan";
            // 
            // AgregarRutina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1181, 845);
            this.Controls.Add(this.panel1);
            this.Name = "AgregarRutina";
            this.Text = "Nueva rutina";
            this.Load += new System.EventHandler(this.AgregarRutina_Load);
            this.Click += new System.EventHandler(this.AgregarRutina_Click);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjercicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCoaches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TBNombrePlan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.Button BGuardarPlan;
        private System.Windows.Forms.TextBox TBCantidadSeries;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LFFin;
        private System.Windows.Forms.Label LFInicio;
        private System.Windows.Forms.DateTimePicker DateTimeInicio;
        private System.Windows.Forms.DateTimePicker DateTimeFin;
        private System.Windows.Forms.Label LCoachs;
        private System.Windows.Forms.Label LEjercicios;
        private System.Windows.Forms.DataGridView dataGridEjercicios;
        private System.Windows.Forms.DataGridView dataGridCoaches;
        private System.Windows.Forms.Button BAgregarEjercicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRep;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombreCoach;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFechaNac;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTel;
    }
}