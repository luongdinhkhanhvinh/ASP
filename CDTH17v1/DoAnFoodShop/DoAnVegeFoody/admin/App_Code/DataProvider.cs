using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DoAnVegeFoody.App_Code
{
    public static class DataProvider
    {
        private static string ChuoiKetNoi = @"Data Source=DESKTOP-77KDDKP;Initial Catalog =WEB_DB;Integrated Security = True";

        private static SqlConnection conn = new SqlConnection(ChuoiKetNoi);
        private static void Connect()
        {
            if(conn.State==ConnectionState.Closed ||conn.State==ConnectionState.Broken)
            {
                conn.Open();
            }
        }

        public static bool executeNonQuery(string sQuery, SqlParameter[] paras) //chung 1 vùng nhớ k cần new đối tượng, chỉ cần lấy tên class chấm trực tiếp tên phương thức
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sQuery, conn);
                cmd.Parameters.AddRange(paras);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public static int executeScalar(string sQuery,SqlParameter[] paras)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sQuery, conn);
                cmd.Parameters.AddRange(paras);
                cmd.ExecuteNonQuery();
                sQuery = "select @@identity";//
                cmd = new SqlCommand(sQuery, conn);
                int id = (int)cmd.ExecuteScalar();
                
                conn.Close();
                return id;

            }
            catch(Exception e)
            {
                return -1;
            }

        }
        
        public static DataTable getDataTable(string sQuery)
        {
            try
            {
                Connect();
                SqlDataAdapter da = new SqlDataAdapter(sQuery, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    
    }
}