using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoAnVegeFoody.App_Code;

namespace DoAnVegeFoody
{
    public partial class Login1 : System.Web.UI.Page
    {
        private static string ChuoiKetNoi = @"Data Source=DESKTOP-77KDDKP;Initial Catalog =WEB_DB;Integrated Security = True";
        private static SqlConnection conn = new SqlConnection(ChuoiKetNoi);
        private static void Connect()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public bool KiemTraDangNhap(string username, string password)
        {
            Connect();

            string sQuery = string.Format("Select username, pass from [dbo].[member] where [username] = '{0}' and [pass] = '{1}'", username, password);
            SqlCommand com = new SqlCommand(sQuery, conn);
            SqlDataReader dr = com.ExecuteReader();
            bool kq = dr.HasRows;
            dr.Close();
            conn.Close();
            return kq;
            
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            String Pass = StringProc.MD5Hash(Password.Text);
            if (KiemTraDangNhap(UserName.Text, Pass)){
                Session["LOGIN"] = UserName.Text;
                Response.Redirect("admin/Member.aspx");
            }
            else
            {
                txt_Message.Text = "Đăng nhập thất bại";
            }
        }
    }
}