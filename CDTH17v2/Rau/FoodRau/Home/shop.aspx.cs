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
    public partial class shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //handle food
            Food food = new Food();
            List<Food> foods = new List<Food>();
            if (Request["type_id"] != null)
            {
                foods = food.getList(Convert.ToInt32(Request["type_id"]));
            }
            else
            {
                foods = food.getList();
            }

            //handle foodtype
            FoodType ft = new FoodType();
            List<FoodType> foodTypes = ft.getList();

            rptLoaiSP.DataSource = foodTypes;
            rptLoaiSP.DataBind();

            //handle phan trang
            int limit = Convert.ToInt32(new Setting().getObjectHome().Value);
            int soTrang = foods.Count / limit + (foods.Count % limit == 0 ? 0 : 1);
            int page = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
            int from = (page - 1) * limit;
            int to = (page * limit) -1 ;
            for (int i = foods.Count-1; i >= 0 ; i--)
            {
                if (i < from || to < i)
                {
                    foods.RemoveAt(i);
                }
            }


            rptSanPham.DataSource = foods;
            rptSanPham.DataBind();

            DataTable dtp = new DataTable();
            dtp.Columns.Add("index");
            dtp.Columns.Add("active");
            for (int i = 1; i <= soTrang; i++)
            {
                DataRow dr = dtp.NewRow();
                dr["index"] = i;
                if ((Request["page"] == null && i == 1) || (Request["page"] != "" && Convert.ToInt32(Request["page"]) == i))
                {
                    dr["active"] = 1;
                }
                else
                {
                    dr["active"] = 0;
                }
                dtp.Rows.Add(dr);
            }
            rptSoTrang.DataSource = dtp;
            rptSoTrang.DataBind();
        }


    }
}