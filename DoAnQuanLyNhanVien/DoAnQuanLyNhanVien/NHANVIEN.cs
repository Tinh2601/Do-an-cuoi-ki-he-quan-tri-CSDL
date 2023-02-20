using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyNhanVien
{
    class NHANVIEN
    {
        My_DB mydb = new My_DB();

        public void Insert(string manv, string hoten, string gioitinh, string ngaysinh,
            string quequan, string sodt, string chucvu, string phongban, string luongcb, string password)
        {
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spInsertNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;
                
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = manv;
                cmd.Parameters.Add("@HoTen", SqlDbType.VarChar).Value = hoten;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.VarChar).Value = gioitinh;
                cmd.Parameters.Add("@NgSinh", SqlDbType.Date).Value = ngaysinh;
                cmd.Parameters.Add("@QueQuan", SqlDbType.VarChar).Value = quequan;
                cmd.Parameters.Add("@SoDT", SqlDbType.Char).Value = sodt;
                cmd.Parameters.Add("@MaCV", SqlDbType.Char).Value = chucvu;
                cmd.Parameters.Add("@MaPB", SqlDbType.Char).Value = phongban;
                cmd.Parameters.Add("@LuongCB", SqlDbType.Int).Value = luongcb;
                cmd.Parameters.Add("@Password", SqlDbType.Char).Value = password;

                cmd.ExecuteNonQuery();
                mydb.closeConnection();
            }
            catch (SqlException)
            {
                Exception e = new Exception("khong thuc hien duoc");
                throw e;
            }

        }
        public void Update(string manv, string hoten, string gioitinh, string ngaysinh,
            string quequan, string sodt, string chucvu, string phongban, string luongcb, string password)
        {
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spUpdateNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = manv;
                cmd.Parameters.Add("@HoTen", SqlDbType.VarChar).Value = hoten;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.VarChar).Value = gioitinh;
                cmd.Parameters.Add("@NgSinh", SqlDbType.Date).Value = ngaysinh;
                cmd.Parameters.Add("@QueQuan", SqlDbType.VarChar).Value = quequan;
                cmd.Parameters.Add("@SoDT", SqlDbType.Char).Value = sodt;
                cmd.Parameters.Add("@MaCV", SqlDbType.Char).Value = chucvu;
                cmd.Parameters.Add("@MaPB", SqlDbType.Char).Value = phongban;
                cmd.Parameters.Add("@LuongCB", SqlDbType.Int).Value = luongcb;
                cmd.Parameters.Add("@Password", SqlDbType.Char).Value = password;

                cmd.ExecuteNonQuery();
                mydb.closeConnection();
            }
            catch (SqlException)
            {
                Exception e = new Exception("khong thuc hien duoc");
                throw e;
            }

        }
        public void Delete(int MaNV)
        {
            mydb.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spDeleteNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = MaNV;



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
