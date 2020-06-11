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
using System.IO;
using BAL;
using BEL;
using QuanLiCuaHangQuanAo.BaoCao;
using QuanLiCuaHangQuanAo.InBaoCao;
namespace QuanLiCuaHangQuanAo.NhanVien
{
    public partial class FrmTrangBanHang : Form
    {
        private int _MaNV;

        public int MaNV
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }
        public FrmTrangBanHang()
        {
            InitializeComponent();
        }
        private bool KiemTraPaste(TextBox Paste)
        {
            char[] XuLiPaste = Paste.Text.Trim().ToCharArray();
            for (int i = 0; i < XuLiPaste.Length; i++)
            {
                if (!char.IsDigit(XuLiPaste[i]))
                {
                    Paste.Focus();
                    Paste.Clear();
                    return true;
                }
            }
            return false;
        }
        
        private void txtMaSP_KeyUp(object sender, KeyEventArgs e)
        {
            if (KiemTraPaste(txtMaSP))
            {
                return;
            }
            btnThemVaoBang.Enabled = true;
            btnThemVaoBang.Text = "Thêm Vào Bảng";
            if (txtMaSP.Text == "")
            {
                return;
            }
            BAL_SANPHAM bal_sp = new BAL_SANPHAM();
            bool KiemTraTonTai = bal_sp.KiemTraMaSPTonTai(int.Parse(txtMaSP.Text.ToString().Trim()));
            if (KiemTraTonTai)
            {
                int MaSP = int.Parse(txtMaSP.Text.Trim());
                DataTable dt = bal_sp.getSanPham_TenHienThi_MaSP(MaSP);
                DataRow dr = dt.Rows[0];
                txtTenSP.Text = dr["TenSP"].ToString();
                rtbMoTa.Text = dr["MoTa"].ToString();
                txtSize.Text = dr["Size"].ToString();
                txtMau.Text = dr["Mau"].ToString();
                txtGia.Text = dr["Gia"].ToString();
                txtUuDai.Text = dr["UuDai"].ToString();

                txtSLTon.Text = dr["SLTon"].ToString();
                int ConLai = int.Parse(txtSLTon.Text.ToString())-1;
                if (ConLai == -1)
                {
                    btnThemVaoBang.Enabled = false;
                    txtSLConLai.Clear();
                    btnThemVaoBang.Text = "Hết Hàng";
                    return;
                }
                txtSLConLai.Text = ConLai.ToString();
                
                string DuongDanProJect = Directory.GetCurrentDirectory();
                string Hinh = dr["Hinh"].ToString();
                ptbHinh.ImageLocation = DuongDanProJect+@"\..\..\Image"+Hinh;
                return;
            }
            else
            {
                txtMaSP.Clear();
                txtMaSP.Focus();
                MessageBox.Show("Sản Phẩm Đã Xóa Hoặc Không Có Sản Phẩm Này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            
            
        }

        private void FrmTrangBanHang_Load(object sender, EventArgs e)
        {
            ClearNhapLieu();
            ClearThanhToan();
            gbNhapThongTin.Enabled = true;
            gbXacNhanChinhSua.Enabled = true;
            gbThanhToan.Enabled = false;
        }

        private void txtMaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        

        private void btnThemVaoBang_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Nhập Mã Sản Phẩm Đi ạ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (KiemTraPaste(txtMaSP))
            {
                return;
            }
            int MaSP = int.Parse(txtMaSP.Text.Trim());
            int index_row = -1;
            //Kiểm tra tồn tại
            for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
            {
                int row_masp =int.Parse(dgvHoaDon.Rows[i].Cells[0].Value.ToString());
                if (row_masp == MaSP)
                {
                    index_row = i;
                    break;
                }
            }
            string TenSP = txtTenSP.Text.Trim();
            string MoTa = rtbMoTa.Text.Trim();
            string Size = txtSize.Text.Trim();
            string Mau = txtMau.Text.Trim();
            float GiaGoc = float.Parse(txtGia.Text.Trim());
            string UuDaiChuaXuLi = txtUuDai.Text.Trim();
            string SoLuong = nudSoLuong.Value.ToString();
            string SLTon = txtSLTon.Text.ToString();
            string SLConLai = txtSLConLai.Text.ToString();
            float ThanhTien = 0;
            // Xử lí ưu Đãi
            string[] UuDaiXuLi = UuDaiChuaXuLi.Split("%".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int UuDai = int.Parse(UuDaiXuLi[0]);
            float Gia = GiaGoc - (GiaGoc * ((float)UuDai / 100));
            //txtMaSP.Text = Gia.ToString();
           
            //Không tồn tại thì thêm vào cột mới
            if (index_row == -1)
            {

                ThanhTien = float.Parse(SoLuong) * Gia;
                dgvHoaDon.Rows.Add(MaSP, TenSP, MoTa, Size, Mau, GiaGoc, UuDaiChuaXuLi, SoLuong, SLTon, SLConLai, ThanhTien);
            }
            else
            {
                ThanhTien = float.Parse(SoLuong) * Gia;
                dgvHoaDon.Rows[index_row].Cells["SoLuong"].Value = SoLuong;
                dgvHoaDon.Rows[index_row].Cells["ThanhTien"].Value = ThanhTien;
                
            
            }
            ClearNhapLieu();
        }

        private void ClearNhapLieu()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            rtbMoTa.Clear();
            txtSize.Clear();
            txtMau.Clear();
            txtGia.Clear();
            nudSoLuong.Value = 1;
            txtMaSP.Focus();
            txtSLTon.Clear();
            txtSLConLai.Clear();
            txtUuDai.Clear();
            ptbHinh.ImageLocation = "";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        
        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            if (txtSLTon.Text == "")
            {
                return;
            }
            if (nudSoLuong.Value < 1)
            {
                //MessageBox.Show("Số Lượng Phải Lớn Hơn 0");
                nudSoLuong.Value = 1;
                return;
            }
            if (int.Parse(txtSLTon.Text) < int.Parse(nudSoLuong.Value.ToString()))
            {
                nudSoLuong.Value = int.Parse(txtSLTon.Text);
                MessageBox.Show("Hết Hàng");
                return;
            }
            txtSLConLai.Text = (int.Parse(txtSLTon.Text) - int.Parse(nudSoLuong.Value.ToString())).ToString();
           

        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
           
            if (dgvHoaDon.Rows.Count <= 0)
            {
                MessageBox.Show("Thêm Sản Phẩm đi Chứ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            gbNhapThongTin.Enabled = false;
            gbXacNhanChinhSua.Enabled = false;
            gbThanhToan.Enabled = true;
            float tong = 0;
            for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
            {
                tong +=float.Parse(dgvHoaDon.Rows[i].Cells["ThanhTien"].Value.ToString());
            }
            txtTongTien.Text = tong.ToString();
            txtTienKhachDua.Focus();
        }
      
        private void btnTang_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Hết Rồi Nhấn Hoài","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }


            int SoLuong = int.Parse(dgvHoaDon.CurrentRow.Cells["SoLuong"].Value.ToString()) + 1;
            DieuChinhTangGiam(SoLuong);
            btnGiam.Enabled = true;
        }

        private void DieuChinhTangGiam(int SoLuong)
        {
            if (SoLuong > int.Parse(dgvHoaDon.CurrentRow.Cells["SLTon"].Value.ToString()))
            {
                //SoLuong = dgvHoaDon.CurrentRow.Cells["SLTon"].Value.ToString();
                MessageBox.Show("Hết Hàng");
                return;
            }


            int SLConLai =int.Parse(dgvHoaDon.CurrentRow.Cells["SLTon"].Value.ToString()) - SoLuong;
            dgvHoaDon.CurrentRow.Cells["SLConLai"].Value = SLConLai.ToString();

            int MaSP = int.Parse(dgvHoaDon.CurrentRow.Cells["MaSP"].Value.ToString());
            BAL_SANPHAM bal_sp = new BAL_SANPHAM();
            DataTable dt = bal_sp.getSanPham_TenHienThi_MaSP(MaSP);
            DataRow dr = dt.Rows[0];

            string UuDaiChuaXuLi = dr["UuDai"].ToString();
            string[] UuDaiXuLi = UuDaiChuaXuLi.Split("%".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int UuDai = int.Parse(UuDaiXuLi[0]);
            float GiaGoc = float.Parse(dr["Gia"].ToString());
            float Gia = GiaGoc - (GiaGoc * ((float)UuDai / 100));

            //float GiaGoc = float.Parse(dr["Gia"].ToString());
            dgvHoaDon.CurrentRow.Cells["SoLuong"].Value = SoLuong;

            dgvHoaDon.CurrentRow.Cells["ThanhTien"].Value = Gia * SoLuong;
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Hết Rồi Nhấn Hoài", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int SoLuong = int.Parse(dgvHoaDon.CurrentRow.Cells["SoLuong"].Value.ToString());
            if (SoLuong == 1)
            {
                dgvHoaDon.Rows.Remove(dgvHoaDon.CurrentRow);
            }
            else
            {
                DieuChinhTangGiam(SoLuong-1);
            }
            
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            dgvHoaDon.Rows.Clear();
        }

        private void nudSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar.Equals(" "))
            {
                e.Handled = true;
            }
        }

