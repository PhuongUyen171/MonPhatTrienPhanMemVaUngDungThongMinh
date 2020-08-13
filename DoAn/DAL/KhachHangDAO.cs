using DAL.dsShopMPTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAO
    {
        KHACH_HANGTableAdapter kh = new KHACH_HANGTableAdapter();

        public KhachHangDAO()
        {

        }

        public DataTable GetKhachHang()
        {
            return kh.GetData();
        }

        public bool InsertCustom(string maKH,string tenKH,string maLoai,DateTime ngaySinh, DateTime ngayDK, string cmnd,string email,string dt,string diaChi,int tongTien)
        {
            return kh.Insert(maKH, tenKH, maLoai, ngaySinh, ngayDK, cmnd, email, dt, diaChi, tongTien)==1;
        }
        
        public bool KiemTraKhoaChinh(string maKH)
        {
            return kh.KiemTraKhoaChinh(maKH).Rows.Count != 0;
        }

        public bool DeleteCustom(string maKH)
        {
            return kh.DeleteQuery(maKH)==1;
        }

        public bool UpdateCustom(string maKH, string tenKH, string maLoai, DateTime ngaySinh, DateTime ngayDK, string cmnd, string email, string dt, string diaChi, int tongTien)
        {
            return kh.UpdateQuery(tenKH,maLoai,ngaySinh.ToString(),ngayDK.ToString(),cmnd,email,dt,diaChi,tongTien,maKH)==1;
        }

        public DataRow SearchCustom(string ma)
        {
            return kh.KiemTraKhoaChinh(ma).FirstOrDefault();
        }
    }
}
