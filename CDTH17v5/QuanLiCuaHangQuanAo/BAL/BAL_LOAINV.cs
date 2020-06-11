using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
namespace BAL
{
    public class BAL_LOAINV
    {
        DAL_LOAINV objdal = new DAL_LOAINV();
        public DataTable getLoaiNV()
        {
            return objdal.Select_LoaiNV();
        }
    }
}
