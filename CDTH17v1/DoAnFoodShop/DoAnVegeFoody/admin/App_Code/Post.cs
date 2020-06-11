using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnVegeFoody.App_Code
{
    public class Post
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        private string _ShortDes;

        public string ShortDes
        {
            get { return _ShortDes; }
            set { _ShortDes = value; }
        }
        private string _Des;

        public string Des
        {
            get { return _Des; }
            set { _Des = value; }
        }
        private string _Img;

        public string Img
        {
            get { return _Img; }
            set { _Img = value; }
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
        private DateTime _Created;

        public DateTime Created
        {
            get { return _Created; }
            set { _Created = value; }
        }
        
    }
}