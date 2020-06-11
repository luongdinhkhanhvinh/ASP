using DoAnVegeFoody.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnVegeFoody.admin
{
    public partial class DanhSachLoaiSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                string sQuery = "";
                sQuery = "Select * from food_type";
                if (Request["key"] != null)
                {
                    sQuery = sQuery + " where type_name like '%" + Request["key"].ToString() + "%'";
                }

                DataTable dt = DataProvider.getDataTable(sQuery);

                int so_item_1trang = 10;
                int so_trang = dt.Rows.Count / so_item_1trang + (dt.Rows.Count % so_item_1trang == 0 ? 0 : 1);
                int page = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
                int from = (page - 1) * 10;
                int to = page * 10 - 1;
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (i < from || i > to)
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }
                Repeater_Foodtype.DataSource = dt;
                Repeater_Foodtype.DataBind();
                DataTable dtPage = new DataTable();
                dtPage.Columns.Add("index");
                dtPage.Columns.Add("active");
                for (int i = 1; i <= so_trang; i++)
                {
                    DataRow dr = dtPage.NewRow();
                    dr["index"] = i;

                    if ((Request["page"] == null && i == 1) || (Request["page"] != null && Convert.ToInt32(Request["page"]) == i))
                        dr["active"] = 1;
                    else
                        dr["active"] = 0;
                    dtPage.Rows.Add(dr);
                }
                Repeater2.DataSource = dtPage;
                Repeater2.DataBind();
            }
        }

        protected void Repeater_Foodtype_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Equals("sua"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("Foodtype.aspx?update=" + id);
            }
            else if (e.CommandName.ToLower().Equals("xoa"))
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-77KDDKP;Initial Catalog =WEB_DB;Integrated Security = True");
                conn.Open();
                int id = Convert.ToInt32(e.CommandArgument);
                string query = "UPDATE  food_type SET status = 0 WHERE type_id = " + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count != null)
                {
                    txtResult.InnerHtml = "Xóa thành công";
                    Response.Redirect("DanhSachLoaiSanPham.aspx");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhSachLoaiSanPham.aspx?key=" + txtkey.Text);
        }
        [WebMethod]
        public static int GETDATA(string key)
        {
            clsFoodType fd = new clsFoodType();
            return 1;
        }
    }
}