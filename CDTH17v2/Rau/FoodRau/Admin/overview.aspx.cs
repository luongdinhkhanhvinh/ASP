using FoodRau.HttpCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodRau.Admin
{
    public partial class overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Session["username"] == null || !Convert.ToBoolean(Session["role"]))
                {
                    Response.Redirect("~/Admin/login.aspx");
                }
                List<Setting> objs = new Setting().getList();
                if (objs.Count >0)
                {
                    rptDS.DataSource = objs;
                    rptDS.DataBind();
                }
            }
        }


        protected void rptDS_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="s")
            {
                int id_setting = Convert.ToInt32(e.CommandArgument);
                TextBox txtValue = (TextBox)e.Item.FindControl("txtRecord");
                Setting s = new Setting();
                s.IdSetting = id_setting;
                s.Value = txtValue.Text;
                s.Username = Session["username"].ToString();
                if (s.update())
                {
                    lblMessage.Text = "Cập Nhật Thành Công";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                }
                else
                {
                    lblMessage.Text = "Cập Nhật Thất Bại";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                }
            }
        }
    }
}