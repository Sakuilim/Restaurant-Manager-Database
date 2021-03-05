using Restaurant_Manager_Database.RestaurantData;
using Restaurant_Manager_Database.TextFileProccesor;
using System;

namespace Restaurant_Manager_Database
{
    class Program
    {
        private static void Main(string[] args)
        {
            StockDataAccess.stockData = GenericTextProccesor.LoadFromTextFile<StockData>("Stock.csv");
            MenuDataAccess.menuData = GenericTextProccesor.LoadFromTextFile<MenuData>("Menu.csv");
            OrderDataAccess.orderData = GenericTextProccesor.LoadFromTextFile<OrderData>("Order.csv");
            UI uI = new UI();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = uI.WholeMenu(OrderDataAccess.orderData,StockDataAccess.stockData, MenuDataAccess.menuData);
            }
        }

    }
}
