using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class ThuongHieuBLL
    {
        QLShopDataContext data = new QLShopDataContext();
        public ThuongHieuBLL() { }

        public IQueryable<THUONG_HIEU> GetThuongHieu()
        {
            return data.THUONG_HIEUs.Select(t=>t);
        }

        public bool KiemTraKhoaChinh(string ma)
        {
            THUONG_HIEU kt = data.THUONG_HIEUs.Where(t => t.MaTH == ma).FirstOrDefault();
            return kt != null;
        }

        public void ThemThuongHieu(string ma,string ten, string hinh)
        {
            THUONG_HIEU t = new THUONG_HIEU();
            t.MaTH = ma;
            t.TenTH = ten;
            t.Images = hinh;
            data.THUONG_HIEUs.InsertOnSubmit(t);
            data.SubmitChanges();
        }

        public void XoaThuongHieu(string ma)
        {
            THUONG_HIEU th = data.THUONG_HIEUs.Where(t => t.MaTH == ma).FirstOrDefault();
            data.THUONG_HIEUs.DeleteOnSubmit(th);
            data.SubmitChanges();
        }

        public void SuaThuongHieu(string ma, string ten,string hinh)
        {
            THUONG_HIEU th = data.THUONG_HIEUs.Where(t => t.MaTH == ma).FirstOrDefault();
            th.TenTH = ten;
            th.Images = hinh;
            data.SubmitChanges();
        }

        public string TimHinhAnh(string ma)
        {
            THUONG_HIEU th = data.THUONG_HIEUs.Where(t => t.MaTH == ma).FirstOrDefault();
            if (th!=null)
                return th.Images;
            return "KoXacDinh.jpg";
        }

        public THUONG_HIEU TimThuongHieu(string ma)
        {
            THUONG_HIEU th = data.THUONG_HIEUs.Where(t => t.MaTH == ma).FirstOrDefault();
            return th;
        }
    }
}
