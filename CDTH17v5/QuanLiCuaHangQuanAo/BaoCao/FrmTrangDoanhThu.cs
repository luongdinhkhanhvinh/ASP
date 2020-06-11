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
using BAL;
namespace QuanLiCuaHangQuanAo.BaoCao
{
    public partial class FrmTrangDoanhThu : Form
    {

        private DateTime _tuNgay;
        private DateTime _denNgay;
        private int _maNV;
        public FrmTrangDoanhThu()
        {
            InitializeComponent();
            this._tuNgay = DateTime.Parse("1/1/1999");
            this._denNgay = DateTime.Parse("1/1/1999");
            this._maNV = 0;
        }


       
        public FrmTrangDoanhThu(DateTime tuNgay, DateTime denNgay,int maNV)
        {
            InitializeComponent();
            this._tuNgay = tuNgay;
            this._denNgay = denNgay;
            this._maNV = maNV;
        }

        private void FrmTrangDoanhThu_Load(object sender, EventArgs e)
        {
            BAL_CHITIETHOADON h = new BAL_CHITIETHOADON();
            DataTable dt = h.getChiTietHoaDon_layN(this._tuNgay, this._denNgay);
            dgvDoanhThu.DataSource = dt;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDoanhThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int MaHD =int.Parse( dgvDoanhThu.CurrentRow.Cells[0].Value.ToString());
            float TongTien = float.Parse(dgvDoanhThu.CurrentRow.Cells[1].Value.ToString());
            BAL_CHITIETHOADON bal_cthd = new BAL_CHITIETHOADON();
            DataTable dt = bal_cthd.getChiTietHoaDon_MaHD(MaHD);
            DataRow dr = dt.Rows[0];
            DateTime ngaylap = (DateTime)dr["NgayLapHD"];
            BAL_HOADON bal_hd = new BAL_HOADON();
            DataTable dt_hd = bal_hd.getHoaDon_MaHD(MaHD);
            DataRow dr_hd = dt_hd.Rows[0];
            int MaNV = int.Parse(dr_hd["MaNV"].ToString());
            BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            DataTable dt_nv = bal_nv.getNhanVien_MaNV(this._maNV);
            string TenNV = dt_nv.Rows[0]["HoTen"].ToString();
            FrmInChiTietHoaDon cthd = new FrmInChiTietHoaDon(TenNV,MaHD,ngaylap,TongTien);
            cthd.ShowDialog();
        }

        private void dgvDoanhThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
