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
    public partial class frmDSPhongBan : Form
    {
        My_DB mydb = new My_DB();

        DataTable dtNhanVien = null;
        DataTable dtPhongBan = null;
        bool them = false;
        public frmDSPhongBan()
        {
            InitializeComponent();
        }

        private void frmDSPhongBan_Load(object sender, EventArgs e)
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
                cmd.CommandText = "spLayDSPhongBan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                var rd = cmd.ExecuteReader();

                dtPhongBan = new DataTable();
                dtPhongBan.Clear();
                dtPhongBan.Load(rd);

                cmd.CommandText = "spLayDSNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                var rdCV = cmd.ExecuteReader();

                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                dtNhanVien.Load(rdCV);

                (dgvDSPhongBan.Columns["TrPhong"] as DataGridViewComboBoxColumn).DataSource = dtNhanVien;
                (dgvDSPhongBan.Columns["TrPhong"] as DataGridViewComboBoxColumn).DisplayMember = "HoTen";
                (dgvDSPhongBan.Columns["TrPhong"] as DataGridViewComboBoxColumn).ValueMember = "MaNV";
                //
                dgvDSPhongBan.DataSource = dtPhongBan;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu trong table PhongBan, Lỗi rồi!!!");
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

            txbMaPB.ResetText();
            txbTenPB.ResetText();
            txbDiaChi.ResetText();
            cbTruongPhong.ResetText();

            txbMaPB.Enabled = true;
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
            this.cbTruongPhong.DataSource = dtNhanVien;
            this.cbTruongPhong.DisplayMember = "HoTen";
            this.cbTruongPhong.ValueMember = "MaNV";
            //Đưa con trỏ đến Mã nhân viên
            this.txbMaPB.Focus();
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
            this.cbTruongPhong.DataSource = dtNhanVien;
            this.cbTruongPhong.DisplayMember = "HoTen";
            this.cbTruongPhong.ValueMember = "MaNV";
            //
            int r = dgvDSPhongBan.CurrentCell.RowIndex;

            txbMaPB.Text = dgvDSPhongBan.Rows[r].Cells[0].Value.ToString();
            txbTenPB.Text = dgvDSPhongBan.Rows[r].Cells[1].Value.ToString();
            txbDiaChi.Text = dgvDSPhongBan.Rows[r].Cells[2].Value.ToString();
            cbTruongPhong.SelectedValue = dgvDSPhongBan.Rows[r].Cells[3].Value.ToString();
            //
            txbMaPB.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dgvDSPhongBan.CurrentCell.RowIndex;
            PHONGBAN nv = new PHONGBAN();
            string MaPB = dgvDSPhongBan.Rows[r].Cells[0].Value.ToString();
            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa phòng ban " + MaPB + " ?", "Thông báo",
                    MessageBoxButtons.OKCancel
                , MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                try
                {
                    nv.Delete(MaPB);
                    MessageBox.Show("Đã xóa thành công");
                    LoadData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa phòng ban này được !!");
                }
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                PHONGBAN pb = new PHONGBAN();
                string mapb = txbMaPB.Text.ToString();
                string tenpb = txbTenPB.Text.ToString();
                string diachi = txbDiaChi.Text.ToString();
                string trphong = cbTruongPhong.SelectedValue.ToString().Trim();
                try
                {
                    pb.Insert(mapb, tenpb, diachi, trphong);
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
                PHONGBAN pb = new PHONGBAN();
                string mapb = txbMaPB.Text.ToString();
                string tenpb = txbTenPB.Text.ToString();
                string diachi = txbDiaChi.Text.ToString();
                string trphong = cbTruongPhong.SelectedValue.ToString().Trim();
                try
                {
                    pb.Update(mapb, tenpb, diachi, trphong);
                    MessageBox.Show("Đã cập nhật thành công");

                    ViewMode();
                    LoadData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thực hiện được, Lỗi rồi!!!");
                }
                txbMaPB.Enabled = true;

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
