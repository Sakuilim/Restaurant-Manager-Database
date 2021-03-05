
using Restaurant_Manager_Database.RestaurantData;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Restaurant_Manager_Database.MenuOperations
{
    public static class MenuAdd
    {
        public static List<MenuData> Add(List<MenuData> menuDataList, List<StockData> stockDataList)
        {
            MenuData menuItem = new MenuData();
            menuItem.menu_id = int.Parse(Console.ReadLine());
            menuItem.name = Console.ReadLine();
            int cnt = 0;
            bool stop = false;
            int size = int.Parse(Console.ReadLine());
            List<int> prod = new List<int>();
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    int sk = int.Parse(Console.ReadLine());
                    if (stockDataList.Count <= 0)
                    {
                        Console.WriteLine("There's no such ID in menu, try again");
                        Thread.Sleep(1000);
                        stop = true;
                        break;
                    }
                    else
                    {
                        for (int j = 0; j < stockDataList.Count; j++)
                        {
                            if (sk == stockDataList[j].stock_id)
                            {
                                prod.Add(sk);
                                cnt++;
                            }

                        }
                    }
                }
                if (stop == false && cnt == size)
                {
                    menuItem.menu = prod;
                    menuDataList.Add(menuItem);
                }
            }
            else
            {
                menuDataList.RemoveAt(menuDataList.Count - 1);
            }
            return menuDataList;
        }
    }
}
