using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Manager_Database.RestaurantData
{
    public class OrderData
    {

        public int order_id { get; set; }

        public DateTime time { get; set; }

        public List<int> order { get; set; }

        public OrderData()
        {
            order = new List<int>();
        }
    }
}
