using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodRau.HttpCode
{
    public class RelativePost
    {
        private int _food1ID;
        private int _food2ID;
        private string des;



        public RelativePost()
        {
            Food1ID = 0;
            Food2ID = 0;
            this.Des = "";
        }
        public RelativePost(int food1ID, int food2ID, string des)
        {
            Food1ID = food1ID;
            Food2ID = food2ID;
            this.Des = des;
        }

        public int Food1ID { get => _food1ID; set => _food1ID = value; }
        public int Food2ID { get => _food2ID; set => _food2ID = value; }
        public string Des { get => des; set => des = value; }
    }
}