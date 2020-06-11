using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoAnVegeFoody.App_Code
{
    public class clsFoodType
    {
        private int _Type_Id;

        public int Type_Id
        {
            get { return _Type_Id; }
            set { _Type_Id = value; }
        }
        private string _Type_Name;

        public string Type_Name
        {
            get { return _Type_Name; }
            set { _Type_Name = value; }
        }
        private string _Type_Img;

        public string Type_Img
        {
            get { return _Type_Img; }
            set { _Type_Img = value; }
        }
        private int _Type_Pos;

        public int Type_Pos
        {
            get { return _Type_Pos; }
            set { _Type_Pos = value; }
        }
        private int _Status;

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private DateTime _Modified;

        public DateTime Modified
        {
            get { return _Modified; }
            set { _Modified = value; }
        }
        public bool AddFoodType()
        {
            String sQuery = "INSERT INTO [dbo].[food_type]([type_name],[type_pos],[type_img],[status],[username],[modified]) VALUES (@type_name, @type_pos, @type_img, @status, @username, @modified)";

            SqlParameter[] sqlParas = {
                                     new SqlParameter("@type_name",SqlDbType.VarChar,50) {Value = this.Type_Name },
                                     new SqlParameter("@type_pos",SqlDbType.Int) {Value = this.Type_Pos},
                                     new SqlParameter("@type_img",SqlDbType.VarChar, 255) {Value = this.Type_Img},
                                     new SqlParameter("@status",SqlDbType.Int) {Value = this.Status },
                                     new SqlParameter("@username",SqlDbType.VarChar,50){Value = this.UserName},
                                     new SqlParameter("@modified",SqlDbType.DateTime){Value = this.Modified}
                                     };

            return DataProvider.executeNonQuery(sQuery, sqlParas);
        }
        public bool UpdateFoodType(int id)
        {
            String sQuery = "UPDATE [dbo].[food_type] SET [type_name] = @type_name, [type_pos] = @type_pos, [type_img] = @type_img, [status] = @status, [username] = @username, [modified] = @modified WHERE [type_id] = " + id;

            SqlParameter[] sqlParas = {
                                     new SqlParameter("@type_id",SqlDbType.Int) {Value = id },
                                     new SqlParameter("@type_name",SqlDbType.VarChar,50) {Value = this.Type_Name },
                                     new SqlParameter("@type_pos",SqlDbType.Int) {Value = this.Type_Pos},
                                     new SqlParameter("@type_img",SqlDbType.VarChar, 255) {Value = this.Type_Img},
                                     new SqlParameter("@status",SqlDbType.Int) {Value = this.Status },
                                     new SqlParameter("@username",SqlDbType.VarChar,50){Value = this.UserName},
                                     new SqlParameter("@modified",SqlDbType.DateTime){Value = this.Modified}
                                     };

            return DataProvider.executeNonQuery(sQuery, sqlParas);
        }
        public clsFoodType(string sType_Name, string sType_Img, int sType_Pos, int iStatus, string sUserName, DateTime dtModified)
        {
            _Type_Name = sType_Name;
            _Type_Img = sType_Img;
            _Type_Pos = sType_Pos;
            _Status = iStatus;
            _UserName = sUserName;
            _Modified = dtModified;
        }
        public clsFoodType(){}
    }
}