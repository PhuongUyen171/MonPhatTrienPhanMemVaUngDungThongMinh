using DAL.dsShopMPTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThongKeDAL
    {
        HOA_DONTableAdapter h = new HOA_DONTableAdapter();
        public ThongKeDAL() { }
        public DataTable GetThongKeTheoNam(int namBD,int namKT)
        {
            return h.GetThongKeTheoNam(namBD,namKT);
        }
        public DataTable GetThongKeTheoThang(int nam)
        {
            return h.GetThongKeTheoThang(nam);
        }
    }
}
