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
    public class BAL_SANPHAM
    {
        DAL_SANPHAM objdal = new DAL_SANPHAM();
        public bool KiemTraMaSPTonTai(int MaSP)
        {
            return objdal.is_SanPham_MaSP(MaSP);
        }
        public DataTable  getSanPham(){
            return objdal.Select_SanPham();
        }
        public DataTable getSanPham_MaSP(int MaSP)
        {
            return objdal.Select_SanPham_MaSP(MaSP);
        }

        public DataTable getSanPham_TenHienThi()
        {
            return objdal.Select_SanPham_TenHienThi();
        }
        public DataTable getSanPham_TenHienThi_MaSP(int MaSP)
        {
            return objdal.Select_SanPham_TenHienThi_MaSP(MaSP);
        }

        public DataTable getSanPham_SLTon(int SLTon)
        {
            return objdal.Select_SanPham_SLTon(SLTon);
        }

        public bool CapNhat(SANPHAM sp,int MaSP)
        {
            return objdal.Update(sp,MaSP);
        }
        
        public bool Them(SANPHAM sp)
        {
            return objdal.Insert(sp);
        }
        public bool Xoa(int MaSP)
        {
            return objdal.Delete(MaSP);
        }

       
    }
}
