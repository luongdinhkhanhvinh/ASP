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
    public partial class lst_food : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/Admin/login.aspx");
            }
        }

        [WebMethod]
        public static string searchCode(string key, string page)
        {
            Food f = new Food();
            List<Food> foods = f.getListFoodType();
            if (key != null && key.Length > 0)
            {
                foods = f.getListFoodType(key.Trim());
            }
            int limit = Convert.ToInt32(new Setting().getObjectAdmin().Value);
            int soTrang = foods.Count / limit + (foods.Count % limit == 0 ? 0 : 1);
            int trang = Convert.ToInt32(page);
            int from = (trang - 1) * limit;
            int to = (trang * limit) - 1;
            for (int i = foods.Count - 1; i >= 0; i--)
            {
                if (i < from || to < i)
                {
                    foods.RemoveAt(i);
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
            json.Add("obj", foods);
            json.Add("record", index);
            json.Add("active", active);
            return new JavaScriptSerializer().Serialize(json);
        }

        [WebMethod]
        public static bool setStatusdelete(string id)
        {
            Food f = new Food();
            f.Id = Convert.ToInt32(id);
            return f.delete();
        }
    }
}