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
    public class DAL_CHITIETHOADON:GENERAL
    {
        public DataTable Select_ChiTietHoaDon()
        {
            getConnect();
            string sql = string.Format("SELECT MaHD,MaSP,NgayLapHD,GiaSP,SoLuong,KhuyenMai,ThanhTien FROM ChiTietHoaDon WHERE XOA = 0");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public DataTable Select_ChiTietHoaDon_MaHD(int MaHD)
        {
            getConnect();
            string sql = string.Format("SELECT MaHD,MaSP,NgayLapHD,GiaSP,SoLuong,KhuyenMai,ThanhTien FROM ChiTietHoaDon WHERE MaHD={0} AND XOA = 0", MaHD);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public DataTable Select_ChiTietHoaDon_LayNgay(DateTime tuNgay,DateTime denNgay)
        {
            getConnect();
            string sql = string.Format("SELECT DISTINCT hd.MaHD,hd.TongTien FROM ChiTietHoaDon ct,HoaDon hd WHERE ct.MaHD = hd.MaHD AND NgayLapHD BETWEEN  '{0}' AND '{1}'", tuNgay, denNgay);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public bool Insert(CHITIETHOADON cthd)
        {
            getConnect();
            string sql = string.Format("INSERT INTO ChiTietHoaDon(MaHD,MaSP,NgayLapHD,GiaSP,SoLuong,KhuyenMai,ThanhTien) VALUES({0},{1},'{2}',{3},{4},N'{5}',{6})", cthd.MaHD, cthd.MaSP, cthd.NgayLapHD, cthd.GiaSP, cthd.SoLuong, cthd.KhuyenMai, cthd.ThanhTien);
            SqlCommand cmd = new SqlCommand(sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }
        public bool Update_SLTon(int MaHD)
        {
            getConnect();
            string Sql = string.Format("UPDATE dbo.SanPham SET SLTon = SLTon - dbo.ChiTietHoaDon.SoLuong FROM dbo.SanPham INNER JOIN dbo.ChiTietHoaDon ON (dbo.SanPham.MaSP = dbo.ChiTietHoaDon.MaSP) WHERE MaHD = {0}", MaHD);
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
