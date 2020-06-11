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
using System.Data.SqlClient;

namespace QuanLiCuaHangQuanAo.NhanVien
{
    public partial class FrmTrangNhanVien : Form
    {
        public FrmTrangNhanVien()
        {
            InitializeComponent();
        }


        private void btnThemNV_Click(object sender, EventArgs e)
        {
            FrmThemNhanVien frmThem = new FrmThemNhanVien();
            frmThem.ShowDialog();
            HienThiNhanVien();
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (dgvNV.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int MaNV = int.Parse(dgvNV.CurrentRow.Cells[0].Value.ToString());
            FrmCapNhatNhanVien frmCapNhat = new FrmCapNhatNhanVien();
            frmCapNhat.MaNV = MaNV;
            frmCapNhat.ShowDialog();
            HienThiNhanVien();
            
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (dgvNV.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (MessageBox.Show("Bạn Có Muốn Xóa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int MaNV = int.Parse(dgvNV.CurrentRow.Cells[0].Value.ToString());
                BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
                DataTable dt_admin = bal_nv.getNhanVien_MaNV(MaNV);
                string is_admin = dt_admin.Rows[0]["TenTaiKhoan"].ToString();
                if (is_admin.Equals("admin"))
                {
                    MessageBox.Show("Không Được Xóa Admin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                bool isXoa = bal_nv.Xoa(MaNV);
                if (isXoa)
                {
                    MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                HienThiNhanVien();
            }
            
        }
        private void HienThiNhanVien()
        {
            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            dgvNV.DataSource = bal_nv.getNhanVien();
        }
        private void FrmTrangNhanVien_Load(object sender, EventArgs e)
        {
            HienThiNhanVien();
            HienThiCBChon();
        }

        private void HienThiCBChon()
        {
            cbChon.Items.Add("Mã NV");
            cbChon.Items.Add("Tên Tài Khoản");
            cbChon.Items.Add("Họ Tên");
            cbChon.Items.Add("Ngày Sinh");
            cbChon.Items.Add("Số điện thoại & CMND");
            cbChon.Items.Add("Trạng Thái");
            cbChon.Items.Add("Khác");
            cbChon.SelectedIndex = 0;
        }


        private bool KiemTraPaste(TextBox Paste)
        {
            char[] XuLiPaste = Paste.Text.Trim().ToCharArray();
            for (int i = 0; i < XuLiPaste.Length; i++)
            {
                if (!char.IsDigit(XuLiPaste[i]))
                {
                    Paste.Focus();
                    Paste.Clear();
                    MessageBox.Show("Vui Lòng Nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
        }

        private bool KiemTraSoQuaLon(TextBox so)
        {
            if (float.Parse(so.Text.Trim()) >= 2000000000)
            {
                so.Clear();
                MessageBox.Show("Lớn Quá Rồi Đấy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void txtTimKiemNV_KeyUp(object sender, KeyEventArgs e)
        {
            if (KiemTraPaste(txtTimTheoMa))
            {
                return;
            }
            
            if (txtTimTheoMa.Text.Trim() == "" && txtTimTheoTen.Text.Trim() == "")
            {
                HienThiNhanVien();
                return;
            }

           
            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            DataView dv = bal_nv.getNhanVien().DefaultView;
            string result = "";
            if (cbChon.SelectedIndex.Equals(0))
            {
                if (txtTimTheoMa.Text.Trim() == "")
                {
                    return;
                }
                if (KiemTraSoQuaLon(txtTimTheoMa))
                {
                    return;
                }
           
                result = string.Format("MANV = {0}", int.Parse(txtTimTheoMa.Text.Trim()));
            }
            if (cbChon.SelectedIndex.Equals(1))
            {
                if (txtTimTheoTen.Text.Trim() == "")
                {
                    return;
                }
                result = string.Format("TenTaiKhoan like '%{0}%' ", txtTimTheoTen.Text.Trim());
            }
            if (cbChon.SelectedIndex.Equals(2))
            {
                if (txtTimTheoTen.Text.Trim() == "")
                {
                    return;
                }
                result = string.Format("HoTen like '%{0}%'", txtTimTheoTen.Text.Trim());
            }
            if (cbChon.SelectedIndex.Equals(3))
            {
                if (dtpSearch.Value.ToString() == "")
                {
                    return;
                }
                result = string.Format("NgaySinh = #{0}#", dtpSearch.Value);
            }
            if (cbChon.SelectedIndex.Equals(4))
            {
                if (txtTimTheoMa.Text.Trim() == "")
                {
                    return;
                }
                if (KiemTraSoQuaLon(txtTimTheoMa))
                {
                    return;
                }
                result = string.Format("SDT like '%{0}%' OR CMND like '%{0}%'",txtTimTheoMa.Text.Trim());
            }
            if (cbChon.SelectedIndex.Equals(5))
            {
                if (txtTimTheoTen.Text.Trim() == "")
                {
                    return;
                }
                 result = string.Format("TrangThai like '%{0}%'", txtTimTheoTen.Text.Trim());
            }
            if (cbChon.SelectedIndex.Equals(6))
            {
                if (txtTimTheoTen.Text.Trim() == "")
                {
                    return;
                }
                result = string.Format("Phai like '%{0}%' OR DiaChi like '%{0}%'", txtTimTheoTen.Text.Trim());
            }
            dv.RowFilter = result;
            dgvNV.DataSource = dv;
        }

        private void ckbXoaLoai_CheckedChanged(object sender, EventArgs e)
        {
           
            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            if (ckbXoaLoai.Checked)
            {
                dgvNV.DataSource = bal_nv.getNhanVien_Xoa();
                pnFunction.Enabled = false;
                if (dgvNV.Rows.Count <= 0)
                {
                    return;
                }
            }
            else
            {
                dgvNV.DataSource = bal_nv.getNhanVien();
                pnFunction.Enabled = true;
            }
        }

        private void txtTimTheoMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui Lòng Nhập Số","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void cbChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChon.SelectedIndex.Equals(0))
            {
                dtpSearch.Visible = false;
                btnClearNgay.Visible = false;
                txtTimTheoMa.Visible = true;
                txtTimTheoTen.Visible = false;
                txtTimTheoMa.Focus();
            }else if(cbChon.SelectedIndex.Equals(3))
            {
                txtTimTheoMa.Visible = false;
                txtTimTheoTen.Visible = false;
                dtpSearch.Visible = true;
                btnClearNgay.Visible = true;
                dtpSearch.Focus();
            }else if(cbChon.SelectedIndex.Equals(4)){
                dtpSearch.Visible = false;
                btnClearNgay.Visible = false;
                txtTimTheoMa.Visible = true;
                txtTimTheoTen.Visible = false;
                txtTimTheoMa.Focus();
            }
            else
            {
                dtpSearch.Visible = false;
                btnClearNgay.Visible = false;
                txtTimTheoMa.Visible = false;
                txtTimTheoTen.Visible = true;
                txtTimTheoTen.Focus();
            }

        }

       

        private void btnClearNgay_Click(object sender, EventArgs e)
        {
            HienThiNhanVien();
        }

        private void dtpSearch_ValueChanged(object sender, EventArgs e)
        {
            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            DataView dv = bal_nv.getNhanVien().DefaultView;
            DateTime dt = dtpSearch.Value;
            string result = "";
            if (cbChon.SelectedIndex == 3)
            {
                result = string.Format("NgaySinh = #{0}#", dt.ToString("MM/dd/yyyy"));
            }
            dv.RowFilter = result;
            dgvNV.DataSource = dv;
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            if (dgvNV.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FrmPhanQuyen pq = new FrmPhanQuyen();
            pq.MaNV = int.Parse(dgvNV.CurrentRow.Cells[0].Value.ToString());
            pq.ShowDialog();
            HienThiNhanVien();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbChon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            //FrmDoiMatKhau f = new FrmDoiMatKhau();
            //f.ShowDialog();

            if (dgvNV.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int MaNV = int.Parse(dgvNV.CurrentRow.Cells[0].Value.ToString());
            
            FrmDoiMatKhau f = new FrmDoiMatKhau(MaNV);
            f.ShowDialog();
           
            HienThiNhanVien();
            
        }

     

     
    }
}
