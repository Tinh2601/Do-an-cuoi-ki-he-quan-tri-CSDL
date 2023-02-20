using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyNhanVien
{
    class DUAN
    {
        My_DB mydb = new My_DB();
        public void Insert(string mada, string tenda, string ngaybd, string ngaykt,
                    string doanhthu, string tinhtrang, string mapb)
        {
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spInsertDuAn";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = mada;
                cmd.Parameters.Add("@TenDA", SqlDbType.VarChar).Value = tenda;
                cmd.Parameters.Add("@NgayBD", SqlDbType.Date).Value = ngaybd;
                cmd.Parameters.Add("@NgayKT", SqlDbType.Date).Value = ngaykt;
                cmd.Parameters.Add("@DoanhThu", SqlDbType.Int).Value = doanhthu;
                cmd.Parameters.Add("@TinhTrang", SqlDbType.VarChar).Value = tinhtrang;
                cmd.Parameters.Add("@MaPB", SqlDbType.Char).Value = mapb;

                cmd.ExecuteNonQuery();
                mydb.closeConnection();
            }
            catch (SqlException)
            {
                Exception e = new Exception("khong thuc hien duoc");
                throw e;
            }

        }
        public void Update(string mada, string tenda, string ngaybd, string ngaykt,
                    string doanhthu, string tinhtrang, string mapb)
        {
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spUpdateDuAn";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = mada;
                cmd.Parameters.Add("@TenDA", SqlDbType.VarChar).Value = tenda;
                cmd.Parameters.Add("@NgayBD", SqlDbType.Date).Value = ngaybd;
                cmd.Parameters.Add("@NgayKT", SqlDbType.Date).Value = ngaykt;
                cmd.Parameters.Add("@DoanhThu", SqlDbType.Int).Value = doanhthu;
                cmd.Parameters.Add("@TinhTrang", SqlDbType.VarChar).Value = tinhtrang;
                cmd.Parameters.Add("@MaPB", SqlDbType.Char).Value = mapb;

                cmd.ExecuteNonQuery();
                mydb.closeConnection();
            }
            catch (SqlException)
            {
                Exception e = new Exception("khong thuc hien duoc");
                throw e;
            }

        }
        public void Delete(string MaDA)
        {
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spDeleteDuAn";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = MaDA;



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
