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
    public partial class frmThongTinCaNhan : Form
    {
        My_DB mydb = new My_DB();
        DataTable dtNhanVien = null;
        DataTable dtThamGiaDA = null;
        DataTable dtHopDong = null;
        public frmThongTinCaNhan()
        {
            InitializeComponent();
        }
        void LoadNhanVien()
        {
            btnLuu.Visible = false;
            btnHuy.Visible = false;btnChinhSua.Enabled = false;
            btnChinhSua.Enabled = true;

            txbMaNV.Enabled = false;
            txbHoTen.Enabled = false;
            txbGioiTinh.Enabled = false;
            txbNgaySinh.Enabled = false;
            txbQueQuan.Enabled = false;
            txbSoDT.Enabled = false;
            txbChucVu.Enabled = false;
            txbPhongBan.Enabled = false;
            try
            {
                mydb.openConnection();
                SqlCommand cmd = new SqlCommand();
                string maNV = frmLogin.manv;
                cmd.CommandText = "spLayDSNhanVien";
                cmd.Connection = mydb.getConnection;

                var rd = cmd.ExecuteReader();
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                dtNhanVien.Load(rd);

                foreach(DataRow r in dtNhanVien.Rows)
                {
                    if(r["MaNV"].ToString() == maNV)
                    {
                        txbMaNV.Text = r["MaNV"].ToString();
                        txbHoTen.Text = r["HoTen"].ToString();
                        txbGioiTinh.Text = r["GioiTinh"].ToString();
                        txbNgaySinh.Text = r["NgaySinh"].ToString();
                        txbQueQuan.Text = r["QueQuan"].ToString();
                        txbSoDT.Text = r["SoDT"].ToString();
                        txbChucVu.Text = r["MaCV"].ToString();
                        txbPhongBan.Text = r["MaPB"].ToString();
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được thông tin nhân viên!!!");
            }
        }
        void LoadHopDong()
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
                foreach (DataRow r in dtHopDong.Rows)
                {
                    if (r["MaNV"].ToString() == frmLogin.manv)
                    {
                        txbMaHD.Text = r["MaHD"].ToString();
                        txbLoaiHD.Text = r["LoaiHD"].ToString();
                        txbNgayBD.Text = r["NgayBD"].ToString();
                    }
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("Không lấy được thông tin hợp đồng!!");
            }
            mydb.closeConnection();
        }
        void LoadDuAnThamGia()
        {
            try
            {
                mydb.openConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spLayDSThamGiaDA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = frmLogin.manv;

                var rd = cmd.ExecuteReader();
                dtThamGiaDA = new DataTable();
                dtThamGiaDA.Clear();
                dtThamGiaDA.Load(rd);

                cbMaDA.DataSource = dtThamGiaDA;
                cbMaDA.DisplayMember = "MaDA";
                foreach(DataRow r in dtThamGiaDA.Rows)
                {
                    if(r["MaDA"].ToString() == cbMaDA.Text)
                    txbTenDA.Text = r["TenDA"].ToString();
                    txbNgayThamGia.Text = r["NgayThamGia"].ToString();
                    txbPhuCap.Text = r["PhuCap"].ToString();
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("Không lấy được thông tin tham gia dự án, Lỗi rồi");
            }
            mydb.closeConnection();

        }
        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadDuAnThamGia();
            LoadHopDong();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            txbNgaySinh.Enabled = true;
            txbQueQuan.Enabled = true;
            txbSoDT.Enabled = true;
            txbNgaySinh.Focus();

            btnChinhSua.Enabled = false;
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            panel2.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                mydb.openConnection();
                string manv = txbMaNV.Text.ToString();

                string ngsinh = txbNgaySinh.Text.ToString();
                string quequan = txbQueQuan.Text.ToString();
                string sodt = txbSoDT.Text.ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Update NhanVien set NgaySinh = '" +
                    "" + ngsinh + "', QueQuan='" + quequan + "', SoDT ='" + sodt + "' where MaNV=" + manv;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = mydb.getConnection;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thông tin cá nhân thành công!");
                LoadNhanVien();
            }
            catch(SqlException)
            {
                MessageBox.Show("Có lỗi rồi!");
                LoadNhanVien();
            }
            panel2.Enabled = true;

            mydb.closeConnection();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
            panel2.Enabled = true;
            panel3.Enabled = true;
        }

        private void cbMaDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow r in dtThamGiaDA.Rows)
            {
                if (r["MaDA"].ToString() == cbMaDA.Text)
                txbTenDA.Text = r["TenDA"].ToString();
                txbNgayThamGia.Text = r["NgayThamGia"].ToString();
                txbPhuCap.Text = r["PhuCap"].ToString();
            }
        }
    }
}
