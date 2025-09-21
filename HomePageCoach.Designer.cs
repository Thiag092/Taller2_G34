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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelCoach = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BSalir = new System.Windows.Forms.Button();
            this.homeContainer = new System.Windows.Forms.SplitContainer();
            this.contentContainer = new System.Windows.Forms.SplitContainer();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.textBoxBusqueda = new System.Windows.Forms.TextBox();
            this.BBuscar = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelTextoBienvenida = new System.Windows.Forms.Label();
            this.BVerRutinas = new System.Windows.Forms.Button();
            this.BVerAlumnos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeContainer)).BeginInit();
            this.homeContainer.Panel1.SuspendLayout();
            this.homeContainer.Panel2.SuspendLayout();
            this.homeContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contentContainer)).BeginInit();
            this.contentContainer.Panel1.SuspendLayout();
            this.contentContainer.Panel2.SuspendLayout();
            this.contentContainer.SuspendLayout();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCoach
            // 
            this.labelCoach.AutoSize = true;
            this.labelCoach.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCoach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            this.labelCoach.Location = new System.Drawing.Point(135, 27);
            this.labelCoach.Name = "labelCoach";
            this.labelCoach.Size = new System.Drawing.Size(279, 32);
            this.labelCoach.TabIndex = 4;
            this.labelCoach.Text = "Bienvenido, Coach ";
            this.labelCoach.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Taller2_G34.Properties.Resources.ChatGPT_Image_1_sept_2025__17_46_04;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // BSalir
            // 
            this.BSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BSalir.BackColor = System.Drawing.SystemColors.MenuText;
            this.BSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BSalir.Location = new System.Drawing.Point(831, 20);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(157, 50);
            this.BSalir.TabIndex = 5;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // homeContainer
            // 
            this.homeContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            this.homeContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homeContainer.Location = new System.Drawing.Point(0, 0);
            this.homeContainer.Name = "homeContainer";
            this.homeContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // homeContainer.Panel1
            // 
            this.homeContainer.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.homeContainer.Panel1.Controls.Add(this.BSalir);
            this.homeContainer.Panel1.Controls.Add(this.pictureBox1);
            this.homeContainer.Panel1.Controls.Add(this.labelCoach);
            this.homeContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint_1);
            // 
            // homeContainer.Panel2
            // 
            this.homeContainer.Panel2.BackColor = System.Drawing.Color.Gold;
            this.homeContainer.Panel2.Controls.Add(this.contentContainer);
            this.homeContainer.Size = new System.Drawing.Size(1000, 595);
            this.homeContainer.SplitterDistance = 76;
            this.homeContainer.TabIndex = 6;
            // 
            // contentContainer
            // 
            this.contentContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            this.contentContainer.Location = new System.Drawing.Point(0, 0);
            this.contentContainer.Name = "contentContainer";
            // 
            // contentContainer.Panel1
            // 
            this.contentContainer.Panel1.Controls.Add(this.contentPanel);
            this.contentContainer.Panel1.Controls.Add(this.labelTextoBienvenida);
            this.contentContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.contentContainer_Panel1_Paint);
            this.contentContainer.Panel1MinSize = 550;
            // 
            // contentContainer.Panel2
            // 
            this.contentContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            this.contentContainer.Panel2.Controls.Add(this.BVerRutinas);
            this.contentContainer.Panel2.Controls.Add(this.BVerAlumnos);
            this.contentContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint_1);
            this.contentContainer.Panel2MinSize = 200;
            this.contentContainer.Size = new System.Drawing.Size(1000, 515);
            this.contentContainer.SplitterDistance = 733;
            this.contentContainer.TabIndex = 8;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.textBoxBusqueda);
            this.contentPanel.Controls.Add(this.BBuscar);
            this.contentPanel.Controls.Add(this.labelTitulo);
            this.contentPanel.Controls.Add(this.dataGridView);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(733, 515);
            this.contentPanel.TabIndex = 3;
            this.contentPanel.Visible = false;
            // 
            // textBoxBusqueda
            // 
            this.textBoxBusqueda.BackColor = System.Drawing.Color.Cornsilk;
            this.textBoxBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBusqueda.Location = new System.Drawing.Point(318, 13);
            this.textBoxBusqueda.Name = "textBoxBusqueda";
            this.textBoxBusqueda.Size = new System.Drawing.Size(288, 24);
            this.textBoxBusqueda.TabIndex = 5;
            // 
            // BBuscar
            // 
            this.BBuscar.BackColor = System.Drawing.Color.Black;
            this.BBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BBuscar.Location = new System.Drawing.Point(612, 10);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(87, 27);
            this.BBuscar.TabIndex = 4;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = false;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(19, 12);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(182, 25);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Titulo de la sección";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(187)))), ((int)(((byte)(9)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.GridColor = System.Drawing.Color.DarkGoldenrod;
            this.dataGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView.Location = new System.Drawing.Point(24, 45);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(675, 400);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick_1);
            // 
            // labelTextoBienvenida
            // 
            this.labelTextoBienvenida.AutoSize = true;
            this.labelTextoBienvenida.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextoBienvenida.Location = new System.Drawing.Point(192, 217);
            this.labelTextoBienvenida.Name = "labelTextoBienvenida";
            this.labelTextoBienvenida.Size = new System.Drawing.Size(367, 74);
            this.labelTextoBienvenida.TabIndex = 1;
            this.labelTextoBienvenida.Text = "Por favor selecciona \r\nla sección que deseas ver";
            this.labelTextoBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BVerRutinas
            // 
            this.BVerRutinas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BVerRutinas.BackColor = System.Drawing.Color.Black;
            this.BVerRutinas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BVerRutinas.FlatAppearance.BorderSize = 0;
            this.BVerRutinas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVerRutinas.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVerRutinas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BVerRutinas.Location = new System.Drawing.Point(39, 265);
            this.BVerRutinas.Name = "BVerRutinas";
            this.BVerRutinas.Size = new System.Drawing.Size(189, 69);
            this.BVerRutinas.TabIndex = 1;
            this.BVerRutinas.Text = "Ver rutinas";
            this.BVerRutinas.UseVisualStyleBackColor = false;
            this.BVerRutinas.Click += new System.EventHandler(this.BVerRutinas_Click);
            // 
            // BVerAlumnos
            // 
            this.BVerAlumnos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BVerAlumnos.BackColor = System.Drawing.Color.Black;
            this.BVerAlumnos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BVerAlumnos.FlatAppearance.BorderSize = 0;
            this.BVerAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVerAlumnos.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVerAlumnos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BVerAlumnos.Location = new System.Drawing.Point(39, 133);
            this.BVerAlumnos.Name = "BVerAlumnos";
            this.BVerAlumnos.Size = new System.Drawing.Size(189, 66);
            this.BVerAlumnos.TabIndex = 0;
            this.BVerAlumnos.Text = "Ver alumnos";
            this.BVerAlumnos.UseVisualStyleBackColor = false;
            this.BVerAlumnos.Click += new System.EventHandler(this.BVerAlumnos_Click);
            // 
            // homePageCoach
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1000, 595);
            this.Controls.Add(this.homeContainer);
            this.Name = "homePageCoach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home page";
            this.Load += new System.EventHandler(this.homePageCoach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.homeContainer.Panel1.ResumeLayout(false);
            this.homeContainer.Panel1.PerformLayout();
            this.homeContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.homeContainer)).EndInit();
            this.homeContainer.ResumeLayout(false);
            this.contentContainer.Panel1.ResumeLayout(false);
            this.contentContainer.Panel1.PerformLayout();
            this.contentContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contentContainer)).EndInit();
            this.contentContainer.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelCoach;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.SplitContainer homeContainer;
        private System.Windows.Forms.SplitContainer contentContainer;
        private System.Windows.Forms.Label labelTextoBienvenida;
        private System.Windows.Forms.Button BVerRutinas;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button BVerAlumnos;
        private System.Windows.Forms.TextBox textBoxBusqueda;
        private System.Windows.Forms.Button BBuscar;
    }
}