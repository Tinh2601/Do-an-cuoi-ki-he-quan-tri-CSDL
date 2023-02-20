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
    public partial class frmQuanLyTaiKhoan : Form
    {
        My_DB mydb = new My_DB();

        DataTable dtQLTK = null;
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            ViewMode();

            LoadData();
        }
        public void ViewMode()
        {
            panel1.Enabled = false;
            this.btnHuy.Enabled = false;
            this.btnLuu.Enabled = false;
            this.btnChinhSua.Enabled = true;
            txbManv.ResetText();
            txbpass.ResetText();
        }
        public void LoadData()
        {
            try
            {
                mydb.openConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spLayDSTaiKhoan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                var rd = cmd.ExecuteReader();

                dtQLTK = new DataTable();
                dtQLTK.Clear();
                dtQLTK.Load(rd);


                dgvQLTK.DataSource = dtQLTK;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu trong table quan ly tai khoan, lỗi rồi huhu!!!");
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ViewMode();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            //Cho phép hiệu chỉnh nút Lưu và Hủy
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            //
            this.txbpass.Enabled = true;

            //this.rbQuanLy.Enabled = true;
            //this.rbNhanVien.Enabled = true;
            int r = dgvQLTK.CurrentCell.RowIndex;

            txbManv.Text = dgvQLTK.Rows[r].Cells[0].Value.ToString();
            txbpass.Text = dgvQLTK.Rows[r].Cells[1].Value.ToString();

            if(dgvQLTK.Rows[r].Cells[2].Value.ToString() == "0")
            {
                rbNhanVien.Checked = true;
            }
            else if(dgvQLTK.Rows[r].Cells[2].Value.ToString() == "1")
            {
                rbQuanLy.Checked = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                mydb.openConnection();
                string manv = txbManv.Text.ToString();
                string dmk = txbpass.Text.ToString();
                string quyen = "";
                if (rbQuanLy.Checked)
                {
                    quyen = "1";
                }
                else if (rbNhanVien.Checked)
                {
                    quyen = "0";
                }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spUpdateTaiKhoan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = manv;
                cmd.Parameters.Add("@Pass", SqlDbType.Char).Value = dmk;
                cmd.Parameters.Add("@Quyen", SqlDbType.Char).Value = quyen;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Chỉnh sửa thành công!");
                LoadData();
                ViewMode();
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi rồi!!!");
            }
            mydb.closeConnection();
        }
    }
}
