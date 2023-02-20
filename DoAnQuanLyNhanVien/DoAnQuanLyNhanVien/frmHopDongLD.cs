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
    public partial class frmHopDongLD : Form
    {
        My_DB mydb = new My_DB();
        DataTable dtHopDong = null;
        bool them = false;

        public frmHopDongLD()
        {
            InitializeComponent();
        }

        private void frmHopDongLD_Load(object sender, EventArgs e)
        {
            ViewMode();
            LoadData();
        }
        void LoadData()
        {
            try
            {
                mydb.openConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spLayDSHopDong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                var rd = cmd.ExecuteReader();

                dtHopDong = new DataTable();
                dtHopDong.Clear();
                dtHopDong.Load(rd);
                dgvDSHopDong.DataSource = dtHopDong;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu trong table HopDong, Lỗi rồi!!!");
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

            txbMaHD.ResetText();
            txbLoaiHD.ResetText();
            txbNgayBD.ResetText();
            txbMaNV.ResetText();

            txbMaNV.Enabled = true;
            txbMaHD.Enabled = true;
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
            //Đưa con trỏ đến Mã nhân viên
            this.txbMaHD.Focus();
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
            int r = dgvDSHopDong.CurrentCell.RowIndex;

            txbMaHD.Text = dgvDSHopDong.Rows[r].Cells[0].Value.ToString();
            txbLoaiHD.Text = dgvDSHopDong.Rows[r].Cells[1].Value.ToString();
            txbNgayBD.Text = dgvDSHopDong.Rows[r].Cells[2].Value.ToString();
            txbMaNV.Text = dgvDSHopDong.Rows[r].Cells[3].Value.ToString();
            //
            txbMaHD.Enabled = false;
            txbMaNV.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dgvDSHopDong.CurrentCell.RowIndex;
            HOPDONGLD hd = new HOPDONGLD();
            string maNV = dgvDSHopDong.Rows[r].Cells[3].Value.ToString();
            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa ?", "Thông báo",
                    MessageBoxButtons.OKCancel
                , MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                try
                {
                    hd.Delete(maNV);
                    MessageBox.Show("Đã xóa thành công");
                    LoadData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa hợp đồng này được !!");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                HOPDONGLD hd = new HOPDONGLD();
                string mahd = txbMaHD.Text.ToString();
                string loaihd = txbLoaiHD.Text.ToString();
                string ngaybd = txbNgayBD.Text.ToString();
                string manv = txbMaNV.Text.ToString().Trim();
                try
                {
                    hd.Insert(mahd, loaihd, ngaybd, manv);
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
                HOPDONGLD hd = new HOPDONGLD();
                string mahd = txbMaHD.Text.ToString();
                string loaihd = txbLoaiHD.Text.ToString();
                string ngaybd = txbNgayBD.Text.ToString();
                string manv = txbMaNV.Text.ToString().Trim();
                try
                {
                    hd.Update(mahd, loaihd, ngaybd, manv);
                    MessageBox.Show("Đã cập nhật thành công");

                    ViewMode();
                    LoadData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thực hiện được, Lỗi rồi!!!");
                }
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
