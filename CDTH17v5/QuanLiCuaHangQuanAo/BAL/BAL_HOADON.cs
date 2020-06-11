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
    public class BAL_HOADON
    {
        DAL_HOADON objdal = new DAL_HOADON();
        public DataTable getHoaDon()
        {
            return objdal.Select_HoaDon();
        }

        public DataTable getHoaDon_MaHD(int MaHD)
        {
            return objdal.Select_HoaDon_MaHD(MaHD);
        }
        public DataTable getHoaDon_MaHD_TrangThai(string TrangThai)
        {
            return objdal.Select_HoaDon_MaHD_TrangThai(TrangThai);
        }

        public bool UpdateTrangThai(string TrangThai)
        {
            return objdal.UpDateTrangThaiHoaDon(TrangThai);
        }

        public bool Them(HOADON hd)
        {
            return objdal.Insert(hd);
        }
    }
}
