using FoodRau.HttpCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodRau.Admin
{
    public partial class post : System.Web.UI.Page
    {

        protected override void OnLoad(EventArgs e)
        {
            bool checkUpdate = false;
            if (!IsPostBack)
            {
                if (Request["post_id"] != null)
                {
                    CKFinder.FileBrowser _f = new CKFinder.FileBrowser();
                    _f.BasePath = "ckfinder";
                    _f.SetupCKEditor(CKEditorControl1);
                    checkUpdate = true;
                    btnThem.Visible = !checkUpdate;
                    btnCapNhat.Visible = checkUpdate;
                    Post pt = new Post();
                    Post p = pt.getItem(Convert.ToInt32(Request["post_id"]));
                    txtTile.Text = p.Title;
                    txtShortDes.Text = p.Short;
                    CKEditorControl1.Text = p.Des;
                    imgReview.ImageUrl = "~/Uploads/Images/" + p.Img;
                    ddlStatus.SelectedValue = p.Status.ToString();
                    selectDropDown(p.Type);
                }
                else
                {
                    btnCapNhat.Visible = checkUpdate;
                    btnThem.Visible = !checkUpdate;
                    resetDropDown();
                }
            }
        }

        private void resetDropDown()
        {
            FoodType ft = new FoodType();
            ddlType.DataSource = ft.getList();
            ddlType.DataTextField = "type_name";
            ddlType.DataValueField = "type_id";
            ddlType.DataBind();
        }

        private void selectDropDown(int value)
        {
            FoodType ft = new FoodType();
            ddlType.DataSource = ft.getList();
            ddlType.DataTextField = "type_name";
            ddlType.DataValueField = "type_id";
            ddlType.DataBind();
            ddlType.SelectedValue = value.ToString();
        }
        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            txtTile.Text = "";
            txtShortDes.Text = "";
            ddlStatus.SelectedValue = "-1";
            ddlType.SelectedIndex = 0;
            CKEditorControl1.Text = "";
            imgReview.ImageUrl = "~/Admin/img/10.jpg";
        }
        protected void BtnThem_Click(object sender,EventArgs e)
        {
            Post p = new Post();
            p.Title = txtTile.Text;
            p.Short = txtShortDes.Text;
            p.Des = CKEditorControl1.Text;
            p.Type = Convert.ToInt32(ddlType.SelectedValue);
            p.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            int lastIndex = hfImgReview.Value.LastIndexOf("/");
            //lấy kí tự phía sau và không lấy dấu / nên +1;
            
            //p.Img = Guid.NewGuid()+hfImgReview.Value.Substring(lastIndex+1).ToString();
            p.Img = hfImgReview.Value.Substring(lastIndex+1).ToString();
            p.Username = "khuong";
            if (p.add())
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

        protected void BtnCapNhat_Click(object sender, EventArgs e)
        {
            Post p = new Post();
            p.Post_id =Convert.ToInt32(Request["post_id"]);
            p.Title = txtTile.Text;
            p.Short = txtShortDes.Text;
            p.Des = CKEditorControl1.Text;
            p.Type = Convert.ToInt32(ddlType.SelectedValue);
            p.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            int lastIndex = hfImgReview.Value.LastIndexOf("/");
            //lấy kí tự phía sau và không lấy dấu / nên +1;
           // p.Img = Guid.NewGuid() + hfImgReview.Value.Substring(lastIndex + 1).ToString();
            p.Img = hfImgReview.Value.Substring(lastIndex + 1).ToString();
            p.Username = "khuong";
            if (p.update())
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

        [WebMethod]
        public static bool setStatusdelete(string id)
        {
            Post p = new Post();
            p.Post_id = Convert.ToInt32(id);
            return p.delete();
        }
    }
}