using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodRau.HttpCode
{
    public class Food
    {
        private int _id;
        private string _name;
        private string _description;
        private decimal _price;
        private decimal _price_promo;
        private string _thumb;
        private string _img;
        private string _unit;
        private decimal _percent_promo;
        private int _rating;
        private int _sold;
        private decimal _point;
        private int _type;
        private int _status;
        private string _username;
        private DateTime _modified;
        private string _type_name;
        

        

        public Food()
        {
            _name = "";
            _description = "";
            _price = 0;
            _price_promo = 0;
            _thumb = "10.jpg";
            _img = "10.jpg";
            _unit = "0";
            _percent_promo = 0;
            _rating = 0;
            _sold = 0;
            _point = 0;
            _type = 0;
            _status = 0;
            _username = "";
            _modified = DateTime.Now;
            _type_name = "";
        }

        public Food(int id, string name, string description, decimal price, decimal price_promo, string thumb, string img, string unit, decimal percent_promo, int rating, int sold, decimal point, int type, int status, string username, DateTime modified,string type_name)
        {
            _id = id;
            _name = name;
            _description = description;
            _price = price;
            _price_promo = price_promo;
            _thumb = thumb;
            _img = img;
            _unit = unit;
            _percent_promo = percent_promo;
            _rating = rating;
            _sold = sold;
            _point = point;
            _type = type;
            _status = status;
            _username = username;
            _modified = modified;
            _type_name = type_name;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public decimal Price { get => _price; set => _price = value; }
        public decimal Price_promo { get => _price_promo; set => _price_promo = value; }
        public string Thumb { get => _thumb; set => _thumb = value; }
        public string Img { get => _img; set => _img = value; }
        public string Unit { get => _unit; set => _unit = value; }
        public decimal Percent_promo { get => _percent_promo; set => _percent_promo = value; }
        public int Rating { get => _rating; set => _rating = value; }
        public int Sold { get => _sold; set => _sold = value; }
        public decimal Point { get => _point; set => _point = value; }
        public int Type { get => _type; set => _type = value; }
        public int Status { get => _status; set => _status = value; }
        public string Username { get => _username; set => _username = value; }
        public DateTime Modified { get => _modified; set => _modified = value; }
        public string TypeName { get => _type_name; set => _type_name = value; }

        public bool exist(int id)
        {
            string sQuery = "SELECT count(*) FROM [dbo].[food] WHERE [id] =@id";
            SqlParameter[] param =
            {
                new SqlParameter("@id",id)
            };
            return Convert.ToInt32(DataProvider.getDataTable(sQuery, param).Rows[0][0]) > 0;
        }

        public bool exist(string name)
        {
            string sQuery = "SELECT count(*) FROM [dbo].[food] WHERE [name] =@name";
            SqlParameter[] param =
            {
                new SqlParameter("@name",name)
            };
            return Convert.ToInt32(DataProvider.getDataTable(sQuery, param).Rows[0][0]) > 0;
        }

        public bool add()
        {
            string sQuery = "INSERT INTO [dbo].[food] ([name] ,[description] ,[price] ,[price_promo] ,[thumb] ,[img] ,[unit] ,[percent_promo] ,[rating] ,[sold] ,[point] ,[type] ,[status] ,[username] ,[modified]) VALUES (@name,@description,@price,@price_promo,@thumb,@img,@unit,@percent_promo,@rating,@sold,@point,@type,@status,@username,@modified)";
            SqlParameter[] param =
            {
                new SqlParameter("@name",this._name),
                new SqlParameter("@description",this._description),
                new SqlParameter("@price",this._price),
                new SqlParameter("@price_promo",this._price_promo),
                new SqlParameter("@thumb",this._thumb),
                new SqlParameter("@img",this._img),
                new SqlParameter("@unit",this._unit),
                new SqlParameter("@percent_promo",this._percent_promo),
                new SqlParameter("@rating",this._rating),
                new SqlParameter("@sold",this._sold),
                new SqlParameter("@point",this._point),
                new SqlParameter("@type",this._type),
                new SqlParameter("@status",this._status),
                new SqlParameter("@username",this._username),
                new SqlParameter("@modified",this._modified)
            };
            //trả về true(1) hoặc false(0)
            return DataProvider.executeNonQuery(sQuery, param);
        }
        public bool update()
        {
            string sQuery = "UPDATE [dbo].[food] SET [name] = @name ,[description] = @description ,[price] = @price ,[price_promo] = @price_promo ,[thumb] = @thumb ,[img] = @img ,[unit] = @unit ,[percent_promo] = @percent_promo ,[rating] = @rating ,[sold] = @sold ,[point] = @point ,[type] = @type ,[status] = @status ,[username] = @username ,[modified] = @modified WHERE [id] = @id";
            SqlParameter[] param =
             {
                new SqlParameter("@id",this._id),
                new SqlParameter("@name",this._name),
                new SqlParameter("@description",this._description),
                new SqlParameter("@price",this._price),
                new SqlParameter("@price_promo",this._price_promo),
                new SqlParameter("@thumb",this._thumb),
                new SqlParameter("@img",this._img),
                new SqlParameter("@unit",this._unit),
                new SqlParameter("@percent_promo",this._percent_promo),
                new SqlParameter("@rating",this._rating),
                new SqlParameter("@sold",this._sold),
                new SqlParameter("@point",this._point),
                new SqlParameter("@type",this._type),
                new SqlParameter("@status",this._status),
                new SqlParameter("@username",this._username),
                new SqlParameter("@modified",this._modified)
            };
            return DataProvider.executeNonQuery(sQuery, param);
        }

        public bool delete()
        {
            string sQuery = "UPDATE [dbo].[food] SET [status] = 0 WHERE [id] = @id";
            SqlParameter[] param =
             {
                new SqlParameter("@id",this._id)
            };
            return DataProvider.executeNonQuery(sQuery, param);
        }
        public List<Food> getList()
        {
            string sQuery = "SELECT *  FROM [dbo].[food] WHERE status =1 ";
            SqlParameter[] param = { };
            DataTable dt = DataProvider.getDataTable(sQuery, param);
            List<Food> ft = new List<Food>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ft.Add(convertToObject(dr));
                }
            }
            return ft;
        }

        public List<Food> getList(int type_id)
        {
            string sQuery = "SELECT *  FROM [dbo].[food] WHERE [type] = @type_id AND status =1 ";
            SqlParameter[] param = {
                new SqlParameter("@type_id",type_id)
            };
            List<Food> ft = new List<Food>();
            DataTable dt = DataProvider.getDataTable(sQuery, param);
            if (dt!=null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ft.Add(convertToObject(dr));
                }
            }
            return ft;
        }

        //kết bảng food và type
        public List<Food> getListFoodType()
        {
            string sQuery = "SELECT food_type.type_name as type_name_f,[id] ,[name] ,[description] ,[price] ,[price_promo] ,[thumb] ,[img] ,[unit] ,[percent_promo] ,[rating] ,[sold] ,[point] ,[type] ,food.[status] ,food.[username] ,food.[modified] FROM [dbo].[food],food_type Where type=type_id AND food.status = 1";
          
            SqlParameter[] param = {};
            List<Food> ft = new List<Food>();
            DataTable dt = DataProvider.getDataTable(sQuery, param);
            if (dt !=null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ft.Add(convertToObjectFoodType(dr));
                }
            }
            return ft;
        }

        public List<Food> getListFoodType(string key)
        {
            string sQuery = "SELECT food_type.type_name as type_name_f,[id] ,[name] ,[description] ,[price] ,[price_promo] ,[thumb] ,[img] ,[unit] ,[percent_promo] ,[rating] ,[sold] ,[point] ,[type] ,food.[status] as status ,food.[username] ,food.[modified],food.[username] as modified FROM [dbo].[food],food_type Where  type=type_id AND food.status = 1 ";
            sQuery += "AND (([id] LIKE '%' + @id + '%')" +
                " OR ([name] LIKE '%' + @name + '%') "+
                " OR ([description] LIKE '%' + @description + '%')" +
                " OR ([price] LIKE '%' + @price + '%') "+
                " OR ([unit] LIKE '%' + @unit + '%') "+
                " OR ([rating] LIKE '%' + @rating + '%') " +
                " OR ([sold] LIKE '%' + @sold + '%') " +
                " OR ([point] LIKE '%' + @point + '%') " +
                " OR ([food_type].[type_name] LIKE '%' + @type_name + '%') " +
                " OR ([food].[username] LIKE '%' + @username + '%') " +
                " OR ([price_promo] LIKE '%' + @price_promo + '%') )";
            SqlParameter[] param = {
                new SqlParameter("@id",key),
                new SqlParameter("@name",key),
                new SqlParameter("@description",key),
                new SqlParameter("@price",key),
                new SqlParameter("@price_promo",key),
                new SqlParameter("@unit",key),
                new SqlParameter("@percent_promo",key),
                new SqlParameter("@rating",key),
                new SqlParameter("@sold",key),
                new SqlParameter("@point",key),
                new SqlParameter("@username",key),
                new SqlParameter("@type_name",key)
            };
            List<Food> ft = new List<Food>();
            DataTable dt = DataProvider.getDataTable(sQuery, param);
            if (dt !=null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ft.Add(convertToObjectFoodType(dr));
                }

            }
            return ft;
        }

        public Food getItem(int id)
        {
            string sQuery = "SELECT *  FROM [dbo].[food] WHERE [id]=@id";
            SqlParameter[] param = {
                new SqlParameter("@id",id)
            };
            return convertToObject(DataProvider.getDataTable(sQuery, param).Rows[0]);
        }

        private Food convertToObject(DataRow dr)
        {
            Food f = new Food();
            f.Id = Convert.ToInt32(dr["id"].ToString());
            f.Name = dr["name"].ToString();
            f.Description = dr["description"].ToString();
            f.Price =Convert.ToDecimal(dr["price"].ToString());
            f.Price_promo =Convert.ToDecimal(dr["price_promo"].ToString());
            f.Thumb = dr["thumb"].ToString();
            f.Img = dr["img"].ToString();
            f.Unit = dr["unit"].ToString();
            f.Percent_promo =Convert.ToDecimal(dr["percent_promo"].ToString());
            f.Rating = Convert.ToInt32(dr["rating"].ToString());
            f.Sold = Convert.ToInt32(dr["sold"].ToString());
            f.Point = Convert.ToDecimal(dr["point"].ToString());
            f.Type = Convert.ToInt32(dr["type"].ToString());
            f.Status = Convert.ToInt32(dr["status"].ToString());
            f.Username = dr["username"].ToString();
            f.Modified = Convert.ToDateTime(dr["modified"].ToString());
            return f;
        }

        private Food convertToObjectFoodType(DataRow dr)
        {
            Food f = new Food();
            f.Id = Convert.ToInt32(dr["id"].ToString());
            f.Name = dr["name"].ToString();
            f.Description = dr["description"].ToString();
            f.Price = Convert.ToDecimal(dr["price"].ToString());
            f.Price_promo = Convert.ToDecimal(dr["price_promo"].ToString());
            f.Thumb = dr["thumb"].ToString();
            f.Img = dr["img"].ToString();
            f.Unit = dr["unit"].ToString();
            f.Percent_promo = Convert.ToDecimal(dr["percent_promo"].ToString());
            f.Rating = Convert.ToInt32(dr["rating"].ToString());
            f.Sold = Convert.ToInt32(dr["sold"].ToString());
            f.Point = Convert.ToDecimal(dr["point"].ToString());
            f.Type = Convert.ToInt32(dr["type"].ToString());
            f.TypeName = dr["type_name_f"].ToString();
            f.Status = Convert.ToInt32(dr["status"].ToString());
            f.Username = dr["username"].ToString();
            f.Modified = Convert.ToDateTime(dr["modified"].ToString());
            return f;
        }



    }
}