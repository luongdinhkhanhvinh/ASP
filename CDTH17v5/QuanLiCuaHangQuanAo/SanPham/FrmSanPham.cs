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
using System.IO;
namespace QuanLiCuaHangQuanAo.SanPham
{
    public partial class FrmSanPham : Form
    {
        public FrmSanPham()
        {
            InitializeComponent();
        }

        private void btnSPMacdinh()
        {
            btnSua.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            
        }
        
       
        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            HienThiMaLoaiSP();
            HienThiMaKM();
            HienThiMaNSX();
            HienThiSize();
            HienThiMau();
            HienThiDanhSachSP();
            btnSPMacdinh();
            HienThiSanPhamTim();
            
        }

        private void HienThiSanPhamTim()
        {
            cbChon.Items.Add("Mã SP");
            cbChon.Items.Add("Giá");
            cbChon.Items.Add("Khác");
            cbChon.SelectedIndex = 0;
        }

        private void HienThiMau()
        {
            cbMau.Items.Add("Trắng");
            cbMau.Items.Add("Xanh");
            cbMau.Items.Add("Vàng");
            cbMau.Items.Add("Đen"); 
            cbMau.Items.Add("Chấm Bi");
            cbMau.Items.Add("Sọc Vằn");
            cbMau.Items.Add("Đỏ");
            cbMau.SelectedIndex = 0;
        }
        private void HienThiSize()
        {
            cbSize.Items.Add("S");
            cbSize.Items.Add("M");
            cbSize.Items.Add("L");
            cbSize.Items.Add("XL");
            cbSize.Items.Add("XXL");
            cbSize.SelectedIndex = 3;
        }
        private void HienThiDanhSachSP()
        {
            BAL_SANPHAM bal_sp = new BAL_SANPHAM();
            dgvSanPham.DataSource = bal_sp.getSanPham_TenHienThi();
        }

       

        
        private void HienThiMaLoaiSP()
        {
            BAL_LOAISP bal_loaisp = new BAL_LOAISP();
            //cbMaLoaiSanPham.DataSource = bal_loaisp.getLoaiSP();
           
           // cbMaLoaiSanPham.Items.Add("Khương");
            //cbMaLoaiSanPham.Items.Add("Đạt");
            cbMaLoaiSanPham.DataSource = bal_loaisp.getLoaiSP();
            cbMaLoaiSanPham.DisplayMember = "TenLoaiSP";
            cbMaLoaiSanPham.ValueMember = "MaLoaiSP";  
        }

        private void HienThiMaKM()
        {
            BAL_KHUYENMAI bal_loaisp = new BAL_KHUYENMAI();
            cbMaKhuyenMai.DataSource = bal_loaisp.getKhuyenMai();
            cbMaKhuyenMai.DisplayMember = "UuDai";
            cbMaKhuyenMai.ValueMember = "MaKM";
        }
        private void HienThiMaNSX()
        {
            BAL_NHANSX bal_loaisp = new BAL_NHANSX();
            cbMaNSX.DataSource = bal_loaisp.getNhaNSX();
            cbMaNSX.DisplayMember = "TENNSX";
            cbMaNSX.ValueMember = "MANSX";
        }

        //private bool KiemTraPaste(TextBox Paste)
        //{
        //    char[] XuLiPaste = Paste.Text.Trim().ToCharArray();
        //    for (int i = 0; i < XuLiPaste.Length; i++)
        //    {
        //        if (!char.IsDigit(XuLiPaste[i]))
        //        {
        //            Paste.Focus();
        //            MessageBox.Show("Vui Lòng Nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return true;
        //        }
        //    }
        //    return false;
        //}


