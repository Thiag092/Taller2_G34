

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.homeContainer = new System.Windows.Forms.SplitContainer();
            this.BSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelAdmin = new System.Windows.Forms.Label();
            this.contentContainer = new System.Windows.Forms.SplitContainer();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.btnVerIntermedio = new System.Windows.Forms.Button();
            this.btnVerAvanzados = new System.Windows.Forms.Button();
            this.btnVerPrincipiantes = new System.Windows.Forms.Button();
            this.btnVerTodos = new System.Windows.Forms.Button();
            this.btnVerAdministradores = new System.Windows.Forms.Button();
            this.BRefresh = new System.Windows.Forms.Button();
            this.btnVerEntrenadores = new System.Windows.Forms.Button();
            this.textBoxBusqueda = new System.Windows.Forms.TextBox();
            this.BBuscar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelTextoBienvenida = new System.Windows.Forms.Label();
            this.BVerRutinas = new System.Windows.Forms.Button();
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
            this.homeContainer.BackColor = System.Drawing.Color.Black;
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
            this.BSalir.FlatAppearance.BorderSize = 0;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BSalir.Image = global::Taller2_G34.Properties.Resources.salida;
            this.BSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BSalir.Location = new System.Drawing.Point(927, 23);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(124, 50);
            this.BSalir.TabIndex = 5;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click_1);
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
            this.contentContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(175)))), ((int)(((byte)(46)))));
            this.contentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentContainer.Location = new System.Drawing.Point(0, 0);
            this.contentContainer.Name = "contentContainer";
            // 
            // contentContainer.Panel1
            // 
            this.contentContainer.Panel1.Controls.Add(this.contentPanel);
            this.contentContainer.Panel1.Controls.Add(this.labelTextoBienvenida);
            this.contentContainer.Panel1MinSize = 550;
            // 
            // contentContainer.Panel2
            // 
            this.contentContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(175)))), ((int)(((byte)(46)))));
            this.contentContainer.Panel2.Controls.Add(this.BVerRutinas);
            this.contentContainer.Panel2.Controls.Add(this.BVerPersonal);
            this.contentContainer.Panel2.Controls.Add(this.BVerAlumnos);
            this.contentContainer.Panel2MinSize = 200;
            this.contentContainer.Size = new System.Drawing.Size(1087, 537);
            this.contentContainer.SplitterDistance = 778;
            this.contentContainer.TabIndex = 7;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(175)))), ((int)(((byte)(46)))));
            this.contentPanel.Controls.Add(this.btnVerIntermedio);
            this.contentPanel.Controls.Add(this.btnVerAvanzados);
            this.contentPanel.Controls.Add(this.btnVerPrincipiantes);
            this.contentPanel.Controls.Add(this.btnVerTodos);
            this.contentPanel.Controls.Add(this.btnVerAdministradores);
            this.contentPanel.Controls.Add(this.BRefresh);
            this.contentPanel.Controls.Add(this.btnVerEntrenadores);
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
            // 
            // btnVerIntermedio
            // 
            this.btnVerIntermedio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVerIntermedio.AutoSize = true;
            this.btnVerIntermedio.BackColor = System.Drawing.Color.Transparent;
            this.btnVerIntermedio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerIntermedio.FlatAppearance.BorderSize = 0;
            this.btnVerIntermedio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerIntermedio.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerIntermedio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVerIntermedio.Location = new System.Drawing.Point(437, 57);
            this.btnVerIntermedio.Name = "btnVerIntermedio";
            this.btnVerIntermedio.Size = new System.Drawing.Size(143, 38);
            this.btnVerIntermedio.TabIndex = 15;
            this.btnVerIntermedio.Text = "Intermedios";
            this.btnVerIntermedio.UseVisualStyleBackColor = false;
            this.btnVerIntermedio.Click += new System.EventHandler(this.btnVerIntermedio_Click);
            // 
            // btnVerAvanzados
            // 
            this.btnVerAvanzados.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVerAvanzados.AutoSize = true;
            this.btnVerAvanzados.BackColor = System.Drawing.Color.Transparent;
            this.btnVerAvanzados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerAvanzados.FlatAppearance.BorderSize = 0;
            this.btnVerAvanzados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerAvanzados.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerAvanzados.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVerAvanzados.Location = new System.Drawing.Point(585, 57);
            this.btnVerAvanzados.Name = "btnVerAvanzados";
            this.btnVerAvanzados.Size = new System.Drawing.Size(143, 38);
            this.btnVerAvanzados.TabIndex = 14;
            this.btnVerAvanzados.Text = "Avanzados";
            this.btnVerAvanzados.UseVisualStyleBackColor = false;
            this.btnVerAvanzados.Visible = false;
            this.btnVerAvanzados.Click += new System.EventHandler(this.btnVerAvanzados_Click);
            // 
            // btnVerPrincipiantes
            // 
            this.btnVerPrincipiantes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVerPrincipiantes.AutoSize = true;
            this.btnVerPrincipiantes.BackColor = System.Drawing.Color.Transparent;
            this.btnVerPrincipiantes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerPrincipiantes.FlatAppearance.BorderSize = 0;
            this.btnVerPrincipiantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPrincipiantes.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerPrincipiantes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVerPrincipiantes.Location = new System.Drawing.Point(289, 57);
            this.btnVerPrincipiantes.Name = "btnVerPrincipiantes";
            this.btnVerPrincipiantes.Size = new System.Drawing.Size(143, 38);
            this.btnVerPrincipiantes.TabIndex = 13;
            this.btnVerPrincipiantes.Text = "Principiantes";
            this.btnVerPrincipiantes.UseVisualStyleBackColor = false;
            this.btnVerPrincipiantes.Click += new System.EventHandler(this.btnVerPrincipiante_Click);
            // 
            // btnVerTodos
            // 
            this.btnVerTodos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVerTodos.AutoSize = true;
            this.btnVerTodos.BackColor = System.Drawing.Color.Transparent;
            this.btnVerTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerTodos.FlatAppearance.BorderSize = 0;
            this.btnVerTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTodos.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerTodos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVerTodos.Location = new System.Drawing.Point(24, 57);
            this.btnVerTodos.Name = "btnVerTodos";
            this.btnVerTodos.Size = new System.Drawing.Size(115, 38);
            this.btnVerTodos.TabIndex = 12;
            this.btnVerTodos.Text = "Ver todos";
            this.btnVerTodos.UseVisualStyleBackColor = false;
            this.btnVerTodos.Click += new System.EventHandler(this.btnVerTodos_Click);
            // 
            // btnVerAdministradores
            // 
            this.btnVerAdministradores.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVerAdministradores.AutoSize = true;
            this.btnVerAdministradores.BackColor = System.Drawing.Color.Transparent;
            this.btnVerAdministradores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerAdministradores.FlatAppearance.BorderSize = 0;
            this.btnVerAdministradores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerAdministradores.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerAdministradores.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVerAdministradores.Location = new System.Drawing.Point(438, 57);
            this.btnVerAdministradores.Name = "btnVerAdministradores";
            this.btnVerAdministradores.Size = new System.Drawing.Size(143, 38);
            this.btnVerAdministradores.TabIndex = 11;
            this.btnVerAdministradores.Text = "Administradores";
            this.btnVerAdministradores.UseVisualStyleBackColor = false;
            this.btnVerAdministradores.Click += new System.EventHandler(this.btnVerAdministradores_Click);
            // 
            // BRefresh
            // 
            this.BRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BRefresh.FlatAppearance.BorderSize = 0;
            this.BRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRefresh.Image = global::Taller2_G34.Properties.Resources.refresh_page_option;
            this.BRefresh.Location = new System.Drawing.Point(331, 448);
            this.BRefresh.Name = "BRefresh";
            this.BRefresh.Size = new System.Drawing.Size(73, 53);
            this.BRefresh.TabIndex = 9;
            this.BRefresh.UseVisualStyleBackColor = true;
            this.BRefresh.Click += new System.EventHandler(this.BRefresh_Click);
            // 
            // btnVerEntrenadores
            // 
            this.btnVerEntrenadores.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVerEntrenadores.AutoSize = true;
            this.btnVerEntrenadores.BackColor = System.Drawing.Color.Transparent;
            this.btnVerEntrenadores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerEntrenadores.FlatAppearance.BorderSize = 0;
            this.btnVerEntrenadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerEntrenadores.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerEntrenadores.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVerEntrenadores.Location = new System.Drawing.Point(586, 57);
            this.btnVerEntrenadores.Name = "btnVerEntrenadores";
            this.btnVerEntrenadores.Size = new System.Drawing.Size(142, 38);
            this.btnVerEntrenadores.TabIndex = 2;
            this.btnVerEntrenadores.Text = "Entrenadores";
            this.btnVerEntrenadores.UseVisualStyleBackColor = false;
            this.btnVerEntrenadores.Click += new System.EventHandler(this.btnVerEntrenadores_Click);
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
            this.textBoxBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxBusqueda_KeyDown);
            // 
            // BBuscar
            // 
            this.BBuscar.BackColor = System.Drawing.Color.Black;
            this.BBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnEliminar.BackColor = System.Drawing.Color.Black;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.Location = new System.Drawing.Point(551, 451);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(177, 45);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(71)))), ((int)(((byte)(152)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
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
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.Color.DarkGoldenrod;
            this.dataGridView.Location = new System.Drawing.Point(24, 101);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Goldenrod;
            this.dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.RowTemplate.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(704, 344);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick_1);
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
            this.BVerRutinas.BackColor = System.Drawing.Color.Transparent;
            this.BVerRutinas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BVerRutinas.FlatAppearance.BorderSize = 0;
            this.BVerRutinas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVerRutinas.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVerRutinas.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BVerRutinas.Image = global::Taller2_G34.Properties.Resources.lista;
            this.BVerRutinas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BVerRutinas.Location = new System.Drawing.Point(2, 213);
            this.BVerRutinas.Name = "BVerRutinas";
            this.BVerRutinas.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BVerRutinas.Size = new System.Drawing.Size(300, 79);
            this.BVerRutinas.TabIndex = 3;
            this.BVerRutinas.Text = "Rutinas";
            this.BVerRutinas.UseVisualStyleBackColor = false;
            this.BVerRutinas.Click += new System.EventHandler(this.BVerRutinas_Click);
            // 
            // BVerPersonal
            // 
            this.BVerPersonal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BVerPersonal.AutoSize = true;
            this.BVerPersonal.BackColor = System.Drawing.Color.Transparent;
            this.BVerPersonal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BVerPersonal.FlatAppearance.BorderSize = 0;
            this.BVerPersonal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cornsilk;
            this.BVerPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVerPersonal.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVerPersonal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BVerPersonal.Image = global::Taller2_G34.Properties.Resources.id_insignia;
            this.BVerPersonal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BVerPersonal.Location = new System.Drawing.Point(2, 45);
            this.BVerPersonal.Name = "BVerPersonal";
            this.BVerPersonal.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BVerPersonal.Size = new System.Drawing.Size(300, 79);
            this.BVerPersonal.TabIndex = 1;
            this.BVerPersonal.Text = "Personal";
            this.BVerPersonal.UseVisualStyleBackColor = false;
            this.BVerPersonal.Click += new System.EventHandler(this.BVerPersonal_Click);
            // 
            // BVerAlumnos
            // 
            this.BVerAlumnos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BVerAlumnos.AutoSize = true;
            this.BVerAlumnos.BackColor = System.Drawing.Color.Transparent;
            this.BVerAlumnos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BVerAlumnos.FlatAppearance.BorderSize = 0;
            this.BVerAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVerAlumnos.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVerAlumnos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BVerAlumnos.Image = global::Taller2_G34.Properties.Resources.publico_objetivo;
            this.BVerAlumnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BVerAlumnos.Location = new System.Drawing.Point(3, 128);
            this.BVerAlumnos.Name = "BVerAlumnos";
            this.BVerAlumnos.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BVerAlumnos.Size = new System.Drawing.Size(302, 79);
            this.BVerAlumnos.TabIndex = 0;
            this.BVerAlumnos.Text = "Alumnos";
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
        private System.Windows.Forms.Button BRefresh;
        private System.Windows.Forms.Button btnVerAdministradores;
        private System.Windows.Forms.Button btnVerTodos;
        private System.Windows.Forms.Button btnVerIntermedio;
        private System.Windows.Forms.Button btnVerAvanzados;
        private System.Windows.Forms.Button btnVerPrincipiantes;
    }
}