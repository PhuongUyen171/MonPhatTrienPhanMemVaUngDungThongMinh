using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class ChucVu
    {
        string ma, ten;

        //get,set
        public string MaChucVu
        {
            get { return ma; }
            set { ma = value; }
        }
        public string TenChucVu
        {
            get { return ten; }
            set { ten = value; }
        }

        //PTKT
        public ChucVu()
        {
            ma = "";
            ten = "";
        }
        public ChucVu(string m,string t)
        {
            ma = m;
            ten = t;
        }
    }
}
