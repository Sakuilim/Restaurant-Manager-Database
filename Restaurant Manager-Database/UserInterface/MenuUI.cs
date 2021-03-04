using Restaurant_Manager_Database.MenuOperations;
using Restaurant_Manager_Database.RestaurantData;
using Restaurant_Manager_Database.TextFileProccesor;
using System;
using System.Collections.Generic;

namespace Restaurant_Manager_Database.UserInterface
{
    public class MenuUI : MenuDataAccess
    {

        public static bool RestMenu(List<MenuData> menuData, List<StockData> stockData)
        {
            Console.Clear();
            Console.WriteLine("Menu Manager:");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add to the menu");
            Console.WriteLine("2) Remove from the menu");
            Console.WriteLine("3) Update the menu");
            Console.WriteLine("4) Exit");
            Console.WriteLine("Current Menu:");
            if (menuData.Count > 0)
            {
                foreach (var m in menuData)
                {
                    Console.Write($"{m.menu_id} {m.name} ");
                    foreach (int sk in m.menu)
                    {
                        Console.Write($"{sk}");
                    }
                    Console.WriteLine();
                }
            }
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    MenuAdd.Add(menuData, stockData);
                    GenericTextProccesor.SaveToTextFile<MenuData>(menuData, "Menu.csv");
                    return true;
                case "2":
                    MenuDelete.Remove(menuData);
                    GenericTextProccesor.SaveToTextFile<MenuData>(menuData, "Menu.csv");
                    return true;
                case "3":
                    MenuUpdate.Update(menuData, stockData);
                    GenericTextProccesor.SaveToTextFile<MenuData>(menuData, "Menu.csv");
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }

    }
}
