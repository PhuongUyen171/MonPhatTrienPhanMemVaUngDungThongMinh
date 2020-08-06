using DAL.dsShopMPTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhanQuyenDAO
    {
        PHAN_QUYENTableAdapter pq = new PHAN_QUYENTableAdapter();
        public PhanQuyenDAO()
        {

        }
        public bool UpdatePhanQuyen(string manhom,string mamh,bool quyen)
        {
            return pq.Update(quyen,manhom,mamh,!quyen) == 1;
        }
    }
}
