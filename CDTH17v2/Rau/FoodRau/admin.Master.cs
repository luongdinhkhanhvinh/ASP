using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodRau
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //nếu gán rồi
            
            if (Session["username"] ==null)
            {
                Response.Redirect("~/Admin/login.aspx");
            }
            else
            {
                lblModal_title.Text = "Bạn có muốn thoát?";
                lblModal_body.Text = "Nhấn vào \' Logout \' để thoát ?";
                lblUserName.Text = Session["username"].ToString();
                CheckVisible(Convert.ToBoolean(Session["role"]));
            }
        }

        private void CheckVisible(bool check)
        {
            hlMember.Visible =check;
            hlSetting.Visible = check;
            hlSettingNav.Visible = check;
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                //xóa username
                Session.Remove("username");
                //mấy thằng khác xóa luôn
                Session.RemoveAll();
                Response.Redirect("~/Admin/login.aspx");
            }
        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/login.aspx");
        }

    }
}