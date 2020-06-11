using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class NHANVIEN
    {
        //private int _maLoaiNV;

        //public int MaLoaiNV
        //{
        //    get { return _maLoaiNV; }
        //    set { _maLoaiNV = value; }
        //}
        private string _tenTaiKhoan;

        public string TenTaiKhoan
        {
            get { return _tenTaiKhoan; }
            set { _tenTaiKhoan = value; }
        }
        //private string _matKhau;

        //public string MatKhau
        //{
        //    get { return _matKhau; }
        //    set { _matKhau = value; }
        //}
        private string _hoTen;

        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }
        private string _phai;

        public string Phai
        {
            get { return _phai; }
            set { _phai = value; }
        }
        private string _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private DateTime _ngaySinh;

        public DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }
        private string _sdt;

        public string Sdt
        {
            get { return _sdt; }
            set { _sdt = value; }
        }
        private string _cmnd;

        public string Cmnd
        {
            get { return _cmnd; }
            set { _cmnd = value; }
        }
        private string _trangThai;

        public string TrangThai
        {
            get { return _trangThai; }
            set { _trangThai = value; }
        }

        public NHANVIEN()
        {
            //this._maLoaiNV = 0;
            this._tenTaiKhoan = "";
            //this._matKhau = "";
            this._hoTen = "";
            this._phai = "";
            this._diaChi = "";
            this._ngaySinh = DateTime.Parse("1/1/1999");
            this._sdt = "";
            this._cmnd = "";
            this._trangThai = "";
        }

        public NHANVIEN(/*int maloainv,string matkhau,*/string tentaikhoan, string hoten, string phai, string diachi, DateTime ngaysinh, string sdt, string cmnd, string trangthai)
        {
            //this._maLoaiNV = maloainv;
            this._tenTaiKhoan = tentaikhoan;
            //this._matKhau = matkhau;
            this._hoTen = hoten;
            this._phai = phai;
            this._diaChi = diachi;
            this._ngaySinh = ngaysinh;
            this._sdt = sdt;
            this._cmnd = cmnd;
            this._trangThai = trangthai;
        }

    }
}
