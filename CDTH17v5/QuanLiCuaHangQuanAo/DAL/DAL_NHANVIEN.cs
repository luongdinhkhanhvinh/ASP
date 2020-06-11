using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BEL;
using System.Security.Cryptography;
namespace DAL
{
    public class DAL_NHANVIEN:GENERAL
    {

        private string MaHoaMD5(string matkhau)
        {
            //khởi tạo MD5
            MD5 md5 = MD5.Create();
            //Chuyển chuỗi thành byte và mã hóa
            // kiểu byte từ 1-> 127 ký tự
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(matkhau));
            //Đây là kiểu dữ liệu string lớn và  cho phép sửa đổi mà không tạo thêm vùng nhớ mới , khác với string thường là tạo đối tượng mới khi thay đổi chuổi
            StringBuilder str_lon = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                //Nối chuỗi con
                str_lon.Append(data[i].ToString("x2"));//X2 kí tự hoa , x2 kí tự thường
   
            }
            return str_lon.ToString();
        }


        public bool is_Login(string taikhoan, string matkhau)
        {
            getConnect();
            //string matkhau_md5 = MaHoaMD5(matkhau);
            string sql = string.Format("SELECT MaLoaiNV  FROM NhanVien WHERE TenTaiKhoan='{0}' AND MatKhau='{1}' AND XOA = 0  AND TrangThai = N'Còn Làm'", taikhoan, MaHoaMD5(matkhau));
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            bool result = dr.HasRows;
            getDisconnect();
            return result;
        }
        public DataTable Select_NhanVien()
        {
            getConnect();
            string sql = string.Format("SELECT MaNV,TenTaiKhoan,HoTen,Phai,DiaChi,NgaySinh,SDT,CMND,TrangThai FROM NHANVIEN WHERE XOA=0");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable("NHANVIEN1");
            da.Fill(dt);
            getDisconnect();
            return dt;
        }
        public DataTable Select_NhanVien_Xoa()
        {
            getConnect();
            string sql = string.Format("SELECT MaNV,TenTaiKhoan,HoTen,Phai,DiaChi,NgaySinh,SDT,CMND,TrangThai FROM NHANVIEN WHERE XOA=1");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public int Select_NhanVien_MaLoaiNV(string taikhoan,string matkhau)
        {
            getConnect();
            string sql = string.Format("SELECT MaLoaiNV  FROM NhanVien WHERE TenTaiKhoan='{0}' AND MatKhau='{1}' AND XOA = 0", taikhoan, MaHoaMD5(matkhau));
            SqlCommand cmd = new SqlCommand(sql, conn);
            int row = (int)cmd.ExecuteScalar();
            getDisconnect();
            return row;
        }

        public int Select_NhanVien_MaNV(string taikhoan, string matkhau)
        {
            getConnect();
            string sql = string.Format("SELECT MaNV  FROM NhanVien WHERE TenTaiKhoan='{0}' AND MatKhau='{1}' AND XOA = 0", taikhoan, MaHoaMD5(matkhau));
            SqlCommand cmd = new SqlCommand(sql, conn);
            int row = (int)cmd.ExecuteScalar();
            getDisconnect();
            return row;
        }
        
       
       
        public DataTable Select_NhanVien_MaNV(int MaNV)
        {
            getConnect();
            string sql = string.Format("SELECT MaNV,TenTaiKhoan,HoTen,Phai,DiaChi,NgaySinh,SDT,CMND,TrangThai FROM NHANVIEN WHERE MaNV = {0} AND XOA=0", MaNV);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable("NHANVIEN");
            da.Fill(dt);
            getDisconnect();
            return dt;
        }

        public bool Update(NHANVIEN nv, int MaNV)
        {
            getConnect();
            string Sql = string.Format("UPDATE NHANVIEN SET HoTen=N'{1}',Phai=N'{2}',DiaChi=N'{3}',NgaySinh='{4}',SDT=N'{5}',CMND=N'{6}',TrangThai=N'{7}',TenTaiKhoan = N'{8}' WHERE MANV = {0}",MaNV,nv.HoTen,nv.Phai,nv.DiaChi,nv.NgaySinh,nv.Sdt,nv.Cmnd,nv.TrangThai,nv.TenTaiKhoan);
            SqlCommand cmd = new SqlCommand(Sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update_PhanQuyen(int MaNV,string TenTaiKhoan,int MaLoaiNV)
        {
            getConnect();
            string Sql = string.Format("UPDATE NHANVIEN SET TenTaiKhoan=N'{1}',MaLoaiNV={2} WHERE MANV = {0}",MaNV,TenTaiKhoan,MaLoaiNV);
            SqlCommand cmd = new SqlCommand(Sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update_DoiMatKhau(int MaNV,string MatKhau)
        {
            getConnect();

            string Sql = string.Format("UPDATE NHANVIEN SET MatKhau=N'{1}' WHERE MANV = {0}", MaNV, MaHoaMD5(MatKhau));
            SqlCommand cmd = new SqlCommand(Sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }


        
        public bool Insert(NHANVIEN nv)
        {
            getConnect();
            string Sql = string.Format("INSERT INTO NHANVIEN(HoTen,Phai,DiaChi,NgaySinh,SDT,CMND,TrangThai,TenTaiKhoan) " + "VALUES(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}',N'{6}',N'{7}')", nv.HoTen, nv.Phai, nv.DiaChi, nv.NgaySinh, nv.Sdt, nv.Cmnd, nv.TrangThai,nv.TenTaiKhoan);
            SqlCommand cmd = new SqlCommand(Sql, conn);
            int row = cmd.ExecuteNonQuery();
            getDisconnect();
            if (row > 0)
            {
                return true;
            }
            return false;
        }
        public bool Delete(int MaNV)
        {
            getConnect();
            string Sql = string.Format("UPDATE NhanVien SET XOA = 1 WHERE MaNV = {0}",MaNV);
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
