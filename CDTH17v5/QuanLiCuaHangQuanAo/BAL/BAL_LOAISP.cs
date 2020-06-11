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
    public class BAL_LOAISP
    {
        DAL_LOAISP objdal = new DAL_LOAISP();
        public DataTable getLoaiSPXoa()
        {
            return objdal.Select_LoaiSP_XoaTrue();
        }
        public DataTable getLoaiSP()
        {
            return objdal.Select_LoaiSP();
        }

        public DataTable getLoaiSP_MaLoaiSP(int MaLoaiSP)
        {
            return objdal.Select_LoaiSP_MaLoaiSP(MaLoaiSP);
        }

        public bool getLoaiSPXoa_MaLoaiSP(int MaLoaiSP)
        {
            return objdal.KiemTra_LoaiSP_MaLoaiSP(MaLoaiSP);
        }

        public bool CapNhat(LOAISP lsp, int MaLoaiSP)
        {
            return objdal.Update(lsp, MaLoaiSP);
        }

        public bool Them(LOAISP lsp)
        {
            return objdal.Insert(lsp);
        }
        public bool Xoa(int MaLoaiSP)
        {
            return objdal.Delete(MaLoaiSP);
        }
    }
}
