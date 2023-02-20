using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnQuanLyNhanVien
{
    public partial class frmDSDuAn : Form
    {
        My_DB mydb = new My_DB();

        DataTable dtDuAn = null;
        DataTable dtPhongBan = null;
        bool them = false;
        public frmDSDuAn()
        {
            InitializeComponent();
        }

        private void frmDSDuAn_Load(object sender, EventArgs e)
        {
            ViewMode();

            LoadData();
        }
        public void LoadData()
        {
            try
            {
                mydb.openConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spLayDSDuAn";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                var rd = cmd.ExecuteReader();

                dtDuAn = new DataTable();
                dtDuAn.Clear();
                dtDuAn.Load(rd);

                cmd.CommandText = "spLayDSPhongBan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                var rdPB = cmd.ExecuteReader();

                dtPhongBan = new DataTable();
                dtPhongBan.Clear();
                dtPhongBan.Load(rdPB);

                (dgvDSDuAn.Columns["PhongBan"] as DataGridViewComboBoxColumn).DataSource = dtPhongBan;
                (dgvDSDuAn.Columns["PhongBan"] as DataGridViewComboBoxColumn).DisplayMember = "TenPB";
                (dgvDSDuAn.Columns["PhongBan"] as DataGridViewComboBoxColumn).ValueMember = "MaPB";
                //

                dgvDSDuAn.DataSource = dtDuAn;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu trong table NhanVien, Lỗi rồi!!!");
            }
        }
        public void ViewMode()
        {
            panel1.Enabled = false;
            this.btnHuy.Enabled = false;
            this.btnLuu.Enabled = false;
            this.btnXoa.Enabled = true;
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnReload.Enabled = true;

            txbMaDA.ResetText();
            txbDoanhThu.ResetText();
            txbTenDA.ResetText();
            txbNgayBD.ResetText();
            txbNgayKT.ResetText();
            txbTinhTrang.ResetText();
            cbPhongBan.ResetText();

            txbMaDA.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.them = true;
            panel1.Enabled = true;
            //Cho phép hiệu chỉnh nút Lưu và Hủy
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            //Vô hiệu hóa nút xóa, sửa và reload
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnReload.Enabled = false;
            //

            this.cbPhongBan.DataSource = dtPhongBan;
            this.cbPhongBan.DisplayMember = "TenPB";
            this.cbPhongBan.ValueMember = "MaPB";
            //Đưa con trỏ đến Mã nhân viên
            this.txbMaDA.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.them = false;

            panel1.Enabled = true;
            //Cho phép hiệu chỉnh nút Lưu và Hủy
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            //Vô hiệu hóa nút xóa, sửa và reload
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnReload.Enabled = false;
            //

            this.cbPhongBan.DataSource = dtPhongBan;
            this.cbPhongBan.DisplayMember = "TenPB";
            this.cbPhongBan.ValueMember = "MaPB";
            //
            int r = dgvDSDuAn.CurrentCell.RowIndex;

            txbMaDA.Text = dgvDSDuAn.Rows[r].Cells[0].Value.ToString();
            txbTenDA.Text = dgvDSDuAn.Rows[r].Cells[1].Value.ToString();
            txbNgayBD.Text = dgvDSDuAn.Rows[r].Cells[2].Value.ToString();
            txbNgayKT.Text = dgvDSDuAn.Rows[r].Cells[3].Value.ToString();
            txbDoanhThu.Text = dgvDSDuAn.Rows[r].Cells[4].Value.ToString();
            txbTinhTrang.Text = dgvDSDuAn.Rows[r].Cells[5].Value.ToString();
            cbPhongBan.SelectedValue = dgvDSDuAn.Rows[r].Cells[6].Value.ToString();

            //
            txbMaDA.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dgvDSDuAn.CurrentCell.RowIndex;
            DUAN da = new DUAN();
            string MaDA = dgvDSDuAn.Rows[r].Cells[0].Value.ToString();
            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa dự án " + MaDA + " ?", "Thông báo",
                    MessageBoxButtons.OKCancel
                , MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                try
                {
                    da.Delete(MaDA);
                    MessageBox.Show("Đã xóa thành công");
                    LoadData();

                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa dự án này được !!");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                DUAN da = new DUAN();
                string mada = txbMaDA.Text.ToString();
                string tenda = txbTenDA.Text.ToString();
                string ngaybd = txbNgayBD.Text.ToString();
                string ngaykt = txbNgayKT.Text.ToString();
                string doanhthu = txbDoanhThu.Text.ToString();
                string tinhtrang = txbTinhTrang.Text.ToString();
                string phongban = cbPhongBan.SelectedValue.ToString().Trim();
                try
                {
                    da.Insert(mada, tenda, ngaybd, ngaykt, doanhthu, tinhtrang, phongban);
                    MessageBox.Show("Đã thêm thành công");
                    ViewMode();
                    LoadData();

                }
                catch (Exception)
                {
                    MessageBox.Show("Không thực hiện được, Lỗi rồi!!!");
                }
            }
            if (!them)
            {
                DUAN da = new DUAN();
                string mada = txbMaDA.Text.ToString();
                string tenda = txbTenDA.Text.ToString();
                string ngaybd = txbNgayBD.Text.ToString();
                string ngaykt = txbNgayKT.Text.ToString();
                string doanhthu = txbDoanhThu.Text.ToString();
                string tinhtrang = txbTinhTrang.Text.ToString();
                string phongban = cbPhongBan.SelectedValue.ToString().Trim();

                try
                {
                    da.Update(mada, tenda, ngaybd, ngaykt, doanhthu, tinhtrang, phongban);
                    MessageBox.Show("Đã cập nhật thành công");

                    ViewMode();
                    LoadData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thực hiện được, Lỗi rồi!!!");
                }
                txbMaDA.Enabled = true;

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ViewMode();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
