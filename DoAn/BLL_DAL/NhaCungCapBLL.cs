using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class NhaCungCapBLL
    {
        QLShopDataContext data = new QLShopDataContext();

        public NhaCungCapBLL() { }

        public void ThemNhaCungCap(string ma,string ten, string maThue,string diaChi,string email,string sdt)
        {
            NHA_CUNG_CAP n = new NHA_CUNG_CAP();
            n.MaNCC = ma;
            n.TenNCC = ten;
            n.MaSoThue = maThue;
            n.DiaChi = diaChi;
            n.Email = email;
            n.SDT = sdt;
            n.TongTien = 0;
            data.NHA_CUNG_CAPs.InsertOnSubmit(n);
            data.SubmitChanges();
        }

        public void XoaNhaCungCap(string ma)
        {
            NHA_CUNG_CAP n = data.NHA_CUNG_CAPs.Where(t => t.MaNCC == ma).FirstOrDefault();
            data.NHA_CUNG_CAPs.DeleteOnSubmit(n);
            data.SubmitChanges();
        }

        public void SuaNhaCungCap(string ma, string ten, string maThue, string diaChi, string email, string sdt,long tien)
        {
            NHA_CUNG_CAP n = data.NHA_CUNG_CAPs.Where(t => t.MaNCC == ma).FirstOrDefault();
            n.TenNCC = ten;
            n.DiaChi = diaChi;
            n.MaSoThue = maThue;
            n.Email = email;
            n.SDT = sdt;
            n.TongTien = tien;
            //tổng tiền ko tự tiện sửa
            data.SubmitChanges();
        }

        public bool KiemTraKhoaChinh(string ma)
        {
            NHA_CUNG_CAP n = data.NHA_CUNG_CAPs.Where(t => t.MaNCC == ma).FirstOrDefault();
            return n!=null;
        }

        public IQueryable<NHA_CUNG_CAP> GetNhaCungCap()
        {
            return data.NHA_CUNG_CAPs.Select(t => t);
        }
    }
}
