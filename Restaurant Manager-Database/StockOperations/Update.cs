using Restaurant_Manager_Database.RestaurantData;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Restaurant_Manager_Database.StockOperations
{
    public static class Update
    {
        public static List<StockData> UpdateList(List<StockData> stockDataList)
        {
            int sk = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < stockDataList.Count; i++)
            {
                if (sk == stockDataList[i].stock_id)
                {
                    stockDataList[i].stock_id = Convert.ToInt32(Console.ReadLine());
                    stockDataList[i].stock = Console.ReadLine();
                    stockDataList[i].prt_cnt = float.Parse(Console.ReadLine());
                    stockDataList[i].unit = Console.ReadLine();
                    stockDataList[i].prt_sze = float.Parse(Console.ReadLine());
                }
                else if (i == stockDataList.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                    Thread.Sleep(1000);
                }
            }
            return stockDataList;
        }
    }
}
