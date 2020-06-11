namespace QuanLiCuaHangQuanAo.SanPham
{
    partial class FrmLoaiSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoaiSanPham));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnFuntion = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTimTheoTen = new System.Windows.Forms.TextBox();
            this.cbChon = new System.Windows.Forms.ComboBox();
            this.txtTimTheoMa = new System.Windows.Forms.TextBox();
            this.btnXoaLoaiSP = new System.Windows.Forms.Button();
            this.btnSuaLoaiSP = new System.Windows.Forms.Button();
            this.btnThemLoaiSP = new System.Windows.Forms.Button();
            this.ckbXoaLoai = new System.Windows.Forms.CheckBox();
            this.dgvLoai = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.pnFuntion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoai)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnFuntion);
            this.groupBox1.Controls.Add(this.ckbXoaLoai);
            this.groupBox1.Controls.Add(this.dgvLoai);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(-3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1153, 610);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hiển Thị Danh Sách Loại Sản Phẩm";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pnFuntion
            // 
            this.pnFuntion.Controls.Add(this.button2);
            this.pnFuntion.Controls.Add(this.button1);
            this.pnFuntion.Controls.Add(this.txtTimTheoTen);
            this.pnFuntion.Controls.Add(this.cbChon);
            this.pnFuntion.Controls.Add(this.txtTimTheoMa);
            this.pnFuntion.Controls.Add(this.btnXoaLoaiSP);
            this.pnFuntion.Controls.Add(this.btnSuaLoaiSP);
            this.pnFuntion.Controls.Add(this.btnThemLoaiSP);
            this.pnFuntion.Location = new System.Drawing.Point(6, 16);
            this.pnFuntion.Name = "pnFuntion";
            this.pnFuntion.Size = new System.Drawing.Size(1059, 56);
            this.pnFuntion.TabIndex = 29;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(364, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 49;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(572, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 48;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // txtTimTheoTen
            // 
            this.txtTimTheoTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimTheoTen.Location = new System.Drawing.Point(653, 14);
            this.txtTimTheoTen.Name = "txtTimTheoTen";
            this.txtTimTheoTen.Size = new System.Drawing.Size(239, 26);
            this.txtTimTheoTen.TabIndex = 47;
            this.txtTimTheoTen.TextChanged += new System.EventHandler(this.txtTimTheoTen_TextChanged);
            this.txtTimTheoTen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimTheoTen_KeyUp);
            // 
            // cbChon
            // 
            this.cbChon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChon.FormattingEnabled = true;
            this.cbChon.Location = new System.Drawing.Point(445, 13);
            this.cbChon.Name = "cbChon";
            this.cbChon.Size = new System.Drawing.Size(121, 27);
            this.cbChon.TabIndex = 46;
            this.cbChon.SelectedIndexChanged += new System.EventHandler(this.cbChon_SelectedIndexChanged);
            this.cbChon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbChon_KeyPress);
            // 
            // txtTimTheoMa
            // 
            this.txtTimTheoMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimTheoMa.Location = new System.Drawing.Point(653, 13);
            this.txtTimTheoMa.Name = "txtTimTheoMa";
            this.txtTimTheoMa.Size = new System.Drawing.Size(239, 27);
            this.txtTimTheoMa.TabIndex = 45;
            this.txtTimTheoMa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimTheoMa_KeyPress);
            this.txtTimTheoMa.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimTheoTen_KeyUp);
            // 
            // btnXoaLoaiSP
            // 
            this.btnXoaLoaiSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXoaLoaiSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaLoaiSP.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaLoaiSP.Image")));
            this.btnXoaLoaiSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaLoaiSP.Location = new System.Drawing.Point(227, 4);
            this.btnXoaLoaiSP.Name = "btnXoaLoaiSP";
            this.btnXoaLoaiSP.Size = new System.Drawing.Size(107, 45);
            this.btnXoaLoaiSP.TabIndex = 44;
            this.btnXoaLoaiSP.Text = "Xóa";
            this.btnXoaLoaiSP.UseVisualStyleBackColor = false;
            this.btnXoaLoaiSP.Click += new System.EventHandler(this.btnXoaLoaiSP_Click);
            // 
            // btnSuaLoaiSP
            // 
            this.btnSuaLoaiSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSuaLoaiSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaLoaiSP.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaLoaiSP.Image")));
            this.btnSuaLoaiSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaLoaiSP.Location = new System.Drawing.Point(114, 4);
            this.btnSuaLoaiSP.Name = "btnSuaLoaiSP";
            this.btnSuaLoaiSP.Size = new System.Drawing.Size(107, 45);
            this.btnSuaLoaiSP.TabIndex = 43;
            this.btnSuaLoaiSP.Text = "Sửa";
            this.btnSuaLoaiSP.UseVisualStyleBackColor = false;
            this.btnSuaLoaiSP.Click += new System.EventHandler(this.btnSuaLoaiSP_Click);
            // 
            // btnThemLoaiSP
            // 
            this.btnThemLoaiSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnThemLoaiSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemLoaiSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemLoaiSP.Image")));
            this.btnThemLoaiSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemLoaiSP.Location = new System.Drawing.Point(1, 4);
            this.btnThemLoaiSP.Name = "btnThemLoaiSP";
            this.btnThemLoaiSP.Size = new System.Drawing.Size(107, 45);
            this.btnThemLoaiSP.TabIndex = 42;
            this.btnThemLoaiSP.Text = "Thêm";
            this.btnThemLoaiSP.UseVisualStyleBackColor = false;
            this.btnThemLoaiSP.Click += new System.EventHandler(this.btnThemLoaiSP_Click);
            // 
            // ckbXoaLoai
            // 
            this.ckbXoaLoai.AutoSize = true;
            this.ckbXoaLoai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbXoaLoai.ForeColor = System.Drawing.Color.Red;
            this.ckbXoaLoai.Location = new System.Drawing.Point(1071, 0);
            this.ckbXoaLoai.Name = "ckbXoaLoai";
            this.ckbXoaLoai.Size = new System.Drawing.Size(76, 23);
            this.ckbXoaLoai.TabIndex = 28;
            this.ckbXoaLoai.Text = "Đã Xóa";
            this.ckbXoaLoai.UseVisualStyleBackColor = true;
            this.ckbXoaLoai.CheckedChanged += new System.EventHandler(this.ckbXoaLoai_CheckedChanged);
            // 
            // dgvLoai
            // 
            this.dgvLoai.AllowUserToAddRows = false;
            this.dgvLoai.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvLoai.Location = new System.Drawing.Point(6, 78);
            this.dgvLoai.Name = "dgvLoai";
            this.dgvLoai.ReadOnly = true;
            this.dgvLoai.RowHeadersWidth = 47;
            this.dgvLoai.Size = new System.Drawing.Size(1147, 526);
            this.dgvLoai.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaLoaiSP";
            this.Column1.HeaderText = "Mã Loại Sản Phẩm";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 382;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenLoaiSP";
            this.Column2.HeaderText = "Tên Loại SP";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 382;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "MoTa";
            this.Column3.HeaderText = "Mô Tả";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 382;
            // 
            // FrmLoaiSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 612);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLoaiSanPham";
            this.Text = "FrmLoaiSanPham";
            this.Load += new System.EventHandler(this.FrmLoaiSanPham_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnFuntion.ResumeLayout(false);
            this.pnFuntion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLoai;
        private System.Windows.Forms.CheckBox ckbXoaLoai;
        private System.Windows.Forms.Panel pnFuntion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTimTheoTen;
        private System.Windows.Forms.ComboBox cbChon;
        private System.Windows.Forms.TextBox txtTimTheoMa;
        private System.Windows.Forms.Button btnXoaLoaiSP;
        private System.Windows.Forms.Button btnSuaLoaiSP;
        private System.Windows.Forms.Button btnThemLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}