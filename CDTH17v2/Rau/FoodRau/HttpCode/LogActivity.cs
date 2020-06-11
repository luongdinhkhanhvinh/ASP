using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodRau.HttpCode
{
    public class LogActivity
    {
        private int _logID;
        private string _username;
        private string _description;
        private DateTime _timeLog;
        private int _type;


        public LogActivity()
        {
            _logID = 0;
            _username = "";
            _description = "";
            _timeLog = DateTime.Now;
            _type = 0;
        }
        public LogActivity(int logID, string username, string description, DateTime timeLog, int type)
        {
            _logID = logID;
            _username = username;
            _description = description;
            _timeLog = timeLog;
            _type = type;
        }
    }
}