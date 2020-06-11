using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FoodRau.HttpCode
{
    public class Member
    {
        private string _userName;
        private string _pass;
        private string _name;
        private string _email;
        private string _phone;
        private int _role;
        private int _status;

        public Member()
        {
            UserName = "";
            Pass = "";
            Name = "";
            Email = "";
            Phone = "";
            Role = 0;
            Status = 0;
        }

       
        public string UserName { get => _userName; set => _userName = value; }
        public string Pass { get => _pass; set => _pass = value; }
        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public int Role { get => _role; set => _role = value; }
        public int Status { get => _status; set => _status = value; }

        public bool exist(string username)
        {
            string sQuery = "SELECT count(*) FROM member WHERE username =@username";
            SqlParameter[] param =
            {
                new SqlParameter("@username",username)
            };
            return Convert.ToInt32(DataProvider.getDataTable(sQuery, param).Rows[0][0]) > 0;
        }

        public bool existEmail(string email)
        {
            string sQuery = "SELECT count(*) FROM member WHERE email =@email";
            SqlParameter[] param =
            {
                new SqlParameter("@email",email)
            };
            return Convert.ToInt32(DataProvider.getDataTable(sQuery, param).Rows[0][0]) > 0;
        }

        public bool existSDT(string sdt)
        {
            string sQuery = "SELECT count(*) FROM member WHERE phone =@phone";
            SqlParameter[] param =
            {
                new SqlParameter("@phone",sdt)
            };
            return Convert.ToInt32(DataProvider.getDataTable(sQuery, param).Rows[0][0]) > 0;
        }
        

        public bool add()
        {
            string sQuery = "INSERT INTO [dbo].[member] ([username] ,[pass] ,[name] ,[email] ,[phone] ,[role],[status]) VALUES (@username,@pass,@name,@email,@phone,@role,@status)";
            SqlParameter[] param =
            {
                new SqlParameter("@username",this._userName),
                new SqlParameter("@pass",StringProc.MD5Hash(this._pass)),
                new SqlParameter("@name",this._name),
                new SqlParameter("@email",this._email),
                new SqlParameter("@phone",this._phone),
                new SqlParameter("@role",this._role),
                new SqlParameter("@status",this.Status)
            };
            return DataProvider.executeNonQuery(sQuery, param);
        }
        public bool update()
        {
            string sQuery = "UPDATE [dbo].[member] SET [username] = @username,[pass] = @pass,[name] = @name ,[email] = @email ,[phone] = @phone,[role] =@role,[status] = @status WHERE [username] = @username";
            SqlParameter[] param =
             {
                new SqlParameter("@username",this._userName),
                new SqlParameter("@pass",StringProc.MD5Hash(this._pass)),
                new SqlParameter("@name",this._name),
                new SqlParameter("@email",this._email),
                new SqlParameter("@phone",this._phone),
                new SqlParameter("@role",this._role),
                new SqlParameter("@status",this._status)
            };
            return DataProvider.executeNonQuery(sQuery, param);
        }

        public bool delete()
        {
            string sQuery = "UPDATE [dbo].[member] SET [status] =0 WHERE [username] = @username";
            SqlParameter[] param =
             {
                new SqlParameter("@username",this._userName),
            };
            return DataProvider.executeNonQuery(sQuery, param);
        }
        public List<Member> getList()
        {
            string sQuery = "SELECT * FROM [dbo].[member] WHERE status = 1";
            SqlParameter[] param = {};
            List<Member> members = new List<Member>();
            DataTable dt = DataProvider.getDataTable(sQuery, param);
            foreach (DataRow dr in dt.Rows)
            {
                members.Add(convertToObject(dr));
            }
            return members;
        }

        public List<Member> getList(string key)
        {
            string sQuery = "SELECT * FROM [member] WHERE ((([username] LIKE '%' + @username + '%') OR ([name] LIKE '%' + @name + '%') OR ([email] LIKE '%' + @email + '%') OR ([phone] LIKE '%' + @phone + '%')) AND status = 1)";
            SqlParameter[] param =
            {
                new SqlParameter("@username",key),
                new SqlParameter("@name",key),
                new SqlParameter("@email",key),
                new SqlParameter("@phone",key)
            };
            List<Member> members = new List<Member>();
            DataTable dt = DataProvider.getDataTable(sQuery, param);
            foreach (DataRow dr in dt.Rows)
            {
                members.Add(convertToObject(dr));
            }
            return members;
        }
        public Member getItem(string username)
        {
            string sQuery = "SELECT * FROM [dbo].[member] WHERE [username] = @username";
            SqlParameter[] param = {
                new SqlParameter("@username",username)
            };
            return convertToObject(DataProvider.getDataTable(sQuery, param).Rows[0]);
        }
        private Member convertToObject(DataRow dr)
        {
            Member mb = new Member();
            mb.UserName = dr["username"].ToString();
            mb.Pass = dr["pass"].ToString();
            mb.Name = dr["name"].ToString();
            mb.Email = dr["email"].ToString();
            mb.Phone = dr["phone"].ToString();
            mb.Role = Convert.ToInt32(dr["role"]);
            mb.Status =Convert.ToInt32(dr["status"]);
            return mb;
        }

    }
}