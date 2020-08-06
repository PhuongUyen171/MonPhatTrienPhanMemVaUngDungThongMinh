using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ThongKeBLL
    {
        ThongKeDAL tk = new ThongKeDAL();

        public ThongKeBLL() { }
        public DataTable ThongKeTheoThang(int nam)
        {
            return tk.GetThongKeTheoThang(nam);
        }
        public DataTable ThongKeTheoNam(int bd,int kt)
        {
            return tk.GetThongKeTheoNam(bd, kt);
        }
    }
}
