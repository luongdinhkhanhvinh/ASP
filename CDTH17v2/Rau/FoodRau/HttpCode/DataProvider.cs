using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodRau.HttpCode
{
   
    public class DataProvider
    {
        private static SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Rau;Integrated Security=True");

        public static void connect()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
        }

        //Có Trả về 1 bảng -> Select
        public static DataTable getDataTable(string sQuery,SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter();
                cmd.Connection = conn;
                cmd.CommandText = sQuery;
                cmd.Parameters.AddRange(param);
                adapter.SelectCommand = cmd;
                
                adapter.Fill(dt);
                conn.Close();
            }
            catch (Exception)
            {
                return null;
            }
            return dt;
        }


        //Không Trả về-> INsert
        public static bool executeNonQuery(string sQuery, SqlParameter[] param)
        {
            int rowAffected = 0;
            try
            {
                connect();
                SqlCommand cmd = new SqlCommand(sQuery,conn);
                cmd.Parameters.AddRange(param);
                rowAffected=cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return (rowAffected > 0);
        }

        //có thể dùng insert vào và lấy id cuối cùng
        //có thể dùng cho select id cuối cùng
        //tăng tự động nên phải lấy id cuối
        public static int executeScalar(string sQuery, SqlParameter[] param)
        {
            int id = 0;
            try
            {
                connect();
                SqlCommand cmd = new SqlCommand(sQuery, conn);
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                string sQueryIdentity = "SELECT @@IDENTITY";
                SqlCommand cmdScalar = new SqlCommand(sQueryIdentity, conn);
                id = (int)cmdScalar.ExecuteScalar();
                conn.Close();
            }
            catch (Exception)
            {
                return 0;
            }
            return id;
        }

    }
}