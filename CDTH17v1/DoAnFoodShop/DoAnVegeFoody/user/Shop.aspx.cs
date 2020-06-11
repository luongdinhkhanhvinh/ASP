using DoAnVegeFoody.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnVegeFoody.user
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sQuery = "";
            sQuery = "Select * from food";
            DataTable dt = DataProvider.getDataTable(sQuery);
            Repeater_Food.DataSource = dt;
            Repeater_Food.DataBind();
        }

        protected void Repeater_Food_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                HiddenField hf_id = (HiddenField)e.Item.FindControl("id");
                HiddenField hf_name = (HiddenField)e.Item.FindControl("name");
                HiddenField hf_description = (HiddenField)e.Item.FindControl("description");
                HiddenField hf_price = (HiddenField)e.Item.FindControl("price");
                HiddenField hf_img = (HiddenField)e.Item.FindControl("img");
                HiddenField hf_unit = (HiddenField)e.Item.FindControl("unit");
                HiddenField hf_foodtype = (HiddenField)e.Item.FindControl("type");

                DataTable dt = new DataTable();
                if (Session["cart"] == null)
                {
                    dt.Columns.Add("id");
                    dt.Columns.Add("name");
                    dt.Columns.Add("description");
                    dt.Columns.Add("price");
                    dt.Columns.Add("type");
                    dt.Columns.Add("img");
                    dt.Columns.Add("unit");
                }
                else
                {
                    dt = (DataTable)Session["cart"];

                }
                int iRow = checkExist(dt, hf_id.Value);
                if (iRow != -1)
                {
                    dt.Rows[iRow]["type"] = Convert.ToInt32(dt.Rows[iRow]["type"]) + 1;
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = hf_id.Value;
                    dr["name"] = hf_name.Value;
                    dr["description"] = hf_description.Value;
                    dr["price"] = hf_price.Value;
                    dr["img"] = hf_img.Value;
                    dr["type"] = hf_foodtype.Value;
                    dr["unit"] = hf_unit.Value;
                    dt.Rows.Add(dr);
                }
                Session["cart"] = dt;
            }
        }
        private int checkExist(DataTable dt, string id)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["id"].ToString() == id)
                {
                    return i;
                }
            }
            return -1;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {

        }
    }
}