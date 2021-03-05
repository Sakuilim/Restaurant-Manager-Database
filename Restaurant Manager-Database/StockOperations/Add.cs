using Restaurant_Manager_Database.RestaurantData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Manager_Database.StockOperations
{
    public static class Add
    {
        public static List<StockData> AddToList(List<StockData> stockDataList)
        {
            StockData stockData = new StockData();
            stockData.stock_id = int.Parse(Console.ReadLine());
            stockData.stock = Console.ReadLine();
            stockData.prt_cnt = float.Parse(Console.ReadLine());
            stockData.unit = Console.ReadLine();
            stockData.prt_sze = float.Parse(Console.ReadLine());
            stockDataList.Add(stockData);
            return stockDataList;
        }
        public static void AddStock(int ID, string name, float portion, string unit, float prtsize, string filepath)
        {
            try
            {
                using System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true); 
                file.WriteLine(ID + "," + name + "," + portion + "," + unit + "," + prtsize);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error", ex);
            }
        }
    }
}
