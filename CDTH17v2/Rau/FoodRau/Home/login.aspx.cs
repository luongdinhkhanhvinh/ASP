using FoodRau.HttpCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodRau.Home
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username_home"] != null)
            {
                Response.Redirect("~/Home/index.aspx");
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Customer obj = new Customer();
            string us = txtUserName.Text;
            string pw = txtPassword.Text;
            obj.Username = us;
            if (obj.exist(us))
            {
                Customer c = obj.getItem(us);
                if (c.Password == StringProc.MD5Hash(pw))
                {
                    Session["username_home"] = us;
                    Response.Redirect("~/Home/index.aspx");
                }
                else
                {
                    lblMessage.Text = "Mật Khẩu Sai";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                }
            }
            else
            {
                lblMessage.Text = "Tài Khoản Không tồn Tại";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
            }
        }
    }
}