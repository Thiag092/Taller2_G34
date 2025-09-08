namespace Taller2_G34
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
            this.homeContainer = new System.Windows.Forms.SplitContainer();
            this.BSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelAdmin = new System.Windows.Forms.Label();
            this.contentContainer = new System.Windows.Forms.SplitContainer();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelTextoBienvenida = new System.Windows.Forms.Label();
            this.BVerUsuarios = new System.Windows.Forms.Button();
            this.BVerAlumnos = new System.Windows.Forms.Button();
            this.btnVerEntrenadores = new System.Windows.Forms.Button();
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
            this.homeContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.homeContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            this.homeContainer.Location = new System.Drawing.Point(2, 0);
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
            this.homeContainer.Size = new System.Drawing.Size(1085, 681);
            this.homeContainer.SplitterDistance = 87;
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
            this.BSalir.Location = new System.Drawing.Point(899, 23);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(157, 50);
            this.BSalir.TabIndex = 5;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Taller2_G34.Properties.Resources.ChatGPT_Image_1_sept_2025__17_46_04;
            this.pictureBox1.Location = new System.Drawing.Point(36, 0);
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
            this.labelAdmin.Location = new System.Drawing.Point(135, 27);
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
            this.contentContainer.Panel2.Controls.Add(this.btnVerEntrenadores);
            this.contentContainer.Panel2.Controls.Add(this.BVerUsuarios);
            this.contentContainer.Panel2.Controls.Add(this.BVerAlumnos);
            this.contentContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint_1);
            this.contentContainer.Panel2MinSize = 200;
            this.contentContainer.Size = new System.Drawing.Size(1085, 590);
            this.contentContainer.SplitterDistance = 792;
            this.contentContainer.TabIndex = 7;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.btnEliminar);
            this.contentPanel.Controls.Add(this.btnAgregar);
            this.contentPanel.Controls.Add(this.labelTitulo);
            this.contentPanel.Controls.Add(this.dataGridView);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(792, 590);
            this.contentPanel.TabIndex = 2;
            this.contentPanel.Visible = false;
            this.contentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.contentPanel_Paint);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Maroon;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(609, 451);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(119, 45);
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
            this.btnAgregar.Size = new System.Drawing.Size(123, 45);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.UseVisualStyleBackColor = false;
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
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.Color.Gold;
            this.dataGridView.Location = new System.Drawing.Point(24, 45);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
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
            // BVerUsuarios
            // 
            this.BVerUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BVerUsuarios.AutoSize = true;
            this.BVerUsuarios.BackColor = System.Drawing.Color.Black;
            this.BVerUsuarios.FlatAppearance.BorderSize = 0;
            this.BVerUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVerUsuarios.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVerUsuarios.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BVerUsuarios.Location = new System.Drawing.Point(42, 45);
            this.BVerUsuarios.Name = "BVerUsuarios";
            this.BVerUsuarios.Size = new System.Drawing.Size(218, 58);
            this.BVerUsuarios.TabIndex = 1;
            this.BVerUsuarios.Text = "Ver usuarios";
            this.BVerUsuarios.UseVisualStyleBackColor = false;
            // 
            // BVerAlumnos
            // 
            this.BVerAlumnos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BVerAlumnos.AutoSize = true;
            this.BVerAlumnos.BackColor = System.Drawing.Color.Black;
            this.BVerAlumnos.FlatAppearance.BorderSize = 0;
            this.BVerAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVerAlumnos.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVerAlumnos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BVerAlumnos.Location = new System.Drawing.Point(42, 152);
            this.BVerAlumnos.Name = "BVerAlumnos";
            this.BVerAlumnos.Size = new System.Drawing.Size(218, 56);
            this.BVerAlumnos.TabIndex = 0;
            this.BVerAlumnos.Text = "Ver alumnos";
            this.BVerAlumnos.UseVisualStyleBackColor = false;
            // 
            // btnVerEntrenadores
            // 
            this.btnVerEntrenadores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerEntrenadores.AutoSize = true;
            this.btnVerEntrenadores.BackColor = System.Drawing.Color.Black;
            this.btnVerEntrenadores.FlatAppearance.BorderSize = 0;
            this.btnVerEntrenadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerEntrenadores.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerEntrenadores.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerEntrenadores.Location = new System.Drawing.Point(42, 259);
            this.btnVerEntrenadores.Name = "btnVerEntrenadores";
            this.btnVerEntrenadores.Size = new System.Drawing.Size(218, 56);
            this.btnVerEntrenadores.TabIndex = 2;
            this.btnVerEntrenadores.Text = "Ver entrenadores";
            this.btnVerEntrenadores.UseVisualStyleBackColor = false;
            // 
            // HomePageAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1087, 620);
            this.Controls.Add(this.homeContainer);
            this.Name = "HomePageAdmin";
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
        private System.Windows.Forms.Button BVerUsuarios;
        private System.Windows.Forms.Button BVerAlumnos;
        private System.Windows.Forms.Button btnVerEntrenadores;
    }
}