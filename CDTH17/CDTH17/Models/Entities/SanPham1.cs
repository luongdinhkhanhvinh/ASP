using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDTH17.Models.Entities
{
    public class SanPham1
    {
        string _MaSP;
        public string MaSP
        {
            get { return _MaSP; }
            set { _MaSP = value; }
        }
        string _TenSP;
        public string TenSP
        {
            get { return _TenSP; }
            set { _TenSP = value; }
        }
        int _Gia;
        public int Gia
        {
            get { return _Gia; }
            set { _Gia = value; }
        }
        string _Anh;
        public string Anh
        {
            get { return _Anh; }
            set { _Anh = value; }
        }
        string _Mota;
        public string Mota
        {
            get { return _Mota; }
            set { _Mota = value; }
        }

    }
}