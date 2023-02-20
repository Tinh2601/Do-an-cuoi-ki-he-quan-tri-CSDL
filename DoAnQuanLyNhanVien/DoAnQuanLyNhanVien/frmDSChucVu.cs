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
    public partial class frmDSChucVu : Form
    {
        public frmDSChucVu()
        {
            InitializeComponent();
        }
        My_DB mydb = new My_DB();
        DataTable dtChucVu = null;
        bool them = false;
        private void frmDSChucVu_Load(object sender, EventArgs e)
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

            txbMaCV.ResetText();
            txbTenCV.ResetText();
            txbPhuCap.ResetText();

            txbMaCV.Enabled = true;
        }
        public void LoadData()
        {
            try
            {
                mydb.openConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spLayDSChucVu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                var rd = cmd.ExecuteReader();

                dtChucVu = new DataTable();
                dtChucVu.Clear();
                dtChucVu.Load(rd);


                dgvDSChucVu.DataSource = dtChucVu;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu trong table ChucVu, lỗi rồi huhu!!!");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
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
            this.txbMaCV.Focus();
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
            int r = dgvDSChucVu.CurrentCell.RowIndex;

            txbMaCV.Text = dgvDSChucVu.Rows[r].Cells[0].Value.ToString();
            txbTenCV.Text = dgvDSChucVu.Rows[r].Cells[1].Value.ToString();
            txbPhuCap.Text = dgvDSChucVu.Rows[r].Cells[2].Value.ToString();
            //
            txbMaCV.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                CHUCVU cv = new CHUCVU();
                string macv = txbMaCV.Text.ToString();
                string tencv = txbTenCV.Text.ToString();
                string phucap = txbPhuCap.Text.ToString();
                try
                {
                    cv.Insert(macv, tencv, phucap);
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
                CHUCVU cv = new CHUCVU();
                string macv = txbMaCV.Text.ToString();
                string tencv = txbTenCV.Text.ToString();
                string phucap = txbPhuCap.Text.ToString();

                try
                {
                    cv.Update(macv, tencv, phucap);
                    MessageBox.Show("Đã cập nhật thành công");
                    ViewMode();
                    LoadData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thực hiện được, Lỗi rồi!!!");
                }
                txbMaCV.Enabled = true;

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dgvDSChucVu.CurrentCell.RowIndex;
            CHUCVU cv = new CHUCVU();
            string MaCV = dgvDSChucVu.Rows[r].Cells[0].Value.ToString();
            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa " + MaCV + " ?", "Thông báo",
                    MessageBoxButtons.OKCancel
                , MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                try
                {
                    cv.Delete(MaCV);
                    MessageBox.Show("Đã xóa thành công");
                    LoadData();

                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa Chức vụ này được !!");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ViewMode();

        }
    }
}
