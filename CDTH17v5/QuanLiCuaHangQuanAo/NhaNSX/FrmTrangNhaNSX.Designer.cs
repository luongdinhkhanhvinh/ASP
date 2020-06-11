namespace QuanLiCuaHangQuanAo.NhaNSX
{
    partial class FrmTrangNhaNSX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrangNhaNSX));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnFunction = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTimTheoTen = new System.Windows.Forms.TextBox();
            this.cbChon = new System.Windows.Forms.ComboBox();
            this.txtTimTheoMa = new System.Windows.Forms.TextBox();
            this.btnXoaNSX = new System.Windows.Forms.Button();
            this.btnSuaNSX = new System.Windows.Forms.Button();
            this.btnThemNSX = new System.Windows.Forms.Button();
            this.ckbXoaLoai = new System.Windows.Forms.CheckBox();
            this.dgvNhaNSX = new System.Windows.Forms.DataGridView();
            this.MaNSX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNSX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChiNSX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoaiNSX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.pnFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaNSX)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnFunction);
            this.groupBox1.Controls.Add(this.ckbXoaLoai);
            this.groupBox1.Controls.Add(this.dgvNhaNSX);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1145, 612);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hiển Thị Danh Sách Nhà Sản Xuất";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pnFunction
            // 
            this.pnFunction.Controls.Add(this.button2);
            this.pnFunction.Controls.Add(this.button1);
            this.pnFunction.Controls.Add(this.txtTimTheoTen);
            this.pnFunction.Controls.Add(this.cbChon);
            this.pnFunction.Controls.Add(this.txtTimTheoMa);
            this.pnFunction.Controls.Add(this.btnXoaNSX);
            this.pnFunction.Controls.Add(this.btnSuaNSX);
            this.pnFunction.Controls.Add(this.btnThemNSX);
            this.pnFunction.Location = new System.Drawing.Point(6, 25);
            this.pnFunction.Name = "pnFunction";
            this.pnFunction.Size = new System.Drawing.Size(1048, 59);
            this.pnFunction.TabIndex = 38;
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
            this.button2.Location = new System.Drawing.Point(436, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 44;
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
            this.button1.Location = new System.Drawing.Point(654, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 34);
            this.button1.TabIndex = 43;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // txtTimTheoTen
            // 
            this.txtTimTheoTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimTheoTen.Location = new System.Drawing.Point(725, 15);
            this.txtTimTheoTen.Name = "txtTimTheoTen";
            this.txtTimTheoTen.Size = new System.Drawing.Size(239, 26);
            this.txtTimTheoTen.TabIndex = 42;
            this.txtTimTheoTen.TextChanged += new System.EventHandler(this.txtTimTheoTen_TextChanged);
            this.txtTimTheoTen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimTheoMa_KeyUp);
            // 
            // cbChon
            // 
            this.cbChon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChon.FormattingEnabled = true;
            this.cbChon.Location = new System.Drawing.Point(517, 14);
            this.cbChon.Name = "cbChon";
            this.cbChon.Size = new System.Drawing.Size(131, 27);
            this.cbChon.TabIndex = 41;
            this.cbChon.SelectedIndexChanged += new System.EventHandler(this.cbChon_SelectedIndexChanged);
            this.cbChon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbChon_KeyPress);
            // 
            // txtTimTheoMa
            // 
            this.txtTimTheoMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimTheoMa.Location = new System.Drawing.Point(725, 14);
            this.txtTimTheoMa.Name = "txtTimTheoMa";
            this.txtTimTheoMa.Size = new System.Drawing.Size(239, 27);
            this.txtTimTheoMa.TabIndex = 40;
            this.txtTimTheoMa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimTheoMa_KeyPress);
            this.txtTimTheoMa.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimTheoMa_KeyUp);
            // 
            // btnXoaNSX
            // 
            this.btnXoaNSX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXoaNSX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNSX.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaNSX.Image")));
            this.btnXoaNSX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaNSX.Location = new System.Drawing.Point(238, 7);
            this.btnXoaNSX.Name = "btnXoaNSX";
            this.btnXoaNSX.Size = new System.Drawing.Size(107, 45);
            this.btnXoaNSX.TabIndex = 39;
            this.btnXoaNSX.Text = "Xóa";
            this.btnXoaNSX.UseVisualStyleBackColor = false;
            this.btnXoaNSX.Click += new System.EventHandler(this.btnXoaNSX_Click);
            // 
            // btnSuaNSX
            // 
            this.btnSuaNSX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSuaNSX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaNSX.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaNSX.Image")));
            this.btnSuaNSX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaNSX.Location = new System.Drawing.Point(125, 7);
            this.btnSuaNSX.Name = "btnSuaNSX";
            this.btnSuaNSX.Size = new System.Drawing.Size(107, 45);
            this.btnSuaNSX.TabIndex = 38;
            this.btnSuaNSX.Text = "Sửa";
            this.btnSuaNSX.UseVisualStyleBackColor = false;
            this.btnSuaNSX.Click += new System.EventHandler(this.btnSuaNSX_Click);
            // 
            // btnThemNSX
            // 
            this.btnThemNSX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnThemNSX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNSX.Image = ((System.Drawing.Image)(resources.GetObject("btnThemNSX.Image")));
            this.btnThemNSX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemNSX.Location = new System.Drawing.Point(3, 7);
            this.btnThemNSX.Name = "btnThemNSX";
            this.btnThemNSX.Size = new System.Drawing.Size(107, 45);
            this.btnThemNSX.TabIndex = 37;
            this.btnThemNSX.Text = "Thêm";
            this.btnThemNSX.UseVisualStyleBackColor = false;
            this.btnThemNSX.Click += new System.EventHandler(this.btnThemNSX_Click);
            // 
            // ckbXoaLoai
            // 
            this.ckbXoaLoai.AutoSize = true;
            this.ckbXoaLoai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbXoaLoai.ForeColor = System.Drawing.Color.Red;
            this.ckbXoaLoai.Location = new System.Drawing.Point(1060, 0);
            this.ckbXoaLoai.Name = "ckbXoaLoai";
            this.ckbXoaLoai.Size = new System.Drawing.Size(76, 23);
            this.ckbXoaLoai.TabIndex = 37;
            this.ckbXoaLoai.Text = "Đã Xóa";
            this.ckbXoaLoai.UseVisualStyleBackColor = true;
            this.ckbXoaLoai.CheckedChanged += new System.EventHandler(this.ckbXoaLoai_CheckedChanged);
            // 
            // dgvNhaNSX
            // 
            this.dgvNhaNSX.AllowUserToAddRows = false;
            this.dgvNhaNSX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhaNSX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNSX,
            this.TenNSX,
            this.DiaChiNSX,
            this.DienThoaiNSX});
            this.dgvNhaNSX.Location = new System.Drawing.Point(6, 90);
            this.dgvNhaNSX.Name = "dgvNhaNSX";
            this.dgvNhaNSX.ReadOnly = true;
            this.dgvNhaNSX.RowHeadersWidth = 40;
            this.dgvNhaNSX.Size = new System.Drawing.Size(1133, 516);
            this.dgvNhaNSX.TabIndex = 0;
            // 
            // MaNSX
            // 
            this.MaNSX.DataPropertyName = "MaNSX";
            this.MaNSX.HeaderText = "Mã Nhà NSX";
            this.MaNSX.Name = "MaNSX";
            this.MaNSX.ReadOnly = true;
            this.MaNSX.Width = 273;
            // 
            // TenNSX
            // 
            this.TenNSX.DataPropertyName = "TenNSX";
            this.TenNSX.HeaderText = "Tên";
            this.TenNSX.Name = "TenNSX";
            this.TenNSX.ReadOnly = true;
            this.TenNSX.Width = 273;
            // 
            // DiaChiNSX
            // 
            this.DiaChiNSX.DataPropertyName = "DiaChiNSX";
            this.DiaChiNSX.HeaderText = "Địa Chỉ";
            this.DiaChiNSX.Name = "DiaChiNSX";
            this.DiaChiNSX.ReadOnly = true;
            this.DiaChiNSX.Width = 273;
            // 
            // DienThoaiNSX
            // 
            this.DienThoaiNSX.DataPropertyName = "DienThoaiNSX";
            this.DienThoaiNSX.HeaderText = "Điện Thoại";
            this.DienThoaiNSX.Name = "DienThoaiNSX";
            this.DienThoaiNSX.ReadOnly = true;
            this.DienThoaiNSX.Width = 273;
            // 
            // FrmTrangNhaNSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 612);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTrangNhaNSX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTrangNhaNSX";
            this.Load += new System.EventHandler(this.FrmTrangNhaNSX_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnFunction.ResumeLayout(false);
            this.pnFunction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaNSX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvNhaNSX;
        private System.Windows.Forms.CheckBox ckbXoaLoai;
        private System.Windows.Forms.Panel pnFunction;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTimTheoTen;
        private System.Windows.Forms.ComboBox cbChon;
        private System.Windows.Forms.TextBox txtTimTheoMa;
        private System.Windows.Forms.Button btnXoaNSX;
        private System.Windows.Forms.Button btnSuaNSX;
        private System.Windows.Forms.Button btnThemNSX;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNSX;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNSX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChiNSX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoaiNSX;
    }
}