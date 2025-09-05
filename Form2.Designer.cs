namespace Taller2_G34
{
    partial class Form2
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
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BAgregarAlumno = new System.Windows.Forms.Button();
            this.BVerAlumnos = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(154, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Panel de Administrador";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Taller2_G34.Properties.Resources.ChatGPT_Image_1_sept_2025__17_46_04;
            this.pictureBox1.Location = new System.Drawing.Point(12, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BAgregarAlumno);
            this.panel1.Controls.Add(this.BVerAlumnos);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Location = new System.Drawing.Point(2, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1085, 548);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Acá me gustaría un panel que muestre a los alumnos. Tipo tabla";
            // 
            // BAgregarAlumno
            // 
            this.BAgregarAlumno.BackColor = System.Drawing.Color.Black;
            this.BAgregarAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarAlumno.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BAgregarAlumno.Location = new System.Drawing.Point(771, 305);
            this.BAgregarAlumno.Name = "BAgregarAlumno";
            this.BAgregarAlumno.Size = new System.Drawing.Size(265, 97);
            this.BAgregarAlumno.TabIndex = 1;
            this.BAgregarAlumno.Text = "Agregar nuevo entrenador";
            this.BAgregarAlumno.UseVisualStyleBackColor = false;
            // 
            // BVerAlumnos
            // 
            this.BVerAlumnos.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BVerAlumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVerAlumnos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BVerAlumnos.Location = new System.Drawing.Point(771, 47);
            this.BVerAlumnos.Name = "BVerAlumnos";
            this.BVerAlumnos.Size = new System.Drawing.Size(265, 97);
            this.BVerAlumnos.TabIndex = 0;
            this.BVerAlumnos.Text = "Ver entrenadores";
            this.BVerAlumnos.UseVisualStyleBackColor = false;
            this.BVerAlumnos.Click += new System.EventHandler(this.BVerAlumnos_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(771, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(265, 97);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ver inscriptos";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(771, 427);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(265, 97);
            this.button2.TabIndex = 4;
            this.button2.Text = "Ver informe mensual";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1087, 620);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BAgregarAlumno;
        private System.Windows.Forms.Button BVerAlumnos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}