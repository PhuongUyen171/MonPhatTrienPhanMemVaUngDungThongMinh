using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace BLL_DAL
{
    public class BLL_DAL_ThongKe
    {
        QLShopDataContext data = new QLShopDataContext();
        public IQueryable<KHACH_HANG> loadKH()
        {
            return data.KHACH_HANGs.Select(k => k);
        }
        public bool kh(string mk)
        {
            int dulieu = data.HOA_DONs.Count(t => t.MaKH == mk.ToString());
            try
            {
                if (dulieu == 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IQueryable<CHI_TIET_HOA_DON> loadcthd()
        {
            return data.CHI_TIET_HOA_DONs.Select(k => k);
        }
        //public List<CHI_TIET_HOA_DON> timKiemHoaDonKH(string mahd)
        //{
        //    var dulieu = (from s in data.HOA_DONs
        //                  join q in data.CHI_TIET_HOA_DONs on s.MaHD equals (q.MaHD)
        //                  where s.MaHD == mahd
        //                  select new
        //                  {
        //                      q.MaHD,
        //                      q.MaSP,
        //                      q.GiaVon,
        //                      q.GiaBan,
        //                      q.SoLuong
        //                  }
        //                  );
        //    var kq = dulieu.ToList().ConvertAll(t => new CHI_TIET_HOA_DON()
        //    {
        //        MaHD = t.MaHD,
        //        MaSP = t.MaSP,
        //        GiaVon = t.GiaVon,
        //        GiaBan = t.GiaBan,
        //        SoLuong = t.SoLuong
        //    });
        //    return kq.ToList<CHI_TIET_HOA_DON>();
        //}
        public List<HOA_DON> timKiemhoadon(DateTime day1, DateTime day2)
        {
            var dulieu = (from s in data.HOA_DONs
                          where (s.ThoiGian >= day1 && s.ThoiGian <= day2)
                          select s).ToList();
            return dulieu;
        }
        public List<CHI_TIET_HOA_DON> xemThongCTHD(int ma)
        { 
            var dulieu = (from s in data.CHI_TIET_HOA_DONs
                          where s.MaHD == ma
                          select s).ToList();
           return dulieu;
        }
        public List<HOA_DON> timKiemhoadonTheoNgay(DateTime day1)
        {
            var dulieu = (from s in data.HOA_DONs
                          where s.ThoiGian == day1
                          select s).ToList();
            return dulieu;
        }
        
        public List<HOA_DON> timKiemhoadonTheoNam(DateTime day1)
        {
            var dulieu = (from s in data.HOA_DONs
                          where (s.ThoiGian.Value.Year == day1.Year)
                          select s).ToList();
            return dulieu;
        }
        public List<HOA_DON> timKiemhoadonTheoNamTruoc(DateTime day1)
        {
            int namtruoc = int.Parse(day1.Year.ToString()) - 1;
            var dulieu = (from s in data.HOA_DONs
                          where (s.ThoiGian.Value.Year == namtruoc)
                          select s).ToList();
            return dulieu;
        }
        public IQueryable<HOA_DON> loadHoaDon()
        {
            return data.HOA_DONs.Select(k => k);
        }
        // tra hang
        public IQueryable<PHIEU_TRA_HANG_BAN> loadPhieuTra()
        {
            return data.PHIEU_TRA_HANG_BANs.Select(k => k);
        }
        public List<PHIEU_TRA_HANG_BAN> timKiemPhieuTraTheoNgay(DateTime day1)
        {
                var dulieu = (from s in data.PHIEU_TRA_HANG_BANs
                          where s.ThoiGian == day1
                          select s).ToList();
            return dulieu;
        }
        public List<PHIEU_TRA_HANG_BAN> timKiemPhieutraHangTheoKhoan(DateTime day1, DateTime day2)
        {
            var dulieu = (from s in data.PHIEU_TRA_HANG_BANs
                          where (s.ThoiGian >= day1 && s.ThoiGian <= day2)
                          select s).ToList();
            return dulieu;
        }
        public List<PHIEU_TRA_HANG_BAN> timKiemPhieunTheoNam(DateTime day1)
        {
            var dulieu = (from s in data.PHIEU_TRA_HANG_BANs
                          where (s.ThoiGian.Value.Year == day1.Year)
                          select s).ToList();
            return dulieu;
        }
        public List<PHIEU_TRA_HANG_BAN> timKiemPhieuTheoNamTruoc(DateTime day1)
        {
            int namtruoc = int.Parse(day1.Year.ToString()) - 1;
            var dulieu = (from s in data.PHIEU_TRA_HANG_BANs
                          where (s.ThoiGian.Value.Year == namtruoc)
                          select s).ToList();
            return dulieu;
        }
        public List<CHI_TIET_PHIEU_TRA_HANG_BAN> xemThongPhieuTra(string ma)
        {
            var dulieu = (from s in data.CHI_TIET_PHIEU_TRA_HANG_BANs
                          where s.MaPTB == ma
                          select s).ToList();
            return dulieu;
        }
    }
}
