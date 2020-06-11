using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class CHITIETHOADON
    {
        private int _maHD;

        public int MaHD
        {
            get { return _maHD; }
            set { _maHD = value; }
        }
        private int _maSP;

        public int MaSP
        {
            get { return _maSP; }
            set { _maSP = value; }
        }
        private DateTime _ngayLapHD;

        public DateTime NgayLapHD
        {
            get { return _ngayLapHD; }
            set { _ngayLapHD = value; }
        }

        private float _giaSP;

        public float GiaSP
        {
            get { return _giaSP; }
            set { _giaSP = value; }
        }

        private int _soLuong;

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
       
        private string _khuyenMai;

        public string KhuyenMai
        {
            get { return _khuyenMai; }
            set { _khuyenMai = value; }
        }
        private float _thanhTien;

        public float ThanhTien
        {
            get { return _thanhTien; }
            set { _thanhTien = value; }
        }

        public CHITIETHOADON()
        {
            this._maHD = 0;
            this._maSP = 0;
            this._ngayLapHD = DateTime.Parse("1/1/2019");
            this._giaSP = 0;
            this._soLuong = 0;
            this._khuyenMai = "";
            this._thanhTien = 0;
        }
        public CHITIETHOADON(int mahd,int masp, DateTime ngaylaphd,float giasp,int soluong,string khuyenmai ,float thanhtien)
        {
            this._maHD = mahd;
            this._maSP = masp;
            this._ngayLapHD = ngaylaphd;
            this._giaSP = giasp;
            this._soLuong = soluong;
            this._khuyenMai = khuyenmai;
            this._thanhTien = thanhtien;
        }



    }
}
