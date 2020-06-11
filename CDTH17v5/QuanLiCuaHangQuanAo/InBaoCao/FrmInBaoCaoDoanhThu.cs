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
    public partial class FrmInBaoCaoDoanhThu : Form
    {
        public FrmInBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private DateTime _tuNgay;
        private DateTime _denNgay;
        private string _maNV;
        public FrmInBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay,  string MaNV)
        {
            InitializeComponent();
            this._tuNgay = tuNgay;
            this._denNgay = denNgay;
            this._maNV = MaNV;
        }

        private void FrmInBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            rpvInBaoCaoDoanhThu.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangQuanAo.rptInBaoCaoDoanhThu.rdlc";
            dsInBaoCaoDoanhThuTableAdapters.V_ChiTietHoaDon_HoaDonTableAdapter da = new dsInBaoCaoDoanhThuTableAdapters.V_ChiTietHoaDon_HoaDonTableAdapter();
            dsInBaoCaoDoanhThu.V_ChiTietHoaDon_HoaDonDataTable dt = new dsInBaoCaoDoanhThu.V_ChiTietHoaDon_HoaDonDataTable();
           
            da.FillByTuNgay_DenNgay(dt, this._tuNgay, this._denNgay);
            rpvInBaoCaoDoanhThu.LocalReport.DataSources.Add(new ReportDataSource("dsInBaoCaoDoanhThu", (DataTable)dt));
            rpvInBaoCaoDoanhThu.LocalReport.SetParameters(new ReportParameter("MaNV",this._maNV));

            this.rpvInBaoCaoDoanhThu.RefreshReport();
        }
    }
}
