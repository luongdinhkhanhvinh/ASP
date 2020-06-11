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
    public class DAL_LOAISP:GENERAL
    {
        public DataTable Select_LoaiSP_XoaTrue()
        {
            getConnect();
            string sql = string.Format("SELECT MaLoaiSP,TenLoaiSP,MoTa FROM LOAISP WHERE Xoa = 1");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }
        public DataTable Select_LoaiSP()
        {
            getConnect();
            string sql = string.Format("SELECT MaLoaiSP,TenLoaiSP,MoTa FROM LOAISP WHERE Xoa = 0");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }
        public DataTable Select_LoaiSP_MaLoaiSP(int MaLoai)
        {
            getConnect();
            string sql = string.Format("SELECT MaLoaiSP,TenLoaiSP,MoTa FROM LOAISP WHERE MaLoaiSP = {0} AND Xoa = 0", MaLoai);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public bool KiemTra_LoaiSP_MaLoaiSP(int MaLoai)
        {
            getConnect();
            string sql = string.Format("SELECT MaLoaiSP FROM LOAISP WHERE MaLoaiSP = {0} AND Xoa = 1", MaLoai);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            bool result = dr.HasRows;
            getDisconnect();
            return result;
            
        }

        public bool Insert(LOAISP lsp)
        {
            getConnect();
            string Sql = string.Format("INSERT INTO LOAISP(TenLoaiSP,MoTa) "+"VALUES(N'{0}' ,N'{1}' )",lsp.TenLoaiSP,lsp.MoTa);
            SqlCommand cmd = new SqlCommand(Sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }
        public bool Update(LOAISP lsp, int MaLoaiSP)
        {
            getConnect();
            string Sql =string.Format("UPDATE LOAISP SET TenLoaiSP= N'{1}' ,MoTa = N'{2}' WHERE MaLoaiSP = {0}",MaLoaiSP,lsp.TenLoaiSP,lsp.MoTa);
            SqlCommand cmd = new SqlCommand(Sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int MaLoaiSP)
        {
            getConnect();
            string Sql = string.Format("UPDATE LoaiSP SET Xoa = 1 WHERE MaLoaiSP = {0}", MaLoaiSP);
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
