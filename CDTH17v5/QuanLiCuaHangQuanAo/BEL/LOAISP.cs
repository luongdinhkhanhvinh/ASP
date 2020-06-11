using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class LOAISP
    {
       
        private string _tenLoaiSP;

        public string TenLoaiSP
        {
            get { return _tenLoaiSP; }
            set { _tenLoaiSP = value; }
        }
        private string _moTa;

        public string MoTa
        {
            get { return _moTa; }
            set { _moTa = value; }
        }

        public LOAISP()
        {
           
            this._tenLoaiSP = "";
            this._moTa = "";
        }

        public LOAISP(string tenloaisp,string mota)
        {
            
            this._tenLoaiSP = tenloaisp;
            this._moTa = mota;
        }

    }
}
