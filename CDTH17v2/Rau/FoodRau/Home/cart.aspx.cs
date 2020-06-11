using FoodRau.HttpCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodRau.Home
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                rptCart.DataSource = Session["cart"];
                rptCart.DataBind();
            }
        }

        protected void BtnCheckOut_Click(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["cart"];
                Order o = new Order();
                o.CusName = "";

            }
        }

    }
}