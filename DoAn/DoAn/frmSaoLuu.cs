using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace DoAn
{
    public partial class frmSaoLuu : Office2007Form
    {
        SqlConnection con = new SqlConnection(DoAn.Properties.Settings.Default.ShopMyPham+"");
        public frmSaoLuu()
        {
            InitializeComponent();
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {

            if(txtTen.Text==string.Empty||txtDuongDan.Text==string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin muốn sao lưu.","ERROR");
                return;
            }
            try
            {
                
                string duongDan = txtDuongDan.Text;
                string tenTep = txtTen.Text;
                bool trangThai = true;

                Cursor.Current = Cursors.WaitCursor;
                if (Directory.Exists(@"" + duongDan))
                {
                    if (File.Exists(@"" + duongDan + "\\" + tenTep))
                    {
                        if (MessageBox.Show(@"Bạn có muốn ghi đè cơ sở dữ liệu đã sao lưu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            File.Delete(@"" + duongDan + "\\" + tenTep);
                        else
                            trangThai = false;
                    }
                }
                else
                    Directory.CreateDirectory(@"" + duongDan);
                if (trangThai)
                {
                    string cmd = @"BACKUP DATABASE " + con.Database.ToString() + " TO DISK='" + txtDuongDan.Text + "\\" + con.Database.ToString() + "_" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".bak'";
                    SqlCommand command = new SqlCommand(cmd, con);
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sao lưu thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình sao lưu");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDuongDan_ButtonCustomClick(object sender, EventArgs e)
        {
            FolderBrowserDialog d = new FolderBrowserDialog();
            if (d.ShowDialog() == DialogResult.OK)
                txtDuongDan.Text = d.SelectedPath;
        }

        private void frmSaoLuu_Load(object sender, EventArgs e)
        {
            txtTen.Text = con.Database.ToString();
            txtDuongDan.Text = @"C:\Users\PC\Desktop";
        }
    }
}
