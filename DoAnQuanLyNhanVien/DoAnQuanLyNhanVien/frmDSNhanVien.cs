using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DoAnQuanLyNhanVien
{
    public partial class frmDSNhanVien : Form
    {
        My_DB mydb = new My_DB();

        DataTable dtNhanVien = null;
        DataTable dtChucVu = null;
        DataTable dtPhongBan = null;
        bool them = false;
        public frmDSNhanVien()
        {
            InitializeComponent();
        }

        private void DSNhanVien_Load(object sender, EventArgs e)
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
                cmd.CommandText = "spLayDSNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                var rd = cmd.ExecuteReader();

                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                dtNhanVien.Load(rd);

                cmd.CommandText = "spLayDSChucVu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                var rdCV = cmd.ExecuteReader();

                dtChucVu = new DataTable();
                dtChucVu.Clear();
                dtChucVu.Load(rdCV);

                (dgvDSNhanVien.Columns["ChucVu"] as DataGridViewComboBoxColumn).DataSource = dtChucVu;
                (dgvDSNhanVien.Columns["ChucVu"] as DataGridViewComboBoxColumn).DisplayMember = "TenChucVu";
                (dgvDSNhanVien.Columns["ChucVu"] as DataGridViewComboBoxColumn).ValueMember = "MaCV";
                //

                cmd.CommandText = "spLayDSPhongBan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                var rdPB = cmd.ExecuteReader();

                dtPhongBan = new DataTable();
                dtPhongBan.Clear();
                dtPhongBan.Load(rdPB);

                (dgvDSNhanVien.Columns["PhongBan"] as DataGridViewComboBoxColumn).DataSource = dtPhongBan;
                (dgvDSNhanVien.Columns["PhongBan"] as DataGridViewComboBoxColumn).DisplayMember = "TenPB";
                (dgvDSNhanVien.Columns["PhongBan"] as DataGridViewComboBoxColumn).ValueMember = "MaPB";

                dgvDSNhanVien.DataSource = dtNhanVien;

            }
            catch(SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu trong table NhanVien, Lỗi rồi!!!");
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
            //
            this.cbChucVu.DataSource = dtChucVu;
            this.cbChucVu.DisplayMember = "TenChucVu";
            this.cbChucVu.ValueMember = "MaCV";

            this.cbPhongBan.DataSource = dtPhongBan;
            this.cbPhongBan.DisplayMember = "TenPB";
            this.cbPhongBan.ValueMember = "MaPB";
            //Đưa con trỏ đến Mã nhân viên
            this.txbMaNV.Focus();
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
            txbHoTen.ResetText();
            txbGioiTinh.ResetText();
            txbLuong.ResetText();
            txbNgaySinh.ResetText();
            txbPassword.ResetText();
            txbQueQuan.ResetText();
            txbSDT.ResetText();
            cbChucVu.ResetText();
            cbPhongBan.ResetText();

            txbMaNV.Enabled = true;
            txbPassword.Enabled = true;

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
            this.cbChucVu.DataSource = dtChucVu;
            this.cbChucVu.DisplayMember = "TenChucVu";
            this.cbChucVu.ValueMember = "MaCV";

            this.cbPhongBan.DataSource = dtPhongBan;
            this.cbPhongBan.DisplayMember = "TenPB";
            this.cbPhongBan.ValueMember = "MaPB";
            //
            int r = dgvDSNhanVien.CurrentCell.RowIndex;
            
            txbMaNV.Text = dgvDSNhanVien.Rows[r].Cells[0].Value.ToString();
            txbHoTen.Text = dgvDSNhanVien.Rows[r].Cells[1].Value.ToString();
            txbGioiTinh.Text = dgvDSNhanVien.Rows[r].Cells[2].Value.ToString();
            txbNgaySinh.Text = dgvDSNhanVien.Rows[r].Cells[3].Value.ToString();
            txbQueQuan.Text = dgvDSNhanVien.Rows[r].Cells[4].Value.ToString();
            txbSDT.Text = dgvDSNhanVien.Rows[r].Cells[5].Value.ToString();
            cbChucVu.SelectedValue = dgvDSNhanVien.Rows[r].Cells[6].Value.ToString();
            cbPhongBan.SelectedValue = dgvDSNhanVien.Rows[r].Cells[7].Value.ToString();
            txbLuong.Text = dgvDSNhanVien.Rows[r].Cells[8].Value.ToString();
            txbPassword.Text = dgvDSNhanVien.Rows[r].Cells[9].Value.ToString();

            //
            txbMaNV.Enabled = false;
            txbPassword.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dgvDSNhanVien.CurrentCell.RowIndex;
            NHANVIEN nv = new NHANVIEN();
            int MaNV = Convert.ToInt32(dgvDSNhanVien.Rows[r].Cells[0].Value);
            DialogResult rs =  MessageBox.Show("Bạn có chắc muốn xóa nhân viên "+MaNV+" ?","Thông báo",
                    MessageBoxButtons.OKCancel
                , MessageBoxIcon.Question);
            if(rs == DialogResult.OK)
            {
                try
                {
                    nv.Delete(MaNV);
                    MessageBox.Show("Đã xóa thành công");
                    LoadData();

                }
                catch(Exception)
                {
                    MessageBox.Show("Không thể xóa nhân viên này được !!");
                }
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(them)
            {
                NHANVIEN nv = new NHANVIEN();
                string manv = txbMaNV.Text.ToString();
                string hoten = txbHoTen.Text.ToString();
                string gioitinh = txbGioiTinh.Text.ToString();
                string ngsinh = txbNgaySinh.Text.ToString();
                string quequan = txbQueQuan.Text.ToString();
                string sodt = txbSDT.Text.ToString();
                string chucvu = cbChucVu.SelectedValue.ToString().Trim();
                string phongban = cbPhongBan.SelectedValue.ToString().Trim();
                string luongcb = txbLuong.Text.ToString();
                string password = txbPassword.Text.ToString();
                try
                {
                    nv.Insert(manv, hoten, gioitinh, ngsinh, quequan, sodt, chucvu, phongban, luongcb, password);
                    MessageBox.Show("Đã thêm thành công");
                    ViewMode();
                    LoadData();

                }
                catch (Exception)
                {
                    MessageBox.Show("Không thực hiện được, Lỗi rồi!!!");
                }
            }
            if(!them)
            {
                NHANVIEN nv = new NHANVIEN();
                string manv = txbMaNV.Text.ToString();
                string hoten = txbHoTen.Text.ToString();
                string gioitinh = txbGioiTinh.Text.ToString();
                string ngsinh = txbNgaySinh.Text.ToString();
                string quequan = txbQueQuan.Text.ToString();
                string sodt = txbSDT.Text.ToString();
                string chucvu = cbChucVu.SelectedValue.ToString();
                string phongban = cbPhongBan.SelectedValue.ToString();
                string luongcb = txbLuong.Text.ToString();
                string password = txbPassword.Text.ToString();

                try
                {
                    nv.Update(manv, hoten, gioitinh, ngsinh, quequan, sodt, chucvu, phongban, luongcb, password);
                    MessageBox.Show("Đã cập nhật thành công");

                    ViewMode();
                    LoadData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thực hiện được, Lỗi rồi!!!");
                }
                txbMaNV.Enabled = true;

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
