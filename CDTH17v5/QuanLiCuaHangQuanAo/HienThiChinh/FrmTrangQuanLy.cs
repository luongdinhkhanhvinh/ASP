using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiCuaHangQuanAo.SanPham;
using QuanLiCuaHangQuanAo.KhuyenMai;
using QuanLiCuaHangQuanAo.NhaNSX;
using QuanLiCuaHangQuanAo.NhanVien;
using QuanLiCuaHangQuanAo.BaoCao;


namespace QuanLiCuaHangQuanAo.HienThiChinh
{
    public partial class FrmTrangQuanLy : Form
    {
        public FrmTrangQuanLy()
        {
            InitializeComponent();
        }
        private void SetPannelView(Form ct)
        {
            ct.TopLevel = false;
            pnView.Controls.Clear();
            pnView.Controls.Add(ct);
            ct.Show();
        }
        private void HienSanPham()
        {
            SetPannelView(new FrmSanPham());
        }
        private void HienThiKhuyenMai()
        {
            SetPannelView(new FrmKhuyenMai());
        }
        private void HienThiNhaNSX()
        {
            SetPannelView(new FrmTrangNhaNSX());
        }

        private void HienThiBaoCao()
        {
            SetPannelView(new FrmTrangBaoCao());
        }
       
        private void HienThiNhanVien()
        {
            SetPannelView(new FrmTrangNhanVien());
        }
        private void HienThiLoaiSP()
        {
            SetPannelView(new FrmLoaiSanPham());
        }
       
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            HienSanPham();
        }
       
        private void FrmTrangQuanLy_Load(object sender, EventArgs e)
        {
            HienSanPham();
            StartTimer();
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            HienThiKhuyenMai();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDangNhap frmdn = new FrmDangNhap();
            frmdn.ShowDialog();
        }

        private void btnNhaSanXuat_Click(object sender, EventArgs e)
        {
            HienThiNhaNSX();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            HienThiBaoCao();
        }

  

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            HienThiNhanVien();
        }

      
        private void StartTimer()
        {
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            lblTimer.Text = dt.ToString("dd/MM/yyyy hh:mm:ss tt");
        }

        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            HienThiLoaiSP();
        }

        private void pnDanhMuc_Paint(object sender, PaintEventArgs e)
        {

        }

       
     

       


       
    }
}
