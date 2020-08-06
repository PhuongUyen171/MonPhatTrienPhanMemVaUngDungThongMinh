using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    
    public class ChucVu
    {
        public string _ma;
        public string _ten;

        //Get,set
        public string MaChucVu
        {
            get { return _ma; }
            set { _ma = value; }
        }
        public string TenChucVu
        {
            get { return _ten; }
            set { _ten = value; }
        }    
        public ChucVu() { }
        public ChucVu(string ma, string ten)
        {
            this.MaChucVu = ma;
            this.TenChucVu = ten;
        }
        public ChucVu(ChucVu c)
        {
            this.MaChucVu = c.MaChucVu;
            this.TenChucVu = c.TenChucVu;
        }
    }
}
