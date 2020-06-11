using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiCuaHangQuanAo.InBaoCao;
using Microsoft.Reporting.WinForms;
using BAL;
namespace QuanLiCuaHangQuanAo.BaoCao
{
    public partial class FrmTrangBaoCao : Form
    {

        private int _maNV;

        public FrmTrangBaoCao()
        {
            InitializeComponent();
        }
        public FrmTrangBaoCao(int manv)
        {
            InitializeComponent();
            this._maNV = manv;
        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmTrangBaoCao_Load(object sender, EventArgs e)
        {
            HienThiFormChucBaoCao(new FrmTrangDoanhThu());
            pnFunction.Visible = true;
            btnInRaTonKho.Enabled = false;
            pnFunctionSLTon.Visible = false;
            btnInRaDoanhThu.Enabled = false;
            dtpDenNgay.Value = DateTime.Now;
        }

        private void HienThiFormChucBaoCao(Form c)
        {
            c.TopLevel = false;
            pnHienThiFormCon.Controls.Clear();
            pnHienThiFormCon.Controls.Add(c);
            c.Show();

        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            HienThiFormChucBaoCao(new FrmTrangDoanhThu());
            pnFunction.Visible = true;
            pnFunctionSLTon.Visible = false;
        }

        

        private void btnHangTon_Click(object sender, EventArgs e)
        {
            HienThiFormChucBaoCao(new FrmTrangHangTon());
            pnFunction.Visible = false;
            pnFunctionSLTon.Visible = true;
        }

       

        private void btnXem_Click(object sender, EventArgs e)
        {
           
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                dtpTuNgay.Focus();
                MessageBox.Show("Ngày Bắt Đầu Phải nhỏ đến ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtpDenNgay.Value > DateTime.Now)
            {
                dtpDenNgay.Focus();
                MessageBox.Show("Phải chọn ngày đến nhỏ hơn hoặc bằng ngày hiện tại mới có kết quả","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;
            btnInRaDoanhThu.Enabled = true;
            FrmTrangDoanhThu f = new FrmTrangDoanhThu(tuNgay,denNgay,this._maNV);
            HienThiFormChucBaoCao(f);
        }

       
        private void btnInRaSLTon_Click(object sender, EventArgs e)
        {
            if (txtSoLuongTon.Text.Trim() == "")
            {
                MessageBox.Show("Bạn Vui Lòng Nhập Số Lượng Trước Khi In", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongTon.Focus();
                return;
            }
            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            DataTable dt_nv = bal_nv.getNhanVien_MaNV(this._maNV);
            string tenNV = dt_nv.Rows[0]["HoTen"].ToString();
            FrmInBaoCaoHangTonKho ht = new FrmInBaoCaoHangTonKho(int.Parse(txtSoLuongTon.Text.Trim()),tenNV);
            ht.ShowDialog();
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
        private void btnXemSLTon_Click(object sender, EventArgs e)
        {
            if (txtSoLuongTon.Text.Trim() == "")
            {
                MessageBox.Show("Vui Lòng Nhập Số Lượng Tồn","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (KiemTraPaste(txtSoLuongTon))
            {
                return;
            }
            if (KiemTraSoQuaLon(txtSoLuongTon))
            {
                return;
            }
            btnInRaTonKho.Enabled = true;
            FrmTrangHangTon f_ton =new FrmTrangHangTon();
            f_ton.SlTon = int.Parse(txtSoLuongTon.Text.Trim());
            HienThiFormChucBaoCao(f_ton);
        }

        private void txtSoLuongTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) || e.KeyChar ==' ')
            {
                e.Handled = true;
            }
        }

        private void pnFunction_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInRaDoanhThu_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                dtpTuNgay.Focus();
                MessageBox.Show("Ngày Bắt Đầu Phải nhỏ đến ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtpDenNgay.Value > DateTime.Now)
            {
                dtpDenNgay.Focus();
                MessageBox.Show("Phải chọn ngày đến nhỏ hơn hoặc bằng ngày hiện tại mới có kết quả", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;
            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            DataTable dt_nv = bal_nv.getNhanVien_MaNV(this._maNV);
            string tenNV = dt_nv.Rows[0]["HoTen"].ToString();
            FrmInBaoCaoDoanhThu dt = new FrmInBaoCaoDoanhThu(tuNgay, denNgay,tenNV);
            dt.ShowDialog();
        }

        private void txtSoLuongTon_TextChanged(object sender, EventArgs e)
        {

        }

    

       
    }
}
