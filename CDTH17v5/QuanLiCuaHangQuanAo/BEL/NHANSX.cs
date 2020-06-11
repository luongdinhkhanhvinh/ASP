using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class NHANSX
    {
       
        private string _tenNSX;

        public string TenNSX
        {
            get { return _tenNSX; }
            set { _tenNSX = value; }
        }
        private string _diaChiNSX;

        public string DiaChiNSX
        {
            get { return _diaChiNSX; }
            set { _diaChiNSX = value; }
        }
        private string _dienThoaiNSX;

        public string DienThoaiNSX
        {
            get { return _dienThoaiNSX; }
            set { _dienThoaiNSX = value; }
        }


        public NHANSX()
        {
           
            this._tenNSX = "";
            this._diaChiNSX = "";
            this._dienThoaiNSX = "";

        }
        public NHANSX(string tennsx,string diachinsx,string dienthoainsx)
        {
            
            this._tenNSX = tennsx;
            this._diaChiNSX = diachinsx;
            this._dienThoaiNSX = dienthoainsx;
        }
    }
}
