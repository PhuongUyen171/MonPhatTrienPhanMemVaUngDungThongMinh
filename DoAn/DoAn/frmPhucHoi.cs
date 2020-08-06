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

namespace DoAn
{
    public partial class frmPhucHoi : Office2007Form
    {
        SqlConnection con = new SqlConnection(DoAn.Properties.Settings.Default.ShopMPConnection);
        public frmPhucHoi()
        {
            InitializeComponent();
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if(txtDuongDan.Text==string.Empty)
            {
                MessageBox.Show("Vui lòng nhập tên tập tin.","ERROR");
                return;
            }    
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (File.Exists(@""+txtDuongDan.Text))
                {
                    
                    if (MessageBox.Show("Bạn có muốn phục hồi lại CSDL?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //string DatabaseName = con.Database.ToString();
                        //if(con.State!=ConnectionState.Open)
                        //    con.Open();
                        //SqlCommand command = new SqlCommand("use master", con);
                        //command.ExecuteNonQuery();
                        //command = new SqlCommand(@"restore database "+DatabaseName+" from disk = '"+txtDuongDan.Text+"' use "+DatabaseName, con);
                        //command.ExecuteNonQuery();
                        
                        //con.Close();

                        //MessageBox.Show("Cơ sở dữ liệu khôi phục thành công", "SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Không tìm thấy đường dẫn.", "Thông báo");

            }
            catch (Exception exp)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình phục hồi","ERROR");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDuongDan_ButtonCustomClick(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Backup files | *.bak";
            if(op.ShowDialog()==DialogResult.OK)
            {
                txtDuongDan.Text = op.FileName;
            }    
        }
    }
}
