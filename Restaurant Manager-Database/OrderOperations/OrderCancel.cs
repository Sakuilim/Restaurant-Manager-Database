using Restaurant_Manager_Database.RestaurantData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Manager_Database.OrderOperations
{
    public static class OrderCancel
    {
        public static List<OrderData> Cancel(List<OrderData> orderDataList, List<MenuData> menuDataList, List<StockData> stockDataList)
        {
            int sk = int.Parse(Console.ReadLine());
            for (int i = 0; i < orderDataList.Count; i++)
            {
                if (sk == orderDataList[i].order_id)
                {
                    bool x = true;
                    for (int l = 0; l < orderDataList[i].order.Count; l++)
                    {
                        for (int j = 0; j < menuDataList.Count; j++)
                        {
                            if (menuDataList[j].menu_id == orderDataList[i].order[l])
                            {
                                for (int k = 0; k < menuDataList[j].menu.Count; k++)
                                {
                                    for (int z = 0; z < stockDataList.Count; z++)
                                    {
                                        if (menuDataList[j].menu[k] == stockDataList[z].stock_id)
                                        {
                                            stockDataList[z].prt_cnt = stockDataList[z].prt_cnt + stockDataList[z].prt_sze;

                                        }
                                    }
                                }
                            }
                        }

                    }
                    if (x == true)
                    {
                        orderDataList.RemoveAt(i);
                    }

                }
                else if (i == orderDataList.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                }

            }
            return orderDataList;

        }
    }
}
