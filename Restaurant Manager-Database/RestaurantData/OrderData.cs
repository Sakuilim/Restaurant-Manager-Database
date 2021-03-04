using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Manager_Database.RestaurantData
{
    public class OrderData
    {

        public int order_id { get; set; }

        public string time { get; set; }

        public List<int> order { get; set; }
    }
}
