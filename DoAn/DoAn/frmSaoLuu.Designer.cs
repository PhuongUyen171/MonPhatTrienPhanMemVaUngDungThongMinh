namespace DoAn
{
    partial class frmSaoLuu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaoLuu));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThucHien = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.txtDuongDan = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTen = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(71, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "SAO LƯU HỆ THỐNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đường dẫn hệ thống";
            // 
            // btnThucHien
            // 
            this.btnThucHien.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThucHien.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThucHien.Image = ((System.Drawing.Image)(resources.GetObject("btnThucHien.Image")));
            this.btnThucHien.Location = new System.Drawing.Point(147, 152);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnThucHien.Size = new System.Drawing.Size(120, 40);
            this.btnThucHien.TabIndex = 5;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(287, 152);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnThoat.Size = new System.Drawing.Size(100, 40);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtDuongDan
            // 
            // 
            // 
            // 
            this.txtDuongDan.Border.Class = "TextBoxBorder";
            this.txtDuongDan.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDuongDan.ButtonCustom.Checked = true;
            this.txtDuongDan.ButtonCustom.Symbol = "";
            this.txtDuongDan.ButtonCustom.SymbolColor = System.Drawing.Color.Black;
            this.txtDuongDan.ButtonCustom.Visible = true;
            this.txtDuongDan.Location = new System.Drawing.Point(168, 105);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.PreventEnterBeep = true;
            this.txtDuongDan.Size = new System.Drawing.Size(223, 24);
            this.txtDuongDan.TabIndex = 7;
            this.txtDuongDan.ButtonCustomClick += new System.EventHandler(this.txtDuongDan_ButtonCustomClick);
            // 
            // txtTen
            // 
            // 
            // 
            // 
            this.txtTen.Border.Class = "TextBoxBorder";
            this.txtTen.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTen.Location = new System.Drawing.Point(168, 64);
            this.txtTen.Name = "txtTen";
            this.txtTen.PreventEnterBeep = true;
            this.txtTen.Size = new System.Drawing.Size(223, 24);
            this.txtTen.TabIndex = 8;
            // 
            // frmSaoLuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 217);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtDuongDan);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmSaoLuu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAO LƯU";
            this.Load += new System.EventHandler(this.frmSaoLuu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnThucHien;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDuongDan;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTen;
    }
}