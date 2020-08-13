using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class LoaiKhachHangBLL
    {
        LoaiKhachHangDAO l = new LoaiKhachHangDAO();
        public LoaiKhachHangBLL() { }

        public DataTable GetLoaiKH()
        {
            return l.GetLoaiKH();
        }

        public bool KiemTraKhoaChinh(string ma)
        {
            return l.KiemTraKhoaChinh(ma);
        }

        public bool ThemLoaiKH(string ma,string ten,long duoi,long tren, int sale)
        {
            return l.InsertTypeCustom(ma, ten, duoi, tren, sale);
        }

        public bool SuaLoaiKH(string ma, string ten, long duoi, long tren, int sale)
        {
            return l.UpdateTypeCustom(ma, ten, duoi, tren, sale);
        }

        public bool XoaLoaiKH(string ma)
        {
            return l.DeleteTypeCustom(ma);
        }

        public DataRow TimLoaiKH(string ma)
        {
            return l.SearchTypeCustom(ma);
        }
    }
}
