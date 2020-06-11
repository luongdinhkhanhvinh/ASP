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
namespace QuanLiCuaHangQuanAo.BaoCao
{
    public partial class FrmTrangHangTon : Form
    {
        public FrmTrangHangTon()
        {
            InitializeComponent();
        }

        private int _SlTon=-1;

        public int SlTon
        {
            get { return _SlTon; }
            set { _SlTon = value; }
        }

        private void FrmTrangHangTon_Load(object sender, EventArgs e)
        {
            BAL_SANPHAM bal_sp = new BAL_SANPHAM();
            DataTable da = bal_sp.getSanPham_SLTon(this._SlTon);
            dgvDoanhThu.DataSource = da;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDoanhThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
