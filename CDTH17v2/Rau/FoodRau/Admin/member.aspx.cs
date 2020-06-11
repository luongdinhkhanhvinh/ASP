using FoodRau.HttpCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodRau.Admin
{
    public partial class member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Session["username"] == null || !Convert.ToBoolean(Session["role"]))
                {
                    Response.Redirect("~/Admin/login.aspx");
                }
            }
            
        }


        [WebMethod]
        public static Member getObject(string username)
        {
            return new Member().getItem(username);
        }


        [WebMethod]
        public static bool existUser(string username)
        {
            return new Member().exist(username);
        }

        [WebMethod]
        public static bool existE(string email)
        {
            return new Member().existEmail(email);
        }

        [WebMethod]
        public static bool existS(string sdt)
        {
            return new Member().existSDT(sdt);
        }

        [WebMethod]
        public static string searchCode(string key, string page)
        {
            //tui truyền qua key với page đó
            //chỗ này ông ko hiểu gì.
            Member mb = new Member();
            List<Member> members = mb.getList();
            if (key != null && key.Length > 0)
            {
                members = mb.getList(key.Trim());
            }
            int limit = Convert.ToInt32(new Setting().getObjectAdmin().Value);
            int soTrang = members.Count / limit + (members.Count % limit == 0 ? 0 : 1);
            int trang = Convert.ToInt32(page);
            int from = (trang - 1) * limit;
            int to = (trang * limit) - 1;
            for (int i = members.Count - 1; i >= 0; i--)
            {
                if (i < from || to < i)
                {
                    members.RemoveAt(i);
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
            //nó như json android thôi.
            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("obj", members);
            json.Add("record", index);
            json.Add("active", active);
            return new JavaScriptSerializer().Serialize(json);
        }


        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            ddlRole.SelectedIndex = -1;
            ddlStatus.SelectedIndex = -1;
        }

        protected void Btn_update_Click(object sender, EventArgs e)
        {
            Member member = new Member();
            member.UserName = hfUserName.Value;
            member.Name = txtName.Text;
            member.Pass = txtPassword.Text;
            member.Email = txtEmail.Text;
            member.Phone = txtPhone.Text;
            member.Role = Convert.ToInt32(ddlRole.SelectedValue);
            member.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            if (member.update())
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

        protected void Btn_register_Click(object sender, EventArgs e)
        {
            Member member = new Member();
            if (!member.exist(txtUserName.Text))
            {
                member.UserName = txtUserName.Text;
                member.Name = txtName.Text;
                member.Pass = txtPassword.Text;
                member.Email = txtEmail.Text;
                member.Phone = txtPhone.Text;
                member.Role = Convert.ToInt32(ddlRole.SelectedValue);
                member.Status = Convert.ToInt32(ddlStatus.SelectedValue);
                if (member.add())
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

        [WebMethod]
        public static bool setStatusdelete(string username)
        {
            Member member = new Member();
            member.UserName = username;
            return member.delete();
        }
    }
}
