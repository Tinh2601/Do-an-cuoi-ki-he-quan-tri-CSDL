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
    public partial class frmPasswordChange : Form
    {
        My_DB mydb = new My_DB();
        public frmPasswordChange()
        {
            InitializeComponent();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                mydb.openConnection();
                string password = txtNewPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;
                if(password !="")
                {
                    if (password == confirmPassword)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "spChangePassword";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = mydb.getConnection;
                        cmd.Parameters.Add("@NewPassword", SqlDbType.Char).Value = password;
                        cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = frmLogin.manv;

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đổi mật khẩu thành công!!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu nhập lại không trùng khớp!!");
                    }
                }    
                else
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu mới");
                }

            }
            catch(SqlException)
            {
                MessageBox.Show("Lỗi không đổi được mật khẩu");
            }
            mydb.closeConnection();
        }
    }
}
