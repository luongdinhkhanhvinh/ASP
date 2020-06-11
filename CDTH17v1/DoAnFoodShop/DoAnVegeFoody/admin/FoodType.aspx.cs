using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoAnVegeFoody.admin;
using DoAnVegeFoody.App_Code;
using System.Data;

namespace DoAnVegeFoody.admin
{
    public partial class FoodType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request["update"] != null)
                {
                    string sQuery = "select * from food_type where type_id = '" + Request["update"] + "'";
                    DataTable dt = DataProvider.getDataTable(sQuery);
                    txt_Type_Name.Text = dt.Rows[0]["type_name"].ToString();
                    img_img.Visible = true;
                    img_img.ImageUrl = "~/Admin/img/" + dt.Rows[0]["type_img"].ToString();
                    txt_Pos.Text = dt.Rows[0]["type_pos"].ToString();
                    DdlStatus.SelectedValue = dt.Rows[0]["status"].ToString();
                    themmoi.Text = "Cập nhật";
                }
            }
        }
        protected void themmoi_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["update"]);
            string sType_Name = txt_Type_Name.Text;
            string sType_Img = Server.MapPath(img_Foodtype.FileName);
            string type_img = img_Foodtype.FileName;
            img_Foodtype.SaveAs(sType_Img);
            int sType_Pos = Convert.ToInt32(txt_Pos.Text);
            int iStatus = Convert.ToInt32(DdlStatus.SelectedValue);
            string sUserName = Session["LOGIN"].ToString();
            DateTime dtModified = DateTime.Now;
            clsFoodType foodtype = new clsFoodType(sType_Name, type_img, sType_Pos, iStatus, sUserName, dtModified);
            
            if (Request["update"] != null)
            {
                if (foodtype.UpdateFoodType(id) == true)
                {
                    txtResult.InnerHtml = "Cập nhật thành công";
                    Xoaform();
                }
                else
                {
                    txtResult.InnerHtml = "Cập nhật thất bại";
                }
            }
            else
            {
               
                if (foodtype.AddFoodType() == true)
                {
                    txtResult.InnerHtml = "Thêm mới thành công";
                    Xoaform();
                }
                else
                {
                    txtResult.InnerHtml = "Thêm mới đã tồn tại";
                }
            }
        }
        protected void Xoaform()
        {
            txt_Type_Name.Text = "";
           
            DdlStatus.SelectedValue = "1";
            txt_Pos.Text = "";
        }
    }
}