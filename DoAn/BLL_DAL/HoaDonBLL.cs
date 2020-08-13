using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class HoaDonBLL
    {
        QLShopDataContext data = new QLShopDataContext();

        public HoaDonBLL() { }

        public int ThemHoaDon(string maKH,string maNV,DateTime thoiGian,int giamGia)
        {
            HOA_DON hd = new HOA_DON();
            hd.MaKH = maKH;
            hd.MaNV = maNV;
            hd.ThoiGian = thoiGian;
            hd.GiamGia = giamGia;
            hd.TongTien = 0;
            data.HOA_DONs.InsertOnSubmit(hd);
            data.SubmitChanges();
            return hd.MaHD;
        }
        
    }
}
