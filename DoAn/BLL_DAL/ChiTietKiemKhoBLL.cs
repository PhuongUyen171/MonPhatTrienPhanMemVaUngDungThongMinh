using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class ChiTietKiemKhoBLL
    {
        QLShopDataContext data = new QLShopDataContext();
        public ChiTietKiemKhoBLL() { }

        public IQueryable<CHI_TIET_PHIEU_KIEM_KHO> GetPhieuKiemKho(string makk)
        {
            return data.CHI_TIET_PHIEU_KIEM_KHOs.Where(t => t.MaKiemKho == makk);
        }

        public bool KiemTraKhoaChinh(string makk,string masp)
        {
            CHI_TIET_PHIEU_KIEM_KHO ct = data.CHI_TIET_PHIEU_KIEM_KHOs.Where(t => t.MaKiemKho == makk && t.MaSP == masp).FirstOrDefault();
            return ct != null;
        }

    }
}
