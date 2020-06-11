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
    public class DAL_HOADON:GENERAL
    {
        public DataTable Select_HoaDon()
        {
            getConnect();
            string sql = string.Format("SELECT MaNV,TongTien,TrangThai FROM HOADON WHERE XOA = 0");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public DataTable Select_HoaDon_MaHD(int MaHD)
        {
            getConnect();
            string sql = string.Format("SELECT MaNV,TongTien,TrangThai FROM HOADON WHERE MaHD={0} AND XOA = 0", MaHD);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public DataTable Select_HoaDon_MaHD_TrangThai(string TrangThai)
        {
            getConnect();
            string sql = string.Format("SELECT MaHD FROM HOADON WHERE TrangThai=N'{0}' AND XOA = 0", TrangThai);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public bool UpDateTrangThaiHoaDon(string TrangThai)
        {
            getConnect();
            string sql = string.Format("UPDATE HOADON SET TrangThai ='Xong' WHERE TrangThai like N'{0}'",TrangThai);
            SqlCommand cmd = new SqlCommand(sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }

        public bool Insert(HOADON hd)
        {
            getConnect();
            string sql = string.Format("INSERT INTO HoaDon(MaNV,TongTien,TrangThai) VALUES({0},{1},N'{2}')",hd.MaNV,hd.TongTien,hd.TrangThai);
            SqlCommand cmd = new SqlCommand(sql, conn);
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
