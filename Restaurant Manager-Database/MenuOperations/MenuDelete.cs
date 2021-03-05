using Restaurant_Manager_Database.RestaurantData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Restaurant_Manager_Database.MenuOperations
{
    public static class MenuDelete
    {
        public static List<MenuData> Remove(List<MenuData> menuDataList)
        {
            MenuData menuData = new MenuData();
            int sk = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < menuDataList.Count; i++)
            {
                if (sk ==  menuDataList[i].menu_id)
                {
                    menuDataList.RemoveAt(i);
                }
                else if (i == menuDataList.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                }
            }
            return menuDataList;
        }
        
    }
}
