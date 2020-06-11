using FoodRau.HttpCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodRau.Home
{
    public partial class blog_single : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request["post_id"] !=null)
            {
                Post p= new Post().getItem(Convert.ToInt32(Request["post_id"]));
                lblTitle.Text = p.Title;
                lblDes.Text = p.Des;
                imgReview.ImageUrl = "../Uploads/images/" + p.Img;

                //category
                rptLSP.DataSource = new Post().getListCount();
                rptLSP.DataBind();

                //recent blog
                rptRecentBlog.DataSource = p.getListDescCreate();
                rptRecentBlog.DataBind();
            }
            else
            {
                Response.Redirect("blog.aspx");
            }
            
        }
    }
}