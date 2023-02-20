using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyNhanVien
{
    internal class CHUCVU
    {
        public void Insert(string macv, string tenchucvu, string phucapcv)
        {
            My_DB mydb = new My_DB();
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spInsertChucVu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaCV", SqlDbType.Char).Value = macv;
                cmd.Parameters.Add("@TenChucVu", SqlDbType.NVarChar).Value = tenchucvu;
                cmd.Parameters.Add("@PhuCapCV", SqlDbType.Int).Value = phucapcv;


                cmd.ExecuteNonQuery();
                mydb.closeConnection();
            }
            catch (SqlException)
            {
                Exception e = new Exception("khong thuc hien duoc");
                throw e;
            }
            // dóng chuỗi kết nối
            finally
            {
                mydb.closeConnection();
            }
        }
        public void Update(string macv, string tenchucvu, string phucapcv)
        {
            My_DB mydb = new My_DB();
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spUpdateChucvu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaCV", SqlDbType.Char).Value = macv;
                cmd.Parameters.Add("@TenChucVu", SqlDbType.NVarChar).Value = tenchucvu;
                cmd.Parameters.Add("@PhuCapCV", SqlDbType.Int).Value = phucapcv;


                cmd.ExecuteNonQuery();
                mydb.closeConnection();
            }
            catch (SqlException)
            {
                Exception e = new Exception("khong thuc hien duoc");
                throw e;
            }
            // dóng chuỗi kết nối
            finally
            {
                mydb.closeConnection();
            }
        }
        public void Delete(string macv)
        {
            My_DB mydb = new My_DB();
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spDeleteChucvu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaCV", SqlDbType.Char).Value = macv;



                cmd.ExecuteNonQuery();
                mydb.closeConnection();
            }
            catch (SqlException)
            {
                Exception e = new Exception("khong thuc hien duoc");
                throw e;
            }
            // dóng chuỗi kết nối
            finally
            {
                mydb.closeConnection();
            }
        }
    }
}
