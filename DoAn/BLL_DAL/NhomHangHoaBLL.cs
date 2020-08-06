using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class NhomHangHoaBLL
    {
        QLShopDataContext data = new QLShopDataContext();

        public NhomHangHoaBLL() { }

        public IQueryable<THE_LOAI_SAN_PHAM> GetNhomHangHoa()
        {
            return data.THE_LOAI_SAN_PHAMs.Select(t => t);
        }

        public void ThemNhomHangHoa(string ma,string ten)
        {
            THE_LOAI_SAN_PHAM t = new THE_LOAI_SAN_PHAM();
            t.MaLoaiSP = ma;
            t.TenLoaiSP = ten;
            data.THE_LOAI_SAN_PHAMs.InsertOnSubmit(t);
            data.SubmitChanges();
        }

        public void XoaNhomHangHoa(string ma)
        {
            THE_LOAI_SAN_PHAM tl = data.THE_LOAI_SAN_PHAMs.Where(t => t.MaLoaiSP == ma).FirstOrDefault();
            data.THE_LOAI_SAN_PHAMs.DeleteOnSubmit(tl);
            data.SubmitChanges();
        }

        public void SuaNhomHangHoa(string ma,string ten)
        {
            THE_LOAI_SAN_PHAM th = data.THE_LOAI_SAN_PHAMs.Where(t => t.MaLoaiSP == ma).FirstOrDefault();
            th.TenLoaiSP = ten;
            data.SubmitChanges();
        }

        public bool KiemTraKhoaChinh(string ma)
        {
            THE_LOAI_SAN_PHAM tl = data.THE_LOAI_SAN_PHAMs.Where(t => t.MaLoaiSP == ma).FirstOrDefault();
            return tl != null;
        }
    }
}
