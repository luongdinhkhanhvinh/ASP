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

namespace QuanLiCuaHangQuanAo.KhuyenMai
{
    public partial class FrmCapNhatKhuyenMai : Form
    {
        public FrmCapNhatKhuyenMai()
        {
            InitializeComponent();
        }

        private int _maKM;

        public int MaKM
        {
            get { return _maKM; }
            set { _maKM = value; }
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
            if (txtUuDai.Text.Trim() == "")
            {
                txtUuDai.Focus();
                MessageBox.Show("Bạn Chưa Nhập Ưu Đãi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dtpBatDau.Value > dtpKetThuc.Value)
            {
                dtpKetThuc.Focus();
                MessageBox.Show("Chọn Ngày kết thúc lớn hơn ngày Bắt Đầu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (int.Parse(txtUuDai.Text.Trim()) < 0 || int.Parse(txtUuDai.Text.Trim()) > 100)
            {
                MessageBox.Show("Tối Đa 100", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUuDai.Focus();
                return;
            }
            if (KiemTraPaste(txtUuDai))
            {
                return;
            }
            BAL_KHUYENMAI bal_km = new BAL_KHUYENMAI();
            for (int i = 0; i < bal_km.getKhuyenMai().Rows.Count; i++)
            {
                if (txtUuDai.Text.Trim() == bal_km.getKhuyenMai().Rows[i]["UuDai"].ToString())
                {
                    MessageBox.Show("Ưu Đãi Không được Trùng Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUuDai.Focus();
                    return;
                }
                if (dtpBatDau.Text.Trim() == bal_km.getKhuyenMai().Rows[i]["NgayBatDau"].ToString())
                {
                    MessageBox.Show("Ngày Bắt Đầu Không được Trùng Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpBatDau.Focus();
                    return;
                }
                if (dtpKetThuc.Text.Trim() == bal_km.getKhuyenMai().Rows[i]["NgayKetThuc"].ToString())
                {
                    MessageBox.Show("Ngày Kết Thúc Không được Trùng Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpKetThuc.Focus();
                    return;
                }
            }
            bool isCapNhat = bal_km.CapNhat(new KHUYENMAI(txtUuDai.Text.Trim(), dtpBatDau.Value, dtpKetThuc.Value), _maKM);
            if (isCapNhat)
            {
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
        }

        private void FrmCapNhatKhuyenMai_Load(object sender, EventArgs e)
        {
            BAL_KHUYENMAI bal_km = new BAL_KHUYENMAI();
            DataTable dt = bal_km.getKhuyenMai_MaKM(_maKM);
            DataRow dr = dt.Rows[0];
            txtUuDai.Text = dr["UuDai"].ToString();
            dtpBatDau.Value = DateTime.Parse(dr["NgayBatDau"].ToString());
            dtpKetThuc.Value = DateTime.Parse(dr["NgayKetThuc"].ToString());
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtpBatDau_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpKetThuc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtUuDai_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTieuDe_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUuDai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtUuDai.Text.Trim().Length == 3 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
