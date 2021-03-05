using Restaurant_Manager_Database.RestaurantData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Manager_Database.MenuOperations
{
    public class MenuUpdate
    {
        public static List<MenuData> Update(List<MenuData> menuDataList, List<StockData> stockDataList)
        {
            int sk = Convert.ToInt32(Console.ReadLine());
            int cnt = 0;
            MenuData menuData = new MenuData();
            menuData.menu_id = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < menuDataList.Count; i++)
            {
                if (sk == menuDataList[i].menu_id)
                {
                    menuData.name = Console.ReadLine();
                    List<int> prod = new List<int>();
                    int size = int.Parse(Console.ReadLine());
                    for (int j = 0; j < size; j++)
                    {
                        int sk2 = int.Parse(Console.ReadLine());
                        for (int k = 0; k < stockDataList.Count; k++)
                        {
                            if (size > stockDataList.Count)
                            {
                                Console.WriteLine("Size is more than the size of stock");
                                break;
                            }
                            if (sk2 == stockDataList[k].stock_id)
                            {
                                menuData.menu.Add(sk2);
                                cnt++;
                            }
                        }
                    }
                    if (cnt == size)
                    {
                        menuDataList[i] = menuData;
                    }
                }
            }
            return menuDataList;
        }
    }
}
