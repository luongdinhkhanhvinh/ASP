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

namespace QuanLiCuaHangQuanAo.NhaNSX
{
    public partial class FrmCapNhatNhaNSX : Form
    {
        public FrmCapNhatNhaNSX()
        {
            InitializeComponent();
        }
        private int _maNSX;

        public int MaNSX
        {
            get { return _maNSX; }
            set { _maNSX = value; }
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
            if (txtTenNSX.Text.Trim() == "")
            {
                txtTenNSX.Focus();
                MessageBox.Show("Bạn Chưa Nhập Tên NSX", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtDiaChi.Text.Trim() == "")
            {
                txtDiaChi.Focus();
                MessageBox.Show("Bạn Chưa Nhập Tên địa Chi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSDT.Text.Trim() == "")
            {
                txtDiaChi.Focus();
                MessageBox.Show("Bạn Chưa Nhập SDT", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (KiemTraPaste(txtSDT))
            {
                return;
            }

            BAL_NHANSX bal_nsx = new BAL_NHANSX();
            for (int i = 0; i < bal_nsx.getNhaNSX().Rows.Count; i++)
            {
                if (txtTenNSX.Text.Trim() == bal_nsx.getNhaNSX().Rows[i]["TenNSX"].ToString())
                {
                    MessageBox.Show("TenNSX Không được Trùng Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenNSX.Focus();
                    return;
                }
                if (txtSDT.Text.Trim() == bal_nsx.getNhaNSX().Rows[i]["DienThoaiNSX"].ToString())
                {
                    MessageBox.Show("SDT Không được Trùng Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSDT.Focus();
                    return;
                }
                if (txtDiaChi.Text.Trim() == bal_nsx.getNhaNSX().Rows[i]["DiaChiNSX"].ToString())
                {
                    MessageBox.Show("Địa Chỉ Không được Trùng Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDiaChi.Focus();
                    return;
                }
            }
            bool isCapNhat = bal_nsx.CapNhat(new NHANSX(txtTenNSX.Text.Trim(), txtDiaChi.Text.Trim(), txtSDT.Text.Trim()), _maNSX);
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

        private void FrmCapNhatNhaNSX_Load(object sender, EventArgs e)
        {
            BAL_NHANSX bal_NhaNSX = new BAL_NHANSX();
            DataTable dt = bal_NhaNSX.getNhaNSX_MaNSX(_maNSX);
            DataRow dr = dt.Rows[0];
            txtTenNSX.Text = dr["TenNSX"].ToString();
            txtDiaChi.Text = dr["DiaChiNSX"].ToString();
            txtSDT.Text = dr["DienThoaiNSX"].ToString();
            
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
                MessageBox.Show("Không Được Quá 10", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
