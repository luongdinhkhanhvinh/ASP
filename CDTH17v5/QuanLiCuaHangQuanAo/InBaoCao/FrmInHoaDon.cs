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
    public partial class FrmInHoaDon : Form
    {
        public FrmInHoaDon()
        {
            InitializeComponent();
        }

        int mahd;
        float tongtien, tienkhachdua, tientralai;
        string manv,ngaylap;
        

        public FrmInHoaDon(string manv,int mahd,float tongtien,float tienkhachdua,float tientralai,string ngaylap)
        {
            InitializeComponent();
            this.manv = manv;
            this.mahd = mahd;
            this.tongtien = tongtien;
            this.tienkhachdua = tienkhachdua;
            this.tientralai=tientralai;
            this.ngaylap = ngaylap;
        }

        private void FrmInHoaDon_Load(object sender, EventArgs e)
        {
            //nhúng vào report
            rpvHoaDon.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangQuanAo.rpvInHoaDon.rdlc";
            
            //Khởi tạo Adapter
            dsInHoaDon.V_ChiTietHoaDon_SanPhamDataTable dt = new dsInHoaDon.V_ChiTietHoaDon_SanPhamDataTable();
            dsInHoaDonTableAdapters.V_ChiTietHoaDon_SanPhamTableAdapter da = new dsInHoaDonTableAdapters.V_ChiTietHoaDon_SanPhamTableAdapter();
            da.FillByMaHD(dt,mahd);

            //add vào ?? đổ bảng ds khác thì làm sao??? -> Đã Giải Quyết
            rpvHoaDon.LocalReport.DataSources.Add(new ReportDataSource("dsInHoaDon", (DataTable)dt));//dsIn hóa đơn này là name trong report lúc vừa tạo đặt name cho table ý
            
            rpvHoaDon.LocalReport.SetParameters(new ReportParameter("MaNV",this.manv.ToString()));
            rpvHoaDon.LocalReport.SetParameters(new ReportParameter("MaHD", this.mahd.ToString()));
            rpvHoaDon.LocalReport.SetParameters(new ReportParameter("TongTien", this.tongtien.ToString()));
            rpvHoaDon.LocalReport.SetParameters(new ReportParameter("TienKhachDua", this.tienkhachdua.ToString()));
            rpvHoaDon.LocalReport.SetParameters(new ReportParameter("TienTraLai", this.tientralai.ToString()));
            rpvHoaDon.LocalReport.SetParameters(new ReportParameter("NgayLap", this.ngaylap.ToString()));
            


            this.rpvHoaDon.RefreshReport();
        }

        private void rpvHoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}
