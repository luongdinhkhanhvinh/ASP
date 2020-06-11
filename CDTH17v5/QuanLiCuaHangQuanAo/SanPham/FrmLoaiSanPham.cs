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
namespace QuanLiCuaHangQuanAo.SanPham
{
    public partial class FrmLoaiSanPham : Form
    {
        public FrmLoaiSanPham()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void HienThiDanhSachLoaiSP()
        {
            BAL_LOAISP bal_loaisp = new BAL_LOAISP();
            dgvLoai.DataSource = bal_loaisp.getLoaiSP();
        }
        private void btnThemLoaiSP_Click(object sender, EventArgs e)
        {
            FrmThemLoaiSanPham frmTSP = new FrmThemLoaiSanPham();
            frmTSP.ShowDialog();
            HienThiDanhSachLoaiSP();
           
        }

        private void btnSuaLoaiSP_Click(object sender, EventArgs e)
        {
            if (dgvLoai.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu để chọn bạn nên thêm vào ","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            int MaLoaiSP = int.Parse(dgvLoai.CurrentRow.Cells[0].Value.ToString());
            FrmCapNhatLoaiSP frmCNSP = new FrmCapNhatLoaiSP();
            frmCNSP.CapNhatLoai = MaLoaiSP;
            frmCNSP.ShowDialog();
            HienThiDanhSachLoaiSP();
           
        }

        private void btnXoaLoaiSP_Click(object sender, EventArgs e)
        {
            if (dgvLoai.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn Có Muốn Xóa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                BAL_LOAISP bal_lsp = new BAL_LOAISP();
                int MaLoaiSP = int.Parse(dgvLoai.CurrentRow.Cells[0].Value.ToString());
                bool isXoa = bal_lsp.Xoa(MaLoaiSP);
                if (isXoa)
                {
                    HienThiDanhSachLoaiSP();
                    MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    HienThiDanhSachLoaiSP();
                    MessageBox.Show("Xóa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void ckbXoaLoai_CheckedChanged(object sender, EventArgs e)
        {
           
            if (ckbXoaLoai.Checked)
            {
                
                BAL_LOAISP lsp = new BAL_LOAISP();
                dgvLoai.DataSource = lsp.getLoaiSPXoa();
                pnFuntion.Enabled = false;
                if (dgvLoai.Rows.Count <= 0)
                {
                    return;
                }
            }
            else
            {
                
                BAL_LOAISP lsp = new BAL_LOAISP();
                dgvLoai.DataSource = lsp.getLoaiSP();
                pnFuntion.Enabled = true;
               
            }
        }

        private void FrmLoaiSanPham_Load(object sender, EventArgs e)
        {
            HienThiDanhSachLoaiSP();
            HienThiLoaiSPTim();
        }
        private void HienThiLoaiSPTim()
        {
            cbChon.Items.Add("Mã Loại");
            cbChon.Items.Add("Khác");
            cbChon.SelectedIndex = 0;
        }

        private void cbChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChon.SelectedIndex.Equals(0))
            {
                txtTimTheoMa.Visible = true;
                txtTimTheoTen.Visible = false;
                txtTimTheoMa.Focus();
            }
            else
            {
                txtTimTheoMa.Visible = false;
                txtTimTheoTen.Visible = true;
                txtTimTheoTen.Focus();
            }
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

        private void txtTimTheoTen_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTimTheoMa.Text.Trim() == "" && txtTimTheoTen.Text.Trim() == "")
            {
                HienThiDanhSachLoaiSP();
                return;
            }
            if (KiemTraPaste(txtTimTheoMa))
            {
                return;
            }
           
            BAL_LOAISP bal_lsp = new BAL_LOAISP();
            DataView dv = bal_lsp.getLoaiSP().DefaultView;
            dv.RowFilter = "";
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
                dv.RowFilter = string.Format("MaLoaiSP = {0}", int.Parse(txtTimTheoMa.Text.Trim()));
            }
            else if (cbChon.SelectedIndex.Equals(1))
            {
                if (txtTimTheoTen.Text.Trim() == "")
                {
                    return;
                }
                dv.RowFilter = string.Format("TenLoaiSP LIKE '%{0}%' OR MoTa LIKE '%{0}%'", txtTimTheoTen.Text.Trim());
            }
            dgvLoai.DataSource = dv;
            
        }

       
        private void txtTimTheoMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui Lòng Nhập Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbChon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtTimTheoTen_TextChanged(object sender, EventArgs e)
        {

        }

     

      
    }
}