        private void ClearThanhToan()
        {
            txtTongTien.Clear();
            txtTienKhachDua.Clear();
            txtTienTraLai.Clear();
            //txtMaHD.Clear();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            ClearNhapLieu();
            ClearThanhToan();
            gbNhapThongTin.Enabled = true;
            gbThanhToan.Enabled = false;
            gbXacNhanChinhSua.Enabled = true;
            dgvHoaDon.Rows.Clear();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtTongTien.Text.Trim() =="")
            {
                MessageBox.Show("Tổng Tiền Không Được Rỗng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTienKhachDua.Text.Trim() =="")
            {
                MessageBox.Show("Nhập Tiền Khách Đưa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
            }
            if (txtTienTraLai.Text.Trim() == "")
            {
                MessageBox.Show("Bạn Phải Kiểm Tra Cái", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BAL_HOADON bal_hd = new BAL_HOADON();
            //BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
            int MaNV = this._MaNV;
            //int MaNV = this.MaNV;
            float TongTien = float.Parse(txtTongTien.Text.ToString().Trim());
            string TrangThai = "Chưa";
            bool isThem = bal_hd.Them(new HOADON(MaNV,TongTien,TrangThai));

            //Lấy Dòng dữ liệu Hóa đơn tự tăng
            BAL_CHITIETHOADON bal_cthd = new BAL_CHITIETHOADON();
            DataTable dt = bal_hd.getHoaDon_MaHD_TrangThai(TrangThai);
            DataRow dr = dt.Rows[0];
            int mahd = int.Parse(dr["MaHD"].ToString());
            //dtpNow.Value = DateTime.Now;
            DateTime ngaylaphd = DateTime.Now;
            //Thêm Vào ChiTiet
            for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
            {
                int masp = int.Parse(dgvHoaDon.Rows[i].Cells["MaSP"].Value.ToString());
                
                float giasp = float.Parse(dgvHoaDon.Rows[i].Cells["GiaSP"].Value.ToString());
                int soluong = int.Parse(dgvHoaDon.Rows[i].Cells["SoLuong"].Value.ToString());
                string khuyenmai = dgvHoaDon.Rows[i].Cells["UuDai"].Value.ToString();
                float thanhtien = float.Parse(dgvHoaDon.Rows[i].Cells["ThanhTien"].Value.ToString());
                DateTime ngaylaphDinhDang = DateTime.Parse(ngaylaphd.ToString("MM/dd/yyyy"));
                bal_cthd.Them(new CHITIETHOADON(mahd, masp, ngaylaphDinhDang, giasp, soluong, khuyenmai, thanhtien));
            }


            if (isThem)
            {
               
               

                MessageBox.Show("Đã Tạo Và Đợi Để In Hóa Đơn");
                //nhớ fix lỗi 
                //Cập Nhật Lại Hàng Tồn
                bal_cthd.CapNhat(mahd);

                //Cập Nhật Lại Trạng Thái Nó
                bal_hd.UpdateTrangThai(TrangThai);
                //Truyền qua form in
                //cần manv
                //mahd
                //tongtien
                //tienkhachdua
                //dientralai
                //ngayLap
                float TienKhachDua = float.Parse(txtTienKhachDua.Text.Trim());
                float TienTraLai = float.Parse(txtTienTraLai.Text.Trim());
                string ngaylap = ngaylaphd.ToString("dd/MM/yyyy");
                BAL_NHANVIEN bal_nv = new BAL_NHANVIEN();
                DataTable dt_nv = bal_nv.getNhanVien_MaNV(MaNV);
                string tenNV = dt_nv.Rows[0]["HoTen"].ToString();
                FrmInHoaDon hd = new FrmInHoaDon(tenNV, mahd, TongTien, TienKhachDua, TienTraLai, ngaylap);
                hd.ShowDialog();



                //clear hết
                txtTongTien.Clear();
                txtTienTraLai.Clear();
                txtTienKhachDua.Clear();
            }
            else
            {
                MessageBox.Show("Không Thể Tạo");
            }


        }

        private void btnKiemTraTien_Click(object sender, EventArgs e)
        {
            
            if (txtTongTien.Text.Trim() == "")
            {
                return;
            }
            if (KiemTraPaste(txtTienKhachDua))
            {
                return;
            }
            if (txtTienKhachDua.Text.Trim() == "")
            {
                MessageBox.Show("Tiền Khách Đưa Phải Lớn Hơn Hoặc Bằng Tổng Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            float TongTien = float.Parse(txtTongTien.Text.Trim());
            float TienKhachDua = float.Parse(txtTienKhachDua.Text.Trim());

            float Tong = TienKhachDua - TongTien;
            if (Tong < 0)
            {
                txtTienTraLai.Clear();
                MessageBox.Show("Tiền Khách Đưa Phải Lớn Hơn Hoặc Bằng Tổng Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                txtTienTraLai.Text = Tong.ToString();
            }
        }

    

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDangNhap dn = new FrmDangNhap();
            dn.ShowDialog();
        }

      
      
        private void ThemVaoPannel(Form c)
        {
            c.TopLevel = false;
            pnBaoCao.Controls.Clear();
            pnBaoCao.Controls.Add(c);
            c.Show();
        }

       

        private void tcTrangBaoCao_Click(object sender, EventArgs e)
        {
            if (tcTrangBaoCao.SelectedIndex == 1)
            {
               
                ThemVaoPannel(new FrmTrangBaoCao(this._MaNV));
            }
            ClearNhapLieu();
            ClearThanhToan();
        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {

        }

       

      

      
    }
}
