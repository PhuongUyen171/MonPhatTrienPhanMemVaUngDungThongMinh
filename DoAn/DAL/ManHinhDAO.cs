using DAL.dsShopMPTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManHinhDAO
    {
        MAN_HINHTableAdapter mh = new MAN_HINHTableAdapter();
        public ManHinhDAO() { }
        public DataTable GetManHinhKoCQ(string ma)
        {
            return mh.GetMHKoCoQuyen(ma);
        }
        public DataTable GetManHinhCQ(string ma)
        {
            return mh.GetMHCoQuyen(ma);
        }
    }
}
