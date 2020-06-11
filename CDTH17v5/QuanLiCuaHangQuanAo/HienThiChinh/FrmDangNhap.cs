using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BAL;
using QuanLiCuaHangQuanAo.HienThiChinh;
using QuanLiCuaHangQuanAo.NhanVien;

namespace QuanLiCuaHangQuanAo
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

       

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Trim() == "")
            {
                txtTaiKhoan.Focus();
                MessageBox.Show("Vui lòng nhập tài khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatKhau.Text.Trim() == "")
            {
                txtMatKhau.Focus();
                MessageBox.Show("Vui lòng nhập tài khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            bool kiemtratontai = bal_nv.KiemTraTonTai(txtTaiKhoan.Text.Trim(),txtMatKhau.Text.Trim());
            if (kiemtratontai)
            {
                int Malnv = bal_nv.DangNhap(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim());
                int MaNV = bal_nv.getNhanVien_MaNV_DangNhap(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim());
                if (Malnv.Equals(1))
                {
                    this.Hide();
                    FrmTrangQuanLy frmql = new FrmTrangQuanLy();
                    frmql.ShowDialog();
                    this.Close();
                    return;
                }
                if (Malnv.Equals(2))
                {
                    this.Hide();
                    FrmTrangBanHang frmbh = new FrmTrangBanHang();
                    frmbh.MaNV = MaNV;
                    frmbh.ShowDialog();
                    this.Close();
                    return;
                }
            }
            txtTaiKhoan.Focus();
            MessageBox.Show("Tài Khoản Hoặc Mật Khẩu Sai Hoặc Tui Cho Nghĩ Làm Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
