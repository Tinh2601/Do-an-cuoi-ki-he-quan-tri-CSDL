using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyNhanVien
{
    internal class CHAMCONG
    {
        public void Insert(string manv, string thang, string nam, string songaydilam)
        {
            My_DB mydb = new My_DB();
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spInsertChamCong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = manv;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = nam;
                cmd.Parameters.Add("@SoNgayDiLam", SqlDbType.Int).Value = songaydilam;



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
        public void Update(string manv, string thang, string nam, string songaydilam)
        {
            My_DB mydb = new My_DB();
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spUpdateChamCong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = manv;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = nam;
                cmd.Parameters.Add("@SoNgayDiLam", SqlDbType.Int).Value = songaydilam;



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
        public void Delete(string manv, string thang, string nam)
        {
            My_DB mydb = new My_DB();
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spDeleteChamCong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = manv;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = nam;



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
