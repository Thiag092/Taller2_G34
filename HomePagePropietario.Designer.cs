namespace Taller2_G34
{
    partial class HomePagePropietario
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BUsuarios = new System.Windows.Forms.Button();
            this.labelTextoBienvenida = new System.Windows.Forms.Label();
            this.textBoxBusqueda = new System.Windows.Forms.TextBox();
            this.BBuscar = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.comboFiltroPlanes = new System.Windows.Forms.ComboBox();
            this.labelTotalAlumnos = new System.Windows.Forms.Label();
            this.chartPagos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartInscriptos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.picBoxEstadisticas = new System.Windows.Forms.PictureBox();
            this.BGraficoPagos = new System.Windows.Forms.Button();
            this.BGraficoInscriptos = new System.Windows.Forms.Button();
            this.BRefresh = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.contentContainer = new System.Windows.Forms.SplitContainer();
            this.BPagos = new System.Windows.Forms.Button();
            this.BEstadisticas = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.labelAdmin = new System.Windows.Forms.Label();
            this.homeContainer = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartInscriptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEstadisticas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentContainer)).BeginInit();
            this.contentContainer.Panel1.SuspendLayout();
            this.contentContainer.Panel2.SuspendLayout();
            this.contentContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homeContainer)).BeginInit();
            this.homeContainer.Panel1.SuspendLayout();
            this.homeContainer.Panel2.SuspendLayout();
            this.homeContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BUsuarios
            // 
            this.BUsuarios.AutoSize = true;
            this.BUsuarios.BackColor = System.Drawing.Color.Black;
            this.BUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BUsuarios.FlatAppearance.BorderSize = 0;
            this.BUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BUsuarios.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUsuarios.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BUsuarios.Location = new System.Drawing.Point(66, 45);
            this.BUsuarios.Name = "BUsuarios";
            this.BUsuarios.Size = new System.Drawing.Size(197, 58);
            this.BUsuarios.TabIndex = 1;
            this.BUsuarios.Text = "Usuarios";
            this.BUsuarios.UseVisualStyleBackColor = false;
            this.BUsuarios.Click += new System.EventHandler(this.BUsuarios_Click);
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
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.comboFiltroPlanes);
            this.contentPanel.Controls.Add(this.labelTotalAlumnos);
            this.contentPanel.Controls.Add(this.chartPagos);
            this.contentPanel.Controls.Add(this.chartInscriptos);
            this.contentPanel.Controls.Add(this.picBoxEstadisticas);
            this.contentPanel.Controls.Add(this.BGraficoPagos);
            this.contentPanel.Controls.Add(this.BGraficoInscriptos);
            this.contentPanel.Controls.Add(this.BRefresh);
            this.contentPanel.Controls.Add(this.textBoxBusqueda);
            this.contentPanel.Controls.Add(this.BBuscar);
            this.contentPanel.Controls.Add(this.btnEliminar);
            this.contentPanel.Controls.Add(this.btnAgregar);
            this.contentPanel.Controls.Add(this.labelTitulo);
            this.contentPanel.Controls.Add(this.dataGridView);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(910, 639);
            this.contentPanel.TabIndex = 2;
            this.contentPanel.Visible = false;
            this.contentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.contentPanel_Paint);
            // 
            // comboFiltroPlanes
            // 
            this.comboFiltroPlanes.FormattingEnabled = true;
            this.comboFiltroPlanes.Location = new System.Drawing.Point(773, 64);
            this.comboFiltroPlanes.Name = "comboFiltroPlanes";
            this.comboFiltroPlanes.Size = new System.Drawing.Size(121, 24);
            this.comboFiltroPlanes.TabIndex = 16;
            this.comboFiltroPlanes.SelectedIndexChanged += new System.EventHandler(this.comboFiltroPlanes_SelectedIndexChanged);
            // 
            // labelTotalAlumnos
            // 
            this.labelTotalAlumnos.AutoSize = true;
            this.labelTotalAlumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalAlumnos.Location = new System.Drawing.Point(264, 574);
            this.labelTotalAlumnos.Name = "labelTotalAlumnos";
            this.labelTotalAlumnos.Size = new System.Drawing.Size(229, 25);
            this.labelTotalAlumnos.TabIndex = 15;
            this.labelTotalAlumnos.Text = "Total alumnos activos:";
            this.labelTotalAlumnos.Visible = false;
            // 
            // chartPagos
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPagos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPagos.Legends.Add(legend1);
            this.chartPagos.Location = new System.Drawing.Point(24, 126);
            this.chartPagos.Name = "chartPagos";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPagos.Series.Add(series1);
            this.chartPagos.Size = new System.Drawing.Size(883, 386);
            this.chartPagos.TabIndex = 14;
            this.chartPagos.Text = "chart1";
            this.chartPagos.Visible = false;
            // 
            // chartInscriptos
            // 
            chartArea2.Name = "ChartArea1";
            this.chartInscriptos.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartInscriptos.Legends.Add(legend2);
            this.chartInscriptos.Location = new System.Drawing.Point(24, 103);
            this.chartInscriptos.Name = "chartInscriptos";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartInscriptos.Series.Add(series2);
            this.chartInscriptos.Size = new System.Drawing.Size(883, 409);
            this.chartInscriptos.TabIndex = 13;
            this.chartInscriptos.Text = "chart1";
            this.chartInscriptos.Visible = false;
            this.chartInscriptos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartInscriptos_MouseClick);
            // 
            // picBoxEstadisticas
            // 
            this.picBoxEstadisticas.Location = new System.Drawing.Point(24, 109);
            this.picBoxEstadisticas.Name = "picBoxEstadisticas";
            this.picBoxEstadisticas.Size = new System.Drawing.Size(713, 403);
            this.picBoxEstadisticas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxEstadisticas.TabIndex = 11;
            this.picBoxEstadisticas.TabStop = false;
            // 
            // BGraficoPagos
            // 
            this.BGraficoPagos.FlatAppearance.BorderSize = 0;
            this.BGraficoPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGraficoPagos.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGraficoPagos.Location = new System.Drawing.Point(208, 45);
            this.BGraficoPagos.Name = "BGraficoPagos";
            this.BGraficoPagos.Size = new System.Drawing.Size(193, 58);
            this.BGraficoPagos.TabIndex = 10;
            this.BGraficoPagos.Text = "Metodos de pago";
            this.BGraficoPagos.UseVisualStyleBackColor = true;
            this.BGraficoPagos.Click += new System.EventHandler(this.BGraficoPagos_Click);
            // 
            // BGraficoInscriptos
            // 
            this.BGraficoInscriptos.FlatAppearance.BorderSize = 0;
            this.BGraficoInscriptos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGraficoInscriptos.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGraficoInscriptos.Location = new System.Drawing.Point(24, 45);
            this.BGraficoInscriptos.Name = "BGraficoInscriptos";
            this.BGraficoInscriptos.Size = new System.Drawing.Size(193, 58);
            this.BGraficoInscriptos.TabIndex = 9;
            this.BGraficoInscriptos.Text = "Inscriptos por mes";
            this.BGraficoInscriptos.UseVisualStyleBackColor = true;
            this.BGraficoInscriptos.Click += new System.EventHandler(this.BGraficoInscriptos_Click);
            // 
            // BRefresh
            // 
            this.BRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BRefresh.FlatAppearance.BorderSize = 0;
            this.BRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRefresh.Image = global::Taller2_G34.Properties.Resources.refresh_page_option;
            this.BRefresh.Location = new System.Drawing.Point(328, 518);
            this.BRefresh.Name = "BRefresh";
            this.BRefresh.Size = new System.Drawing.Size(73, 53);
            this.BRefresh.TabIndex = 8;
            this.BRefresh.UseVisualStyleBackColor = true;
            this.BRefresh.Click += new System.EventHandler(this.BRefresh_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Maroon;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.Location = new System.Drawing.Point(551, 518);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(177, 45);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Green;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Location = new System.Drawing.Point(24, 518);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(177, 45);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
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
            this.dataGridView.Location = new System.Drawing.Point(24, 112);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Goldenrod;
            this.dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.RowTemplate.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(704, 400);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
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
            this.contentContainer.Panel2.Controls.Add(this.BPagos);
            this.contentContainer.Panel2.Controls.Add(this.BUsuarios);
            this.contentContainer.Panel2.Controls.Add(this.BEstadisticas);
            this.contentContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint_1);
            this.contentContainer.Panel2MinSize = 200;
            this.contentContainer.Size = new System.Drawing.Size(1232, 639);
            this.contentContainer.SplitterDistance = 910;
            this.contentContainer.TabIndex = 7;
            // 
            // BPagos
            // 
            this.BPagos.AutoSize = true;
            this.BPagos.BackColor = System.Drawing.Color.Black;
            this.BPagos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BPagos.FlatAppearance.BorderSize = 0;
            this.BPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BPagos.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPagos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BPagos.Location = new System.Drawing.Point(66, 255);
            this.BPagos.Name = "BPagos";
            this.BPagos.Size = new System.Drawing.Size(197, 56);
            this.BPagos.TabIndex = 2;
            this.BPagos.Text = "Pagos";
            this.BPagos.UseVisualStyleBackColor = false;
            this.BPagos.Click += new System.EventHandler(this.BPagos_Click);
            // 
            // BEstadisticas
            // 
            this.BEstadisticas.AutoSize = true;
            this.BEstadisticas.BackColor = System.Drawing.Color.Black;
            this.BEstadisticas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEstadisticas.FlatAppearance.BorderSize = 0;
            this.BEstadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEstadisticas.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEstadisticas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BEstadisticas.Location = new System.Drawing.Point(66, 152);
            this.BEstadisticas.Name = "BEstadisticas";
            this.BEstadisticas.Size = new System.Drawing.Size(197, 56);
            this.BEstadisticas.TabIndex = 0;
            this.BEstadisticas.Text = "Estadisticas";
            this.BEstadisticas.UseVisualStyleBackColor = false;
            this.BEstadisticas.Click += new System.EventHandler(this.BEstadisticas_Click);
            // 
            // BSalir
            // 
            this.BSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BSalir.BackColor = System.Drawing.SystemColors.MenuText;
            this.BSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BSalir.Location = new System.Drawing.Point(1031, 23);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(157, 50);
            this.BSalir.TabIndex = 5;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // labelAdmin
            // 
            this.labelAdmin.AutoSize = true;
            this.labelAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(201)))), ((int)(((byte)(19)))));
            this.labelAdmin.Location = new System.Drawing.Point(125, 30);
            this.labelAdmin.Name = "labelAdmin";
            this.labelAdmin.Size = new System.Drawing.Size(301, 32);
            this.labelAdmin.TabIndex = 4;
            this.labelAdmin.Text = "Panel del Propietario";
            this.labelAdmin.Click += new System.EventHandler(this.labelAdmin_Click);
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
            this.homeContainer.Size = new System.Drawing.Size(1232, 736);
            this.homeContainer.SplitterDistance = 93;
            this.homeContainer.TabIndex = 8;
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
            // HomePagePropietario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 736);
            this.Controls.Add(this.homeContainer);
            this.Name = "HomePagePropietario";
            this.Text = "Panel del Propietario";
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartInscriptos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEstadisticas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contentContainer.Panel1.ResumeLayout(false);
            this.contentContainer.Panel1.PerformLayout();
            this.contentContainer.Panel2.ResumeLayout(false);
            this.contentContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contentContainer)).EndInit();
            this.contentContainer.ResumeLayout(false);
            this.homeContainer.Panel1.ResumeLayout(false);
            this.homeContainer.Panel1.PerformLayout();
            this.homeContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.homeContainer)).EndInit();
            this.homeContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BUsuarios;
        private System.Windows.Forms.Label labelTextoBienvenida;
        private System.Windows.Forms.TextBox textBoxBusqueda;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.SplitContainer contentContainer;
        private System.Windows.Forms.Button BEstadisticas;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Label labelAdmin;
        private System.Windows.Forms.SplitContainer homeContainer;
        private System.Windows.Forms.Button BPagos;
        private System.Windows.Forms.Button BRefresh;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button BGraficoInscriptos;
        private System.Windows.Forms.Button BGraficoPagos;
        private System.Windows.Forms.PictureBox picBoxEstadisticas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartInscriptos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPagos;
        private System.Windows.Forms.Label labelTotalAlumnos;
        private System.Windows.Forms.ComboBox comboFiltroPlanes;
    }
}