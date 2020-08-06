using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DAL;

namespace BLL
{
    public class ChucVuBLL
    {
        ChucVuDAO cv = new ChucVuDAO();
        public ChucVuBLL() { }

        public bool KiemTraKhoaChinh(string ma)
        {
            return cv.KiemTraKhoaChinh(ma);
        }

        public bool ThemChucVu(string ma,string ten)
        {
            return cv.InsertChucVu(ma, ten);
        }
        
        public bool SuaChucVu(string ma,string ten)
        {
            return cv.UpdateChucVu(ma, ten);
        }

        public DataTable GetChucVu()
        {
            return cv.GetChucVu();
        }

        public bool XoaChucVu(string ma)
        {
            return cv.DeleteChucVu(ma);
        }
       
    }
}
