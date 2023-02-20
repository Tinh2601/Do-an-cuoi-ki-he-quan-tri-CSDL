using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyNhanVien
{
    class PHONGBAN
    {
        public void Insert(string mapb, string tenpb, string diachi, string truongphong)
        {
            My_DB mydb = new My_DB();
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spInsertPhongBan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaCV", SqlDbType.Char).Value = mapb;
                cmd.Parameters.Add("@TenPB", SqlDbType.VarChar).Value = tenpb;
                cmd.Parameters.Add("@DiaChi", SqlDbType.VarChar).Value = diachi;
                cmd.Parameters.Add("@TrPhong", SqlDbType.Int).Value = truongphong;



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
        public void Update(string mapb, string tenpb, string diachi, string truongphong)
        {
            My_DB mydb = new My_DB();
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spUpdatePhongBan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaCV", SqlDbType.Char).Value = mapb;
                cmd.Parameters.Add("@TenPB", SqlDbType.VarChar).Value = tenpb;
                cmd.Parameters.Add("@DiaChi", SqlDbType.VarChar).Value = diachi;
                cmd.Parameters.Add("@TrPhong", SqlDbType.Int).Value = truongphong;



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
        public void Delete(string mapb)
        {
            My_DB mydb = new My_DB();
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spDeletePhongBan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaPB", SqlDbType.Char).Value = mapb;



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
