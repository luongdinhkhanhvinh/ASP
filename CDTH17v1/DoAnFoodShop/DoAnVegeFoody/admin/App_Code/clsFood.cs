using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoAnVegeFoody.App_Code
{
    public class clsFood
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private decimal _Price;

        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        private decimal _Price_promo;

        public decimal Price_promo
        {
            get { return _Price_promo; }
            set { _Price_promo = value; }
        }
        private string _Thumb;

        public string Thumb
        {
            get { return _Thumb; }
            set { _Thumb = value; }
        }
        private string _Img;

        public string Img
        {
            get { return _Img; }
            set { _Img = value; }
        }
        private string _Unit;

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        private decimal _Percent_promo;

        public decimal Percent_promo
        {
            get { return _Percent_promo; }
            set { _Percent_promo = value; }
        }
        private int _Rating;

        public int Rating
        {
            get { return _Rating; }
            set { _Rating = value; }
        }
        private int _Sold;

        public int Sold
        {
            get { return _Sold; }
            set { _Sold = value; }
        }
        private double _Point;

        public double Point
        {
            get { return _Point; }
            set { _Point = value; }
        }
        private int _Type;

        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        private int _Status;

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private string _Username;

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        private DateTime _Modified;

        public DateTime Modified
        {
            get { return _Modified; }
            set { _Modified = value; }
        }

        public clsFood(string name, decimal price, decimal pricepro, string thumb, string img, string unit, decimal percentpro, int type, int status, string username, DateTime modified, string des)
        {
            _Name = name;
            _Description = des;
            _Price = price;
            _Price_promo = pricepro;
            _Thumb = thumb;
            _Img = img;
            _Unit = unit;
            _Percent_promo = percentpro;
            _Type = type;
            _Status = status;
            _Username = username;
            _Modified = modified;
        }
        public clsFood()
        {
            _Name = "";
            _Description = "";
            _Price = 0;
            _Price_promo = 0;
            _Thumb = "";
            _Img = "";
            _Unit = "";
            _Percent_promo = 0;
            _Type = 0;
            _Status = 0;
            _Username = "";
        }
        public bool AddFood()
        {
            string addQuery = "INSERT INTO [dbo].[food]([name],[price],[price_promo],[thumb],[img],[unit],[percent_promo],[type],[status],[username],[modified],[description])VALUES(@name,@price,@pricepro,@thumb,@img,@unit,@percentpro,@type,@status,@username,@modified,@des)";

            SqlParameter[] paras =
            {
                new SqlParameter("@name",SqlDbType.NVarChar,50){Value=this.Name},
                new SqlParameter("@price",SqlDbType.Decimal){Value= this.Price},
                new SqlParameter("@pricepro",SqlDbType.Decimal){Value=this.Price_promo},
                new SqlParameter("@thumb",SqlDbType.VarChar,255){Value=this.Thumb},
                new SqlParameter("@img",SqlDbType.VarChar,255){Value=this.Img},
                new SqlParameter("@unit",SqlDbType.NVarChar,10){Value=this.Unit},
                new SqlParameter("@percentpro",SqlDbType.Decimal){Value=this.Percent_promo},
                new SqlParameter("@type",SqlDbType.Int){Value=this.Type},
                new SqlParameter("@status",SqlDbType.Int){Value=this.Status},
                new SqlParameter("@username",SqlDbType.VarChar,50){Value=this.Username},
                new SqlParameter("@modified",SqlDbType.DateTime){Value=Modified.ToString()},
                new SqlParameter("@des",SqlDbType.VarChar,255){Value=this.Description}
            };
            return DataProvider.executeNonQuery(addQuery, paras);

        }
        public bool upDateFood(int id)
        {
            string addQuery = "UPDATE [dbo].[food] SET [name] = @name,[price] = @price,[price_promo] = @pricepro,[thumb] = @thumb ,[img] = @img,[unit] = @unit,[percent_promo] = @percentpro,[type] = @type,[status] = @status,[username] = @username ,[modified] = @modified ,[description] = @des WHERE [id] = @id";

            SqlParameter[] paras =
            {
                new SqlParameter("@id",SqlDbType.Int){Value=id},
                new SqlParameter("@name",SqlDbType.NVarChar,50){Value=this.Name},
                new SqlParameter("@price",SqlDbType.Decimal){Value= this.Price},
                new SqlParameter("@pricepro",SqlDbType.Decimal){Value=this.Price_promo},
                new SqlParameter("@thumb",SqlDbType.VarChar,255){Value=this.Thumb},
                new SqlParameter("@img",SqlDbType.VarChar,255){Value=this.Img},
                new SqlParameter("@unit",SqlDbType.NVarChar,10){Value=this.Unit},
                new SqlParameter("@percentpro",SqlDbType.Decimal){Value=this.Percent_promo},
                new SqlParameter("@type",SqlDbType.Int){Value=this.Type},
                new SqlParameter("@status",SqlDbType.Int){Value=this.Status},
                new SqlParameter("@username",SqlDbType.VarChar,50){Value=this.Username},
                new SqlParameter("@modified",SqlDbType.DateTime){Value=Modified.ToString()},
                new SqlParameter("@des",SqlDbType.VarChar,255){Value=this.Description}
            };
            return DataProvider.executeNonQuery(addQuery, paras);

        }
        public bool deLeTeFood(int id)
        {
            string addQuery = "DELETE FROM [dbo].[food] WHERE [id]=@id ";

            SqlParameter[] paras =
            {   new SqlParameter("@id",SqlDbType.Int){Value=id},

            };
            return DataProvider.executeNonQuery(addQuery, paras);
        }
    }
}