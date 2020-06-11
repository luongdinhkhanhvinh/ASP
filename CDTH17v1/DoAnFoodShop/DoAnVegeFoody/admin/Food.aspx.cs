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
    public partial class Food : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-77KDDKP;Initial Catalog =WEB_DB;Integrated Security = True");
                string sQuery = "";
                sQuery = "Select * from food_type";
                SqlDataAdapter daf = new SqlDataAdapter(sQuery, con);
                DataTable dtf = new DataTable();
                daf.Fill(dtf);
                ddType.DataSource = dtf;
                ddType.DataTextField = "type_name";
                ddType.DataValueField = "type_id";
                ddType.DataBind();

                if (Request["update"] != null)
                {
                    sQuery = "select * from food where id = " + Request["update"];
                    SqlDataAdapter lst = new SqlDataAdapter(sQuery, con);
                    DataTable sp = new DataTable();
                    lst.Fill(sp);
                    txtName.Text = sp.Rows[0]["name"].ToString();
                    txtPrice.Text = sp.Rows[0]["price"].ToString();
                    txtPricePromo.Text = sp.Rows[0]["price_promo"].ToString();
                    img_thumb.Visible = true;
                    img_thumb.ImageUrl = "~/Admin/img/" + sp.Rows[0]["thumb"].ToString();
                    img_img.Visible = true;
                    img_img.ImageUrl = "~/Admin/img/" + sp.Rows[0]["img"].ToString();
                    txtUnit.Text = sp.Rows[0]["unit"].ToString();
                    int percentpro = Convert.ToInt32(sp.Rows[0]["percent_promo"]);
                    percentpro *= 100;
                    txtPercentPromo.Text = percentpro.ToString();
                    ddType.SelectedValue = sp.Rows[0]["type"].ToString();
                    ddStatus.SelectedValue = sp.Rows[0]["status"].ToString();
                    txtDes.Text = sp.Rows[0]["description"].ToString();
                    btn_add.Text = "Cập nhật";
                }
            }
        }
        protected void ThemFood(object sender, EventArgs e)
        {
            if (btn_add.Text == "Thêm thực phẩm")
            {
                string name = txtName.Text;
                decimal price = Convert.ToDecimal(txtPrice.Text);
                decimal pricepro = Convert.ToDecimal(txtPricePromo.Text);
                string thumb = ful_thumb.FileName;
                string img = ful_img.FileName;
                string unit = txtUnit.Text;
                decimal percentpro = Convert.ToDecimal(txtPercentPromo.Text);
                percentpro = percentpro / 100;
                int type = Convert.ToInt32(ddType.SelectedValue);
                int status = Convert.ToInt32(ddStatus.SelectedValue);
                string username = Session["LOGIN"].ToString();
                DateTime modified = DateTime.Now;
                string des = txtDes.Text;
                clsFood fd = new clsFood(name, price, pricepro, thumb, img, unit, percentpro, type, status, username, modified, des);
                if (fd.AddFood() == true)
                {
                    txtResult.InnerHtml = "Thêm thành công " + name;
                    if (ful_img.HasFile)
                    {
                        ful_img.SaveAs(Server.MapPath("../Admin/img/" + ful_img.FileName));
                    }
                }
                else
                {
                    txtResult.InnerHtml = "Thêm không thành công ";
                }
            }
            else
            {
                string name = txtName.Text;
                decimal price = Convert.ToDecimal(txtPrice.Text);
                decimal pricepro = Convert.ToDecimal(txtPricePromo.Text);
                string thumb = ful_thumb.FileName;
                string img = ful_img.FileName;
                string unit = txtUnit.Text;
                decimal percentpro = Convert.ToDecimal(txtPercentPromo.Text);
                percentpro = percentpro / 100;
                int type = Convert.ToInt32(ddType.SelectedValue);
                int status = Convert.ToInt32(ddStatus.SelectedValue);
                string username = Session["LOGIN"].ToString();
                DateTime modified = DateTime.Now;
                string des = txtDes.Text;
                clsFood fd = new clsFood(name, price, pricepro, thumb, img, unit, percentpro, type, status, username, modified, des);
                if (fd.upDateFood(Int32.Parse(Request["update"])))
                {
                    txtResult.InnerHtml = "Cập nhật thành công " + name;
                    if (ful_img.HasFile)
                    {
                        ful_img.SaveAs(Server.MapPath("../Admin/img//" + ful_img.FileName));
                    }
                }
                else
                {
                    txtResult.InnerHtml = "Cập nhật thất bại ";
                }
            }
        }
    }
}