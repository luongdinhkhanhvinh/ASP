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
    public class DAL_KHUYENMAI:GENERAL
    {
        public DataTable Select_KhuyenMai()
        {
            getConnect();
            string sql = string.Format("SELECT MaKM,UuDai,NgayBatDau,NgayKetThuc FROM KHUYENMAI WHERE XOA = 0");
            SqlDataAdapter da = new SqlDataAdapter(sql,conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }
        public DataTable Select_KhuyenMai_Xoa()
        {
            getConnect();
            string sql = string.Format("SELECT MaKM,UuDai,NgayBatDau,NgayKetThuc FROM KHUYENMAI WHERE XOA = 1");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public DataTable Select_KhuyenMai_MaKM(int MaKM)
        {
            getConnect();
            string sql = string.Format("SELECT UuDai,NgayBatDau,NgayKetThuc FROM KHUYENMAI WHERE MaKM={0} AND XOA = 0",MaKM);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }
        public bool KiemTra_KhuyenMai_MaKM(int MaKM)
        {
            getConnect();
            string sql = string.Format("SELECT MaKM FROM KhuyenMai WHERE MaKM = {0} AND Xoa = 1", MaKM);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            bool result = dr.HasRows;
            getDisconnect();
            return result;

        }

        public bool Insert(KHUYENMAI km)
        {
            getConnect();
            string sql = string.Format("INSERT INTO KhuyenMai(UuDai,NgayBatDau,NgayKetThuc) VALUES(N'{0}','{1}','{2}')",km.UuDai,km.NgayBatDau,km.NgayKetThuc);
            SqlCommand cmd = new SqlCommand(sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update(KHUYENMAI km, int MaKM)
        {
            getConnect();
            string Sql = string.Format("UPDATE KhuyenMai SET UuDai= N'{1}' ,NgayBatDau = '{2}',NgayKetThuc = '{3}' WHERE MaKM = {0}", MaKM, km.UuDai, km.NgayBatDau,km.NgayKetThuc);
            SqlCommand cmd = new SqlCommand(Sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int MaKM)
        {
            getConnect();
            string Sql = string.Format("UPDATE KhuyenMai SET Xoa = 1 WHERE MaKM = {0}", MaKM);
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
