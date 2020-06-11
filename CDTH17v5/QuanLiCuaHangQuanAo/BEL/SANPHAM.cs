using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class SANPHAM
    {
        private int _maLoaiSP;

        public int MaLoaiSP
        {
            get { return _maLoaiSP; }
            set { _maLoaiSP = value; }
        }
        private int _maKM;

        public int MaKM
        {
            get { return _maKM; }
            set { _maKM = value; }
        }
        private int _maNSX;

        public int MaNSX
        {
            get { return _maNSX; }
            set { _maNSX = value; }
        }
        private string _tenSP;

        public string TenSP
        {
            get { return _tenSP; }
            set { _tenSP = value; }
        }
        private string _moTa;

        public string MoTa
        {
            get { return _moTa; }
            set { _moTa = value; }
        }
        private string _size;

        public string Size
        {
            get { return _size; }
            set { _size = value; }
        }
        private string _mau;

        public string Mau
        {
            get { return _mau; }
            set { _mau = value; }
        }
        private string _hinh;

        public string Hinh
        {
            get { return _hinh; }
            set { _hinh = value; }
        }
        private int _slTon;

        public int SlTon
        {
            get { return _slTon; }
            set { _slTon = value; }
        }

        private float _gia;

        public float Gia
        {
            get { return _gia; }
            set { _gia = value; }
        }
        public SANPHAM()
        {
            this._maLoaiSP = 0;
            this._maKM = 0;
            this._maNSX = 0;
            this._tenSP = "";
            this._moTa = "";
            this._size = "";
            this._mau = "";
            this._hinh = "";
            this._slTon = 0;
            this._gia = 0;
        }

        public SANPHAM(int MaLoaiSP, int MaKM,int MaNSX , string TenSP, string MoTa,string Size, string Mau,string Hinh,int slton,float Gia)
        {
            this._maLoaiSP = MaLoaiSP;
            this._maKM = MaKM;
            this._maNSX = MaNSX;
            this._tenSP = TenSP;
            this._moTa = MoTa;
            this._size = Size;
            this._mau = Mau;
            this._hinh = Hinh;
            this._slTon = slton;
            this._gia = Gia;
        }
        


        
    }
}
