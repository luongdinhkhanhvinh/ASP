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
using BEL;

namespace QuanLiCuaHangQuanAo.NhanVien
{
    public partial class FrmCapNhatNhanVien : Form
    {
        public FrmCapNhatNhanVien()
        {
            InitializeComponent();
        }
        private int _maNV;
        string cmmd = null;
        string sdt = null;
        string tk = null;
        public int MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
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
            if (txtTenTaiKhoan.Text.Trim() == "")
            {
                txtTenTaiKhoan.Focus();
                MessageBox.Show("Vui lòng nhập Tên Tài Khoản Cho Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                
                    if (txtSDT.Text.Trim() == bal_nv.getNhanVien().Rows[i]["SDT"].ToString() && sdt != txtSDT.Text.Trim())
                    {
                        MessageBox.Show("SDT Không được Trùng Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSDT.Focus();
                        return;
                    }
               
               
                    if (txtCMND.Text.Trim() == bal_nv.getNhanVien().Rows[i]["CMND"].ToString() && cmmd != txtCMND.Text.Trim())
                    {
                        MessageBox.Show("CMND Không được Trùng Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCMND.Focus();
                        return;
                    }
               
                
                    if (txtTenTaiKhoan.Text.Trim() == bal_nv.getNhanVien().Rows[i]["TenTaiKhoan"].ToString() && tk != txtTenTaiKhoan.Text.Trim())
                    {
                        MessageBox.Show("Tên Tài Khoản Không Được trùng Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTenTaiKhoan.Focus();
                        return;
                    }
             
               
            }

            //DataRow dr_admin = bal_nv.getNhanVien_MaNV(this._maNV).Rows[0];
           

            string Phai = radNam.Checked ? "Nam" : "Nữ";
            string TrangThai = radConLam.Checked ? "Còn Làm" : "Nghĩ Làm";

            bool isThem = bal_nv.CapNhat(new NHANVIEN(txtTenTaiKhoan.Text,txtHoTen.Text, Phai, txtDiaChi.Text, dtpNgaySinh.Value, txtSDT.Text, txtCMND.Text, TrangThai), _maNV);
            if (isThem)
            {
                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
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

        private void CheckBoxText()
        {
            //txtCMND.Enabled = false;
            //txtTenTaiKhoan.Enabled = false;
            //txtSDT.Enabled = false;
        }

        private void FrmCapNhatNhanVien_Load(object sender, EventArgs e)
        {
            CheckBoxText();
            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            DataTable dt = bal_nv.getNhanVien_MaNV(_maNV);
            DataRow dr = dt.Rows[0];
            
            txtHoTen.Text = dr["HoTen"].ToString();
            string is_admin = dr["TenTaiKhoan"].ToString();
            if (is_admin.Equals("admin"))
            {

                txtTenTaiKhoan.Enabled = false;
                groupBox2.Enabled = false;
                //ckbTaiKhoan.Enabled = false;
                //return;
            }
            if (dr["Phai"].Equals("Nam"))
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }
            
            txtDiaChi.Text = dr["DiaChi"].ToString();
            dtpNgaySinh.Value = DateTime.Parse(dr["NgaySinh"].ToString());
            txtSDT.Text = dr["SDT"].ToString();
             sdt = dr["SDT"].ToString();
            txtCMND.Text = dr["CMND"].ToString();
            cmmd = dr["CMND"].ToString();
            txtTenTaiKhoan.Text = dr["TenTaiKhoan"].ToString();
            tk = dr["TenTaiKhoan"].ToString();
            if (dr["TrangThai"].Equals("Còn Làm"))
            {
                radConLam.Checked = true;
            }
            else
            {
                radNghiLam.Checked = true;
            }

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
                MessageBox.Show("Không Được Quá 10", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtHoTen_TextChanged(object sender, EventArgs e)
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

        //private void ckbSDT_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (ckbSDT.Checked)
        //    {
        //        txtSDT.Enabled = true;

        //        ckbSDT.Enabled = false;
        //        ckbCMND.Enabled = false;
        //        ckbTaiKhoan.Enabled = false;
        //    }
        //    else
        //    {
        //        txtCMND.Enabled = false;
        //        txtTenTaiKhoan.Enabled = false;

        //        ckbCMND.Enabled = false;
        //        ckbTaiKhoan.Enabled = false;
        //    }
        //}

        //private void ckbCMND_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (ckbCMND.Checked)
        //    {
        //        txtCMND.Enabled = true;

        //        ckbCMND.Enabled = false;
        //        ckbSDT.Enabled = false;
        //        ckbTaiKhoan.Enabled = false;
        //    }
        //    else
        //    {
        //        txtSDT.Enabled = false;
        //        txtTenTaiKhoan.Enabled = false;

        //        ckbSDT.Enabled = false;
        //        ckbTaiKhoan.Enabled = false;
        //    }
        //}

        //private void ckbTaiKhoan_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (ckbTaiKhoan.Checked)
        //    {
        //        txtTenTaiKhoan.Enabled = true;

        //        ckbTaiKhoan.Enabled = false;
        //        ckbSDT.Enabled = false;
        //        ckbCMND.Enabled = false;

        //    }
        //    else
        //    {
        //        txtSDT.Enabled = false;
        //        txtCMND.Enabled = false;

        //        ckbSDT.Enabled = false;
        //        ckbCMND.Enabled = false;
               
        //    }
        //}

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        
    }
}
