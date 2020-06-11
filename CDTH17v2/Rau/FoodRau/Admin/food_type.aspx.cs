using FoodRau.HttpCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace FoodRau.Admin
{
    public partial class food_type : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/Admin/login.aspx");
            }
        }

        [WebMethod]
        public static string searchCode(string key, string page)
        {
            FoodType f = new FoodType();
            List<FoodType> foodTypes = f.getList();
            if (key != null && key.Length > 0)
            {
                foodTypes = f.getList(key.Trim());
            }
            int limit = Convert.ToInt32(new Setting().getObjectAdmin().Value);
            int soTrang = foodTypes.Count / limit + (foodTypes.Count % limit == 0 ? 0 : 1);
            int trang = Convert.ToInt32(page);
            int from = (trang - 1) * limit;
            int to = (trang * limit) - 1;
            for (int i = foodTypes.Count - 1; i >= 0; i--)
            {
                if (i < from || to < i)
                {
                    foodTypes.RemoveAt(i);
                }
            }
            int[] index = new int[soTrang];
            int[] active = new int[soTrang];

            for (int i = 0; i < soTrang; i++)
            {
                index[i] = i;
                if (i + 1 == trang)
                {
                    active[i] = 1;
                }
                else
                {
                    active[i] = 0;
                }
            }
            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("obj", foodTypes);
            json.Add("record", index);
            json.Add("active", active);
            return new JavaScriptSerializer().Serialize(json);
        }
        

        protected void BtnThem_Click(object sender, EventArgs e)
        {
            FoodType f = new FoodType();
            if (!f.exist(txtName.Text))
            {
                f.Type_name = txtName.Text;
                f.Type_post =Convert.ToInt32(txtPost.Text);
                int lastIndex = hfImgReview.Value.LastIndexOf("/");
                f.Type_img = hfImgReview.Value.Substring(lastIndex + 1).ToString();
             
                f.Status = Convert.ToInt32(ddlStatus.SelectedValue);
                f.Username = Session["username"].ToString();
                if (f.add())
                {
                    lblMessage.Text = "Thêm Thành Công";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                    Btn_cancel_Click(sender, e);
                }
                else
                {
                    Response.Write("<script>alert('Thất Bại') </script>");
                }
            }
            else
            {
                lblMessage.Text = "Đã Tồn Tại";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
            }
        }

        protected void Btn_update_Click(object sender, EventArgs e)
        {
            FoodType ft = new FoodType();
            if (ft.Type_id ==0)
            {
                ft.Type_id = Convert.ToInt32(hfTypeID.Value);
                ft.Type_name = txtName.Text;
                ft.Type_post = Convert.ToInt32(txtPost.Text);
                int lastIndex = hfImgReview.Value.LastIndexOf("/");
                ft.Type_img = hfImgReview.Value.Substring(lastIndex + 1).ToString();
                ft.Status = Convert.ToInt32(ddlStatus.SelectedValue);
                ft.Username = "khuong";
                if (ft.update())
                {
                    lblMessage.Text = "Cập Nhật Thành Công";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                    Btn_cancel_Click(sender, e);
                }
                else
                {
                    Response.Write("<script>alert('Thất Bại') </script>");
                }
            }
        }


        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            hfTypeID.Value = "";
            hfImgReview.Value = "";
            txtName.Text = "";
            txtPost.Text = "";
            imgReview.ImageUrl = "../Uploads/Images/10.jpg";
            ddlStatus.SelectedValue = "-1";
        }


        [WebMethod]
        public static FoodType getObject(string type_id)
        {
            return new FoodType().getItem(Convert.ToInt32(type_id));
        }

        [WebMethod]
        public static bool existN(string type_name)
        {
            return new FoodType().exist(type_name);
        }
        [WebMethod]
        public static bool setStatusdelete(string type_id)
        {
            FoodType ft = new FoodType();
            ft.Type_id = Convert.ToInt32(type_id);
            return ft.delete();
        }

        

    }
}