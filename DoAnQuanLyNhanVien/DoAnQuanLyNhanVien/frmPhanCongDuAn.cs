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
    public partial class frmPhanCongDuAn : Form
    {
        My_DB mydb = new My_DB();
        DataTable dtDuAn = null;
        DataTable dtThamGiaDA = null;
        DataTable dtRestNhanVien = null;
        bool them = false;
        public frmPhanCongDuAn()
        {
            InitializeComponent();
        }

        private void frmPhanCongDuAn_Load(object sender, EventArgs e)
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

            cbMaDA.DataSource = dtDuAn;
            cbMaDA.DisplayMember = "MaDA";
            foreach (DataRow r in dtDuAn.Rows)
            {
                string str = r["MaDA"].ToString();
                if (str.CompareTo(cbMaDA.Text.ToString()) == 0)
                {
                    txbTenDA.Text = r["TenDA"].ToString();
                }
            }
        }
        void LoadData()
        {
            try
            {
                mydb.openConnection();
                SqlCommand cmd = new SqlCommand();
                string mada = cbMaDA.Text.ToString();

                cmd.CommandText = "spDSNhanVienCuaDA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = mada;

                var rd1 = cmd.ExecuteReader();

                dtThamGiaDA = new DataTable();
                dtThamGiaDA.Clear();
                dtThamGiaDA.Load(rd1);
                dgvNhanVienDuAn.DataSource = dtThamGiaDA;

                cmd = new SqlCommand();
                cmd.CommandText = "spDSNhanVienKhongCoTrongDuAn";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = mada;

                var rd2 = cmd.ExecuteReader();

                dtRestNhanVien = new DataTable();
                dtRestNhanVien.Clear();
                dtRestNhanVien.Load(rd2);
                dgvRestNhanVien.DataSource = dtRestNhanVien;
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi rồi!!");
            }
        }
        private void cbMaDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string mada = cbMaDA.Text.ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spDSNhanVienCuaDA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = mada;

                var rd = cmd.ExecuteReader();

                dtThamGiaDA = new DataTable();
                dtThamGiaDA.Clear();
                dtThamGiaDA.Load(rd);

                dgvNhanVienDuAn.DataSource = dtThamGiaDA;


                //Load du lieu len datagridview restNhanVien
                cmd = new SqlCommand();
                cmd.CommandText = "spDSNhanVienKhongCoTrongDuAn";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = mada;

                var rd1 = cmd.ExecuteReader();

                dtRestNhanVien = new DataTable();
                dtRestNhanVien.Clear();
                dtRestNhanVien.Load(rd1);
                dgvRestNhanVien.DataSource = dtRestNhanVien;

                foreach (DataRow r in dtDuAn.Rows)
                {
                    string str = r["MaDA"].ToString();
                    if (str.CompareTo(cbMaDA.Text.ToString()) == 0)
                    {
                        txbTenDA.Text = r["TenDA"].ToString();
                    }
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("Lỗi rồi!!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            dgvRestNhanVien.Enabled = true;
            dgvNhanVienDuAn.Enabled = false;
      
            btnXoa.Enabled = false;
            btnChon.Enabled = true;
            btnHuy.Enabled = true;
            txbPhuCap.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            them = false;
            dgvRestNhanVien.Enabled = false;
            dgvNhanVienDuAn.Enabled = true;

            btnThem.Enabled = false;
            btnChon.Enabled = true;
            btnHuy.Enabled = true;

        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if(them)
            {
                int r = dgvRestNhanVien.CurrentCell.RowIndex;
                THAMGIADA tgda = new THAMGIADA();
                string mada = cbMaDA.Text;
                string manv = dgvRestNhanVien.Rows[r].Cells[0].Value.ToString();
                string ngaythamgia = DateTime.Today.ToShortDateString();
                string phucap = txbPhuCap.Text;
                DialogResult rs = MessageBox.Show("Bạn có chắc muốn thêm nhân viên này vào dự án?", "Thông báo",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                
                if (rs == DialogResult.OK)
                {
                    tgda.Insert(mada, manv, ngaythamgia, phucap);
                    ViewMode();
                    LoadData();
                }

                
            }
            else
            {
                int r = dgvNhanVienDuAn.CurrentCell.RowIndex;

                THAMGIADA tgda = new THAMGIADA();
                string mada = cbMaDA.Text;
                int manv = Convert.ToInt32(dgvNhanVienDuAn.Rows[r].Cells[0].Value);
                DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    tgda.Delete(mada, manv);
                    ViewMode();
                    LoadData();

                }
            }
        }
        void ViewMode()
        {
            btnChon.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnChon.Enabled = false;
            btnHuy.Enabled = false;
            dgvRestNhanVien.Enabled = true;
            dgvNhanVienDuAn.Enabled = true;
            txbPhuCap.Enabled = false;

        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ViewMode();
        }
    }
}
