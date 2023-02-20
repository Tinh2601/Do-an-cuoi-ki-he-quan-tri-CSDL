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
    public partial class frmSearch : Form
    {
        My_DB mydb = new My_DB();

        DataTable dtNhanVien = null;
        DataTable dtChucVu = null;
        DataTable dtPhongBan = null;
        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
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
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu trong table NhanVien, Lỗi rồi!!!");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void GetData()
        {
            mydb.openConnection();
            NHANVIEN nv = new NHANVIEN();
            string search = txtSearch.Text.ToString();
            SqlCommand cmd;

            if (rdbID.Checked)
            {
                cmd = new SqlCommand("select * from SearchNhanVien('" + search + "','MaNV')");
            }
            else if (rdbName.Checked)
            {
                cmd = new SqlCommand("SELECT * from SearchNhanVien('" + search + "','HoTen')");
            }
            else
            {
                cmd = new SqlCommand("SELECT * from SearchNhanVien('" + search + "','SoDT')");
            }
            //câu lệnh hiển thị dữ liệu ra datagridview
            cmd.Connection = mydb.getConnection;
            var rd = cmd.ExecuteReader();
            dtNhanVien.Clear();
            dtNhanVien.Load(rd);

            dgvDSNhanVien.DataSource = dtNhanVien;
            mydb.closeConnection();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
