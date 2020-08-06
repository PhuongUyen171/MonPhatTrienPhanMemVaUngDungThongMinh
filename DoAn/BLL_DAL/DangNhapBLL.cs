using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class DangNhapBLL
    {
        QLShopDataContext data = new QLShopDataContext();
        public DangNhapBLL() { }

        public string GetPassDangNhap(string ma)
        {
            DANG_NHAP dn = data.DANG_NHAPs.Where(t => t.TaiKhoan == ma).FirstOrDefault();
            return dn.MatKhau;
        }

        public void DoiMatKhau(string taikhoan,string mk1,string mk2)
        {
            DANG_NHAP dn = data.DANG_NHAPs.Where(t => t.TaiKhoan == taikhoan).FirstOrDefault();
            if(dn.MatKhau==mk1)
            {
                dn.MatKhau = mk2;
                data.SubmitChanges();
            }    
        }

        public void ThemTaiKhoa(string manv,string taiKhoan,string pass,bool tinhTrang)
        {
            DANG_NHAP dn = new DANG_NHAP();
            dn.MaNV = manv;
            dn.TaiKhoan = taiKhoan;
            dn.MatKhau = pass;
            dn.TinhTrang = tinhTrang;
            data.DANG_NHAPs.InsertOnSubmit(dn);
            data.SubmitChanges();
        }

        public void XoaTaiKhoan(string taiKhoan)
        {
            DANG_NHAP dn = data.DANG_NHAPs.Where(t => t.TaiKhoan == taiKhoan).FirstOrDefault();
            data.DANG_NHAPs.DeleteOnSubmit(dn);
            data.SubmitChanges();
        }

        public void SuaTaiKhoan(string manv, string taiKhoan, string pass, bool tinhTrang)
        {
            DANG_NHAP dn = data.DANG_NHAPs.Where(t => t.TaiKhoan == taiKhoan).FirstOrDefault();
            dn.MaNV = manv;
            dn.MatKhau = pass;
            dn.TinhTrang = tinhTrang;
            data.SubmitChanges();
        }

        public bool KiemTraKhoaChinh(string taiKhoan)
        {
            DANG_NHAP dn = data.DANG_NHAPs.Where(t => t.TaiKhoan == taiKhoan).FirstOrDefault();
            return dn != null;
        }

        public DANG_NHAP TimTaiKhoan(string ma)
        {
            DANG_NHAP dn = data.DANG_NHAPs.Where(t => t.MaNV == ma).FirstOrDefault();
            return dn;
        }
        
    }
}
