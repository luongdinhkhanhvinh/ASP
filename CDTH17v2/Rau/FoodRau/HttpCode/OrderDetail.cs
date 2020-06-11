using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodRau.HttpCode
{
    public class OrderDetail
    {
        private int _orderID;
        private int _foodID;
        private decimal _quan;
        private string _unit;
        private decimal _price;
        private decimal _total;
        private string _name;

        public int OrderID { get => _orderID; set => _orderID = value; }
        public int FoodID { get => _foodID; set => _foodID = value; }
        public decimal Quan { get => _quan; set => _quan = value; }
        public string Unit { get => _unit; set => _unit = value; }
        public decimal Price { get => _price; set => _price = value; }
        public decimal Total { get => _total; set => _total = value; }
        public string Name { get => _name; set => _name = value; }

        public OrderDetail()
        {
            OrderID = 0;
            FoodID = 0;
            Quan = 0;
            Unit = "";
            Price = 0;
            Total = 0;
            Name = "";
        }

        public OrderDetail(int orderID, int foodID, decimal quan, string unit, decimal price, decimal total, string name)
        {
            OrderID = orderID;
            FoodID = foodID;
            Quan = quan;
            Unit = unit;
            Price = price;
            Total = total;
            Name = name;
        }

        public bool add()
        {
            string sQuery = "INSERT INTO [dbo].[order_detail] ([order_id] ,[food_id] ,[quan] ,[unit] ,[price] ,[total]) VALUES (@order_id,@food_id,@quan,@unit,@price,@total)";
            SqlParameter[] sParams =
            {
                new SqlParameter("@order_id",this.OrderID),
                new SqlParameter("@food_id",this.FoodID),
                new SqlParameter("@quan",this.Quan),
                new SqlParameter("@unit",this.Unit),
                new SqlParameter("@price",this.Price),
                new SqlParameter("@total",this.Total)
            };
            return DataProvider.executeNonQuery(sQuery, sParams);
        }

       

        public bool update()
        {

            string sQuery = "UPDATE [dbo].[order_detail] SET [order_id] = @order_id,[food_id] =@food_id,[quan] = @quan,[unit] = @unit,[price] = @price,[total] = @total WHERE [order_id] = @order_id";
            SqlParameter[] param =
            {
                new SqlParameter("@order_id",this.OrderID),
                new SqlParameter("@food_id",this.FoodID),
                new SqlParameter("@quan",this.Quan),
                new SqlParameter("@unit",this.Unit),
                new SqlParameter("@price",this.Price),
                new SqlParameter("@total",this.Total)
            };
            return DataProvider.executeNonQuery(sQuery, param);
        }

        public List<OrderDetail> getList(int order_id)
        {
            string sQuery = "SELECT Name,[order_id] ,[food_id] ,[quan] ,[order_detail].[unit] ,[order_detail].[price] ,[total] FROM [dbo].[order_detail],food WHERE id=food_id AND";
            sQuery += " (([order_id] = @order_id))";

            SqlParameter[] param = {
                new SqlParameter("@order_id",order_id)
            };
            List<OrderDetail> o = new List<OrderDetail>();
            DataTable dt = DataProvider.getDataTable(sQuery, param);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    o.Add(convertToObject(dr));
                }
            }

            return o;
        }


        public OrderDetail convertToObject(DataRow dr)
        {
            OrderDetail o = new OrderDetail();
            o.OrderID = Convert.ToInt32(dr["order_id"]);
            o.FoodID = Convert.ToInt32(dr["food_id"]);
            o.Quan = Convert.ToInt32(dr["quan"]);
            o.Unit = dr["unit"].ToString();
            o.Price = Convert.ToInt32(dr["price"]);
            o.Total = Convert.ToInt32(dr["total"]);
            o.Name = dr["name"].ToString();
            return o;
        }


    }
}