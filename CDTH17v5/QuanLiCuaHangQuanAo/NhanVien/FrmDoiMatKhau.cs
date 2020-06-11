using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
namespace QuanLiCuaHangQuanAo.NhanVien
{
    public partial class FrmDoiMatKhau : Form
    {
        public FrmDoiMatKhau()
        {
            InitializeComponent();
        }
        private int _maNV;
        public FrmDoiMatKhau(int manv)
        {
            InitializeComponent();
            this._maNV = manv;
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            HienThiNhanVien();
        }
        private void HienThiNhanVien()
        {
            txtMaNV.Text = this._maNV.ToString();
            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            DataTable dt = bal_nv.getNhanVien_MaNV(_maNV);
            DataRow dr = dt.Rows[0];
            txtTenTaiKhoan.Text = dr["TenTaiKhoan"].ToString();

        }
        private void btnXong_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Bạn Phải Nhập Mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhau.Focus();
                return;
            }
            string MatKhau = txtMatKhau.Text.Trim();
            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            bool isCapNhat = bal_nv.CapNhat_DoiMatKhau(this._maNV,MatKhau);
            if (isCapNhat)
            {
                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMatKhau.Text.Trim().Length == 20 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Tối Đa 20 Ký Tự");
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
