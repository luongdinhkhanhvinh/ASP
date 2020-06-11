using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class HOADON
    {
        private int _maNV;

        public int MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }

        private float _tongTien;

        public float TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }

        private string _trangThai;

        public string TrangThai
        {
            get { return _trangThai; }
            set { _trangThai = value; }
        }

        public HOADON()
        {
            this._maNV = 0;
            this._tongTien = 0;
            this._trangThai = "";
            
        }

        public HOADON(int manv,float tongtien, string trangthai)
        {
            this._maNV = manv;
            this._tongTien = tongtien;
            this._trangThai = trangthai;
        }

    }
}
