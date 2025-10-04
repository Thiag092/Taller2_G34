namespace Taller2_G34
{
    partial class EditEjercicio
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
            this.LEjercicio = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelTiempo = new System.Windows.Forms.Label();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.txtRepeticiones = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labelRepeticiones = new System.Windows.Forms.Label();
            this.labelNombreEjercicio = new System.Windows.Forms.Label();
            this.BConfirmar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.pictureBox1.Location = new System.Drawing.Point(317, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Gold;
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(733, 539);
            this.splitContainer1.SplitterDistance = 96;
            this.splitContainer1.TabIndex = 10;
            // 
            // panel2
            // 
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
            this.panel2.Size = new System.Drawing.Size(733, 439);
            this.panel2.TabIndex = 0;
            // 
            // labelTiempo
            // 
            this.labelTiempo.AutoSize = true;
            this.labelTiempo.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTiempo.Location = new System.Drawing.Point(256, 219);
            this.labelTiempo.Name = "labelTiempo";
            this.labelTiempo.Size = new System.Drawing.Size(187, 25);
            this.labelTiempo.TabIndex = 44;
            this.labelTiempo.Text = "Tiempo (segundos)";
            // 
            // txtTiempo
            // 
            this.txtTiempo.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTiempo.Location = new System.Drawing.Point(260, 246);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(229, 31);
            this.txtTiempo.TabIndex = 2;
            // 
            // txtRepeticiones
            // 
            this.txtRepeticiones.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepeticiones.Location = new System.Drawing.Point(260, 165);
            this.txtRepeticiones.Name = "txtRepeticiones";
            this.txtRepeticiones.Size = new System.Drawing.Size(229, 31);
            this.txtRepeticiones.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(260, 87);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(229, 31);
            this.txtNombre.TabIndex = 0;
            // 
            // labelRepeticiones
            // 
            this.labelRepeticiones.AutoSize = true;
            this.labelRepeticiones.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRepeticiones.Location = new System.Drawing.Point(256, 138);
            this.labelRepeticiones.Name = "labelRepeticiones";
            this.labelRepeticiones.Size = new System.Drawing.Size(126, 25);
            this.labelRepeticiones.TabIndex = 37;
            this.labelRepeticiones.Text = "Repeticiones";
            // 
            // labelNombreEjercicio
            // 
            this.labelNombreEjercicio.AutoSize = true;
            this.labelNombreEjercicio.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreEjercicio.Location = new System.Drawing.Point(256, 54);
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
            this.BConfirmar.Location = new System.Drawing.Point(212, 293);
            this.BConfirmar.Name = "BConfirmar";
            this.BConfirmar.Size = new System.Drawing.Size(173, 40);
            this.BConfirmar.TabIndex = 35;
            this.BConfirmar.Text = "Guardar cambios";
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
            this.BCancelar.Location = new System.Drawing.Point(406, 293);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(147, 40);
            this.BCancelar.TabIndex = 34;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = false;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // EditEjercicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 539);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditEjercicio";
            this.Text = "EditEjercicio";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LEjercicio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelTiempo;
        private System.Windows.Forms.TextBox txtTiempo;
        private System.Windows.Forms.TextBox txtRepeticiones;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labelRepeticiones;
        private System.Windows.Forms.Label labelNombreEjercicio;
        private System.Windows.Forms.Button BConfirmar;
        private System.Windows.Forms.Button BCancelar;
    }
}