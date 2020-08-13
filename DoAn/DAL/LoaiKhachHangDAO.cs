using DAL.dsShopMPTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiKhachHangDAO
    {
        LOAI_KHACH_HANGTableAdapter l = new LOAI_KHACH_HANGTableAdapter();
        public LoaiKhachHangDAO() { }

        public DataTable GetLoaiKH()
        {
            return l.GetData();
        }

        public bool KiemTraKhoaChinh(string ma)
        {
            return l.KiemTraKhoaChinh(ma).Rows.Count!=0;
        }

        public bool InsertTypeCustom(string ma,string ten,long duoi,long tren,int sale)
        {
            return l.Insert(ma, ten, duoi, tren, sale)==1;
        }

        public bool DeleteTypeCustom(string ma)
        {
            return l.DeleteQuery(ma) == 1;
        }

        public bool UpdateTypeCustom(string ma, string ten, long duoi, long tren, int sale)
        {
            return l.UpdateQuery(ten, duoi, tren, sale,ma) == 1;
        }

        public DataRow  SearchTypeCustom(string ma)
        {
            return l.KiemTraKhoaChinh(ma).FirstOrDefault();
        }
    }
}
