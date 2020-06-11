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
    public partial class lst_customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/Admin/login.aspx");
            }
        }

        [WebMethod(EnableSession=true)]
        
        public static string searchCode(string key, string page)
        {
            Customer c = new Customer();
            List<Customer> customers = c.getList();
            if (key != null && key.Length > 0)
            {
                customers = c.getList(key);
            }
            int limit =Convert.ToInt32(new Setting().getObjectAdmin().Value);
            int soTrang = customers.Count / limit + (customers.Count % limit == 0 ? 0 : 1);
            int trang = Convert.ToInt32(page);
            int from = (trang - 1) * limit;
            int to = (trang * limit) - 1;
            for (int i = customers.Count - 1; i >= 0; i--)
            {
                if (i < from || to < i)
                {
                    customers.RemoveAt(i);
                }
            }
            int[] index = new int[soTrang];
            int[] active = new int[soTrang];

            for (int i = 0; i < soTrang; i++)
            {
                index[i] = i;
                if (i + 1 == trang)
                {
                    active[i] = 1;
                }
                else
                {
                    active[i] = 0;
                }
            }
            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("obj", customers);
            json.Add("record", index);
            json.Add("active", active);
            return new JavaScriptSerializer().Serialize(json);
        }

        [WebMethod]
        public static bool setStatusdelete(string username)
        {
            Customer c = new Customer();
            c.Username = username;
            return c.delete();
        }
    }
}