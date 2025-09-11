﻿namespace Taller2_G34
{
    partial class HomePageAdmin
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
            this.homeContainer = new System.Windows.Forms.SplitContainer();
            this.BSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelAdmin = new System.Windows.Forms.Label();
            this.contentContainer = new System.Windows.Forms.SplitContainer();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.textBoxBusqueda = new System.Windows.Forms.TextBox();
            this.BBuscar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelTextoBienvenida = new System.Windows.Forms.Label();
            this.BVerRutinas = new System.Windows.Forms.Button();
            this.btnVerEntrenadores = new System.Windows.Forms.Button();
            this.BVerPersonal = new System.Windows.Forms.Button();
            this.BVerAlumnos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.homeContainer)).BeginInit();
            this.homeContainer.Panel1.SuspendLayout();
            this.homeContainer.Panel2.SuspendLayout();
            this.homeContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentContainer)).BeginInit();
            this.contentContainer.Panel1.SuspendLayout();
            this.contentContainer.Panel2.SuspendLayout();
            this.contentContainer.SuspendLayout();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
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
            this.homeContainer.Panel1.Controls.Add(this.labelAdmin);
            this.homeContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint_1);
            // 
            // homeContainer.Panel2
            // 
            this.homeContainer.Panel2.BackColor = System.Drawing.Color.Gold;
            this.homeContainer.Panel2.Controls.Add(this.contentContainer);
            this.homeContainer.Size = new System.Drawing.Size(1087, 620);
            this.homeContainer.SplitterDistance = 79;
            this.homeContainer.TabIndex = 7;
            // 
            // BSalir
            // 
            this.BSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BSalir.BackColor = System.Drawing.SystemColors.MenuText;
            this.BSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BSalir.Location = new System.Drawing.Point(901, 23);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(157, 50);
            this.BSalir.TabIndex = 5;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Taller2_G34.Properties.Resources.ChatGPT_Image_1_sept_2025__17_46_04;
            this.pictureBox1.Location = new System.Drawing.Point(24, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // labelAdmin
            // 
            this.labelAdmin.AutoSize = true;
            this.labelAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            this.labelAdmin.Location = new System.Drawing.Point(125, 30);
            this.labelAdmin.Name = "labelAdmin";
            this.labelAdmin.Size = new System.Drawing.Size(340, 32);
            this.labelAdmin.TabIndex = 4;
            this.labelAdmin.Text = "Panel de Administrador ";
            // 
            // contentContainer
            // 
            this.contentContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            this.contentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.contentContainer.Panel2.Controls.Add(this.btnVerEntrenadores);
            this.contentContainer.Panel2.Controls.Add(this.BVerPersonal);
            this.contentContainer.Panel2.Controls.Add(this.BVerAlumnos);
            this.contentContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint_1);
            this.contentContainer.Panel2MinSize = 200;
            this.contentContainer.Size = new System.Drawing.Size(1087, 537);
            this.contentContainer.SplitterDistance = 778;
            this.contentContainer.TabIndex = 7;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.textBoxBusqueda);
            this.contentPanel.Controls.Add(this.BBuscar);
            this.contentPanel.Controls.Add(this.btnEliminar);
            this.contentPanel.Controls.Add(this.btnAgregar);
            this.contentPanel.Controls.Add(this.labelTitulo);
            this.contentPanel.Controls.Add(this.dataGridView);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(778, 537);
            this.contentPanel.TabIndex = 2;
            this.contentPanel.Visible = false;
            this.contentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.contentPanel_Paint);
            // 
            // textBoxBusqueda
            // 
            this.textBoxBusqueda.BackColor = System.Drawing.Color.Cornsilk;
            this.textBoxBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBusqueda.Location = new System.Drawing.Point(347, 12);
            this.textBoxBusqueda.Name = "textBoxBusqueda";
            this.textBoxBusqueda.Size = new System.Drawing.Size(288, 24);
            this.textBoxBusqueda.TabIndex = 7;
            // 
            // BBuscar
            // 
            this.BBuscar.BackColor = System.Drawing.Color.Black;
            this.BBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BBuscar.Location = new System.Drawing.Point(641, 10);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(87, 27);
            this.BBuscar.TabIndex = 6;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = false;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Maroon;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(551, 451);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(177, 45);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Green;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(24, 451);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(177, 45);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
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
            this.dataGridView.BackgroundColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.Color.DarkGoldenrod;
            this.dataGridView.Location = new System.Drawing.Point(24, 45);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Goldenrod;
            this.dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.RowTemplate.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(704, 400);
            this.dataGridView.TabIndex = 0;
            // 
            // labelTextoBienvenida
            // 
            this.labelTextoBienvenida.AutoSize = true;
            this.labelTextoBienvenida.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextoBienvenida.Location = new System.Drawing.Point(29, 233);
            this.labelTextoBienvenida.Name = "labelTextoBienvenida";
            this.labelTextoBienvenida.Size = new System.Drawing.Size(654, 37);
            this.labelTextoBienvenida.TabIndex = 1;
            this.labelTextoBienvenida.Text = "Por favor selecciona la sección que deseas ver";
            this.labelTextoBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BVerRutinas
            // 
            this.BVerRutinas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BVerRutinas.AutoSize = true;
            this.BVerRutinas.BackColor = System.Drawing.Color.Black;
            this.BVerRutinas.FlatAppearance.BorderSize = 0;
            this.BVerRutinas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVerRutinas.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVerRutinas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BVerRutinas.Location = new System.Drawing.Point(50, 360);
            this.BVerRutinas.Name = "BVerRutinas";
            this.BVerRutinas.Size = new System.Drawing.Size(197, 56);
            this.BVerRutinas.TabIndex = 3;
            this.BVerRutinas.Text = "Ver Rutinas";
            this.BVerRutinas.UseVisualStyleBackColor = false;
            this.BVerRutinas.Click += new System.EventHandler(this.BVerRutinas_Click);
            // 
            // btnVerEntrenadores
            // 
            this.btnVerEntrenadores.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVerEntrenadores.AutoSize = true;
            this.btnVerEntrenadores.BackColor = System.Drawing.Color.Black;
            this.btnVerEntrenadores.FlatAppearance.BorderSize = 0;
            this.btnVerEntrenadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerEntrenadores.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerEntrenadores.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerEntrenadores.Location = new System.Drawing.Point(50, 259);
            this.btnVerEntrenadores.Name = "btnVerEntrenadores";
            this.btnVerEntrenadores.Size = new System.Drawing.Size(197, 56);
            this.btnVerEntrenadores.TabIndex = 2;
            this.btnVerEntrenadores.Text = "Ver entrenadores";
            this.btnVerEntrenadores.UseVisualStyleBackColor = false;
            this.btnVerEntrenadores.Click += new System.EventHandler(this.btnVerEntrenadores_Click);
            // 
            // BVerPersonal
            // 
            this.BVerPersonal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BVerPersonal.AutoSize = true;
            this.BVerPersonal.BackColor = System.Drawing.Color.Black;
            this.BVerPersonal.FlatAppearance.BorderSize = 0;
            this.BVerPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVerPersonal.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVerPersonal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BVerPersonal.Location = new System.Drawing.Point(50, 45);
            this.BVerPersonal.Name = "BVerPersonal";
            this.BVerPersonal.Size = new System.Drawing.Size(197, 58);
            this.BVerPersonal.TabIndex = 1;
            this.BVerPersonal.Text = "Ver Personal";
            this.BVerPersonal.UseVisualStyleBackColor = false;
            this.BVerPersonal.Click += new System.EventHandler(this.BVerPersonal_Click);
            // 
            // BVerAlumnos
            // 
            this.BVerAlumnos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BVerAlumnos.AutoSize = true;
            this.BVerAlumnos.BackColor = System.Drawing.Color.Black;
            this.BVerAlumnos.FlatAppearance.BorderSize = 0;
            this.BVerAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVerAlumnos.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVerAlumnos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BVerAlumnos.Location = new System.Drawing.Point(50, 152);
            this.BVerAlumnos.Name = "BVerAlumnos";
            this.BVerAlumnos.Size = new System.Drawing.Size(197, 56);
            this.BVerAlumnos.TabIndex = 0;
            this.BVerAlumnos.Text = "Ver alumnos";
            this.BVerAlumnos.UseVisualStyleBackColor = false;
            this.BVerAlumnos.Click += new System.EventHandler(this.BVerAlumnos_Click);
            // 
            // HomePageAdmin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1087, 620);
            this.Controls.Add(this.homeContainer);
            this.Name = "HomePageAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de administrador";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.homeContainer.Panel1.ResumeLayout(false);
            this.homeContainer.Panel1.PerformLayout();
            this.homeContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.homeContainer)).EndInit();
            this.homeContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contentContainer.Panel1.ResumeLayout(false);
            this.contentContainer.Panel1.PerformLayout();
            this.contentContainer.Panel2.ResumeLayout(false);
            this.contentContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contentContainer)).EndInit();
            this.contentContainer.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer homeContainer;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelAdmin;
        private System.Windows.Forms.SplitContainer contentContainer;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelTextoBienvenida;
        private System.Windows.Forms.Button BVerPersonal;
        private System.Windows.Forms.Button BVerAlumnos;
        private System.Windows.Forms.Button btnVerEntrenadores;
        private System.Windows.Forms.TextBox textBoxBusqueda;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Button BVerRutinas;
    }
}