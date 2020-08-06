using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PhanQuyenBLL
    {
        PhanQuyenDAO pq = new PhanQuyenDAO();
        public PhanQuyenBLL() { }

        public bool SuaPhanQuyen(string maNhom, string maManHinh,bool quyen)
        {
            return pq.UpdatePhanQuyen(maNhom, maManHinh, quyen);
        }
    }
}
