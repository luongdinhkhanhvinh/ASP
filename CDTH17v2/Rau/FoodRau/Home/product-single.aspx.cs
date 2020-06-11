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
    public partial class product_single : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request["id"] != null)
            {
                Food food = new Food();
                Food f = food.getItem(Convert.ToInt32(Request["id"]));
                hf_ID.Value = f.Id.ToString();
                hf_Img.Value = f.Img.ToString();
                lblName.Text = f.Name.ToString();
                lblPoint.Text = (f.Point * 10).ToString();
                lblRating.Text = f.Rating.ToString();
                lblSold.Text = f.Sold.ToString();
                lblPrice.Text = f.Price.ToString();
                lblPrice_promo.Text = f.Price_promo.ToString();
                lblDescription.Text = f.Description.ToString();
                lblUnit.Text = f.Unit.ToString();
                imgReview.ImageUrl = "../Uploads/images/" + f.Img;
                hlZoom.NavigateUrl = "../Uploads/images/" + f.Img;

                List<Food> fLates = f.getList(f.Type);
                //trường hợp lớn hơn 4 item thì remove các item còn lại
                for (int i = 0; i < fLates.Count; i++)
                {
                    if (i == 0 || i >= 4)
                    {
                        fLates.RemoveAt(i);
                    }
                }
                rptRelated.DataSource = fLates;
                rptRelated.DataBind();
            }
            else
            {
                Response.Redirect("shop.aspx");
            }
        }

        protected void BtnAddToCart_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (Session["cart"] == null)
            {
                dt.Columns.Add("ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Description");
                dt.Columns.Add("Price");
                dt.Columns.Add("Img");
                dt.Columns.Add("Quan");
                dt.Columns.Add("Unit");
            }
            else
            {
                dt = (DataTable)Session["cart"];
            }
            int iRow = checkExist(dt,Convert.ToInt32(Request["id"]));
            if (iRow != -1)
            {
                dt.Rows[iRow]["Quan"] = Convert.ToInt32(dt.Rows[iRow]["Quan"]) + 1;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = hf_ID.Value;
                dr["Name"] = lblName.Text;
                dr["Description"] = lblDescription.Text;
                dr["Price"] = lblPrice.Text;
                dr["Img"] = hf_Img.Value;
                dr["Quan"] = quantity.Text;
                dr["Unit"] = ddlUnit.SelectedItem;
                dt.Rows.Add(dr);
            }
            
            Session["cart"] = dt;
            Response.Redirect("cart.aspx");
        }
        
        private int checkExist(DataTable dt,int id)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["ID"]) == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}