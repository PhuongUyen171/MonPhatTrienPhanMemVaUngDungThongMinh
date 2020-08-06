using DAL.dsShopMPTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhomNguoiDungDAO
    {
        NHOM_NGUOI_DUNGTableAdapter nnd = new NHOM_NGUOI_DUNGTableAdapter();
        public NhomNguoiDungDAO() { }
        public DataTable GetNhomNguoiDung()
        {
            return nnd.GetData();
        }
    }
}
