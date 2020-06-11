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

namespace QuanLiCuaHangQuanAo.NhaNSX
{
    public partial class FrmTrangNhaNSX : Form
    {
        public FrmTrangNhaNSX()
        {
            InitializeComponent();
        }

        private void btnThemNSX_Click(object sender, EventArgs e)
        {
            FrmThemNhaNSX frmThem = new FrmThemNhaNSX();
            frmThem.ShowDialog();
            HienThiNhaNSX();
        }

        private void btnSuaNSX_Click(object sender, EventArgs e)
        {
            if (dgvNhaNSX.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int MaNSX =int.Parse(dgvNhaNSX.CurrentRow.Cells[0].Value.ToString());
            FrmCapNhatNhaNSX frmCapNhat = new FrmCapNhatNhaNSX();
            frmCapNhat.MaNSX = MaNSX;
            frmCapNhat.ShowDialog();
            HienThiNhaNSX();
        }

        private void HienThiNhaNSX()
        {
            BAL_NHANSX bal_nsx = new BAL_NHANSX();
            dgvNhaNSX.DataSource = bal_nsx.getNhaNSX();
        }

        private void FrmTrangNhaNSX_Load(object sender, EventArgs e)
        {
            HienThiNhaNSX();
            cbHienThiNhaNSX();
        }

        private void cbHienThiNhaNSX(){
            cbChon.Items.Add("Mã NSX");
            cbChon.Items.Add("Điện Thoại NSX");
            cbChon.Items.Add("Khác");
            cbChon.SelectedIndex = 0;
        }
        private void btnXoaNSX_Click(object sender, EventArgs e)
        {
            if (dgvNhaNSX.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn Có Muốn Xóa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int MaNSX = int.Parse(dgvNhaNSX.CurrentRow.Cells[0].Value.ToString());
                BAL_NHANSX bal_nsx = new BAL_NHANSX();
                bool isXoa = bal_nsx.Xoa(MaNSX);
                if (isXoa)
                {
                    MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                HienThiNhaNSX();
            }
        }

        private void cbChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChon.SelectedIndex.Equals(0) || cbChon.SelectedIndex.Equals(1))
            {
                txtTimTheoTen.Visible = false;
                txtTimTheoMa.Visible = true;
                txtTimTheoMa.Focus();
            }
            else
            {
                txtTimTheoTen.Visible = true;
                txtTimTheoMa.Visible = false;
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
     
        private void txtTimTheoMa_KeyUp(object sender, KeyEventArgs e)
        {
            if (KiemTraPaste(txtTimTheoMa))
            {
                return;
            }
           
            if (txtTimTheoMa.Text.Trim() == "" && txtTimTheoTen.Text.Trim() == "")
            {
                HienThiNhaNSX();
                return;
            }
            BAL_NHANSX bal_nsx = new BAL_NHANSX();
            DataView dv = bal_nsx.getNhaNSX().DefaultView;
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
                dv.RowFilter = string.Format("MaNSX = {0}", int.Parse(txtTimTheoMa.Text.Trim()));
            }else if(cbChon.SelectedIndex.Equals(1))
            {
                if (txtTimTheoMa.Text.Trim() == "")
                {
                    return;
                }
                if (KiemTraSoQuaLon(txtTimTheoMa))
                {
                    return;
                }
                dv.RowFilter = string.Format("DienThoaiNSX ={0}",int.Parse(txtTimTheoMa.Text));
            }else if (cbChon.SelectedIndex.Equals(2))
            {
                if (txtTimTheoTen.Text.Trim() == "")
                {
                    return;
                }
                dv.RowFilter = string.Format("TenNSX LIKE '%{0}%' OR DiaChiNSX LIKE '%{0}%'", txtTimTheoTen.Text.Trim());
            }
            dgvNhaNSX.DataSource = dv;

        }

        private void txtTimTheoMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui Lòng Nhập Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ckbXoaLoai_CheckedChanged(object sender, EventArgs e)
        {
            BAL_NHANSX bal_nsx = new BAL_NHANSX();
            if (ckbXoaLoai.Checked)
            {
                dgvNhaNSX.DataSource = bal_nsx.getNhaNSX_Xoa();
                pnFunction.Enabled = false;
                if (dgvNhaNSX.Rows.Count <= 0)
                {
                    return;
                }
            }
            else
            {
                dgvNhaNSX.DataSource = bal_nsx.getNhaNSX();
                pnFunction.Enabled = true;
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
