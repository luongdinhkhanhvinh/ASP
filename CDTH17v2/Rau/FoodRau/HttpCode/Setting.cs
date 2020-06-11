using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodRau.HttpCode
{
    public class Setting
    {
        private int _idSetting;
        private string _name;
        private string _des;
        private string _value;
        private string _username;
        private DateTime _modified;

        public Setting()
        {
            IdSetting = 0;
            Name = "";
            Des = "";
            Value = "1";
            Username = "";
            Modified = DateTime.Now;
        }
        public Setting(int idSetting, string name, string des, string value, string username, DateTime modified)
        {
            IdSetting = idSetting;
            Name = name;
            Des = des;
            Value = value;
            Username = username;
            Modified = modified;
        }

        public int IdSetting { get => _idSetting; set => _idSetting = value; }
        public string Name { get => _name; set => _name = value; }
        public string Des { get => _des; set => _des = value; }
        public string Value { get => _value; set => _value = value; }
        public string Username { get => _username; set => _username = value; }
        public DateTime Modified { get => _modified; set => _modified = value; }

        public bool add()
        {
            string sQuery = "INSERT INTO [dbo].[setting] ([name] ,[des] ,[value] ,[username] ,[modified]) VALUES (@name,@des,@value,@username,@modified)";
            SqlParameter[] sParams =
            {
                new SqlParameter("@name",this.Name),
                new SqlParameter("@des",this.Des),
                new SqlParameter("@value",this.Value),
                new SqlParameter("@username",this.Username),
                new SqlParameter("@modified",this.Modified)
  
            };
            return DataProvider.executeNonQuery(sQuery, sParams);
        }



        public bool update()
        {
            string sQuery = "UPDATE [dbo].[setting] SET [value] = @value,[username] = @username,[modified] = @modified WHERE id_setting=@id_setting";
            SqlParameter[] param =
            {
                new SqlParameter("@id_setting",this.IdSetting),
                new SqlParameter("@value",this.Value),
                new SqlParameter("@username",this.Username),
                new SqlParameter("@modified",this.Modified)
            };
            return DataProvider.executeNonQuery(sQuery, param);
        }

        public List<Setting> getList()
        {
            string sQuery = "SELECT [id_setting] ,[name] ,[des] ,[value] ,[username] ,[modified] FROM [dbo].[setting]";

            SqlParameter[] param = {
            };
            List<Setting> objs = new List<Setting>();
            DataTable dt = DataProvider.getDataTable(sQuery, param);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    objs.Add(convertToObject(dr));
                }
            }
            return objs;
        }

        public Setting getObjectAdmin()
        {
            string sQuery = "SELECT [id_setting] ,[name] ,[des] ,[value] ,[username] ,[modified] FROM [dbo].[setting] WHERE id_setting = 1";

            SqlParameter[] param = {
            };
            DataTable dt = DataProvider.getDataTable(sQuery, param);
            if (dt != null && dt.Rows.Count > 0)
            {
                return convertToObject(dt.Rows[0]);
            }
            return new Setting();
        }

        public Setting getObjectHome()
        {
            string sQuery = "SELECT [id_setting] ,[name] ,[des] ,[value] ,[username] ,[modified] FROM [dbo].[setting] WHERE id_setting = 2";

            SqlParameter[] param = {
            };
            DataTable dt = DataProvider.getDataTable(sQuery, param);
            if (dt != null && dt.Rows.Count > 0)
            {
                return convertToObject(dt.Rows[0]);
            }
            return new Setting();
        }

        public Setting convertToObject(DataRow dr)
        {
            Setting obj = new Setting();
            obj.IdSetting = Convert.ToInt32(dr["id_setting"]);
            obj.Name = dr["name"].ToString();
            obj.Des = dr["des"].ToString();
            obj.Value = dr["value"].ToString();
            obj.Username =dr["username"].ToString();
            obj.Modified = Convert.ToDateTime(dr["modified"]);
            return obj;
        }

    }
}