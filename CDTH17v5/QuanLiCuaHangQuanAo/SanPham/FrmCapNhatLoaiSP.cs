using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BAL;
using BEL;
namespace QuanLiCuaHangQuanAo.SanPham
{
    public partial class FrmCapNhatLoaiSP : Form
    {
        public FrmCapNhatLoaiSP()
        {
            InitializeComponent();
        }

        private int _capNhatLoai;

        public int CapNhatLoai
        {
            get { return _capNhatLoai; }
            set { _capNhatLoai = value; }
        }

        

        private void btnXong_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiSP.Text.Trim() == "")
            {
                txtTenLoaiSP.Focus();
                MessageBox.Show("Vui Lòng Nhập Tên Loại SP", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BAL_LOAISP l = new BAL_LOAISP();
            for (int i = 0; i < l.getLoaiSP().Rows.Count; i++)
            {
                if (txtTenLoaiSP.Text.Trim() == l.getLoaiSP().Rows[i]["TenLoaiSP"].ToString())
                {
                    MessageBox.Show("Đã có sản phẩm trùng");
                    txtTenLoaiSP.Focus();
                    return;
                }
            }
            if (txtMoTa.Text.Trim() == "")
            {
                txtMoTa.Focus();
                MessageBox.Show("Vui Lòng Nhập Mô Tả SP", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BAL_LOAISP bal_lsp = new BAL_LOAISP();
            bool isCapNhat = bal_lsp.CapNhat(new LOAISP(txtTenLoaiSP.Text.Trim(), txtMoTa.Text.Trim()),_capNhatLoai);
           
            if (isCapNhat)
            {
                this.Close();
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Close();
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmCapNhatLoaiSP_Load(object sender, EventArgs e)
        {
            BAL_LOAISP bal_lsp = new BAL_LOAISP();
            DataTable dt = bal_lsp.getLoaiSP_MaLoaiSP(_capNhatLoai);
            DataRow dr = dt.Rows[0];
            string TenLoaiSP = dr["TenLoaiSP"].ToString();
            string MoTa = dr["MoTa"].ToString();
            txtTenLoaiSP.Text = TenLoaiSP.ToString();
            txtMoTa.Text = MoTa.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