        private void btnThem_Click(object sender, EventArgs e)
        {
           
            if (txtTenSP.Text.Trim() == "")
            {
                txtTenSP.Focus();
                MessageBox.Show("Vui Lòng Nhập Tên SP", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (rtbMoTa.Text.Trim() == "")
            {
                rtbMoTa.Focus();
                MessageBox.Show("Vui Lòng Nhập Mô Tả", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtGia.Text.Trim() == "")
            {
                txtGia.Focus();
                MessageBox.Show("Vui Lòng Nhập Giá", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSLTon.Text.Trim() == "")
            {
                txtSLTon.Focus();
                MessageBox.Show("Vui Lòng Nhập Số Lượng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtHinh.Text.Trim() == "")
            {
                btnThemAnh.Focus();
                MessageBox.Show("Vui Lòng Chọn 1 ảnh trong máy cho Sản Phẩm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (KiemTraPaste(txtGia))
            {
                return;
            }
            if (KiemTraPaste(txtSLTon))
            {
                return;
            }
            
            int MaLoaiSP = int.Parse(cbMaLoaiSanPham.SelectedValue.ToString());
            int MaKM = int.Parse(cbMaKhuyenMai.SelectedValue.ToString());
            int MaNSX = int.Parse(cbMaNSX.SelectedValue.ToString());

            string TenSP = txtTenSP.Text.Trim();
            string MoTa = rtbMoTa.Text.Trim();
         
            string Size = cbSize.SelectedItem.ToString();
            string Mau = cbMau.SelectedItem.ToString();
            //Sử lí hình
           
            string Hinh = txtHinh.Text.Trim();
            int SlTon = int.Parse(txtSLTon.Text.Trim());
            float Gia =int.Parse(txtGia.Text.Trim());
            
            BAL_SANPHAM bal_sp = new BAL_SANPHAM();

            bool isThem = bal_sp.Them(new SANPHAM( MaLoaiSP,  MaKM, MaNSX ,  TenSP,  MoTa, Size,  Mau, Hinh,SlTon, Gia));
            if (isThem)
            {
                HienThiDanhSachSP();
                btnThem.Enabled = false;
                btnHuy.Enabled = true;
                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btnThem.Enabled = false;
                btnHuy.Enabled = true;
                MessageBox.Show("Thêm Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DatLaiMacDinhSP()
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSanPham.Rows.Count <=0)
            {
                MessageBox.Show("Vui Lòng Chọn Cột Có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ckbXoaSP.Checked)
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnHuy.Enabled = false;
                return;
            }
            //Chọn Dòng Dang Chọn
            DatLaiMacDinhSP();
            int MaSP            = int.Parse(dgvSanPham.CurrentRow.Cells[0].Value.ToString().Trim());
            txtMaSP.Text        = MaSP.ToString();

            //Khởi Tạo Đối Tượng 
            BAL_SANPHAM dal_sp  = new BAL_SANPHAM();
            DataTable da = dal_sp.getSanPham_TenHienThi_MaSP(MaSP);

            //Lấy dòng Thứ 0
            DataRow daRow = da.Rows[0];// Lấy dòng
            
            //cbMaLoaiSanPham.SelectedItem = daRow["TenLoaiSP"].ToString();//Cột Thứ dòng 0 cột TênLoaiSP -> Lỗi 

            BAL_LOAISP bal_lsp = new BAL_LOAISP();
            bool kiemTraXoaLoaiSP = bal_lsp.getLoaiSPXoa_MaLoaiSP(int.Parse(daRow["MaLoaiSP"].ToString()));
            if (kiemTraXoaLoaiSP)
            {
                MessageBox.Show("Sản Phẩm Thuộc Loại Này Đã Bị Xóa Bạn Hãy Chuyển Loại Khác Hoặc Xóa Sản Phẩm Này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaLoaiSanPham.Focus();
            }else{
                cbMaLoaiSanPham.SelectedValue = int.Parse(daRow["MaLoaiSP"].ToString());
            }



            BAL_KHUYENMAI bal_km = new BAL_KHUYENMAI();
            bool kiemTraXoaMaKM = bal_km.getKhuyenMai_KiemTra_Xoa(int.Parse(daRow["MaKM"].ToString()));
            if (kiemTraXoaMaKM)
            {
                MessageBox.Show("Sản Phẩm Thuộc Khuyến Mãi Này Đã Bị Xóa Bạn Hãy Chuyển Loại Khác Hoặc Xóa Sản Phẩm Này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaKhuyenMai.Focus();
            }
            else
            {
                
                //cần fix lỗi 
                cbMaKhuyenMai.SelectedValue = int.Parse(daRow["MaKM"].ToString());
            }

            BAL_NHANSX bal_nsx = new BAL_NHANSX();
            bool kiemTraXoaMaNSX= bal_nsx.getNhaNSX_Xoa_MaNSX(int.Parse(daRow["MaNSX"].ToString()));
            if (kiemTraXoaMaNSX)
            {
                MessageBox.Show("Sản Phẩm Thuộc Nhà Sản Xuất Này Đã Bị Xóa Bạn Hãy Chuyển Loại Khác Hoặc Xóa Sản Phẩm Này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaNSX.Focus();
            }
            else
            {
                cbMaNSX.SelectedValue = int.Parse(daRow["MaNSX"].ToString());
            }

            txtTenSP.Text = daRow["TenSP"].ToString();
            rtbMoTa.Text = daRow["MoTa"].ToString();

            cbMau.SelectedItem = daRow["Mau"].ToString();
            cbSize.SelectedItem = daRow["Size"].ToString();

            txtHinh.Text = daRow["Hinh"].ToString();
            try
            {
                string duongDanProJectCurrent = Directory.GetCurrentDirectory();
                string duongDanHinh = duongDanProJectCurrent + @"\..\..\Image" + txtHinh.Text;
                ptbHinh.ImageLocation = duongDanHinh;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            txtSLTon.Text = daRow["SLTon"].ToString();
            txtGia.Text = daRow["Gia"].ToString();
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow.Cells[0].Value.ToString().Trim() == "")
            {
                MessageBox.Show("Vui Lòng Chọn Cột Có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbMaLoaiSanPham.SelectedValue == null)
            {
                 MessageBox.Show("Vui Lòng Chọn Cột Có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
            }
            if (cbMaKhuyenMai.SelectedValue == null)
            {
                MessageBox.Show("Vui Lòng Chọn Cột Có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbMaNSX.SelectedValue == null)
            {
                MessageBox.Show("Vui Lòng Chọn Cột Có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenSP.Text.Trim() == "")
            {
                txtTenSP.Focus();
                MessageBox.Show("Vui Lòng Nhập Tên SP", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (rtbMoTa.Text.Trim() == "")
            {
                rtbMoTa.Focus();
                MessageBox.Show("Vui Lòng Nhập Mô Tả", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtGia.Text.Trim() == "")
            {
                txtGia.Focus();
                MessageBox.Show("Vui Lòng Nhập Giá", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtHinh.Text.Trim() == "")
            {
                btnThemAnh.Focus();
                MessageBox.Show("Vui Lòng Chọn 1 ảnh trong máy cho Sản Phẩm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (KiemTraPaste(txtGia))
            {
                return;
            }
            if (KiemTraPaste(txtSLTon))
            {
                return;
            }

            int MaSP = int.Parse(txtMaSP.Text.Trim());

            int MaLoaiSP = int.Parse(cbMaLoaiSanPham.SelectedValue.ToString());
            int MaKM = int.Parse(cbMaKhuyenMai.SelectedValue.ToString());
            int MaNSX = int.Parse(cbMaNSX.SelectedValue.ToString());

            string TenSP = txtTenSP.Text.Trim();
            string MoTa = rtbMoTa.Text.Trim();

            string Size = cbSize.SelectedItem.ToString();
            string Mau = cbMau.SelectedItem.ToString();

            string Hinh = txtHinh.Text.Trim();
            float Gia = int.Parse(txtGia.Text.Trim());
            int SlTon = int.Parse(txtSLTon.Text.Trim());
            BAL_SANPHAM bal_sp = new BAL_SANPHAM();
            bool isCapNhat = bal_sp.CapNhat(new SANPHAM(MaLoaiSP, MaKM, MaNSX, TenSP, MoTa, Size, Mau, Hinh,SlTon, Gia), MaSP);
            if (isCapNhat)
            {
                HienThiDanhSachSP();
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void isComboBox(object sender, KeyPressEventArgs e)
        {
            
            MessageBox.Show("Chỉ Được Phép Chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            e.Handled = true;
        }

        private void cbMaLoaiSanPham_KeyPress(object sender, KeyPressEventArgs e)
        {
            isComboBox( sender,  e);
        }

        private void cbMaKhuyenMai_KeyPress(object sender, KeyPressEventArgs e)
        {
            isComboBox(sender, e);
        }

        private void cbMaNSX_KeyPress(object sender, KeyPressEventArgs e)
        {
            isComboBox(sender, e);
        }

        private void cbSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            isComboBox(sender, e);
        }

        private void cbMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            isComboBox(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Xóa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtMaSP.Text.Trim() == "")
                {
                    MessageBox.Show("Vui Lòng Chọn Cột Có dữ liệu để có thể xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int MaSP = int.Parse(txtMaSP.Text.Trim());
                BAL_SANPHAM bal_sp = new BAL_SANPHAM();
                bool isXoa = bal_sp.Xoa(MaSP);
                if (isXoa)
                {
                    HienThiDanhSachSP();
                    MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
          
        }
        private void DatVeMacDinh()
        {
            cbMau.SelectedIndex = 0;
            cbSize.SelectedIndex = 3;
            cbMaKhuyenMai.SelectedIndex = 0;
            cbMaNSX.SelectedIndex = 0;
            cbMaLoaiSanPham.SelectedIndex = 0;
            txtMaSP.Clear();
            rtbMoTa.Clear();
            txtTenSP.Clear();
            txtGia.Clear();
            txtHinh.Clear();
            txtSLTon.Clear();
            ptbHinh.ImageLocation = Directory.GetCurrentDirectory() +@"\..\..\Image\icons8-add-image-100.png";
        }
        private void btnMacDinh()
        {
            btnHuy.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DatVeMacDinh();
            btnMacDinh();
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTimTheoMa.Text.Trim() == "")
            {
                txtTimTheoMa.Focus();
                MessageBox.Show("Vui Lòng Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

    
        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            try
            {
                ofdMoThuMuc.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
                if (ofdMoThuMuc.ShowDialog() == DialogResult.OK)
                {

                    ptbHinh.ImageLocation = ofdMoThuMuc.FileName;
                    string duongDanHinh = ofdMoThuMuc.FileName;
                    int TimViTriCuoi = duongDanHinh.LastIndexOf(@"\");
                    string LayTenHinh = duongDanHinh.Substring(TimViTriCuoi);
                    txtHinh.Text = LayTenHinh;
                    string LayDuongDanProJectTuDeBug = Directory.GetCurrentDirectory(); 
                    File.Copy(duongDanHinh,LayDuongDanProJectTuDeBug +@"\..\..\Image"+LayTenHinh,true);
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hãy Chọn File Hình ý Chọn File Khác là Lỗi đó","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
               
            }
        }

        private void KiemTraNhapTexTBoxChu(object sender , KeyPressEventArgs e){
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
            
        }

        private void txtTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            KiemTraNhapTexTBoxChu(sender , e);
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtGia.Text.Trim().Length == 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Lớn Quá Rồi");
                return;
            }
           
        }

  

        private void ckbXoaSP_CheckedChanged(object sender, EventArgs e)
        {
            
            if (ckbXoaSP.Checked)
            {
                gbThemSanPham.Enabled = false;
                
                btnHuy_Click(sender, e);
                BAL_SANPHAM bal_sp = new BAL_SANPHAM();
                dgvSanPham.DataSource = bal_sp.getSanPham();
                pnTimKiem.Enabled = false;
                
            }
            else
            {
                gbThemSanPham.Enabled = true;
               
                BAL_SANPHAM bal_sp = new BAL_SANPHAM();
                dgvSanPham.DataSource = bal_sp.getSanPham_TenHienThi();
                pnTimKiem.Enabled = true;
            }
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
      
        private void txtTimSanPham_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTimTheoMa.Text.Trim() == "" && txtTimTheoTen.Text.Trim() == "")
            {
                HienThiDanhSachSP();
                return;
            }
            if (KiemTraPaste(txtTimTheoMa))
            {
                return;
            }
            
           
            BAL_SANPHAM bal_sp = new BAL_SANPHAM();
            DataView dv = bal_sp.getSanPham_TenHienThi().DefaultView;
            dv.RowFilter = "";
            if (cbChon.SelectedIndex.Equals(0))
            {
                if (txtTimTheoMa.Text.Trim() == "")
                {
                    return;
                }
                if (KiemTraSoQuaLon(txtTimTheoMa))
                {
                    return;
                }
                dv.RowFilter = string.Format("MaSP = {0}",int.Parse(txtTimTheoMa.Text.Trim()));
            }else if(cbChon.SelectedIndex.Equals(1))
            {
                if (txtTimTheoMa.Text.Trim() == "")
                {
                    return;
                }
                if (KiemTraSoQuaLon(txtTimTheoMa))
                {
                    return;
                }
                dv.RowFilter = string.Format("Gia = {0}", int.Parse(txtTimTheoMa.Text.Trim()));
            }
            else if(cbChon.SelectedIndex.Equals(2))
            {
                if (txtTimTheoTen.Text.Trim() == "")
                {
                    return;
                }
                dv.RowFilter = string.Format("TenLoaiSP LIKE '%{0}%' OR UuDai LIKE '%{0}%' OR TenNSX LIKE '%{0}%'  OR TenSP LIKE '%{0}%' OR MoTa LIKE '%{0}%' OR Size LIKE '%{0}%' OR Mau LIKE '%{0}%' OR Hinh LIKE '%{0}%' ", txtTimTheoTen.Text.Trim());
            }
            dgvSanPham.DataSource = dv;
            
        }

        private void cbChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChon.SelectedIndex.Equals(0) || cbChon.SelectedIndex.Equals(1))
            {
                txtTimTheoMa.Visible = true;
                txtTimTheoTen.Visible = false;
                txtTimTheoMa.Focus();
            }
            else 
            {
                txtTimTheoMa.Visible = false;
                txtTimTheoTen.Visible = true;
                txtTimTheoTen.Focus();
            }

        }

        private void txtTimTheoMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui Lòng Nhập Số","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cbChon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtTimTheoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSLTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;                
            }
            if (!char.IsControl(e.KeyChar) && txtSLTon.Text.Trim().Length == 7)
            {
                e.Handled = true;
                MessageBox.Show("Tối Đa 1 Triệu");
                return;
            }
        }

    }
}
