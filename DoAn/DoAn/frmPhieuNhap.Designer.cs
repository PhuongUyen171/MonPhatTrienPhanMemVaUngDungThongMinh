namespace DoAn
{
    partial class frmPhieuNhap
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuNhap));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grThongTinPN = new System.Windows.Forms.GroupBox();
            this.btnLuuPN = new DevComponents.DotNetBar.ButtonX();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtmThoiGian = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.txtMaPN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.cboPhieuNhap = new System.Windows.Forms.ComboBox();
            this.btnSuaCTPN = new DevComponents.DotNetBar.ButtonX();
            this.btnXoaCTPN = new DevComponents.DotNetBar.ButtonX();
            this.btnThemCTPN = new DevComponents.DotNetBar.ButtonX();
            this.cboSP = new System.Windows.Forms.ComboBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.txtGG = new System.Windows.Forms.TextBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtgvChiTietPN = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextPhieuNhap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuXoaSP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSuaSP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInPN = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.grThongTinPN.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTietPN)).BeginInit();
            this.contextPhieuNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.grThongTinPN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtgvChiTietPN, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1038, 549);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grThongTinPN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grThongTinPN, 2);
            this.grThongTinPN.Controls.Add(this.btnLuuPN);
            this.grThongTinPN.Controls.Add(this.txtTongTien);
            this.grThongTinPN.Controls.Add(this.txtGiamGia);
            this.grThongTinPN.Controls.Add(this.label6);
            this.grThongTinPN.Controls.Add(this.dtmThoiGian);
            this.grThongTinPN.Controls.Add(this.label5);
            this.grThongTinPN.Controls.Add(this.cboNhaCungCap);
            this.grThongTinPN.Controls.Add(this.cboNhanVien);
            this.grThongTinPN.Controls.Add(this.txtMaPN);
            this.grThongTinPN.Controls.Add(this.label4);
            this.grThongTinPN.Controls.Add(this.label1);
            this.grThongTinPN.Controls.Add(this.label3);
            this.grThongTinPN.Controls.Add(this.label2);
            this.grThongTinPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grThongTinPN.Location = new System.Drawing.Point(3, 3);
            this.grThongTinPN.Name = "grThongTinPN";
            this.grThongTinPN.Size = new System.Drawing.Size(1032, 103);
            this.grThongTinPN.TabIndex = 0;
            this.grThongTinPN.TabStop = false;
            this.grThongTinPN.Text = "Thông tin phiếu nhập";
            // 
            // btnLuuPN
            // 
            this.btnLuuPN.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuuPN.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuuPN.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuPN.Image")));
            this.btnLuuPN.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLuuPN.Location = new System.Drawing.Point(914, 19);
            this.btnLuuPN.Name = "btnLuuPN";
            this.btnLuuPN.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnLuuPN.Size = new System.Drawing.Size(109, 78);
            this.btnLuuPN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLuuPN.TabIndex = 14;
            this.btnLuuPN.Text = "Lưu thông tin phiếu nhập";
            this.btnLuuPN.Click += new System.EventHandler(this.btnLuuPN_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(704, 63);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(150, 24);
            this.txtTongTien.TabIndex = 13;
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(704, 23);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(150, 24);
            this.txtGiamGia.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(631, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tổng tiền";
            // 
            // dtmThoiGian
            // 
            this.dtmThoiGian.CustomFormat = "dd/MM/yyyy";
            this.dtmThoiGian.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmThoiGian.Location = new System.Drawing.Point(416, 61);
            this.dtmThoiGian.Name = "dtmThoiGian";
            this.dtmThoiGian.Size = new System.Drawing.Size(150, 24);
            this.dtmThoiGian.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(631, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Giảm giá";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(416, 21);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(150, 26);
            this.cboNhaCungCap.TabIndex = 10;
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(119, 58);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(150, 26);
            this.cboNhanVien.TabIndex = 9;
            // 
            // txtMaPN
            // 
            this.txtMaPN.Location = new System.Drawing.Point(119, 23);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.Size = new System.Drawing.Size(150, 24);
            this.txtMaPN.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Thời gian";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã phiếu nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nhà cung cấp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nhân viên";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cboPhieuNhap);
            this.panel1.Controls.Add(this.btnSuaCTPN);
            this.panel1.Controls.Add(this.btnXoaCTPN);
            this.panel1.Controls.Add(this.btnThemCTPN);
            this.panel1.Controls.Add(this.cboSP);
            this.panel1.Controls.Add(this.txtSL);
            this.panel1.Controls.Add(this.txtGG);
            this.panel1.Controls.Add(this.txtGiaNhap);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 434);
            this.panel1.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 18);
            this.label12.TabIndex = 18;
            this.label12.Text = "Phiếu nhập";
            // 
            // cboPhieuNhap
            // 
            this.cboPhieuNhap.FormattingEnabled = true;
            this.cboPhieuNhap.Location = new System.Drawing.Point(102, 54);
            this.cboPhieuNhap.Name = "cboPhieuNhap";
            this.cboPhieuNhap.Size = new System.Drawing.Size(200, 26);
            this.cboPhieuNhap.TabIndex = 17;
            this.cboPhieuNhap.TextChanged += new System.EventHandler(this.cboPhieuNhap_TextChanged);
            // 
            // btnSuaCTPN
            // 
            this.btnSuaCTPN.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSuaCTPN.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSuaCTPN.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaCTPN.Image")));
            this.btnSuaCTPN.Location = new System.Drawing.Point(197, 281);
            this.btnSuaCTPN.Name = "btnSuaCTPN";
            this.btnSuaCTPN.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSuaCTPN.Size = new System.Drawing.Size(50, 50);
            this.btnSuaCTPN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSuaCTPN.TabIndex = 16;
            this.btnSuaCTPN.Click += new System.EventHandler(this.btnSuaCTPN_Click);
            // 
            // btnXoaCTPN
            // 
            this.btnXoaCTPN.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoaCTPN.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoaCTPN.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaCTPN.Image")));
            this.btnXoaCTPN.Location = new System.Drawing.Point(129, 281);
            this.btnXoaCTPN.Name = "btnXoaCTPN";
            this.btnXoaCTPN.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnXoaCTPN.Size = new System.Drawing.Size(50, 50);
            this.btnXoaCTPN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXoaCTPN.TabIndex = 15;
            this.btnXoaCTPN.Click += new System.EventHandler(this.btnXoaCTPN_Click);
            // 
            // btnThemCTPN
            // 
            this.btnThemCTPN.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThemCTPN.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThemCTPN.Image = ((System.Drawing.Image)(resources.GetObject("btnThemCTPN.Image")));
            this.btnThemCTPN.Location = new System.Drawing.Point(60, 281);
            this.btnThemCTPN.Name = "btnThemCTPN";
            this.btnThemCTPN.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnThemCTPN.Size = new System.Drawing.Size(50, 50);
            this.btnThemCTPN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThemCTPN.TabIndex = 14;
            this.btnThemCTPN.Click += new System.EventHandler(this.btnThemCTPN_Click);
            // 
            // cboSP
            // 
            this.cboSP.FormattingEnabled = true;
            this.cboSP.Location = new System.Drawing.Point(102, 94);
            this.cboSP.Name = "cboSP";
            this.cboSP.Size = new System.Drawing.Size(200, 26);
            this.cboSP.TabIndex = 13;
            this.cboSP.TextChanged += new System.EventHandler(this.cboSP_TextChanged);
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(102, 217);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(200, 24);
            this.txtSL.TabIndex = 12;
            // 
            // txtGG
            // 
            this.txtGG.Location = new System.Drawing.Point(102, 178);
            this.txtGG.Name = "txtGG";
            this.txtGG.Size = new System.Drawing.Size(200, 24);
            this.txtGG.TabIndex = 11;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Enabled = false;
            this.txtGiaNhap.Location = new System.Drawing.Point(102, 136);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(200, 24);
            this.txtGiaNhap.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 223);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 18);
            this.label11.TabIndex = 4;
            this.label11.Text = "Số lượng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 18);
            this.label10.TabIndex = 3;
            this.label10.Text = "Giảm giá";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "Giá nhập";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "Sản phẩm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(24, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(263, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "CHI TIẾT PHIẾU NHẬP";
            // 
            // dtgvChiTietPN
            // 
            this.dtgvChiTietPN.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtgvChiTietPN.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvChiTietPN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvChiTietPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvChiTietPN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column8});
            this.dtgvChiTietPN.ContextMenuStrip = this.contextPhieuNhap;
            this.dtgvChiTietPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvChiTietPN.Location = new System.Drawing.Point(314, 112);
            this.dtgvChiTietPN.Name = "dtgvChiTietPN";
            this.dtgvChiTietPN.ReadOnly = true;
            this.dtgvChiTietPN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvChiTietPN.Size = new System.Drawing.Size(721, 434);
            this.dtgvChiTietPN.TabIndex = 2;
            this.dtgvChiTietPN.SelectionChanged += new System.EventHandler(this.dtgvChiTietPN_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaPN";
            this.Column1.HeaderText = "Mã phiếu nhập";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MaSP";
            this.Column2.HeaderText = "Mã sản phẩm";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "GiaNhap";
            dataGridViewCellStyle2.Format = "N0";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Giá nhập";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "GiamGia";
            this.Column4.HeaderText = "Giảm giá";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SoLuong";
            this.Column5.HeaderText = "Số lượng";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "PHIEU_NHAP";
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "SAN_PHAM";
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // contextPhieuNhap
            // 
            this.contextPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.contextPhieuNhap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuXoaSP,
            this.mnuSuaSP,
            this.mnuInPN});
            this.contextPhieuNhap.Name = "contextPhieuNhap";
            this.contextPhieuNhap.Size = new System.Drawing.Size(173, 76);
            // 
            // mnuXoaSP
            // 
            this.mnuXoaSP.Name = "mnuXoaSP";
            this.mnuXoaSP.Size = new System.Drawing.Size(172, 24);
            this.mnuXoaSP.Text = "Xóa sản phẩm";
            this.mnuXoaSP.Click += new System.EventHandler(this.mnuXoaSP_Click);
            // 
            // mnuSuaSP
            // 
            this.mnuSuaSP.Name = "mnuSuaSP";
            this.mnuSuaSP.Size = new System.Drawing.Size(172, 24);
            this.mnuSuaSP.Text = "Sửa sản phẩm";
            this.mnuSuaSP.Click += new System.EventHandler(this.mnuSuaSP_Click);
            // 
            // mnuInPN
            // 
            this.mnuInPN.Name = "mnuInPN";
            this.mnuInPN.Size = new System.Drawing.Size(172, 24);
            this.mnuInPN.Text = "In phiếu nhập";
            this.mnuInPN.Click += new System.EventHandler(this.mnuInPN_Click);
            // 
            // frmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 549);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHIẾU NHẬP";
            this.Load += new System.EventHandler(this.frmPhieuNhap_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grThongTinPN.ResumeLayout(false);
            this.grThongTinPN.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTietPN)).EndInit();
            this.contextPhieuNhap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grThongTinPN;
        private DevComponents.DotNetBar.ButtonX btnLuuPN;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtmThoiGian;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.TextBox txtMaPN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgvChiTietPN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSP;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.TextBox txtGG;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboPhieuNhap;
        private DevComponents.DotNetBar.ButtonX btnSuaCTPN;
        private DevComponents.DotNetBar.ButtonX btnXoaCTPN;
        private DevComponents.DotNetBar.ButtonX btnThemCTPN;
        private System.Windows.Forms.ContextMenuStrip contextPhieuNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuXoaSP;
        private System.Windows.Forms.ToolStripMenuItem mnuSuaSP;
        private System.Windows.Forms.ToolStripMenuItem mnuInPN;
    }
}