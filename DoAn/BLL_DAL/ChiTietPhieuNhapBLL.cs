using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class ChiTietPhieuNhapBLL
    {
        QLShopDataContext data = new QLShopDataContext();

        public ChiTietPhieuNhapBLL() { }

        public IQueryable<CHI_TIET_PHIEU_NHAP> GetCTPN(string ma)
        {
            return data.CHI_TIET_PHIEU_NHAPs.Where(t => t.MaPN == ma);
        }

        public void ThemCTPN(string maPN,string maSP,int sl,int giamGia,long giaNhap) 
        {
            CHI_TIET_PHIEU_NHAP ct = new CHI_TIET_PHIEU_NHAP();
            ct.MaPN = maPN;
            ct.MaSP = maSP;
            ct.SoLuong = sl;
            ct.GiamGia = giamGia;
            ct.GiaNhap = giaNhap;
            data.CHI_TIET_PHIEU_NHAPs.InsertOnSubmit(ct);
            data.SubmitChanges();
        }

        public void XoaCTPN(string maPN,string maSP) 
        {
            CHI_TIET_PHIEU_NHAP ct = data.CHI_TIET_PHIEU_NHAPs.Where(t => t.MaPN == maPN && t.MaSP == maSP).FirstOrDefault();
            data.CHI_TIET_PHIEU_NHAPs.DeleteOnSubmit(ct);
            data.SubmitChanges();
        }
        
        public void SuaCTPN(string maPN, string maSP, int sl, int giamGia, long giaNhap)
        {
            CHI_TIET_PHIEU_NHAP ct = data.CHI_TIET_PHIEU_NHAPs.Where(t => t.MaPN == maPN && t.MaSP == maSP).FirstOrDefault();
            ct.SoLuong = sl;
            ct.GiamGia = giamGia;
            ct.GiaNhap = giaNhap;
            data.SubmitChanges();
        }

        public bool KiemTraKhoaChinh(string mapn,string masp)
        {
            CHI_TIET_PHIEU_NHAP ct = data.CHI_TIET_PHIEU_NHAPs.Where(t => t.MaPN == mapn && t.MaSP == masp).FirstOrDefault();
            return ct != null;
        }

        public long TinhTongTien(string mapn)
        {
            long? kq = (long)data.CHI_TIET_PHIEU_NHAPs.Where(t => t.MaPN == mapn).Sum(t => t.GiaNhap * t.SoLuong*(1-t.GiamGia/100));
            if(kq==null)
                return 0;
            return (long)kq;
        }
    }
}
