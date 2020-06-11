using DoAnVegeFoody.admin;
using DoAnVegeFoody.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnVegeFoody
{
    public partial class Member : System.Web.UI.Page
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
                    string sQuery = "select * from member where id = '" + Request["update"] + "'";
                    DataTable dt = DataProvider.getDataTable(sQuery);
                    exampleUserName.Text = dt.Rows[0]["username"].ToString();
                    exampleInputEmail.Text = dt.Rows[0]["email"].ToString();
                    exampleInputPassword.Text = "*****";
                    exampleRepeatPassword.Text = "*****";
                    exampleName.Text = dt.Rows[0]["name"].ToString();
                    examplePhone.Text = dt.Rows[0]["phone"].ToString();
                    exampleStatus.SelectedValue = dt.Rows[0]["status"].ToString();
                    exampleRole.SelectedValue = dt.Rows[0]["role"].ToString();

                    exampleUserName.Enabled = false;

                    register.Text = "Update";
                }
            }
        }
        protected void register_Click(object sender, EventArgs e)
        {
            string sUsername = exampleUserName.Text;
            string sName = exampleName.Text;
            string sPass = exampleInputPassword.Text;
            string sRepeatPage = exampleRepeatPassword.Text;
            string sPhone = examplePhone.Text;
            string sEmail = exampleInputEmail.Text;
            int iRole = Convert.ToInt32(exampleRole.SelectedValue);
            int iStatus = Convert.ToInt32(exampleStatus.SelectedValue);

            if (CheckExits(sName) == 1)
            {
                txt_username.Text = "Tên người dùng đã tồn tại!";
            }
            else
            {
                Account acc = new Account(sUsername, sName, sPass, sPhone, iRole, iStatus, sEmail);

                if (Request["update"] != null)
                {
                    if (acc.UpdateMember() == true)
                    {
                        txtResult.InnerHtml = "Cập nhật thành công";
                    }
                    else
                    {
                        txtResult.InnerHtml = "Cập nhật đã tồn tại";
                    }
                }
                else
                {
                    if (acc.AddMember() == true)
                    {
                        txtResult.InnerHtml = "Thêm mới thành công";
                    }
                    else
                    {
                        txtResult.InnerHtml = "Thêm mới đã tồn tại";
                    }
                }
            }
            
        }
        protected int CheckExits(string name){
            string sQuery = "select username from member where username = '" + name + "'";
            DataTable dt = DataProvider.getDataTable(sQuery);
            if (dt != null)
            {
                return 1;
            }
            return -1;
    }
    }
}