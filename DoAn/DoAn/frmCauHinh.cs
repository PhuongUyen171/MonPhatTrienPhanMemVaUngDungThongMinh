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
using System.Data.Sql;
using System.Data.SqlClient;

namespace DoAn
{
    public partial class frmCauHinh : Office2007Form
    {
        NguoiDung CauHinh = new NguoiDung();
        public frmCauHinh()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(cboDatabase.Text==""||cboServer.Text==""||txtPass.Text==""||txtUser.Text=="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.","ERROR");
                return;
            }    
            CauHinh.SaveConfig(cboServer.Text, txtUser.Text, txtPass.Text, cboDatabase.Text);
            this.Close();
            MessageBox.Show("Thay đổi chuỗi kết nối thành công.", "Thông báo");
        }

        private void cboDatabase_DropDown(object sender, EventArgs e)
        {
            cboDatabase.DataSource = GetDBName(cboServer.Text, txtUser.Text, txtPass.Text);
            cboDatabase.DisplayMember = "name";
        }

        private void cboServer_DropDown(object sender, EventArgs e)
        {
            cboServer.DataSource = GetServerName();
            cboServer.DisplayMember = "ServerName";
        }
        public DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }
        public DataTable GetDBName(string server, string user, string pass)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases", new SqlConnection("Data Source=" + server + ";Initial Catalog=master;User ID=" + user + ";pwd=" + pass));
            da.Fill(dt);
            return dt;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
