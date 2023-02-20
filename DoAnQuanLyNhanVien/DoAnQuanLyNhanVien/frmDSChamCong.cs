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
    public partial class frmDSChamCong : Form
    {
        My_DB mydb = new My_DB();
        DataTable dtChamCong = null;
        bool them = false;
        public frmDSChamCong()
        {
            InitializeComponent();
        }

        private void frmDSChamCong_Load(object sender, EventArgs e)
        {
            ViewMode();
            LoadData();
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

            txbMaNV.ResetText();
            txbThang.ResetText();
            txbNam.ResetText();
            txbSoNgayDiLam.ResetText();

            txbMaNV.Enabled = true;
            txbThang.Enabled = true;
            txbNam.Enabled = true;
        }
        public void LoadData()
        {
            try
            {
                mydb.openConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spLayDSChamCong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                var rd = cmd.ExecuteReader();

                dtChamCong = new DataTable();
                dtChamCong.Clear();
                dtChamCong.Load(rd);
                dgvDSChamCong.DataSource = dtChamCong;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu trong table, lỗi rồi huhu!!!");
            }
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
            //Đưa con trỏ đến Mã nhân viên
            this.txbMaNV.Focus();
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
            int r = dgvDSChamCong.CurrentCell.RowIndex;

            txbMaNV.Text = dgvDSChamCong.Rows[r].Cells[0].Value.ToString();
            txbThang.Text = dgvDSChamCong.Rows[r].Cells[1].Value.ToString();
            txbNam.Text = dgvDSChamCong.Rows[r].Cells[2].Value.ToString();
            txbSoNgayDiLam.Text = dgvDSChamCong.Rows[r].Cells[3].Value.ToString();
            //
            txbMaNV.Enabled = false;
            txbThang.Enabled = false;
            txbNam.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dgvDSChamCong.CurrentCell.RowIndex;
            CHAMCONG cc = new CHAMCONG();
            string MaNV = dgvDSChamCong.Rows[r].Cells[0].Value.ToString();
            string Thang = dgvDSChamCong.Rows[r].Cells[1].Value.ToString();
            string Nam = dgvDSChamCong.Rows[r].Cells[2].Value.ToString();

            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa ?", "Thông báo",
                    MessageBoxButtons.OKCancel
                , MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                try
                {
                    cc.Delete(MaNV, Thang, Nam);
                    MessageBox.Show("Đã xóa thành công");
                    LoadData();

                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa Chức vụ này được !!");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                CHAMCONG cc = new CHAMCONG();
                string manv = txbMaNV.Text.ToString();
                string thang = txbThang.Text.ToString();
                string nam = txbNam.Text.ToString();
                string songaydilam = txbSoNgayDiLam.Text.ToString();

                try
                {
                    cc.Insert(manv, thang, nam, songaydilam);
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
                CHAMCONG cc = new CHAMCONG();
                string manv = txbMaNV.Text.ToString();
                string thang = txbThang.Text.ToString();
                string nam = txbNam.Text.ToString();
                string songaydilam = txbSoNgayDiLam.Text.ToString();

                try
                {
                    cc.Update(manv, thang, nam, songaydilam);
                    MessageBox.Show("Đã cập nhật thành công");
                    ViewMode();
                    LoadData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thực hiện được, Lỗi rồi!!!");
                }
                txbMaNV.Enabled = true;
                txbThang.Enabled = true;
                txbNam.Enabled = true;
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
