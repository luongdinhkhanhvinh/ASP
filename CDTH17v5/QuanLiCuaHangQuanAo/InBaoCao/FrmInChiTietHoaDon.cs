using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace QuanLiCuaHangQuanAo.InBaoCao
{
    public partial class FrmInChiTietHoaDon : Form
    {
        private string _maNV;
        private int _maHD;
        private DateTime _NgayLap;
        private float _TongTien;
        
        
        public FrmInChiTietHoaDon()
        {
            InitializeComponent();
        }
        public FrmInChiTietHoaDon(string manv, int mahd,DateTime ngaylap,float tongtien)
        {
            InitializeComponent();
            this._maNV = manv;
            this._maHD = mahd;
            this._NgayLap = ngaylap;
            this._TongTien = tongtien;
        }

        private void FrmInChiTietHoaDon_Load(object sender, EventArgs e)
        {
            rpvChiTietHoaDon.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangQuanAo.rpvChiTietHoaDon.rdlc";
            dsChiTietHoaDonTableAdapters.V_ChiTietHoaDon_SanPhamTableAdapter da = new dsChiTietHoaDonTableAdapters.V_ChiTietHoaDon_SanPhamTableAdapter();
            dsChiTietHoaDon.V_ChiTietHoaDon_SanPhamDataTable dt = new dsChiTietHoaDon.V_ChiTietHoaDon_SanPhamDataTable();
            da.FillByMaHD(dt, this._maHD);
            rpvChiTietHoaDon.LocalReport.DataSources.Add(new ReportDataSource("dsChiTietHoaDon", (DataTable)dt));
            rpvChiTietHoaDon.LocalReport.SetParameters(new ReportParameter("NguoiLap",this._maNV+""));
            rpvChiTietHoaDon.LocalReport.SetParameters(new ReportParameter("MaHD",this._maHD+""));
            rpvChiTietHoaDon.LocalReport.SetParameters(new ReportParameter("NgayLap",this._NgayLap.ToString("dd/MM/yyyy")));
            rpvChiTietHoaDon.LocalReport.SetParameters(new ReportParameter("TongTien",this._TongTien+""));


            
            this.rpvChiTietHoaDon.RefreshReport();
        }
    }
}
