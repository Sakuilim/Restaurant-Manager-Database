using Restaurant_Manager_Database.RestaurantData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Manager_Database.OrderOperations
{
    public class OrderCreate
    {
        public static List<OrderData> Create(List<OrderData> orderDataList, List<MenuData> menuDataList, List<StockData> stockDataList)
        {
            OrderData orderData = new OrderData();
            int cnt = 0;
            bool stop = false;
            orderData.time = DateTime.Now;
            orderData.order_id = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            {
                for (int j = 0; j < size; j++)
                {
                    int sk = int.Parse(Console.ReadLine());
                    for (int l = 0; l < menuDataList.Count; l++)
                    {
                        if (sk == menuDataList[l].menu_id)
                        {
                            orderData.order.Add(sk);
                            cnt++;
                            foreach (var id in menuDataList[l].menu)
                            {
                                for (int i = 0; i < stockDataList.Count; i++)
                                {
                                    if (id == stockDataList[i].stock_id)
                                    {
                                        if (stockDataList[i].prt_cnt > 0 && stockDataList[i].prt_cnt - stockDataList[i].prt_sze > 0)
                                        {
                                            stockDataList[i].prt_cnt = stockDataList[i].prt_cnt - stockDataList[i].prt_sze;
                                        }
                                        else
                                        {
                                            stop = true;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
                if (stop == false && cnt == size)
                {
                    orderDataList.Add(orderData);
                   
                }
                else
                {
                    Console.WriteLine("Error!");
                    Console.ReadLine();
                }
            }
            return orderDataList;
        }
    }
}
