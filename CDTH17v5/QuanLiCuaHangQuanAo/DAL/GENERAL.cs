using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class GENERAL
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=QuanLiCuaHangQuanAo;Integrated Security=True");
        //public DataTable dt = new DataTable();
        public SqlConnection getConnect()
        {
            if (ConnectionState.Closed == conn.State)
            {
                conn.Open();
            }
            return conn;
        }

        public void getDisconnect()
        {
            conn.Close();
        }

        
    }
}
