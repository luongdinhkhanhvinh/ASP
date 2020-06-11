using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDTH17.Models.Entities
{
    public class DangNhap
    {
        string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        string _pass;

        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }       

    }
}

