namespace Taller2_G34
{
    partial class homePageCoach
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
            this.BAgregarAlumno = new System.Windows.Forms.Button();
            this.BVerAlumnos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BAgregarAlumno);
            this.panel1.Controls.Add(this.BVerAlumnos);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Location = new System.Drawing.Point(-1, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1258, 561);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BAgregarAlumno
            // 
            this.BAgregarAlumno.BackColor = System.Drawing.Color.Black;
            this.BAgregarAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarAlumno.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BAgregarAlumno.Location = new System.Drawing.Point(928, 237);
            this.BAgregarAlumno.Name = "BAgregarAlumno";
            this.BAgregarAlumno.Size = new System.Drawing.Size(265, 97);
            this.BAgregarAlumno.TabIndex = 1;
            this.BAgregarAlumno.Text = "Agregar nuevo alumno";
            this.BAgregarAlumno.UseVisualStyleBackColor = false;
            // 
            // BVerAlumnos
            // 
            this.BVerAlumnos.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BVerAlumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVerAlumnos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BVerAlumnos.Location = new System.Drawing.Point(928, 72);
            this.BVerAlumnos.Name = "BVerAlumnos";
            this.BVerAlumnos.Size = new System.Drawing.Size(265, 97);
            this.BVerAlumnos.TabIndex = 0;
            this.BVerAlumnos.Text = "Ver alumnos";
            this.BVerAlumnos.UseVisualStyleBackColor = false;
            this.BVerAlumnos.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Taller2_G34.Properties.Resources.ChatGPT_Image_1_sept_2025__17_46_04;
            this.pictureBox1.Location = new System.Drawing.Point(19, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Acá me gustaría un panel que muestre a los alumnos. Tipo tabla";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // homePageCoach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1254, 650);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "homePageCoach";
            this.Text = "Home page";
            this.Load += new System.EventHandler(this.homePageCoach_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BVerAlumnos;
        private System.Windows.Forms.Button BAgregarAlumno;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}