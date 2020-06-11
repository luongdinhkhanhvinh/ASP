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
namespace QuanLiCuaHangQuanAo.KhuyenMai
{
    public partial class FrmKhuyenMai : Form
    {
        public FrmKhuyenMai()
        {
            InitializeComponent();
        }

        private void FrmKhuyenMai_Load(object sender, EventArgs e)
        {
            HienThiKhuyenMai();
            HienThiCBChon();
        }
        private void HienThiCBChon()
        {
            cbChon.Items.Add("Mã Khuyến Mãi");
            cbChon.Items.Add("Ưu Đãi");
            cbChon.Items.Add("Ngày Bắt Đầu");
            cbChon.Items.Add("Ngày Kết Thúc");
            cbChon.SelectedIndex = 2;
        }

        private void HienThiKhuyenMai()
        {
            BAL_KHUYENMAI bal_km = new BAL_KHUYENMAI();
            dgvKhuyenMai.DataSource = bal_km.getKhuyenMai();
        }

        private void btnThemKM_Click(object sender, EventArgs e)
        {
            FrmThemKhuyenMai frmTKM = new FrmThemKhuyenMai();
            frmTKM.ShowDialog();
            HienThiKhuyenMai();
        }

        private void btnSuaKM_Click(object sender, EventArgs e)
        {
            if (dgvKhuyenMai.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int MaKm = int.Parse(dgvKhuyenMai.CurrentRow.Cells[0].Value.ToString());
            FrmCapNhatKhuyenMai frmCNKM = new FrmCapNhatKhuyenMai();
            frmCNKM.MaKM = MaKm;
            frmCNKM.ShowDialog();
            HienThiKhuyenMai();
        }

        private void btnXoaKM_Click(object sender, EventArgs e)
        {
            if (dgvKhuyenMai.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn Có Muốn Xóa Loại Này", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int MaKm = int.Parse(dgvKhuyenMai.CurrentRow.Cells[0].Value.ToString());
                BAL_KHUYENMAI bal_km = new BAL_KHUYENMAI();
                bool isXoa = bal_km.Xoa(MaKm);
                if (isXoa)
                {
                    MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                HienThiKhuyenMai();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChon.SelectedIndex == 0)
            {
                dtpSearch.Visible = false;
                btnClearNgay.Visible = false;
                txtTimTheoMa.Visible = true;
                txtTimTheoTen.Visible = false;
                txtTimTheoMa.Focus();
            }
            else if (cbChon.SelectedIndex == 2 || cbChon.SelectedIndex == 3)
            {
                txtTimTheoMa.Visible = false;
                btnClearNgay.Visible = true;
                txtTimTheoTen.Visible = false;
                dtpSearch.Visible = true;
                dtpSearch.Focus();
            }else
            {
                btnClearNgay.Visible = false;
                dtpSearch.Visible = false;
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
            if (KiemTraPaste(txtTimTheoMa))
            {
                return;
            }
           
            BAL_KHUYENMAI bal_km = new BAL_KHUYENMAI();
            if (txtTimTheoMa.Text.Trim() == "" && txtTimTheoTen.Text.Trim() == "")
            {
                dgvKhuyenMai.DataSource = bal_km.getKhuyenMai();
                return;
            }
            
            DataView dv = bal_km.getKhuyenMai().DefaultView;
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
                result = string.Format("MaKM = {0}",int.Parse(txtTimTheoMa.Text.Trim()));
            }
            if (cbChon.SelectedIndex.Equals(1))
            {
                if (txtTimTheoTen.Text.Trim() == "")
                {
                    return;
                }
                result = string.Format("UuDai like '%{0}%'", txtTimTheoTen.Text.Trim());
            }
           
            dv.RowFilter = result;
            dgvKhuyenMai.DataSource = dv;
        }

        private void ckbXoaLoai_CheckedChanged(object sender, EventArgs e)
        {
           
            BAL_KHUYENMAI bal_km = new BAL_KHUYENMAI();
            if (ckbXoaLoai.Checked)
            {
                
                dgvKhuyenMai.DataSource = bal_km.getKhuyenMai_Xoa();
                pnFunction.Enabled = false;
                if (dgvKhuyenMai.Rows.Count <= 0)
                {
                    return;
                }
            }
            else
            {
                dgvKhuyenMai.DataSource = bal_km.getKhuyenMai();
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

      
        private void dtpSearch_ValueChanged(object sender, EventArgs e)
        {
            BAL_KHUYENMAI bal_km = new BAL_KHUYENMAI();
            DataView dv = bal_km.getKhuyenMai().DefaultView;
            DateTime dt = dtpSearch.Value;
            string result = "";
            if (cbChon.SelectedIndex == 2)
            {
                result = string.Format("NgayBatDau = #{0}#", dt.ToString("MM/dd/yyyy"));
            }
            else if(cbChon.SelectedIndex == 3)
            {
                result = string.Format("NgayKetThuc = #{0}#", dt.ToString("MM/dd/yyyy"));
                
            }
            dv.RowFilter = result;
            dgvKhuyenMai.DataSource = dv;
        }

        private void btnClearNgay_Click(object sender, EventArgs e)
        {
            HienThiKhuyenMai();
        }

        private void cbChon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        
    }
}
