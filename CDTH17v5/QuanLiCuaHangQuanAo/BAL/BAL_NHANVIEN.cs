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
    public class BAL_NHANVIEN
    {
        DAL_NHANVIEN objdal = new DAL_NHANVIEN();

        public bool KiemTraTonTai(string tk, string mk)
        {
            return objdal.is_Login(tk, mk);
        }

        public int DangNhap(string tk,string mk)
        {
            return objdal.Select_NhanVien_MaLoaiNV(tk, mk);
        }
        public int getNhanVien_MaNV_DangNhap(string taikhoan, string matkhau)
        {
            return objdal.Select_NhanVien_MaNV( taikhoan,  matkhau);
        }

        public DataTable getNhanVien()
        {
            return objdal.Select_NhanVien();
        }
        public DataTable getNhanVien_Xoa()
        {
            return objdal.Select_NhanVien_Xoa();
        }

        public DataTable getNhanVien_MaNV(int  MaNV)
        {
            return objdal.Select_NhanVien_MaNV(MaNV);
        }
        public bool CapNhat(NHANVIEN nv, int MaNV)
        {
            return objdal.Update(nv, MaNV);
        }
        public bool CapNhat_PhanQuyen(int MaNV,string TenTaiKhoan,int MaLoaiNV)
        {
            return objdal.Update_PhanQuyen( MaNV, TenTaiKhoan, MaLoaiNV);
        }

        public bool CapNhat_DoiMatKhau(int MaNV,string MatKhau)
        {
            return objdal.Update_DoiMatKhau(MaNV, MatKhau);
            
        }
        public bool Them(NHANVIEN nv)
        {
            return objdal.Insert(nv);
        }
        public bool Xoa(int MaNV)
        {
            return objdal.Delete(MaNV);
        }
    }
}
