using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnVegeFoody.user
{
    public partial class Cart : System.Web.UI.Page
    {
         DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                dt = (DataTable)Session["cart"];
                Repeater_Cart.DataSource = dt;
                Repeater_Cart.DataBind();
            }
        }

        protected void btn_remove_Click(object sender, EventArgs e)
        {
        }

        protected void Repeater_Cart_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Equals("remove"))
            {
                HiddenField hf_id = (HiddenField)e.Item.FindControl("id");
                int id = Convert.ToInt32(hf_id.Value);
               
                DataRow[] advRow = dt.Select("id= "+ id);
                dt.Rows.Remove(advRow[0]);
                Repeater_Cart.DataSource = dt;
                Repeater_Cart.DataBind();
            }
            else if(e.CommandName.ToLower().Equals("checkout")){
                Session["order"] = dt;
                Response.Redirect("Checkout.asxp");
            }
        }

        protected void btn_checkout_Click(object sender, EventArgs e)
        {

        }
    }
}