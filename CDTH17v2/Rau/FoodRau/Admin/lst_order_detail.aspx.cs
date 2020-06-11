using FoodRau.HttpCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodRau.Admin
{
    public partial class lst_order_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/Admin/login.aspx");
            }
        }

        [WebMethod]
        public static string searchCode(string key)
        {
            OrderDetail o = new OrderDetail();
            List<OrderDetail> orderDetails = o.getList(Convert.ToInt32(key));
            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("obj", orderDetails);
            return new JavaScriptSerializer().Serialize(json);
        }
    }
}