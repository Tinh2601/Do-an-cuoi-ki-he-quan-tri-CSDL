using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyNhanVien
{
    class My_DB
    {
        //static string manv = frmLogin.manv.ToString().Trim();
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=QuanLyNhanVien;Integrated Security=True");
        
        // get the connection : láy kết nối 
        public SqlConnection getConnection
        {
            get
            {
                return con;
            }
        }
        // open the connection : mo ket noi 
        public void openConnection()
        {
            if ((con.State == ConnectionState.Closed))// con,state để cho biết trạng thái 
            {
                con.Open();
            }
        }

        // close the connection: đóng kết nối (đóng lại để giải phóng tài nguyên )
        public void closeConnection()
        {
            if ((con.State == ConnectionState.Open))
            {
                con.Close();
            }
        }
    }
}
