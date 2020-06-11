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
    public partial class blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                List<Post> posts = new List<Post>();
                Post p = new Post();
                //recent blog
                rptRecentBlog.DataSource = p.getListDescCreate();
                rptRecentBlog.DataBind();

                //categori
                rptLSP.DataSource = p.getListCount();
                rptLSP.DataBind();
                ////theo type  Post
                if (Request["type"] != null)
                {
                    posts = p.getList(Convert.ToInt32(Request["type"]));
                }
                else
                {
                     posts = p.getList();
                }
                //handle phan trang
                int limit = Convert.ToInt32(new Setting().getObjectHome().Value);
                int soTrang = posts.Count / limit + (posts.Count % limit == 0 ? 0 : 1);
                int page = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
                int from = (page - 1) * limit;
                int to = (page * limit) - 1;
                for (int i = posts.Count - 1; i >= 0; i--)
                {
                    if (i < from || to < i)
                    {
                        posts.RemoveAt(i);
                    }
                }


                rptPost.DataSource = posts;
                rptPost.DataBind();

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
}