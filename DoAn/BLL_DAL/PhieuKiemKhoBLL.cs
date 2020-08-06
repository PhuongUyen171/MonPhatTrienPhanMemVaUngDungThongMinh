using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class PhieuKiemKhoBLL
    {
        QLShopDataContext data = new QLShopDataContext();

        public PhieuKiemKhoBLL() { }

        public IQueryable<PHIEU_KIEM_KHO> GetPhieuKiemKho()
        {
            return data.PHIEU_KIEM_KHOs.Select(t => t);
        }

        public bool KiemTraKhoaChinh(string makk)
        {
            PHIEU_KIEM_KHO kk = data.PHIEU_KIEM_KHOs.Where(t => t.MaKiemKho == makk).FirstOrDefault();
            return kk != null;
        }
    }
}
