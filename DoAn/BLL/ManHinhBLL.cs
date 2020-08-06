using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ManHinhBLL
    {
        ManHinhDAO mh = new ManHinhDAO();
        public ManHinhBLL() { }
        public DataTable GetManHinhKoCQ(string ma)
        {
            return mh.GetManHinhKoCQ(ma);
        }
        public DataTable GetManHinhCQ(string ma)
        {
            return mh.GetManHinhCQ(ma);
        }
    }
}
