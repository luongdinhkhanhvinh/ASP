using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodRau.HttpCode
{
    public class Customer
	{
        private string _username;
        private string _password;
        private string _name;
        private string _phone;
        private string _email;
		private string _address;
        private int _numOrder;
        private int _numSuccessfulOrder;
        private decimal _sum;
        private int _status;
        private DateTime _created;

		public string Username { get => _username; set => _username = value; }
		public string Password { get => _password; set => _password = value; }
		public string Name { get => _name; set => _name = value; }
		public string Phone { get => _phone; set => _phone = value; }
		public string Email { get => _email; set => _email = value; }
		public int NumOrder { get => _numOrder; set => _numOrder = value; }
		public int NumSuccessfulOrder { get => _numSuccessfulOrder; set => _numSuccessfulOrder = value; }
		public decimal Sum { get => _sum; set => _sum = value; }
		public int Status { get => _status; set => _status = value; }
		public DateTime Created { get => _created; set => _created = value; }
		public string Address { get => _address; set => _address = value; }

		public Customer()
        {
            Username = "";
            Password = "";
            Name = "";
            Phone = "";
			Address = "";
			Email = "";
            NumOrder = 0;
            NumSuccessfulOrder = 0;
            Sum = 0;
            Status = 0;
            Created = DateTime.Now;
        }

		public bool exist(string username)
		{
			string sQuery = "SELECT count(*) FROM customer WHERE username =@username";
			SqlParameter[] param =
			{
				new SqlParameter("@username",username)
			};
			return Convert.ToInt32(DataProvider.getDataTable(sQuery, param).Rows[0][0]) > 0;
		}

		public Customer getItem(string username)
		{
			string sQuery = "SELECT [username] ,[password] ,[name] ,[phone] ,[email] ,[address] ,[num_order] ,[num_successful_order] ,[sum] ,[status] ,[created] FROM [dbo].[customer] WHERE username=@username";
			SqlParameter[] param = {
				new SqlParameter("@username",username)
			};
			return convertToObject(DataProvider.getDataTable(sQuery, param).Rows[0]);
		}


		public Customer(string username, string password, string name, string phone, string email,string address, int numOrder, int numSuccessfulOrder, decimal sum, int status, DateTime created)
        {
            Username = username;
            Password = password;
            Name = name;
            Phone = phone;
            Email = email;
			Address = address;
			NumOrder = numOrder;
            NumSuccessfulOrder = numSuccessfulOrder;
            Sum = sum;
            Status = status;
            Created = created;
        }

		public List<Customer> getList()
		{
			string sQuery = "SELECT [username] ,[password] ,[name] ,[phone] ,[email] ,[address] ,[num_order] ,[num_successful_order] ,[sum] ,[status] ,[created] FROM [dbo].[customer] WHERE status=1 ";
			SqlParameter[] param = { };
			List<Customer> c = new List<Customer>();
			DataTable dt = DataProvider.getDataTable(sQuery, param);
			foreach (DataRow dr in dt.Rows)
			{
				c.Add(convertToObject(dr));
			}
			return c;
		}

		public bool add()
		{
			string sQuery = "INSERT INTO [dbo].[customer] ([username] ,[password] ,[name] ,[phone] ,[email] ,[address] ,[num_order] ,[num_successful_order] ,[sum] ,[status] ,[created]) VALUES (@username ,@password,@name,@phone,@email,@address,@num_order,@num_successful_order,@sum,@status,@created)";
			SqlParameter[] param =
			{
				new SqlParameter("@username",this._username),
				new SqlParameter("@password",StringProc.MD5Hash(this._password)),
				new SqlParameter("@name",this._name),
				new SqlParameter("@email",this._email),
				new SqlParameter("@phone",this._phone),
				new SqlParameter("@address",this._address),
				new SqlParameter("@num_order",this._numOrder),
				new SqlParameter("@num_successful_order",this._numSuccessfulOrder),
				new SqlParameter("@sum",this._sum),
				new SqlParameter("@status",this._status),
				new SqlParameter("@created",this._created)
			};

			return DataProvider.executeNonQuery(sQuery, param);
		}
		public bool update()
		{
			//string sQuery = "UPDATE [dbo].[customer] SET [password] = @password,[name] = @name,[phone] = @phone ,[email] = @email ,[address] = @address ,[num_order] = @num_order ,[num_successful_order] = @num_successful_order,[sum] = @sum,[status] = @status,[created] = @created WHERE username = @username";
			string sQuery = "UPDATE [dbo].[customer] SET [name] = @name,[phone] = @phone ,[email] = @email ,[address] = @address ,[status] = @status,[created] = @created WHERE username = @username";
			SqlParameter[] param =
			{
				new SqlParameter("@username",this._username),
				new SqlParameter("@name",this._name),
				new SqlParameter("@email",this._email),
				new SqlParameter("@phone",this._phone),
				new SqlParameter("@address",this._address),
				//new SqlParameter("@num_order",this._numOrder),
				//new SqlParameter("@num_successful_order",this._numSuccessfulOrder),
				//new SqlParameter("@sum",this._sum),
				new SqlParameter("@status",this._status),
				new SqlParameter("@created",this._created)
			};
			return DataProvider.executeNonQuery(sQuery, param);
		}

		public bool delete()
		{
			string sQuery = "UPDATE [dbo].[customer] SET [status] = 0 WHERE [username] = @username";
			SqlParameter[] param =
			 {
				new SqlParameter("@username",this._username)
			};
			return DataProvider.executeNonQuery(sQuery, param);
		}

		public List<Customer> getList(string key)
		{
			string sQuery = "SELECT [username] ,[password] ,[name] ,[phone] ,[email] ,[address] ,[num_order] ,[num_successful_order] ,[sum] ,[status] ,[created] FROM [dbo].[customer] WHERE status=1 ";
			sQuery += " AND (([username] LIKE '%' + @username + '%')"
				+ " OR ([name] LIKE '%' + @name + '%') "
				+ " OR ([phone] LIKE '%' + @phone + '%') "
				+ " OR ([email] LIKE '%' + @email + '%') "
				+ " OR ([address] LIKE '%' + @address + '%') "
				+ " OR ([num_order] LIKE '%' + @num_order + '%') "
				+ " OR ([num_successful_order] LIKE '%' + @num_successful_order + '%') "
				+ " OR ([sum] LIKE '%' + @sum + '%')) ";

			SqlParameter[] param = {
				new SqlParameter("@username",key),
				new SqlParameter("@name",key),
				new SqlParameter("@phone",key),
				new SqlParameter("@email",key),
				new SqlParameter("@address",key),
				new SqlParameter("@num_order",key),
				new SqlParameter("@num_successful_order",key),
				new SqlParameter("@sum",key)
			};
			List<Customer> ft = new List<Customer>();
			DataTable dt = DataProvider.getDataTable(sQuery, param);
			if (dt != null)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ft.Add(convertToObject(dr));
				}
			}

			return ft;
		}

		public Customer convertToObject(DataRow dr)
		{
			Customer c = new Customer();
			c.Username = dr["username"].ToString();
			c.Password = dr["password"].ToString();
			c.Name = dr["name"].ToString();
			c.Phone = dr["phone"].ToString();
			c.Email = dr["email"].ToString();
			c.Address = dr["address"].ToString();
			c.NumOrder = Convert.ToInt32(dr["num_order"]);
			c.NumSuccessfulOrder = Convert.ToInt32(dr["num_successful_order"]);
			c.Sum = Convert.ToInt32(dr["sum"]);
			c.Status = Convert.ToInt32(dr["status"]);
			c.Created = Convert.ToDateTime(dr["created"]);
			return c;
		}

	}
}