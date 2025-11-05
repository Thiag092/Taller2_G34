namespace Taller2_G34
{
    partial class AgregarEjercicio
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
            this.labelTiempo = new System.Windows.Forms.Label();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.txtRepeticiones = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labelRepeticiones = new System.Windows.Forms.Label();
            this.labelNombreEjercicio = new System.Windows.Forms.Label();
            this.BConfirmar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LEjercicio = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelEjercicios = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BBuscar = new System.Windows.Forms.Button();
            this.dataGridEjercicios = new System.Windows.Forms.DataGridView();
            this.ColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjercicios)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTiempo
            // 
            this.labelTiempo.AutoSize = true;
            this.labelTiempo.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTiempo.Location = new System.Drawing.Point(72, 196);
            this.labelTiempo.Name = "labelTiempo";
            this.labelTiempo.Size = new System.Drawing.Size(187, 25);
            this.labelTiempo.TabIndex = 44;
            this.labelTiempo.Text = "Tiempo (segundos)";
            // 
            // txtTiempo
            // 
            this.txtTiempo.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTiempo.Location = new System.Drawing.Point(76, 223);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(229, 31);
            this.txtTiempo.TabIndex = 2;
            // 
            // txtRepeticiones
            // 
            this.txtRepeticiones.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepeticiones.Location = new System.Drawing.Point(76, 142);
            this.txtRepeticiones.Name = "txtRepeticiones";
            this.txtRepeticiones.Size = new System.Drawing.Size(229, 31);
            this.txtRepeticiones.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(76, 64);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(229, 31);
            this.txtNombre.TabIndex = 0;
            // 
            // labelRepeticiones
            // 
            this.labelRepeticiones.AutoSize = true;
            this.labelRepeticiones.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRepeticiones.Location = new System.Drawing.Point(72, 115);
            this.labelRepeticiones.Name = "labelRepeticiones";
            this.labelRepeticiones.Size = new System.Drawing.Size(126, 25);
            this.labelRepeticiones.TabIndex = 37;
            this.labelRepeticiones.Text = "Repeticiones";
            // 
            // labelNombreEjercicio
            // 
            this.labelNombreEjercicio.AutoSize = true;
            this.labelNombreEjercicio.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreEjercicio.Location = new System.Drawing.Point(72, 31);
            this.labelNombreEjercicio.Name = "labelNombreEjercicio";
            this.labelNombreEjercicio.Size = new System.Drawing.Size(197, 25);
            this.labelNombreEjercicio.TabIndex = 36;
            this.labelNombreEjercicio.Text = "Nombre del ejercicio";
            // 
            // BConfirmar
            // 
            this.BConfirmar.BackColor = System.Drawing.Color.Green;
            this.BConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BConfirmar.FlatAppearance.BorderSize = 0;
            this.BConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BConfirmar.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BConfirmar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BConfirmar.Location = new System.Drawing.Point(28, 270);
            this.BConfirmar.Name = "BConfirmar";
            this.BConfirmar.Size = new System.Drawing.Size(173, 40);
            this.BConfirmar.TabIndex = 3;
            this.BConfirmar.Text = "Agregar ejercicio";
            this.BConfirmar.UseVisualStyleBackColor = false;
            this.BConfirmar.Click += new System.EventHandler(this.BConfirmar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCancelar.FlatAppearance.BorderSize = 0;
            this.BCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCancelar.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BCancelar.Location = new System.Drawing.Point(222, 270);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(147, 40);
            this.BCancelar.TabIndex = 4;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = false;
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
            this.splitContainer1.Panel1.Controls.Add(this.LEjercicio);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Gold;
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1167, 492);
            this.splitContainer1.SplitterDistance = 88;
            this.splitContainer1.TabIndex = 9;
            // 
            // LEjercicio
            // 
            this.LEjercicio.AutoSize = true;
            this.LEjercicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEjercicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            this.LEjercicio.Location = new System.Drawing.Point(12, 42);
            this.LEjercicio.Name = "LEjercicio";
            this.LEjercicio.Size = new System.Drawing.Size(198, 29);
            this.LEjercicio.TabIndex = 56;
            this.LEjercicio.Text = "Nuevo Ejercicio";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Taller2_G34.Properties.Resources.ChatGPT_Image_1_sept_2025__17_46_04;
            this.pictureBox1.Location = new System.Drawing.Point(495, -9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelEjercicios);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.BBuscar);
            this.panel2.Controls.Add(this.dataGridEjercicios);
            this.panel2.Controls.Add(this.labelTiempo);
            this.panel2.Controls.Add(this.txtTiempo);
            this.panel2.Controls.Add(this.txtRepeticiones);
            this.panel2.Controls.Add(this.txtNombre);
            this.panel2.Controls.Add(this.labelRepeticiones);
            this.panel2.Controls.Add(this.labelNombreEjercicio);
            this.panel2.Controls.Add(this.BConfirmar);
            this.panel2.Controls.Add(this.BCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1167, 400);
            this.panel2.TabIndex = 0;
            // 
            // labelEjercicios
            // 
            this.labelEjercicios.AutoSize = true;
            this.labelEjercicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEjercicios.Location = new System.Drawing.Point(397, 38);
            this.labelEjercicios.Name = "labelEjercicios";
            this.labelEjercicios.Size = new System.Drawing.Size(164, 20);
            this.labelEjercicios.TabIndex = 48;
            this.labelEjercicios.Text = "Listado de ejercicios";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(805, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 22);
            this.textBox1.TabIndex = 47;
            // 
            // BBuscar
            // 
            this.BBuscar.BackColor = System.Drawing.Color.Black;
            this.BBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BBuscar.Location = new System.Drawing.Point(1016, 21);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(87, 27);
            this.BBuscar.TabIndex = 46;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = false;
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
            this.dataGridEjercicios.Location = new System.Drawing.Point(400, 64);
            this.dataGridEjercicios.Name = "dataGridEjercicios";
            this.dataGridEjercicios.ReadOnly = true;
            this.dataGridEjercicios.RowHeadersWidth = 51;
            this.dataGridEjercicios.RowTemplate.Height = 24;
            this.dataGridEjercicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEjercicios.Size = new System.Drawing.Size(755, 246);
            this.dataGridEjercicios.TabIndex = 45;
            this.dataGridEjercicios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEjercicios_CellContentClick);
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
            // AgregarEjercicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 492);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AgregarEjercicio";
            this.Text = "Nuevo Ejercicio";
            this.Load += new System.EventHandler(this.AgregarEjercicio_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjercicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelTiempo;
        private System.Windows.Forms.TextBox txtTiempo;
        private System.Windows.Forms.TextBox txtRepeticiones;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labelRepeticiones;
        private System.Windows.Forms.Label labelNombreEjercicio;
        private System.Windows.Forms.Button BConfirmar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label LEjercicio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridEjercicios;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRep;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTiempo;
        private System.Windows.Forms.Label labelEjercicios;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BBuscar;
    }
}