using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodRau.HttpCode
{
    public class Slider
    {
        private int _slideID;
        private int _id_object;
        private string _img;
        private string _caption;
        private int _type;
        private int _rand;
        private int _status;
        private string _username;
        private DateTime _modified;

        public int SlideID { get => _slideID; set => _slideID = value; }
        public int Id_object { get => _id_object; set => _id_object = value; }
        public string Img { get => _img; set => _img = value; }
        public string Caption { get => _caption; set => _caption = value; }
        public int Type { get => _type; set => _type = value; }
        public int Rand { get => _rand; set => _rand = value; }
        public int Status { get => _status; set => _status = value; }
        public string Username { get => _username; set => _username = value; }
        public DateTime Modified { get => _modified; set => _modified = value; }

        public Slider()
        {
            _slideID = 0;
            _id_object = 0;
            _img = "10.jpg";
            _caption = "";
            _type = 0;
            _rand = 0;
            _status = 0;
            _username = "";
            _modified = DateTime.Now;
        }


        public Slider(int slideID, int id_object, string img, string caption, int type, int rand, int status, string username, DateTime modified)
        {
            _slideID = slideID;
            _id_object = id_object;
            _img = img;
            _caption = caption;
            _type = type;
            _rand = rand;
            _status = status;
            _username = username;
            _modified = modified;
        }

        public DataTable getList()
        {
            string sQuery = "SELECT [slide_id] ,[id_object] ,[slider].[img] ,[caption] ,[rank] ,[slider].[status] ,[slider].[username] ,[slider].[modified],post.title FROM [dbo].[slider],[dbo].post WHERE [id_object]=[post_id] AND [slider].status = 1";
            SqlParameter[] param = { };           
            return DataProvider.getDataTable(sQuery, param);
        }

        
    }
}