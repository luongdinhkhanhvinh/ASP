namespace QuanLiCuaHangQuanAo.HienThiChinh
{
    partial class FrmTrangQuanLy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrangQuanLy));
            this.btnSanPham = new System.Windows.Forms.Button();
            this.pnDanhMuc = new System.Windows.Forms.Panel();
            this.btnLoaiSP = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnNhaSanXuat = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnKhuyenMai = new System.Windows.Forms.Button();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblTrangHienHanh = new System.Windows.Forms.Label();
            this.pnView = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnDanhMuc.SuspendLayout();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSanPham
            // 
            this.btnSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSanPham.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanPham.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSanPham.Image = ((System.Drawing.Image)(resources.GetObject("btnSanPham.Image")));
            this.btnSanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSanPham.Location = new System.Drawing.Point(33, 40);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(140, 52);
            this.btnSanPham.TabIndex = 0;
            this.btnSanPham.Text = "    Sản Phẩm";
            this.btnSanPham.UseVisualStyleBackColor = true;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // pnDanhMuc
            // 
            this.pnDanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnDanhMuc.Controls.Add(this.btnLoaiSP);
            this.pnDanhMuc.Controls.Add(this.btnNhanVien);
            this.pnDanhMuc.Controls.Add(this.btnNhaSanXuat);
            this.pnDanhMuc.Controls.Add(this.btnDangXuat);
            this.pnDanhMuc.Controls.Add(this.btnKhuyenMai);
            this.pnDanhMuc.Controls.Add(this.btnSanPham);
            this.pnDanhMuc.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.pnDanhMuc.Name = "pnDanhMuc";
            this.pnDanhMuc.Size = new System.Drawing.Size(176, 662);
            this.pnDanhMuc.TabIndex = 7;
            this.pnDanhMuc.Paint += new System.Windows.Forms.PaintEventHandler(this.pnDanhMuc_Paint);
            // 
            // btnLoaiSP
            // 
            this.btnLoaiSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoaiSP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaiSP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoaiSP.Image = ((System.Drawing.Image)(resources.GetObject("btnLoaiSP.Image")));
            this.btnLoaiSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoaiSP.Location = new System.Drawing.Point(33, 98);
            this.btnLoaiSP.Name = "btnLoaiSP";
            this.btnLoaiSP.Size = new System.Drawing.Size(140, 52);
            this.btnLoaiSP.TabIndex = 10;
            this.btnLoaiSP.Text = "      Loại  Sản Phẩm";
            this.btnLoaiSP.UseVisualStyleBackColor = true;
            this.btnLoaiSP.Click += new System.EventHandler(this.btnLoaiSP_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("btnNhanVien.Image")));
            this.btnNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.Location = new System.Drawing.Point(33, 214);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(140, 52);
            this.btnNhanVien.TabIndex = 9;
            this.btnNhanVien.Text = "      Nhân Viên";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnNhaSanXuat
            // 
            this.btnNhaSanXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhaSanXuat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhaSanXuat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNhaSanXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnNhaSanXuat.Image")));
            this.btnNhaSanXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhaSanXuat.Location = new System.Drawing.Point(33, 156);
            this.btnNhaSanXuat.Name = "btnNhaSanXuat";
            this.btnNhaSanXuat.Size = new System.Drawing.Size(140, 52);
            this.btnNhaSanXuat.TabIndex = 8;
            this.btnNhaSanXuat.Text = "   Nhà NSX";
            this.btnNhaSanXuat.UseVisualStyleBackColor = true;
            this.btnNhaSanXuat.Click += new System.EventHandler(this.btnNhaSanXuat_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.Image")));
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(33, 598);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(140, 52);
            this.btnDangXuat.TabIndex = 7;
            this.btnDangXuat.Text = "   Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhuyenMai.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnKhuyenMai.Image = ((System.Drawing.Image)(resources.GetObject("btnKhuyenMai.Image")));
            this.btnKhuyenMai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhuyenMai.Location = new System.Drawing.Point(33, 272);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.Size = new System.Drawing.Size(140, 52);
            this.btnKhuyenMai.TabIndex = 4;
            this.btnKhuyenMai.Text = "       Khuyến Mãi";
            this.btnKhuyenMai.UseVisualStyleBackColor = true;
            this.btnKhuyenMai.Click += new System.EventHandler(this.btnKhuyenMai_Click);
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnHeader.Controls.Add(this.lblTimer);
            this.pnHeader.Controls.Add(this.lblTrangHienHanh);
            this.pnHeader.Location = new System.Drawing.Point(176, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1173, 44);
            this.pnHeader.TabIndex = 9;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTimer.Location = new System.Drawing.Point(698, 8);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(67, 31);
            this.lblTimer.TabIndex = 1;
            this.lblTimer.Text = "0:00";
            // 
            // lblTrangHienHanh
            // 
            this.lblTrangHienHanh.AutoSize = true;
            this.lblTrangHienHanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTrangHienHanh.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangHienHanh.ForeColor = System.Drawing.Color.White;
            this.lblTrangHienHanh.Location = new System.Drawing.Point(22, 9);
            this.lblTrangHienHanh.Name = "lblTrangHienHanh";
            this.lblTrangHienHanh.Size = new System.Drawing.Size(187, 31);
            this.lblTrangHienHanh.TabIndex = 0;
            this.lblTrangHienHanh.Text = "Trang Quản Lí";
            // 
            // pnView
            // 
            this.pnView.BackColor = System.Drawing.SystemColors.Control;
            this.pnView.Location = new System.Drawing.Point(182, 50);
            this.pnView.Name = "pnView";
            this.pnView.Size = new System.Drawing.Size(1152, 612);
            this.pnView.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmTrangQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 662);
            this.Controls.Add(this.pnDanhMuc);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.pnView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmTrangQuanLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTrangQuanLy";
            this.Load += new System.EventHandler(this.FrmTrangQuanLy_Load);
            this.pnDanhMuc.ResumeLayout(false);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Panel pnDanhMuc;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnKhuyenMai;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label lblTrangHienHanh;
        private System.Windows.Forms.Panel pnView;
        private System.Windows.Forms.Button btnNhaSanXuat;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnLoaiSP;
    }
}