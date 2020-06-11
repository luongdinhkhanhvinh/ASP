using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace FoodRau.HttpCode
{
    public class FoodType
    {
        private int _type_id;
        private string _type_name;
        private int _type_post;
        private string _type_img;
        private int _status;
        private string _username;
        private DateTime _modified;

        public int Type_id { get => _type_id; set => _type_id = value; }
        public string Type_name { get => _type_name; set => _type_name = value; }
        public int Type_post { get => _type_post; set => _type_post = value; }
        public string Type_img { get => _type_img; set => _type_img = value; }
        public int Status { get => _status; set => _status = value; }
        public string Username { get => _username; set => _username = value; }
        public DateTime Modified { get => _modified; set => _modified = value; }

        public FoodType()
        {
            _type_id = 0;
            _type_name = "";
            _type_post = 0;
            _type_img = "";
            _status = 0;
            _username = "";
            this._modified = DateTime.Now;
        }

        public FoodType(int type_id, string type_name, int type_post, string type_img, int status, string username, DateTime modified)
        {
            _type_id = type_id;
            _type_name = type_name;
            _type_post = type_post;
            _type_img = type_img;
            _status = status;
            _username = username;
            _modified = modified;
        }

        public bool exist(string type_name)
        {
            string sQuery = "SELECT count(*) FROM [dbo].[food_type] WHERE [type_name] =@type_name";
            SqlParameter[] param =
            {
                new SqlParameter("@type_name",type_name)
            };
            return Convert.ToInt32(DataProvider.getDataTable(sQuery, param).Rows[0][0]) > 0;
        }

        public bool add()
        {
            string sQuery = "INSERT INTO [dbo].[food_type] ([type_name] ,[type_pos] ,[type_img] ,[status] ,[username] ,[modified]) VALUES (@type_name,@type_pos,@type_img,@status,@username,@modified)";
            SqlParameter[] param =
            {
                new SqlParameter("@type_name",this._type_name),
                new SqlParameter("@type_pos",this._type_post),
                new SqlParameter("@type_img",this._type_img),
                new SqlParameter("@status",this._status),
                new SqlParameter("@username",this._username),
                new SqlParameter("@modified",this._modified)
            };
            //trả về true(1) hoặc false(0)
            return DataProvider.executeNonQuery(sQuery, param);
        }
        public bool update()
        {
            string sQuery = "UPDATE [dbo].[food_type] SET [type_name] =@type_name,[type_pos] = @type_pos,[type_img] = @type_img,[status] = @status,[username] = @username,[modified] =@modified WHERE [type_id] = @type_id";
            SqlParameter[] param =
             {
                new SqlParameter("@type_id",this._type_id),
                new SqlParameter("@type_name",this._type_name),
                new SqlParameter("@type_pos",this._type_post),
                new SqlParameter("@type_img",this._type_img),
                new SqlParameter("@status",this._status),
                new SqlParameter("@username",this._username),
                new SqlParameter("@modified",this._modified)
            };
            return DataProvider.executeNonQuery(sQuery, param);
        }

        public bool delete()
        {
            string sQuery = "UPDATE [dbo].[food_type] SET [status] = 0 WHERE [type_id] = @type_id";
            SqlParameter[] param =
             {
                new SqlParameter("@type_id",this._type_id)
            };
            return DataProvider.executeNonQuery(sQuery, param);
        }

        public List<FoodType> getList()
        {
            string sQuery = "SELECT *  FROM [dbo].[food_type] WHERE status =1 ";
            SqlParameter[] param = { };
            List<FoodType> ft = new List<FoodType>();
            DataTable dt = DataProvider.getDataTable(sQuery, param);
            if (dt !=null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ft.Add(convertToObject(dr));
                }
            }
            return ft;

        }

        public List<FoodType> getList(string key)
        {
            string sQuery = "SELECT *  FROM [dbo].[food_type] WHERE  status =1 And ([type_id] LIKE '%' + @type_id + '%' OR [type_name] LIKE '%' + @type_name + '%' OR [type_pos] LIKE '%' + @type_pos + '%')";
            SqlParameter[] param = {
                new SqlParameter("@type_id",key),
                new SqlParameter("@type_name",key),
                new SqlParameter("@type_pos",key)
            };
            List<FoodType> ft = new List<FoodType>();
            DataTable dt = DataProvider.getDataTable(sQuery, param);
            if (dt !=null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ft.Add(convertToObject(dr));
                }
            }
            return ft;
        }
        public FoodType getItem(int type_id)
        {
            string sQuery = "SELECT *  FROM [dbo].[food_type] WHERE [type_id]=@type_id";
            SqlParameter[] param = {
                new SqlParameter("@type_id",type_id)
            };
            return convertToObject(DataProvider.getDataTable(sQuery, param).Rows[0]);
        }

        private FoodType convertToObject(DataRow dr)
        {
            FoodType ft = new FoodType();
            ft.Type_id = Convert.ToInt32(dr["type_id"].ToString());
            ft.Type_name = dr["type_name"].ToString();
            ft.Type_post = Convert.ToInt32(dr["type_pos"].ToString());
            ft.Type_img = dr["type_img"].ToString();
            ft.Status = Convert.ToInt32(dr["status"].ToString());
            ft.Username = dr["username"].ToString();
            ft.Modified = Convert.ToDateTime(dr["modified"].ToString());
            return ft;
        }
    }
}