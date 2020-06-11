namespace QuanLiCuaHangQuanAo.KhuyenMai
{
    partial class FrmKhuyenMai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKhuyenMai));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnFunction = new System.Windows.Forms.Panel();
            this.btnClearNgay = new System.Windows.Forms.Button();
            this.dtpSearch = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTimTheoTen = new System.Windows.Forms.TextBox();
            this.cbChon = new System.Windows.Forms.ComboBox();
            this.txtTimTheoMa = new System.Windows.Forms.TextBox();
            this.btnXoaKM = new System.Windows.Forms.Button();
            this.btnSuaKM = new System.Windows.Forms.Button();
            this.btnThemKM = new System.Windows.Forms.Button();
            this.ckbXoaLoai = new System.Windows.Forms.CheckBox();
            this.dgvKhuyenMai = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.pnFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnFunction);
            this.groupBox1.Controls.Add(this.ckbXoaLoai);
            this.groupBox1.Controls.Add(this.dgvKhuyenMai);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(-3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1153, 613);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hiển Thị Danh Sách Khuyến Mãi";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pnFunction
            // 
            this.pnFunction.Controls.Add(this.btnClearNgay);
            this.pnFunction.Controls.Add(this.dtpSearch);
            this.pnFunction.Controls.Add(this.button2);
            this.pnFunction.Controls.Add(this.button1);
            this.pnFunction.Controls.Add(this.txtTimTheoTen);
            this.pnFunction.Controls.Add(this.cbChon);
            this.pnFunction.Controls.Add(this.txtTimTheoMa);
            this.pnFunction.Controls.Add(this.btnXoaKM);
            this.pnFunction.Controls.Add(this.btnSuaKM);
            this.pnFunction.Controls.Add(this.btnThemKM);
            this.pnFunction.Location = new System.Drawing.Point(6, 25);
            this.pnFunction.Name = "pnFunction";
            this.pnFunction.Size = new System.Drawing.Size(1068, 60);
            this.pnFunction.TabIndex = 38;
            // 
            // btnClearNgay
            // 
            this.btnClearNgay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClearNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearNgay.Image = ((System.Drawing.Image)(resources.GetObject("btnClearNgay.Image")));
            this.btnClearNgay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearNgay.Location = new System.Drawing.Point(940, 7);
            this.btnClearNgay.Name = "btnClearNgay";
            this.btnClearNgay.Size = new System.Drawing.Size(124, 45);
            this.btnClearNgay.TabIndex = 49;
            this.btnClearNgay.Text = "       Clear Date";
            this.btnClearNgay.UseVisualStyleBackColor = false;
            this.btnClearNgay.Click += new System.EventHandler(this.btnClearNgay_Click);
            // 
            // dtpSearch
            // 
            this.dtpSearch.CustomFormat = "dd/MM/yyyy";
            this.dtpSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSearch.Location = new System.Drawing.Point(683, 17);
            this.dtpSearch.Name = "dtpSearch";
            this.dtpSearch.Size = new System.Drawing.Size(239, 26);
            this.dtpSearch.TabIndex = 48;
            this.dtpSearch.Value = new System.DateTime(2019, 5, 23, 0, 0, 0, 0);
            this.dtpSearch.ValueChanged += new System.EventHandler(this.dtpSearch_ValueChanged);
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
            this.button2.Location = new System.Drawing.Point(394, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 47;
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
            this.button1.Location = new System.Drawing.Point(602, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 46;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // txtTimTheoTen
            // 
            this.txtTimTheoTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimTheoTen.Location = new System.Drawing.Point(683, 18);
            this.txtTimTheoTen.Name = "txtTimTheoTen";
            this.txtTimTheoTen.Size = new System.Drawing.Size(239, 26);
            this.txtTimTheoTen.TabIndex = 45;
            this.txtTimTheoTen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimTheoTen_KeyUp);
            // 
            // cbChon
            // 
            this.cbChon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChon.FormattingEnabled = true;
            this.cbChon.Location = new System.Drawing.Point(475, 17);
            this.cbChon.Name = "cbChon";
            this.cbChon.Size = new System.Drawing.Size(121, 27);
            this.cbChon.TabIndex = 44;
            this.cbChon.SelectedIndexChanged += new System.EventHandler(this.cbChon_SelectedIndexChanged);
            this.cbChon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbChon_KeyPress);
            // 
            // txtTimTheoMa
            // 
            this.txtTimTheoMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimTheoMa.Location = new System.Drawing.Point(683, 17);
            this.txtTimTheoMa.Name = "txtTimTheoMa";
            this.txtTimTheoMa.Size = new System.Drawing.Size(239, 27);
            this.txtTimTheoMa.TabIndex = 43;
            this.txtTimTheoMa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimTheoMa_KeyPress);
            this.txtTimTheoMa.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimTheoTen_KeyUp);
            // 
            // btnXoaKM
            // 
            this.btnXoaKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXoaKM.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaKM.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaKM.Image")));
            this.btnXoaKM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaKM.Location = new System.Drawing.Point(239, 8);
            this.btnXoaKM.Name = "btnXoaKM";
            this.btnXoaKM.Size = new System.Drawing.Size(116, 45);
            this.btnXoaKM.TabIndex = 42;
            this.btnXoaKM.Text = "Xóa";
            this.btnXoaKM.UseVisualStyleBackColor = false;
            this.btnXoaKM.Click += new System.EventHandler(this.btnXoaKM_Click);
            // 
            // btnSuaKM
            // 
            this.btnSuaKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSuaKM.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaKM.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaKM.Image")));
            this.btnSuaKM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaKM.Location = new System.Drawing.Point(126, 8);
            this.btnSuaKM.Name = "btnSuaKM";
            this.btnSuaKM.Size = new System.Drawing.Size(107, 45);
            this.btnSuaKM.TabIndex = 41;
            this.btnSuaKM.Text = "Sửa";
            this.btnSuaKM.UseVisualStyleBackColor = false;
            this.btnSuaKM.Click += new System.EventHandler(this.btnSuaKM_Click);
            // 
            // btnThemKM
            // 
            this.btnThemKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnThemKM.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemKM.Image = ((System.Drawing.Image)(resources.GetObject("btnThemKM.Image")));
            this.btnThemKM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemKM.Location = new System.Drawing.Point(4, 8);
            this.btnThemKM.Name = "btnThemKM";
            this.btnThemKM.Size = new System.Drawing.Size(116, 45);
            this.btnThemKM.TabIndex = 40;
            this.btnThemKM.Text = "     Thêm";
            this.btnThemKM.UseVisualStyleBackColor = false;
            this.btnThemKM.Click += new System.EventHandler(this.btnThemKM_Click);
            // 
            // ckbXoaLoai
            // 
            this.ckbXoaLoai.AutoSize = true;
            this.ckbXoaLoai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbXoaLoai.ForeColor = System.Drawing.Color.Red;
            this.ckbXoaLoai.Location = new System.Drawing.Point(1077, 0);
            this.ckbXoaLoai.Name = "ckbXoaLoai";
            this.ckbXoaLoai.Size = new System.Drawing.Size(76, 23);
            this.ckbXoaLoai.TabIndex = 37;
            this.ckbXoaLoai.Text = "Đã Xóa";
            this.ckbXoaLoai.UseVisualStyleBackColor = true;
            this.ckbXoaLoai.CheckedChanged += new System.EventHandler(this.ckbXoaLoai_CheckedChanged);
            // 
            // dgvKhuyenMai
            // 
            this.dgvKhuyenMai.AllowUserToAddRows = false;
            this.dgvKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuyenMai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvKhuyenMai.Location = new System.Drawing.Point(6, 91);
            this.dgvKhuyenMai.Name = "dgvKhuyenMai";
            this.dgvKhuyenMai.ReadOnly = true;
            this.dgvKhuyenMai.RowHeadersWidth = 39;
            this.dgvKhuyenMai.Size = new System.Drawing.Size(1147, 516);
            this.dgvKhuyenMai.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaKM";
            this.Column1.HeaderText = "Mã Khuyến Mãi";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 276;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "UuDai";
            this.Column2.HeaderText = "Ưu Đãi";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 276;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NgayBatDau";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "Ngày Bắt Đầu";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 276;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NgayKetThuc";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Ngày Kết Thúc";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 276;
            // 
            // FrmKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 612);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmKhuyenMai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmKhuyenMai";
            this.Load += new System.EventHandler(this.FrmKhuyenMai_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnFunction.ResumeLayout(false);
            this.pnFunction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvKhuyenMai;
        private System.Windows.Forms.CheckBox ckbXoaLoai;
        private System.Windows.Forms.Panel pnFunction;
        private System.Windows.Forms.Button btnClearNgay;
        private System.Windows.Forms.DateTimePicker dtpSearch;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTimTheoTen;
        private System.Windows.Forms.ComboBox cbChon;
        private System.Windows.Forms.TextBox txtTimTheoMa;
        private System.Windows.Forms.Button btnXoaKM;
        private System.Windows.Forms.Button btnSuaKM;
        private System.Windows.Forms.Button btnThemKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}