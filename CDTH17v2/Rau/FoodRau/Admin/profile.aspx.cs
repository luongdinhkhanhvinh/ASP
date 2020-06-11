using FoodRau.HttpCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodRau.Admin
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    Member mb = new Member();
                    Member m = mb.getItem(Session["username"].ToString());
                    hfUserName.Value = m.UserName;
                    txtUserName.Text = m.UserName;
                    txtUserName.Enabled = false;
                    txtName.Text = m.Name;
                    txtEmail.Text = m.Email;
                    txtPhone.Text = m.Phone;
                    ddlStatus.SelectedValue = m.Status.ToString();
                    ddlStatus.Enabled = false;
                    ddlRole.SelectedValue = m.Role.ToString();
                    ddlRole.Enabled = false;
                   
                }
            }
        }

        protected void Btn_update_Click(object sender, EventArgs e)
        {
            Member member = new Member();
            member.UserName = hfUserName.Value;
            member.Name = txtName.Text;
            member.Pass = txtPassword.Text;
            member.Email = txtEmail.Text;
            member.Phone = txtPhone.Text;
            member.Role = Convert.ToInt32(ddlRole.SelectedValue);
            member.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            if (member.update())
            {
                lblMessage.Text = "Cập Nhật Thành Công";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
            }
            else
            {
                Response.Write("<script>alert('Thất Bại') </script>");
            }
        }
    }
}