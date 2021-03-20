using Restaurant_Manager_Database.RestaurantData;
using System;
using System.Collections.Generic;

namespace Restaurant_Manager_Database.OrderOperations
{
    public static class OrderComplete
    {
        public static List<OrderData> Complete(List<OrderData> orderDataList)
        {
            int sk = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < orderDataList.Count; i++)
            {
                if (sk == orderDataList[i].order_id)
                {
                    orderDataList.RemoveAt(i);
                    break;
                }
                else if (i == orderDataList.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                }
            }
            return orderDataList;
        }
    }
}
