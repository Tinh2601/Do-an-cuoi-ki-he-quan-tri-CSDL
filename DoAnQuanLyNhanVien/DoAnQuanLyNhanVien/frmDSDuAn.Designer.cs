
namespace DoAnQuanLyNhanVien
{
    partial class frmDSDuAn
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
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvDSDuAn = new System.Windows.Forms.DataGridView();
            this.MaDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhongBan = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPhongBan = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbDoanhThu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbTinhTrang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbNgayKT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbMaDA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbTenDA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbNgayBD = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDuAn)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(438, 527);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 47);
            this.btnSua.TabIndex = 63;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(582, 527);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 47);
            this.btnXoa.TabIndex = 62;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(720, 527);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 47);
            this.btnLuu.TabIndex = 61;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(854, 527);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 47);
            this.btnHuy.TabIndex = 60;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(86, 527);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(100, 47);
            this.btnReload.TabIndex = 59;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(293, 527);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 47);
            this.btnThem.TabIndex = 58;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvDSDuAn
            // 
            this.dgvDSDuAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSDuAn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDA,
            this.TenDA,
            this.NgayBD,
            this.NgayKT,
            this.DoanhThu,
            this.TinhTrang,
            this.PhongBan});
            this.dgvDSDuAn.Location = new System.Drawing.Point(86, 215);
            this.dgvDSDuAn.Name = "dgvDSDuAn";
            this.dgvDSDuAn.ReadOnly = true;
            this.dgvDSDuAn.RowHeadersWidth = 51;
            this.dgvDSDuAn.RowTemplate.Height = 24;
            this.dgvDSDuAn.Size = new System.Drawing.Size(867, 276);
            this.dgvDSDuAn.TabIndex = 64;
            // 
            // MaDA
            // 
            this.MaDA.DataPropertyName = "MaDA";
            this.MaDA.HeaderText = "Mã Dự Án";
            this.MaDA.MinimumWidth = 6;
            this.MaDA.Name = "MaDA";
            this.MaDA.ReadOnly = true;
            this.MaDA.Width = 125;
            // 
            // TenDA
            // 
            this.TenDA.DataPropertyName = "TenDA";
            this.TenDA.HeaderText = "Tên Dự Án";
            this.TenDA.MinimumWidth = 6;
            this.TenDA.Name = "TenDA";
            this.TenDA.ReadOnly = true;
            this.TenDA.Width = 125;
            // 
            // NgayBD
            // 
            this.NgayBD.DataPropertyName = "NgayBD";
            this.NgayBD.HeaderText = "Ngày Bắt Đầu";
            this.NgayBD.MinimumWidth = 6;
            this.NgayBD.Name = "NgayBD";
            this.NgayBD.ReadOnly = true;
            this.NgayBD.Width = 125;
            // 
            // NgayKT
            // 
            this.NgayKT.DataPropertyName = "NgayKT";
            this.NgayKT.HeaderText = "Ngày Kết Thúc";
            this.NgayKT.MinimumWidth = 6;
            this.NgayKT.Name = "NgayKT";
            this.NgayKT.ReadOnly = true;
            this.NgayKT.Width = 125;
            // 
            // DoanhThu
            // 
            this.DoanhThu.DataPropertyName = "DoanhThu";
            this.DoanhThu.HeaderText = "Doanh Thu";
            this.DoanhThu.MinimumWidth = 6;
            this.DoanhThu.Name = "DoanhThu";
            this.DoanhThu.ReadOnly = true;
            this.DoanhThu.Width = 125;
            // 
            // TinhTrang
            // 
            this.TinhTrang.DataPropertyName = "TinhTrang";
            this.TinhTrang.HeaderText = "Tình Trạng";
            this.TinhTrang.MinimumWidth = 6;
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.ReadOnly = true;
            this.TinhTrang.Width = 125;
            // 
            // PhongBan
            // 
            this.PhongBan.DataPropertyName = "MaPB";
            this.PhongBan.HeaderText = "Phòng Ban";
            this.PhongBan.MinimumWidth = 6;
            this.PhongBan.Name = "PhongBan";
            this.PhongBan.ReadOnly = true;
            this.PhongBan.Width = 125;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbPhongBan);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txbDoanhThu);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txbTinhTrang);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txbNgayKT);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbMaDA);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txbTenDA);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txbNgayBD);
            this.panel1.Location = new System.Drawing.Point(86, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 163);
            this.panel1.TabIndex = 65;
            // 
            // cbPhongBan
            // 
            this.cbPhongBan.FormattingEnabled = true;
            this.cbPhongBan.Location = new System.Drawing.Point(678, 123);
            this.cbPhongBan.Name = "cbPhongBan";
            this.cbPhongBan.Size = new System.Drawing.Size(167, 24);
            this.cbPhongBan.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(592, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "Phòng Ban";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(592, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 35;
            this.label6.Text = "Doanh Thu";
            // 
            // txbDoanhThu
            // 
            this.txbDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDoanhThu.Location = new System.Drawing.Point(678, 79);
            this.txbDoanhThu.Name = "txbDoanhThu";
            this.txbDoanhThu.Size = new System.Drawing.Size(167, 22);
            this.txbDoanhThu.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "Tình Trạng";
            // 
            // txbTinhTrang
            // 
            this.txbTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTinhTrang.Location = new System.Drawing.Point(113, 127);
            this.txbTinhTrang.Name = "txbTinhTrang";
            this.txbTinhTrang.Size = new System.Drawing.Size(225, 22);
            this.txbTinhTrang.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(333, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Ngày Kết Thúc";
            // 
            // txbNgayKT
            // 
            this.txbNgayKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNgayKT.Location = new System.Drawing.Point(435, 81);
            this.txbNgayKT.Name = "txbNgayKT";
            this.txbNgayKT.Size = new System.Drawing.Size(115, 22);
            this.txbNgayKT.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Mã Dự Án";
            // 
            // txbMaDA
            // 
            this.txbMaDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMaDA.Location = new System.Drawing.Point(113, 30);
            this.txbMaDA.Name = "txbMaDA";
            this.txbMaDA.Size = new System.Drawing.Size(115, 22);
            this.txbMaDA.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(333, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Tên Dự Án";
            // 
            // txbTenDA
            // 
            this.txbTenDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTenDA.Location = new System.Drawing.Point(435, 32);
            this.txbTenDA.Name = "txbTenDA";
            this.txbTenDA.Size = new System.Drawing.Size(410, 22);
            this.txbTenDA.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Ngày Bắt Đầu";
            // 
            // txbNgayBD
            // 
            this.txbNgayBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNgayBD.Location = new System.Drawing.Point(113, 83);
            this.txbNgayBD.Name = "txbNgayBD";
            this.txbNgayBD.Size = new System.Drawing.Size(115, 22);
            this.txbNgayBD.TabIndex = 30;
            // 
            // frmDSDuAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 628);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDSDuAn);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnThem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDSDuAn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDSDuAn";
            this.Load += new System.EventHandler(this.frmDSDuAn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDuAn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvDSDuAn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbMaDA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbTenDA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbNgayBD;
        private System.Windows.Forms.ComboBox cbPhongBan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbDoanhThu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbTinhTrang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbNgayKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhTrang;
        private System.Windows.Forms.DataGridViewComboBoxColumn PhongBan;
    }
}