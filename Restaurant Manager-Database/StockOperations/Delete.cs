﻿using Restaurant_Manager_Database.RestaurantData;
using System;
using System.Collections.Generic;

namespace Restaurant_Manager_Database.StockOperations
{
    public static class Delete
    {
        public static List<StockData> Remove(List<StockData> stockDataList)
        {

            int sk = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < stockDataList.Count; i++)
            {
                if (sk == stockDataList[i].stock_id)
                {
                    stockDataList.RemoveAt(i);
                }
                else if (i == stockDataList.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                }
            }
            return stockDataList;
        }

    }
}
