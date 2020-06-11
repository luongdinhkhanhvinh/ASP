using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BEL;
namespace DAL
{
    public class DAL_NHANSX:GENERAL
    {
        public DataTable Select_NhaNSX()
        {
            getConnect();
            string sql = string.Format("SELECT MaNSX,TenNSX,DiaChiNSX,DienThoaiNSX FROM NhaNSX WHERE Xoa = 0");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }
        public DataTable Select_NhaNSX_Xoa()
        {
            getConnect();
            string sql = string.Format("SELECT MaNSX,TenNSX,DiaChiNSX,DienThoaiNSX FROM NhaNSX WHERE Xoa = 1");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public DataTable Select_NhaNSX_MaNSX(int MaNSX)
        {
            getConnect();
            string sql = string.Format("SELECT MaNSX,TenNSX,DiaChiNSX,DienThoaiNSX FROM NhaNSX WHERE MaNSX = {0} AND Xoa = 0", MaNSX);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public bool KiemTra_NhaNSX_MaNSX(int MaNSX)
        {
            getConnect();
            string sql = string.Format("SELECT MaNSX FROM NhaNSX WHERE MaNSX = {0} AND Xoa = 1", MaNSX);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            bool result = dr.HasRows;
            getDisconnect();
            return result;

        }

        public bool Insert(NHANSX nsx)
        {
            getConnect();
            string Sql = string.Format("INSERT INTO NhaNSX(TenNSX,DiaChiNSX,DienThoaiNSX) " + "VALUES(N'{0}',N'{1}',N'{2}')",nsx.TenNSX,nsx.DiaChiNSX,nsx.DienThoaiNSX);
            SqlCommand cmd = new SqlCommand(Sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }
        public bool Update(NHANSX nsx, int MaNSX)
        {
            getConnect();
            string Sql = string.Format("UPDATE NhaNSX SET TenNSX= N'{1}' ,DiaChiNSX = N'{2}',DienThoaiNSX=N'{3}' WHERE MaNSX = {0}", MaNSX,nsx.TenNSX,nsx.DiaChiNSX,nsx.DienThoaiNSX);
            SqlCommand cmd = new SqlCommand(Sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int MaNSX)
        {
            getConnect();
            string Sql = string.Format("UPDATE NhaNSX SET Xoa = 1 WHERE MaNSX = {0}", MaNSX);
            SqlCommand cmd = new SqlCommand(Sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }
    }
}
