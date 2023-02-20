
namespace DoAnQuanLyNhanVien
{
    partial class frmPhanCongDuAn
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbTenDA = new System.Windows.Forms.TextBox();
            this.dgvNhanVienDuAn = new System.Windows.Forms.DataGridView();
            this.cbMaDA = new System.Windows.Forms.ComboBox();
            this.dgvRestNhanVien = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnChon = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txbPhuCap = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVienDuAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Dự Án";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên Dự án";
            // 
            // txbTenDA
            // 
            this.txbTenDA.Enabled = false;
            this.txbTenDA.Location = new System.Drawing.Point(130, 117);
            this.txbTenDA.Name = "txbTenDA";
            this.txbTenDA.Size = new System.Drawing.Size(150, 22);
            this.txbTenDA.TabIndex = 3;
            // 
            // dgvNhanVienDuAn
            // 
            this.dgvNhanVienDuAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNhanVienDuAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVienDuAn.Location = new System.Drawing.Point(21, 169);
            this.dgvNhanVienDuAn.MultiSelect = false;
            this.dgvNhanVienDuAn.Name = "dgvNhanVienDuAn";
            this.dgvNhanVienDuAn.ReadOnly = true;
            this.dgvNhanVienDuAn.RowHeadersWidth = 51;
            this.dgvNhanVienDuAn.RowTemplate.Height = 24;
            this.dgvNhanVienDuAn.Size = new System.Drawing.Size(488, 161);
            this.dgvNhanVienDuAn.TabIndex = 6;
            // 
            // cbMaDA
            // 
            this.cbMaDA.FormattingEnabled = true;
            this.cbMaDA.Location = new System.Drawing.Point(130, 83);
            this.cbMaDA.Name = "cbMaDA";
            this.cbMaDA.Size = new System.Drawing.Size(150, 24);
            this.cbMaDA.TabIndex = 7;
            this.cbMaDA.SelectedIndexChanged += new System.EventHandler(this.cbMaDA_SelectedIndexChanged);
            // 
            // dgvRestNhanVien
            // 
            this.dgvRestNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRestNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRestNhanVien.Location = new System.Drawing.Point(599, 169);
            this.dgvRestNhanVien.MultiSelect = false;
            this.dgvRestNhanVien.Name = "dgvRestNhanVien";
            this.dgvRestNhanVien.ReadOnly = true;
            this.dgvRestNhanVien.RowHeadersWidth = 51;
            this.dgvRestNhanVien.RowTemplate.Height = 24;
            this.dgvRestNhanVien.Size = new System.Drawing.Size(389, 161);
            this.dgvRestNhanVien.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(700, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Danh Sách Nhân viên còn lại";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(735, 402);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(156, 35);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(185, 402);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(156, 35);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnChon
            // 
            this.btnChon.Enabled = false;
            this.btnChon.Location = new System.Drawing.Point(458, 479);
            this.btnChon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(156, 35);
            this.btnChon.TabIndex = 12;
            this.btnChon.Text = "Chọn";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Enabled = false;
            this.btnHuy.Location = new System.Drawing.Point(458, 518);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(156, 35);
            this.btnHuy.TabIndex = 13;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(596, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Nhập phụ cấp";
            // 
            // txbPhuCap
            // 
            this.txbPhuCap.Enabled = false;
            this.txbPhuCap.Location = new System.Drawing.Point(708, 354);
            this.txbPhuCap.Name = "txbPhuCap";
            this.txbPhuCap.Size = new System.Drawing.Size(159, 22);
            this.txbPhuCap.TabIndex = 14;
            // 
            // frmPhanCongDuAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 581);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbPhuCap);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvRestNhanVien);
            this.Controls.Add(this.cbMaDA);
            this.Controls.Add(this.dgvNhanVienDuAn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbTenDA);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPhanCongDuAn";
            this.Text = "frmPhanCongDuAn";
            this.Load += new System.EventHandler(this.frmPhanCongDuAn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVienDuAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbTenDA;
        private System.Windows.Forms.DataGridView dgvNhanVienDuAn;
        private System.Windows.Forms.ComboBox cbMaDA;
        private System.Windows.Forms.DataGridView dgvRestNhanVien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbPhuCap;
    }
}