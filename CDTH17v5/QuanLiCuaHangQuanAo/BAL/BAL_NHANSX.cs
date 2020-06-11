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
    public class BAL_NHANSX
    {
        DAL_NHANSX objdal = new DAL_NHANSX();
        public DataTable getNhaNSX()
        {
            return objdal.Select_NhaNSX();
        }
        public DataTable getNhaNSX_Xoa()
        {
            return objdal.Select_NhaNSX_Xoa();
        }
        public DataTable getNhaNSX_MaNSX(int MaNSX)
        {
            return objdal.Select_NhaNSX_MaNSX(MaNSX);
        }
        public bool getNhaNSX_Xoa_MaNSX(int MaNSX)
        {
            return objdal.KiemTra_NhaNSX_MaNSX(MaNSX);
        }
        public bool CapNhat(NHANSX nsx, int MaNSX)
        {
            return objdal.Update(nsx, MaNSX);
        }

        public bool Them(NHANSX nsx)
        {
            return objdal.Insert(nsx);
        }
        public bool Xoa(int MaNSX)
        {
            return objdal.Delete(MaNSX);
        }
    }
}
