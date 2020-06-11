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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Slider s = new Slider();
                rptSlider.DataSource = s.getList();
                rptSlider.DataBind();

                Food f = new Food();
                List<Food> fs = f.getList();
                //trường hợp lớn hơn 4 item thì remove các item còn lại
                for (int i = fs.Count-1; i >= 8; i--)
                {
                    fs.RemoveAt(i);

                }
                rptSanPham.DataSource = fs;
                rptSanPham.DataBind();
            }

        }
    }
}