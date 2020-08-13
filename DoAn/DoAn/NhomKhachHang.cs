using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class NhomKhachHang
    {
        string ma, ten;
        long ghTren, ghDuoi;
        int sale;
        string _stt;

        //Get,set
        public string STT
        {
            get { return _stt; }
            set { _stt = value; }
        }
        public string MaNhomKH
        {
            get { return ma; }
            set { ma = value; }
        }
        public string TenNhomKH
        {
            get { return ten; }
            set { ten = value; }
        }
        public long GioiHanTren
        {
            get { return ghTren; }
            set
            {
                if (value < ghDuoi)
                    ghTren = ghDuoi;
                else
                    ghTren = value;
            }
        }
        public long GioiHanDuoi
        {
            get { return ghDuoi; }
            set { ghDuoi = value; }
        }
        public int GiamGia
        {
            get { return sale; }
            set { sale = value; }
        }

        //PTKT
        public NhomKhachHang()
        {
            ma = "";
            ten = "";
            ghDuoi = 0;
            ghTren = 0;
            sale = 0;
        }
        public NhomKhachHang(string m, string t, long duoi, long tren, int sale)
        {
            ma = m;
            ten = t;
            ghDuoi = duoi;
            ghTren = tren;
            this.sale = sale;
        }
    }
}
