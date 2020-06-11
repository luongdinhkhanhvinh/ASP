using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BEL;
using BAL;

namespace QuanLiCuaHangQuanAo.NhanVien
{
    public partial class FrmThemNhanVien : Form
    {
        public FrmThemNhanVien()
        {
            InitializeComponent();
        }

        private void FrmThemNhanVien_Load(object sender, EventArgs e)
        {
            radNam.Checked = true;
            radConLam.Checked = true;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private bool KiemTraPaste(TextBox Paste)
        {
            char[] XuLiPaste = Paste.Text.Trim().ToCharArray();
            for (int i = 0; i < XuLiPaste.Length; i++)
            {
                if (!char.IsDigit(XuLiPaste[i]))
                {
                    Paste.Focus();
                    MessageBox.Show("Vui Lòng Nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
        }
        private void btnXong_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() == "")
            {
                txtHoTen.Focus();
                MessageBox.Show("Vui lòng nhập Họ tên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                txtDiaChi.Focus();
                MessageBox.Show("Vui lòng nhập Địa Chỉ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSDT.Text.Trim() == "")
            {
                txtSDT.Focus();
                MessageBox.Show("Vui lòng nhập Số Điện Thoại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtCMND.Text.Trim() == "")
            {
                txtCMND.Focus();
                MessageBox.Show("Vui lòng nhập Chứng minh nhân dân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(txtTenTaiKhoan.Text.Trim() == ""){
                txtTenTaiKhoan.Focus();
                MessageBox.Show("Vui lòng nhập Tên Tài Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (KiemTraPaste(txtSDT))
            {
                return;
            }

            if (KiemTraPaste(txtCMND))
            {
                return;
            }

            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            

            for (int i = 0; i < bal_nv.getNhanVien().Rows.Count; i++)
            {
                if (txtCMND.Text.Trim() == bal_nv.getNhanVien().Rows[i]["CMND"].ToString())
                {
                    MessageBox.Show("CMND Không được Trùng Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCMND.Focus();
                    return;
                }
                if (txtSDT.Text.Trim() == bal_nv.getNhanVien().Rows[i]["SDT"].ToString())
                {
                    MessageBox.Show("SDT Không được Trùng Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCMND.Focus();
                    return;
                }
                if (txtTenTaiKhoan.Text.Trim() == bal_nv.getNhanVien().Rows[i]["TenTaiKhoan"].ToString())
                {
                    MessageBox.Show("Tên Tài Khoản Không Được trùng Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenTaiKhoan.Focus();
                    return;
                }
            }
            
            string Phai = radNam.Checked ? "Nam" : "Nữ";
            string TrangThai = radConLam.Checked ? "Còn Làm" : "Nghĩ Làm";
            
            bool isThem = bal_nv.Them(new NHANVIEN(txtTenTaiKhoan.Text,txtHoTen.Text,Phai,txtDiaChi.Text,dtpNgaySinh.Value,txtSDT.Text,txtCMND.Text,TrangThai));
            if (isThem)
            {
                MessageBox.Show("Thêm Thành Công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Question);
                this.Close();
                return;
            }
            MessageBox.Show("Thêm Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtSDT.Text.Length == 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Không Được Quá 10","Thông báo ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtCMND.Text.Length == 12 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Không Được Quá 12", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtTenTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTenTaiKhoan.Text.Trim().Length == 20 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Tối Đa 20 Ký Tự");
                return;
            }
        }
    }
}
