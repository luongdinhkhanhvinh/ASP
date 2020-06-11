using FoodRau.HttpCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodRau.Admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Member obj = new Member();
            string us = txtUserName.Text;
            string pw = txtPassword.Text;
            obj.UserName = us;
            if (obj.exist(us))
            {
                Member mb = obj.getItem(us);
                if (mb.Pass == StringProc.MD5Hash(pw))
                {
                    if (mb.Role == 1)
                    {
                        Session["role"] = true;
                    }
                    else
                    {
                        Session["role"] = false;
                    }
                    Session["username"] = us;
                    Response.Redirect("~");
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