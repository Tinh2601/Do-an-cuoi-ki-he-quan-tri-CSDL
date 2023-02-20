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
    public partial class frmLogin : Form
    {
        public static string quyen = "";
        public static string manv;
        DataTable dtAccount = null;
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string maNV = txbID.Text;
            string password = txbPassword.Text;
            manv = maNV;
            My_DB mydb = new My_DB();
            mydb.openConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spAccountCheck";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = mydb.getConnection;
            cmd.Parameters.Add("@maNV", SqlDbType.Char).Value = maNV;
            cmd.Parameters.Add("@pass", SqlDbType.Char).Value = password;

            try
            {
                var rd = cmd.ExecuteReader();
                dtAccount = new DataTable();
                dtAccount.Clear();
                dtAccount.Load(rd);
                if (dtAccount.Rows.Count > 0)
                {
                    //
                    foreach (DataRow r in dtAccount.Rows)
                    {
                        quyen = r["Quyen"].ToString().Trim();
                        manv = r["MaNV"].ToString().Trim();
                    }

                    MessageBox.Show("Đăng nhập thành công");
                    FormMain fmain = new FormMain();
                    this.Hide();
                    fmain.Show();
                }
                else
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!!");
            }
            mydb.closeConnection();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
