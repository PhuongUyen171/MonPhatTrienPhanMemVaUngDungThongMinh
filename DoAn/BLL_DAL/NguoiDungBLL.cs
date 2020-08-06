using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class NguoiDungBLL
    {
        QLShopDataContext data = new QLShopDataContext();

        public NguoiDungBLL() { }

        public IQueryable<NGUOI_DUNG_NHOM_NGUOI_DUNG> GetNguoiDung()
        {
            return data.NGUOI_DUNG_NHOM_NGUOI_DUNGs.Select(t => t);
        }

        public void ThemNguoiDung(string tk,string manhom)
        {
            NGUOI_DUNG_NHOM_NGUOI_DUNG n = new NGUOI_DUNG_NHOM_NGUOI_DUNG();
            n.TaiKhoan = tk;
            n.MaNhom = manhom;
            data.NGUOI_DUNG_NHOM_NGUOI_DUNGs.InsertOnSubmit(n);
            data.SubmitChanges();
        }

        public void XoaNguoiDung(string tk)
        {
            NGUOI_DUNG_NHOM_NGUOI_DUNG n = data.NGUOI_DUNG_NHOM_NGUOI_DUNGs.Where(t => t.TaiKhoan == tk).FirstOrDefault();
            data.NGUOI_DUNG_NHOM_NGUOI_DUNGs.DeleteOnSubmit(n);
            data.SubmitChanges();
        }

        public void SuaNguoiDung(string taiKhoan,string maNhom)
        {
            NGUOI_DUNG_NHOM_NGUOI_DUNG n = data.NGUOI_DUNG_NHOM_NGUOI_DUNGs.Where(t => t.TaiKhoan == taiKhoan).FirstOrDefault();
            n.MaNhom = maNhom;
            data.SubmitChanges();
        }

        public string GetMaNhomTheoNguoiDung(string taiKhoan)
        {
            NGUOI_DUNG_NHOM_NGUOI_DUNG nd = data.NGUOI_DUNG_NHOM_NGUOI_DUNGs.Where(t=>t.TaiKhoan==taiKhoan).FirstOrDefault();
            return nd.MaNhom;
        }
    }
}
