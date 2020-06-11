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
namespace QuanLiCuaHangQuanAo.SanPham
{
    public partial class FrmThemLoaiSanPham : Form
    {
        public FrmThemLoaiSanPham()
        {
            InitializeComponent();
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            
            if (txtTenLoaiSP.Text.Trim() == "")
            {
                txtTenLoaiSP.Focus();
                MessageBox.Show("Vui Lòng Nhập Tên Loại","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Question);
                return;
            }
            //DataTable lsp = new DataTable();
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
                MessageBox.Show("Vui Lòng Nhập Mô Tả", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            BAL_LOAISP bal_lsp = new BAL_LOAISP();
            bool isThem = bal_lsp.Them(new LOAISP(txtTenLoaiSP.Text.Trim(),txtMoTa.Text.Trim()));
            if (isThem)
            {
                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

            this.Close();


        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
