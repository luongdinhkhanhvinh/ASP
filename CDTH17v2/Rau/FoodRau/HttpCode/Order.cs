using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodRau.HttpCode
{
    public class Order
    {
        private int _orderID;
        private string _cusName;
        private string _cusPhone;
        private string _cusAdd;
        private int _quan;
        private decimal _sum;
        private int _status;
        private string _username;
        private DateTime _modified;
        private DateTime _created;
        private string _cusUserName;


        public Order()
        {
            OrderID = 0;
            CusName = "";
            CusPhone = "";
            CusAdd = "";
            Quan = 0;
            Sum = 0;
            Status = 0;
            Username = "";
            Modified = DateTime.Now;
            Created = DateTime.Now;
            CusUserName = "";
        }

        public Order(int OrderID, string cusName, string cusPhone, string cusAdd, int quan, decimal sum, int status, string username, DateTime modified, DateTime created, string cusUserName)
        {
            this.OrderID = OrderID;
            CusName = cusName;
            CusPhone = cusPhone;
            CusAdd = cusAdd;
            Quan = quan;
            Sum = sum;
            Status = status;
            Username = username;
            Modified = modified;
            Created = created;
            CusUserName = cusUserName;
        }

        public int OrderID { get => _orderID; set => _orderID = value; }
        public string CusName { get => _cusName; set => _cusName = value; }
        public string CusPhone { get => _cusPhone; set => _cusPhone = value; }
        public string CusAdd { get => _cusAdd; set => _cusAdd = value; }
        public int Quan { get => _quan; set => _quan = value; }
        public decimal Sum { get => _sum; set => _sum = value; }
        public int Status { get => _status; set => _status = value; }
        public string Username { get => _username; set => _username = value; }
        public DateTime Modified { get => _modified; set => _modified = value; }
        public DateTime Created { get => _created; set => _created = value; }
        public string CusUserName { get => _cusUserName; set => _cusUserName = value; }

        public int add()
        {
            string sQuery = "INSERT INTO [dbo].[order] ([cus_name] ,[cus_phone] ,[cus_add] ,[quan] ,[sum] ,[status] ,[username] ,[modified] ,[created] ,[cus_username]) VALUES (@cus_name,@cus_phone,@cus_add ,@quan,@sum,@status,@username,@modified,@created,@cus_username)";
            SqlParameter[] sParams =
            {
                new SqlParameter("@order_id",this.OrderID),
                new SqlParameter("@cus_name",this.CusName),
                new SqlParameter("@cus_add",this.CusAdd),
                new SqlParameter("@quan",this.Quan),
                new SqlParameter("@sum",this.Sum),
                new SqlParameter("@status",this.Status),
                new SqlParameter("@username",this.Username),
                new SqlParameter("@modified",this.Modified),
                new SqlParameter("@created",this.Created),
                new SqlParameter("@cus_username",this.CusUserName)
            };
            return DataProvider.executeScalar(sQuery,sParams);
        }
        public List<Order> getList()
        {
            string sQuery = "SELECT [order_id] ,[cus_name] ,[cus_phone] ,[cus_add] ,[quan] ,[sum] ,[status] ,[username] ,[modified] ,[created] ,[cus_username] FROM [dbo].[order] WHERE status=1 ";
            SqlParameter[] param = { };
            List<Order> o = new List<Order>();
            DataTable dt = DataProvider.getDataTable(sQuery, param);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(convertToObject(dr));
            }
            return o;
        }

        public bool update()
        {
            
            string sQuery = "UPDATE [dbo].[order] SET [cus_name] = @cus_name,[cus_phone] = @cus_phone,[cus_add] = @cus_add ,[quan] = @quan,[sum] = @sum,[status] = @status,[username] = @username,[modified] = @modified,[created] = @created ,[cus_username] = @cus_username WHERE order_id=@order_id";
            SqlParameter[] param =
            {
                new SqlParameter("@order_id",this.OrderID),
                new SqlParameter("@cus_name",this.CusName),
                new SqlParameter("@cus_phone",this.CusPhone),
                new SqlParameter("@cus_add",this.CusAdd),
                new SqlParameter("@quan",this.Quan),
                new SqlParameter("@sum",this.Sum),
                new SqlParameter("@status",this.Status),
                new SqlParameter("@username",this.Username),
                new SqlParameter("@modified",this.Modified),
                new SqlParameter("@created",this.Created),
                new SqlParameter("@cus_username",this.CusUserName)
            };
            return DataProvider.executeNonQuery(sQuery, param);
        }

        public bool delete()
        {
            string sQuery = "UPDATE [dbo].[order] SET [status] = 0 WHERE [order_id] = @order_id";
            SqlParameter[] param =
             {
                new SqlParameter("@order_id",this.OrderID),
            };
            return DataProvider.executeNonQuery(sQuery, param);
        }

        public List<Order> getList(string key)
        {
            string sQuery = "SELECT [order_id] ,[cus_name] ,[cus_phone] ,[cus_add] ,[quan] ,[sum] ,[status] ,[username] ,[modified] ,[created] ,[cus_username] FROM [dbo].[order] WHERE status=1 ";
            sQuery += " AND (([order_id] LIKE '%' + @order_id + '%')"
                + " OR ([cus_name] LIKE '%' + @cus_name + '%') "
                + " OR ([cus_phone] LIKE '%' + @cus_phone + '%') "
                + " OR ([cus_add] LIKE '%' + @cus_add + '%') "
                + " OR ([quan] LIKE '%' + @quan + '%') "
                + " OR ([sum] LIKE '%' + @sum + '%') "
                + " OR ([cus_username] LIKE '%' + @cus_username + '%') "
                + " OR ([username] LIKE '%' + @username + '%')) ";

            SqlParameter[] param = {
                new SqlParameter("@order_id",key),
                new SqlParameter("@cus_name",key),
                new SqlParameter("@cus_phone",key),
                new SqlParameter("@cus_add",key),
                new SqlParameter("@quan",key),
                new SqlParameter("@sum",key),
                new SqlParameter("@cus_username",key),
                new SqlParameter("@username",key)
            };
            List<Order> o = new List<Order>();
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

        public Order convertToObject(DataRow dr)
        {
            Order o = new Order();
            o.OrderID =Convert.ToInt32(dr["order_id"]);
            o.CusName = dr["cus_name"].ToString();
            o.CusPhone = dr["cus_phone"].ToString();
            o.CusAdd = dr["cus_add"].ToString();
            o.Quan =Convert.ToInt32(dr["quan"]);
            o.Sum = Convert.ToInt32(dr["sum"]);
            o.CusUserName = dr["cus_username"].ToString();
            o.Username = dr["username"].ToString();
            o.Status = Convert.ToInt32(dr["status"]);
            o.Created = Convert.ToDateTime(dr["created"]);
            o.Modified = Convert.ToDateTime(dr["modified"]);
            return o;
        }

    }
}