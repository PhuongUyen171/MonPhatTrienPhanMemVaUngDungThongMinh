using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class NhomNguoiDungBLL
    {
        NhomNguoiDungDAO nnd = new NhomNguoiDungDAO();
        public NhomNguoiDungBLL()
        { }
        public DataTable GetNhomNguoiDung()
        {
            return nnd.GetNhomNguoiDung();
        }
    }
}
