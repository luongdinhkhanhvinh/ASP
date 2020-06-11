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
    public partial class FrmInBaoCaoHangTonKho : Form
    {
        public FrmInBaoCaoHangTonKho()
        {
            InitializeComponent();
        }
        private int _slTon;
        private string _maNV;
        public FrmInBaoCaoHangTonKho(int slton,string maNV)
        {
            InitializeComponent();
            this._slTon = slton;
            this._maNV = maNV;
        }

        private void FrmInBaoCaoHangTonKho_Load(object sender, EventArgs e)
        {
            rpvInHangTonKho.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangQuanAo.rptInBaoCaoHangTon.rdlc";
            dsBaoCaoHangTonKhoTableAdapters.SanPhamTableAdapter da = new dsBaoCaoHangTonKhoTableAdapters.SanPhamTableAdapter();
            dsBaoCaoHangTonKho.SanPhamDataTable dt = new dsBaoCaoHangTonKho.SanPhamDataTable();
            da.FillBySLTon(dt, this._slTon);
            rpvInHangTonKho.LocalReport.DataSources.Add(new ReportDataSource("dsInBaoCaoHangTonKho", (DataTable)dt));
            rpvInHangTonKho.LocalReport.SetParameters(new ReportParameter("MaNV",this._maNV.ToString()));
            this.rpvInHangTonKho.RefreshReport();
        }
    }
}
