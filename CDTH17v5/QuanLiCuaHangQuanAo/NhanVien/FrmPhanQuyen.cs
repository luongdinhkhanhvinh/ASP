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
    public partial class FrmPhanQuyen : Form
    {
        public FrmPhanQuyen()
        {
            InitializeComponent();
        }

        private int _maNV;

        public int MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            if (txtTenTaiKhoan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn Phải Nhập Tài Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTaiKhoan.Focus();
                return;
            }
           
            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            
            


            //&& txtMatKhau.Text.Trim() == bal_nv.getNhanVien_MaNV(this._maNV).Rows[i]["MatKhau"].ToString()
            //try
            //{
            //    for (int i = 0; i < bal_nv.getNhanVien().Rows.Count; i++)
            //    {
            //        if (txtTenTaiKhoan.Text.Trim() == bal_nv.getNhanVien().Rows[i]["TenTaiKhoan"].ToString())
            //        {
            //            MessageBox.Show("Tên tài Khoản Không được Trùng Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            txtTenTaiKhoan.Focus();
            //            return;
            //        }
            //    }
            
            //}
            //catch (Exception)
            //{
                
            //    throw;
            //}
           

            int MaNV = int.Parse(txtMaNV.Text.Trim());
            int MaLoaiNV = 0;
            if (radNhanVien.Checked)
            {
                MaLoaiNV = 2;
            }
            else
            {
                MaLoaiNV = 1;
            }
            string TenTaiKhoan = txtTenTaiKhoan.Text.Trim();
            

           
            bool isCapNhat = bal_nv.CapNhat_PhanQuyen(MaNV,TenTaiKhoan,MaLoaiNV);
            if (isCapNhat)
            {
                MessageBox.Show("Thành Công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
                return;
            }
            MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            
        }

        private void FrmPhanQuyen_Load(object sender, EventArgs e)
        {
            
            HienThiNhanVien();
        }
        private void HienThiNhanVien()
        {
            txtMaNV.Text = _maNV.ToString();
            radNhanVien.Checked = true;
            txtTenTaiKhoan.Enabled = false;
            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            DataTable dt = bal_nv.getNhanVien_MaNV(_maNV);
            DataRow dr = dt.Rows[0];
            txtTenTaiKhoan.Text = dr["TenTaiKhoan"].ToString();

            //DataRow dr_admin = bal_nv.getNhanVien_MaNV(this._maNV).Rows[0];
            string is_admin = dr["TenTaiKhoan"].ToString();
            if (is_admin.Equals("admin"))
            {
                
                groupBox1.Enabled = false;
                //return;
            }
        }

        private void txtTenTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (txtTenTaiKhoan.Text.Trim().Length == 20  && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Tối Đa 20 Ký Tự");
                return;
            }

        }

       
       
    }
}
