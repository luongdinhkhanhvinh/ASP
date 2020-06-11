using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class KHUYENMAI
    {
       
        private string _uuDai;

        public string UuDai
        {
            get { return _uuDai; }
            set { _uuDai = value; }
        }
        private DateTime _ngayBatDau;

        public DateTime NgayBatDau
        {
            get { return _ngayBatDau; }
            set { _ngayBatDau = value; }
        }
        private DateTime _ngayKetThuc;

        public DateTime NgayKetThuc
        {
            get { return _ngayKetThuc; }
            set { _ngayKetThuc = value; }
        }
        public KHUYENMAI()
        {
           
            this._uuDai = "";
            this._ngayBatDau = DateTime.Now;
            this._ngayKetThuc = DateTime.Now;
        }

        public KHUYENMAI(string uudai,DateTime ngaybatdau,DateTime ngayketthuc)
        {
            
            this._uuDai = uudai;
            this._ngayBatDau = ngaybatdau;
            this._ngayKetThuc = ngayketthuc;
        }
    }
}
