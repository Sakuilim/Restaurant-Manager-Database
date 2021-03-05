using Restaurant_Manager_Database.RestaurantData;
using Restaurant_Manager_Database.TextFileProccesor;
using Restaurant_Manager_Database.UserInterface;
using System;
using System.Collections.Generic;

namespace Restaurant_Manager_Database
{
    public class UI
    {
        public bool WholeMenu(List<OrderData> orderData, List<StockData> stockData, List<MenuData> menuData)
        {
            Console.Clear();
            Console.WriteLine("Restaurant Manager:");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Use the Stock Manager");
            Console.WriteLine("2) Use the Menu Manager");
            Console.WriteLine("3) Use the Order Manager");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    
                    StockUI.StockMenu(stockData);
                    GenericTextProccesor.SaveToTextFile(StockDataAccess.stockData, "Stock.csv");
                    return true;
                case "2":
                    MenuUI.RestMenu(menuData,stockData);
                    GenericTextProccesor.SaveToTextFile(MenuDataAccess.menuData, "Menu.csv");
                    return true;
                case "3":
                    OrderUI.OrderMenu(orderData,menuData,stockData);
                    GenericTextProccesor.SaveToTextFile(OrderDataAccess.orderData, "Order.csv");
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
    }
}
