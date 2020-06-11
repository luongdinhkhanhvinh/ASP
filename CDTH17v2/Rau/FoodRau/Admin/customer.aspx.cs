using FoodRau.HttpCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodRau.Admin;

namespace FoodRau.Admin
{
    public partial class customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["username"] !=null)
                {
                    Customer ct = new Customer();
                    Customer c = ct.getItem(Request["username"]);
                    txtUserName.Text = c.Username;
                    txtName.Text = c.Name;
                    txtAddress.Text = c.Address;
                    txtEmail.Text = c.Email;
                    txtPhone.Text = c.Phone;
                    ddlStatus.SelectedValue =c.Status.ToString();
                }
                
            }
        }

        [WebMethod]
        public static string searchCode(string key, string page)
        {
            Post p = new Post();
            List<Post> posts = p.getList();
            if (key != null && key.Length > 0)
            {
                posts = p.getList(key);
            }
            
            int limit = Convert.ToInt32(new Setting().getObjectAdmin().Value);
            int soTrang = posts.Count / limit + (posts.Count % limit == 0 ? 0 : 1);
            int trang = Convert.ToInt32(page);
            int from = (trang - 1) * limit;
            int to = (trang * limit) - 1;
            for (int i = posts.Count - 1; i >= 0; i--)
            {
                if (i < from || to < i)
                {
                    posts.RemoveAt(i);
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
            json.Add("obj", posts);
            json.Add("record", index);
            json.Add("active", active);
            return new JavaScriptSerializer().Serialize(json);
        }

        [WebMethod]
        public static bool setStatusdelete(string id)
        {
            Post p = new Post();
            p.Post_id = Convert.ToInt32(id);
            return p.delete();
        }

        protected void BtnCapNhat_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.Username = Request["username"].ToString();
            c.Name = txtName.Text;
            c.Phone = txtPhone.Text;
            c.Email = txtEmail.Text;
            c.Address = txtAddress.Text;
            c.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            if (c.update())
            {
                lblMessage.Text = "Cập Nhật Thành Công";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                
            }
            else
            {
                Response.Write("<script>alert('Thất Bại') </script>");
            }
        }
    }
}