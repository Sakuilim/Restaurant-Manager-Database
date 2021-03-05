using Restaurant_Manager_Database.RestaurantData;
using Restaurant_Manager_Database.StockOperations;
using Restaurant_Manager_Database.TextFileProccesor;
using System;
using System.Collections.Generic;

namespace Restaurant_Manager_Database.UserInterface
{
    public class StockUI : StockDataAccess
    {
       
        public static bool StockMenu(List<StockData> stockData)
        {
            Console.Clear();
            Console.WriteLine("Stock Manager:");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add to the stock");
            Console.WriteLine("2) Remove from the stock");
            Console.WriteLine("3) Update the stock");
            Console.WriteLine("4) Exit");
            Console.WriteLine("Current Stock:");
            if (stockData.Count > 0)
            {
                foreach (var s in stockData)
                {
                    if (s != stockData[0])
                    {
                        Console.WriteLine($"{s.stock_id} {s.stock} {s.prt_cnt} {s.unit} {s.prt_sze}");
                    }
                }
            }
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Add.AddToList(stockData);
                   // GenericTextProccesor.SaveToTextFile<StockData>(stockData, "Stock.csv");
                    return true;
                case "2":
                    Delete.Remove(stockData);
                  //  GenericTextProccesor.SaveToTextFile<StockData>(stockData, "Stock.csv");
                    return true;
                case "3":
                    Update.UpdateList(stockData);
                  //  GenericTextProccesor.SaveToTextFile<StockData>(stockData, "Stock.csv");
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
    }
}
