
using DAL.dsShopMPTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChucVuDAO
    {
        CHUC_VUTableAdapter cv = new CHUC_VUTableAdapter();
        public ChucVuDAO() { }

        public bool KiemTraKhoaChinh(string ma)
        {
            return cv.KiemTraKhoaChinh(ma).Rows.Count != 0;
        }
        
        public bool InsertChucVu(string ma,string ten)
        {
            return cv.Insert(ma, ten)==1;
        }
        
        public bool UpdateChucVu(string ma,string ten)
        {
            return cv.UpdateQuery(ten, ma)==1;
        }

        public bool DeleteChucVu(string ma)
        {
            return cv.DeleteQuery(ma)==1;
        }

        public DataTable GetChucVu()
        {
            return cv.GetData();
        }
    }
}
