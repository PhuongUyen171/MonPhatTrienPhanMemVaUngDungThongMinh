using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using System.IO;
using System.Windows.Forms;

namespace DoAn
{
    class NguoiDung
    {
        public int CheckConfig()
        {
            if (Properties.Settings.Default.ShopMPConnection == string.Empty)
                return 1;
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ShopMPConnection);
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                return 0;
            }
            catch
            {
                return 2;
            }
        }

        public LoginResult CheckUser(string user, string pass)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from DANG_NHAP where TaiKhoan='" + user + "' and MatKhau='" + pass + "'", Properties.Settings.Default.ShopMPConnection);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception)
            {
                return LoginResult.Invalid;
            }

            if (dt.Rows.Count == 0)
                return LoginResult.Invalid;
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
                return LoginResult.Disable;
            return LoginResult.Success;
        }

        public void SaveConfig(string server, string user, string pass, string db)
        {
            DoAn.Properties.Settings.Default.ShopMyPham = "Data Source=" + server + ";Initial Catalog=" + db + ";User ID=" + user + ";pwd=" + pass;
            DoAn.Properties.Settings.Default.ShopMyPham= "Data Source=" + server + ";Initial Catalog=" + db + ";User ID=" + user + ";pwd=" + pass;
            //DoAn_PTPMvaUDTM.Properties.Settings.Default.KetNoi = "Data Source=" + server + ";Initial Catalog=" + db + ";User ID=" + user + ";pwd=" + pass;
            DoAn.Properties.Settings.Default.Save();
        }

        public void SaoLuuDuLieu(string duongDan,string tenTep)
        {
            bool trangThai = true;

            Cursor.Current = Cursors.WaitCursor;

            if (Directory.Exists(@""+duongDan))
            {
                if (File.Exists(@""+duongDan+"\\"+tenTep))
                {
                    if (MessageBox.Show(@"Bạn có muốn sao lưu cơ sở dữ liệu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        File.Delete(@"" + duongDan + "\\" + tenTep);
                    else
                        trangThai = false;
                }
            }
            else
                Directory.CreateDirectory(@""+duongDan);
            if (trangThai)
            {
                //Kết nối
                SqlConnection connect;
                string con = "Data Source = localhost; Initial Catalog=QLShopMP ;Integrated Security = True;";
                connect = new SqlConnection(con);
                connect.Open();

                //Thực thi 
                SqlCommand command;
                command = new SqlCommand(@"backup database QLShopMP to disk ='"+duongDan+"\\"+tenTep+"' with init,stats=10", connect);
                command.ExecuteNonQuery();
                connect.Close();

                MessageBox.Show("Cơ sở dữ liệu đã được sao lưu thành công.", "SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
