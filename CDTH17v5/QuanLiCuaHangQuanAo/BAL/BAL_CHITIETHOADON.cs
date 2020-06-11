using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BEL;
namespace BAL
{
    public class BAL_CHITIETHOADON
    {
        DAL_CHITIETHOADON objdal = new DAL_CHITIETHOADON();
        public DataTable getChiTietHoaDon()
        {
            return objdal.Select_ChiTietHoaDon();
        }

        public DataTable getChiTietHoaDon_MaHD(int MaHD)
        {
            return objdal.Select_ChiTietHoaDon_MaHD(MaHD);
        }
        public DataTable getChiTietHoaDon_layN(DateTime tungay,DateTime denngay)
        {
            return objdal.Select_ChiTietHoaDon_LayNgay(tungay,denngay);
        }

        public bool Them(CHITIETHOADON cthd)
        {
            return objdal.Insert(cthd);
        }

        public bool CapNhat(int MaHD)
        {
            return objdal.Update_SLTon(MaHD);
        }
    }
}
