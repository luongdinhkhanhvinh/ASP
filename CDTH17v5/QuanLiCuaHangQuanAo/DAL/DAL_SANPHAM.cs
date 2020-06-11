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
    public class DAL_SANPHAM:GENERAL
    {
        public bool is_SanPham_MaSP(int MaSP)
        {

            getConnect();
            string sql = string.Format("SELECT MaSP FROM SanPham WHERE MASP={0} AND XOA = 0",MaSP);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            bool result = dr.HasRows;
            getDisconnect();
            return result;
        }
        public DataTable Select_SanPham()
        {
            getConnect();
            string sql = string.Format("SELECT sp.MaSP,lsp.TenLoaiSP,km.UuDai,nnsx.TenNSX ,sp.TenSP,sp.MoTa,sp.Size,sp.Mau,sp.Hinh,sp.Gia,sp.SLTon FROM SanPham sp,LoaiSP lsp,KhuyenMai km,NhaNSX nnsx WHERE sp.MaLoaiSP = lsp.MaLoaiSP AND sp.MaKM = km.MaKM AND sp.MaNSX = nnsx.MaNSX AND sp.Xoa = 1");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }
        public DataTable Select_SanPham_SLTon(int SLTon)
        {
            getConnect();
            string sql = string.Format("SELECT MaSP, TenSP, SLTon FROM SanPham WHERE SLTon <={0} AND Xoa = 0",SLTon);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public DataTable Select_SanPham_TenHienThi()
        {
            getConnect();
            string sql = string.Format("SELECT sp.MaSP,lsp.TenLoaiSP,km.UuDai,nnsx.TenNSX ,sp.TenSP,sp.MoTa,sp.Size,sp.Mau,sp.Hinh,sp.Gia,sp.SLTon FROM SanPham sp,LoaiSP lsp,KhuyenMai km,NhaNSX nnsx WHERE sp.MaLoaiSP = lsp.MaLoaiSP AND sp.MaKM = km.MaKM AND sp.MaNSX = nnsx.MaNSX AND sp.Xoa = 0");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }
        public DataTable Select_SanPham_TenHienThi_MaSP(int MaSP)
        {
            getConnect();
            string sql = string.Format("SELECT sp.MaSP,sp.TenSP,sp.MoTa,sp.Size,sp.Mau,sp.Hinh,sp.Gia,sp.SLTon,lsp.TenLoaiSP,km.UuDai,nnsx.TenNSX,lsp.MaLoaiSP,nnsx.MaNSX,km.MaKM FROM SanPham sp,LoaiSP lsp,KhuyenMai km,NhaNSX nnsx WHERE sp.MaLoaiSP = lsp.MaLoaiSP AND sp.MaKM = km.MaKM AND sp.MaNSX = nnsx.MaNSX AND sp.MaSP={0} AND sp.Xoa = 0", MaSP);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

       

        public DataTable Select_SanPham_MaSP(int MaSP)
        {
            getConnect();
            string sql = string.Format("SELECT MaSP,MaLoaiSP,MaKM,MaNSX,TenSP,MoTa,Size,Mau,Hinh,Gia,SLTon FROM SanPham WHERE MaSP = {0} AND Xoa = 0", MaSP);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }
        public bool Insert(SANPHAM sp)
        {
            getConnect();
            string Sql = string.Format("INSERT INTO SanPham(MaLoaiSP, MaKM, MaNSX, TenSP, MoTa, Size, Mau, Hinh,SLTon, Gia) " + "VALUES({0},{1},{2},N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',{8},{9})", sp.MaLoaiSP, sp.MaKM, sp.MaNSX, sp.TenSP, sp.MoTa, sp.Size, sp.Mau, sp.Hinh,sp.SlTon, sp.Gia); 
            SqlCommand cmd = new SqlCommand(Sql,conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }
        public bool Update(SANPHAM sp,int MaSP)
        {
            getConnect();
            string Sql = string.Format("UPDATE SanPham SET MaLoaiSP ={1}, MaKM = {2}, MaNSX={3}, TenSP=N'{4}', MoTa =N'{5}', Size=N'{6}', Mau=N'{7}', Hinh=N'{8}',SLTon={9}, Gia={10}" + " WHERE MaSP = {0}", MaSP, sp.MaLoaiSP, sp.MaKM, sp.MaNSX, sp.TenSP, sp.MoTa, sp.Size, sp.Mau, sp.Hinh, sp.SlTon,sp.Gia);
            //string Sql = "";
            SqlCommand cmd = new SqlCommand(Sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }

        

        public bool Delete(int MaSP)
        {
            getConnect();
            string Sql = string.Format("UPDATE SanPham SET Xoa = 1 WHERE MaSP = {0}", MaSP);
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
