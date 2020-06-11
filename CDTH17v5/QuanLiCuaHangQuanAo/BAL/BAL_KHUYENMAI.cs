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
    public class BAL_KHUYENMAI
    {
        DAL_KHUYENMAI objdal = new DAL_KHUYENMAI();
        public DataTable getKhuyenMai()
        {
            return objdal.Select_KhuyenMai();
        }

        public DataTable getKhuyenMai_Xoa()
        {
            return objdal.Select_KhuyenMai_Xoa();
        }

        public DataTable getKhuyenMai_MaKM(int MaKm){
            return objdal.Select_KhuyenMai_MaKM(MaKm);
        }
        public bool getKhuyenMai_KiemTra_Xoa(int MaKm)
        {
            return objdal.KiemTra_KhuyenMai_MaKM(MaKm);
        }

        public bool Them(KHUYENMAI km)
        {
            return objdal.Insert(km);
        }
        public bool CapNhat(KHUYENMAI km, int MaKm)
        {
            return objdal.Update(km, MaKm);
        }

       
        public bool Xoa(int Makm)
        {
            return objdal.Delete(Makm);
        }
    }
}
