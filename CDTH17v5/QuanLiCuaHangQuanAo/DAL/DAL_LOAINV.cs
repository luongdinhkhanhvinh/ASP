using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_LOAINV:GENERAL
    {
        public DataTable Select_LoaiNV()
        {
            getConnect();
            string sql = string.Format("SELECT * FROM LoaiNV WHERE Xoa = 0");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }
        public DataTable Select_TaiKhoan_MaTK(int MaTK)
        {
            getConnect();
            string sql = string.Format("SELECT MaTK,TenTaiKhoan,MatKhau,MaNV FROM TaiKhoan WHERE MaTK = {0} AND Xoa = 0", MaTK);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public bool Update(NHANVIEN nv, int MaTK)
        {
            getConnect();
            string Sql = string.Format("");
            SqlCommand cmd = new SqlCommand(Sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }
        public bool Insert(NHANVIEN tk)
        {
            getConnect();
            string Sql = string.Format("");
            SqlCommand cmd = new SqlCommand(Sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }
        public bool Delete(int MaTK)
        {
            getConnect();
            string Sql = string.Format("UPDATE LoaiSP SET Xoa = 1 WHERE MaLoaiSP = {0}", MaTK);
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
