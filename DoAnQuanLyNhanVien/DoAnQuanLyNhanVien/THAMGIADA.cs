using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyNhanVien
{
    class THAMGIADA
    {
        My_DB mydb = new My_DB();
        public void Insert(string mada, string manv, string ngaythamgia, string phucap)
        {
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spInsertThamGiaDA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = mada;
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = manv;
                cmd.Parameters.Add("@NgayThamGia", SqlDbType.Date).Value = ngaythamgia;
                cmd.Parameters.Add("@PhuCap", SqlDbType.Int).Value = phucap;

                cmd.ExecuteNonQuery();
                mydb.closeConnection();
            }
            catch (SqlException)
            {
                Exception e = new Exception("khong thuc hien duoc");
                throw e;
            }

        }
        public void Delete(string mada, int manv)
        {
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spDeleteThamGiaDA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = mada;
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = manv;
                cmd.ExecuteNonQuery();
                mydb.closeConnection();
            }
            catch (SqlException)
            {
                Exception e = new Exception("khong thuc hien duoc");
                throw e;
            }
            mydb.closeConnection();
        }
    }
}
