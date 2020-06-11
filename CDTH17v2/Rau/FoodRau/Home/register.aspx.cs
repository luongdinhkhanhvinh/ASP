using FoodRau.HttpCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodRau.Home
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtRepass.Text = "";
       
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Customer obj = new Customer();
            if (!obj.exist(txtUserName.Text))
            {
                obj.Username = txtUserName.Text;
                obj.Name = txtName.Text;
                obj.Password = txtPassword.Text;
                obj.Email = txtEmail.Text;
                obj.Phone = txtPhone.Text;
                obj.Address = txtAddress.Text;
                obj.Status = 1;
                if (obj.add())
                {
                    lblMessage.Text = "Thêm Thành Công";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                    Btn_cancel_Click(sender, e);
                }
                else
                {
                    Response.Write("<script>alert('Thất Bại') </script>");
                }
            }
            else
            {
                lblMessage.Text = "Đã Tồn Tại";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
            }
        }
    }
}