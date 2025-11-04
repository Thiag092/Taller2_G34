namespace Taller2_G34
{
    partial class FormEditarPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.comboBoxTipoPlan = new System.Windows.Forms.ComboBox();
            this.lblTipoPlan = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cantSeries = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cantRepeticiones = new System.Windows.Forms.NumericUpDown();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEjercicioNuevo = new System.Windows.Forms.Label();
            this.btnNuevoEjercicio = new System.Windows.Forms.Button();
            this.cboEjercicioCatalogo = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtNombrePlan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvEjercicios = new System.Windows.Forms.DataGridView();
            this.cboDias = new System.Windows.Forms.ComboBox();
            this.labelDia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantRepeticiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicios)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.labelTitulo);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(175)))), ((int)(((byte)(46)))));
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1234, 694);
            this.splitContainer1.SplitterDistance = 123;
            this.splitContainer1.TabIndex = 11;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(175)))), ((int)(((byte)(46)))));
            this.labelTitulo.Location = new System.Drawing.Point(49, 45);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(204, 31);
            this.labelTitulo.TabIndex = 56;
            this.labelTitulo.Text = "EDITAR PLAN";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Taller2_G34.Properties.Resources.ChatGPT_Image_1_sept_2025__17_46_04;
            this.pictureBox1.Location = new System.Drawing.Point(1040, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(175)))), ((int)(((byte)(46)))));
            this.panel2.Controls.Add(this.lblMensaje);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.btnQuitar);
            this.panel2.Controls.Add(this.comboBoxTipoPlan);
            this.panel2.Controls.Add(this.lblTipoPlan);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btnAgregar);
            this.panel2.Controls.Add(this.txtNombrePlan);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Controls.Add(this.dgvEjercicios);
            this.panel2.Controls.Add(this.cboDias);
            this.panel2.Controls.Add(this.labelDia);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1234, 567);
            this.panel2.TabIndex = 0;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Black;
            this.lblMensaje.Location = new System.Drawing.Point(520, 176);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(539, 27);
            this.lblMensaje.TabIndex = 60;
            this.lblMensaje.Text = "Selecciona un día para comenzar a editar esta rutina";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotal.Location = new System.Drawing.Point(400, 396);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(161, 19);
            this.lblTotal.TabIndex = 59;
            this.lblTotal.Text = "Total de ejercicios: 0";
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.Black;
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitar.Location = new System.Drawing.Point(965, 396);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(201, 46);
            this.btnQuitar.TabIndex = 58;
            this.btnQuitar.Text = "🗑️ Quitar Ejercicio";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // comboBoxTipoPlan
            // 
            this.comboBoxTipoPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxTipoPlan.FormattingEnabled = true;
            this.comboBoxTipoPlan.Location = new System.Drawing.Point(55, 103);
            this.comboBoxTipoPlan.Name = "comboBoxTipoPlan";
            this.comboBoxTipoPlan.Size = new System.Drawing.Size(289, 24);
            this.comboBoxTipoPlan.TabIndex = 57;
            // 
            // lblTipoPlan
            // 
            this.lblTipoPlan.AutoSize = true;
            this.lblTipoPlan.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoPlan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTipoPlan.Location = new System.Drawing.Point(50, 75);
            this.lblTipoPlan.Name = "lblTipoPlan";
            this.lblTipoPlan.Size = new System.Drawing.Size(123, 25);
            this.lblTipoPlan.TabIndex = 56;
            this.lblTipoPlan.Text = "Tipo de Plan";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.MenuText;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Location = new System.Drawing.Point(809, 494);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(157, 45);
            this.btnCancelar.TabIndex = 52;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTiempo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cantSeries);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cantRepeticiones);
            this.panel1.Controls.Add(this.btnConfirmar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblEjercicioNuevo);
            this.panel1.Controls.Add(this.btnNuevoEjercicio);
            this.panel1.Controls.Add(this.cboEjercicioCatalogo);
            this.panel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(55, 235);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 305);
            this.panel1.TabIndex = 55;
            this.panel1.Visible = false;
            // 
            // txtTiempo
            // 
            this.txtTiempo.Location = new System.Drawing.Point(224, 214);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(55, 27);
            this.txtTiempo.TabIndex = 70;
            this.txtTiempo.Text = "30";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 20);
            this.label6.TabIndex = 69;
            this.label6.Text = "Tiempo en segundos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 68;
            this.label5.Text = "Series";
            // 
            // cantSeries
            // 
            this.cantSeries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cantSeries.Location = new System.Drawing.Point(235, 174);
            this.cantSeries.Name = "cantSeries";
            this.cantSeries.Size = new System.Drawing.Size(44, 27);
            this.cantSeries.TabIndex = 67;
            this.cantSeries.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 66;
            this.label4.Text = "Repeticiones";
            // 
            // cantRepeticiones
            // 
            this.cantRepeticiones.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cantRepeticiones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cantRepeticiones.Location = new System.Drawing.Point(235, 136);
            this.cantRepeticiones.Name = "cantRepeticiones";
            this.cantRepeticiones.Size = new System.Drawing.Size(44, 27);
            this.cantRepeticiones.TabIndex = 65;
            this.cantRepeticiones.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.Black;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConfirmar.Location = new System.Drawing.Point(27, 264);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(235, 36);
            this.btnConfirmar.TabIndex = 64;
            this.btnConfirmar.Text = "Confirmar y Agregar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 19);
            this.label3.TabIndex = 63;
            this.label3.Text = "Agregar ejercicio del Catálogo";
            // 
            // lblEjercicioNuevo
            // 
            this.lblEjercicioNuevo.AutoSize = true;
            this.lblEjercicioNuevo.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEjercicioNuevo.Location = new System.Drawing.Point(3, 29);
            this.lblEjercicioNuevo.Name = "lblEjercicioNuevo";
            this.lblEjercicioNuevo.Size = new System.Drawing.Size(146, 19);
            this.lblEjercicioNuevo.TabIndex = 62;
            this.lblEjercicioNuevo.Text = "Añadir al catálogo";
            // 
            // btnNuevoEjercicio
            // 
            this.btnNuevoEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(71)))), ((int)(((byte)(152)))));
            this.btnNuevoEjercicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoEjercicio.FlatAppearance.BorderSize = 0;
            this.btnNuevoEjercicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoEjercicio.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoEjercicio.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNuevoEjercicio.Location = new System.Drawing.Point(248, 19);
            this.btnNuevoEjercicio.Name = "btnNuevoEjercicio";
            this.btnNuevoEjercicio.Size = new System.Drawing.Size(31, 35);
            this.btnNuevoEjercicio.TabIndex = 61;
            this.btnNuevoEjercicio.Text = "+";
            this.btnNuevoEjercicio.UseVisualStyleBackColor = false;
            this.btnNuevoEjercicio.Click += new System.EventHandler(this.btnNuevoEjercicio_Click);
            // 
            // cboEjercicioCatalogo
            // 
            this.cboEjercicioCatalogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEjercicioCatalogo.FormattingEnabled = true;
            this.cboEjercicioCatalogo.Location = new System.Drawing.Point(7, 99);
            this.cboEjercicioCatalogo.Name = "cboEjercicioCatalogo";
            this.cboEjercicioCatalogo.Size = new System.Drawing.Size(272, 28);
            this.cboEjercicioCatalogo.TabIndex = 60;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Black;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Location = new System.Drawing.Point(55, 202);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(289, 36);
            this.btnAgregar.TabIndex = 54;
            this.btnAgregar.Text = "➕ Agregar Ejercicios";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtNombrePlan
            // 
            this.txtNombrePlan.Location = new System.Drawing.Point(55, 39);
            this.txtNombrePlan.Name = "txtNombrePlan";
            this.txtNombrePlan.Size = new System.Drawing.Size(289, 22);
            this.txtNombrePlan.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(50, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 51;
            this.label1.Text = "Nombre del Plan";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(71)))), ((int)(((byte)(152)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Location = new System.Drawing.Point(1009, 495);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(157, 45);
            this.btnGuardar.TabIndex = 50;
            this.btnGuardar.Text = "💾 Guardar Plan";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvEjercicios
            // 
            this.dgvEjercicios.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dgvEjercicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEjercicios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEjercicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEjercicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvEjercicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEjercicios.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvEjercicios.EnableHeadersVisualStyles = false;
            this.dgvEjercicios.Location = new System.Drawing.Point(400, 31);
            this.dgvEjercicios.Name = "dgvEjercicios";
            this.dgvEjercicios.RowHeadersVisible = false;
            this.dgvEjercicios.RowHeadersWidth = 51;
            this.dgvEjercicios.RowTemplate.Height = 24;
            this.dgvEjercicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEjercicios.Size = new System.Drawing.Size(766, 359);
            this.dgvEjercicios.TabIndex = 46;
            // 
            // cboDias
            // 
            this.cboDias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDias.FormattingEnabled = true;
            this.cboDias.Location = new System.Drawing.Point(55, 158);
            this.cboDias.Name = "cboDias";
            this.cboDias.Size = new System.Drawing.Size(289, 24);
            this.cboDias.TabIndex = 45;
            // 
            // labelDia
            // 
            this.labelDia.AutoSize = true;
            this.labelDia.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelDia.Location = new System.Drawing.Point(50, 130);
            this.labelDia.Name = "labelDia";
            this.labelDia.Size = new System.Drawing.Size(117, 25);
            this.labelDia.TabIndex = 36;
            this.labelDia.Text = "Día del Plan";
            // 
            // FormEditarPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1234, 694);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormEditarPlan";
            this.Text = "FormEditarPlan";
            this.Load += new System.EventHandler(this.FormEditarPlan_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantRepeticiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.ComboBox comboBoxTipoPlan;
        private System.Windows.Forms.Label lblTipoPlan;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTiempo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown cantSeries;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown cantRepeticiones;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEjercicioNuevo;
        private System.Windows.Forms.Button btnNuevoEjercicio;
        private System.Windows.Forms.ComboBox cboEjercicioCatalogo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtNombrePlan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvEjercicios;
        private System.Windows.Forms.ComboBox cboDias;
        private System.Windows.Forms.Label labelDia;
        private System.Windows.Forms.Label lblMensaje;
    }
}