using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.SqlServer.Server;

namespace BLL
{
    public class KhachHangBLL
    {
        KhachHangDAO kh = new KhachHangDAO();
        public KhachHangBLL() { }
        
        public DataTable GetKhachHang()
        {
            return kh.GetKhachHang();
        }

        public bool ThemKhachHang(string maKH, string tenKH, string maLoai, DateTime ngaySinh, DateTime ngayDK, string cmnd, string email, string dt, string diaChi, int tongTien)
        {
            return kh.InsertCustom(maKH, tenKH, maLoai, ngaySinh, ngayDK, cmnd, email, dt, diaChi, tongTien);
        }
        
        public bool KiemTraKhoaChinh(string maKH)
        {
            return kh.KiemTraKhoaChinh(maKH);
        }

        public bool XoaKhachHang(string maKH)
        {
            return kh.DeleteCustom(maKH);
        }

        public bool SuaKhachHang(string maKH, string tenKH, string maLoai, DateTime ngaySinh, DateTime ngayDK, string cmnd, string email, string dt, string diaChi, int tongTien)
        {
            return kh.UpdateCustom(maKH, tenKH, maLoai, ngaySinh, ngayDK, cmnd, email, dt, diaChi, tongTien);
        }

        public DataRow TimKiemKhachHang(string ma)
        {
            return kh.SearchCustom(ma);
        }
    }
}
