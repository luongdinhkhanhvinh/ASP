using FoodRau.HttpCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
namespace FoodRau.Admin
{
    public partial class food : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("~/Admin/login.aspx");
                }
                btnUpdate.Visible = false;
                btnThem.Visible = false;
                if (Request.QueryString["id"] != null)
                {
                    btnUpdate.Visible = true;
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Food fo = new Food();
                    if (fo.exist(id))
                    {
                        Food f = fo.getItem(id);
                        txtName.Text = f.Name;
                        txtDescription.Text = f.Description;
                        txtPrice.Text = f.Price.ToString();
                        txtPrice_promo.Text = f.Price_promo.ToString();
                        txtUnit.Text = f.Unit.ToString();
                        txtPercent_Promo.Text = (Convert.ToDouble(f.Percent_promo.ToString()) * 100).ToString();
                        txtRating.Text = f.Rating.ToString();
                        txtPoint.Text =(Convert.ToDouble(f.Point.ToString())*100).ToString();
                        hfImgReviewImg.Value = f.Img;
                        hfImgReviewThumb.Value = f.Thumb;
                        imgImage.ImageUrl = "../Uploads/Images/" + f.Img;
                        imgThumb.ImageUrl = "../Uploads/Images/" + f.Thumb;
                        ddl_status.SelectedValue = f.Status.ToString();
                        selectedDropDown(f.Type);
                    }
                    else
                    {
                        Response.Redirect("lst_food.aspx");
                    }

                }
                else
                {
                    resetDropDownType();
                    btnThem.Visible = true;
                }

            }

        }

        private void resetDropDownType()
        {
            FoodType ft = new FoodType();
            List<FoodType> foodTypes = ft.getList();
            if (foodTypes.Count > 0)
            {
                ddListType.DataSource = foodTypes;
                ddListType.DataTextField = "type_name";
                ddListType.DataValueField = "type_id";
                ddListType.DataBind();
            }
        }

        private void selectedDropDown(int value)
        {
            FoodType ft = new FoodType();
            ddListType.DataSource = ft.getList();
            ddListType.DataTextField = "type_name";
            ddListType.DataValueField = "type_id";
            ddListType.DataBind();
            ddListType.SelectedValue = value.ToString();
        }
        protected void Btn_Them_Click(object sender, EventArgs e)
        {
            Food f = new Food();
            if (!f.exist(txtName.Text))
            {
                f.Name = txtName.Text;
                f.Type = Convert.ToInt32(ddListType.SelectedValue);
                f.Description = txtDescription.Text;
                f.Price = Convert.ToDecimal(txtPrice.Text);
                f.Price_promo = Convert.ToDecimal(hfPrice_Promo.Value);
                f.Unit = txtUnit.Text;
                double percent = Convert.ToDouble(txtPercent_Promo.Text)/100;
                f.Percent_promo = Convert.ToDecimal((percent));
                f.Rating = Convert.ToInt32(txtRating.Text);
                double point = Convert.ToDouble(txtPoint.Text)/100;
                f.Point = Convert.ToDecimal((point));
                f.Type = Convert.ToInt32(ddListType.SelectedValue);
                f.Status = Convert.ToInt32(ddl_status.SelectedValue);
                int lastIndexImg = hfImgReviewImg.Value.LastIndexOf("/");
                f.Img = hfImgReviewImg.Value.Substring(lastIndexImg + 1).ToString();
                int lastIndexThumb = hfImgReviewThumb.Value.LastIndexOf("/");
                f.Thumb = hfImgReviewThumb.Value.Substring(lastIndexThumb + 1).ToString();
                f.Username = Session["username"].ToString();
                if (f.add())
                {
                    lblMessage.Text = "Thêm Thành Công";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                }
                else
                {
                    Response.Write("<script>alert('Thất Bại') </script>");
                }
            }
            else
            {
                lblMessage.Text = "Tồn Tại";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
            }
        }
      
       
        protected void Btn_update_Click(object sender, EventArgs e)
        {
            Food f = new Food();
            if (Request.QueryString["id"] != null)
            {
                f.Id =Convert.ToInt32(Request.QueryString["id"]);
                f.Name = txtName.Text;
                f.Type = Convert.ToInt32(ddListType.SelectedValue);
                f.Description = txtDescription.Text;
                f.Price = Convert.ToDecimal(txtPrice.Text);
                f.Price_promo = Convert.ToDecimal(hfPrice_Promo.Value);
                f.Unit = txtUnit.Text;
                double percent = Convert.ToDouble(txtPercent_Promo.Text) / 100;
                f.Percent_promo = Convert.ToDecimal((percent));
                f.Rating = Convert.ToInt32(txtRating.Text);
                double point = Convert.ToDouble(txtPoint.Text) / 100;
                f.Point = Convert.ToDecimal((point));
                f.Type = Convert.ToInt32(ddListType.SelectedValue);
                f.Status = Convert.ToInt32(ddl_status.SelectedValue);
                int lastIndexImg = hfImgReviewImg.Value.LastIndexOf("/");
                f.Img = hfImgReviewImg.Value.Substring(lastIndexImg + 1).ToString();
                int lastIndexThumb = hfImgReviewThumb.Value.LastIndexOf("/");
                f.Thumb = hfImgReviewThumb.Value.Substring(lastIndexThumb + 1).ToString();

                f.Username = Session["username"].ToString();
                if (f.update())
                {
                    lblMessage.Text = "Cập nhật Thành Công";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                }
                else
                {
                    Response.Write("<script>alert('Thất Bại') </script>");
                }

            }
        }


    }
}