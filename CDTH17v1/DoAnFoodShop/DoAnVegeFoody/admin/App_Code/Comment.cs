using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnVegeFoody.App_Code
{
    public class Comment
    {

        private int _Comment_Id;

        public int Comment_Id
        {
            get { return _Comment_Id; }
            set { _Comment_Id = value; }
        }
        private string _Cus_Name;

        public string Cus_Name
        {
            get { return _Cus_Name; }
            set { _Cus_Name = value; }
        }
        private string _Cus_Email;

        public string Cus_Email
        {
            get { return _Cus_Email; }
            set { _Cus_Email = value; }
        }
        private int _Post_Id;

        public int Post_Id
        {
            get { return _Post_Id; }
            set { _Post_Id = value; }
        }
        private int _Rep_Id;

        public int Rep_Id
        {
            get { return _Rep_Id; }
            set { _Rep_Id = value; }
        }
        private string _Des;

        public string Des
        {
            get { return _Des; }
            set { _Des = value; }
        }
        private int _Status;

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private DateTime _Created;

        public DateTime Created
        {
            get { return _Created; }
            set { _Created = value; }
        }
    }
}