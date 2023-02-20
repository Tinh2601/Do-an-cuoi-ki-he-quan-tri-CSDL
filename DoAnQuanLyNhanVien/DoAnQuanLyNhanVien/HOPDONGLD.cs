using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyNhanVien
{
    internal class HOPDONGLD
    {
        public void Insert(string mahd, string loaihd, string ngaybd, string manv)
        {
            My_DB mydb = new My_DB();
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spInsertHopDong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaHD", SqlDbType.Char).Value = mahd;
                cmd.Parameters.Add("@LoaiHD", SqlDbType.VarChar).Value = loaihd;
                cmd.Parameters.Add("@NgayBD", SqlDbType.Date).Value = ngaybd;
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = manv;
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
        public void Update(string mahd, string loaihd, string ngaybd, string manv)
        {
            My_DB mydb = new My_DB();
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spUpdateHopDong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaHD", SqlDbType.Char).Value = mahd;
                cmd.Parameters.Add("@LoaiHD", SqlDbType.VarChar).Value = loaihd;
                cmd.Parameters.Add("@NgayBD", SqlDbType.Date).Value = ngaybd;
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = manv;
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
        public void Delete(string manv)
        {
            My_DB mydb = new My_DB();
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spDeleteHopDong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = manv;

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
