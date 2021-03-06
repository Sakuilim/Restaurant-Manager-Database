﻿using Restaurant_Manager_Database.OrderOperations;
using Restaurant_Manager_Database.RestaurantData;
using Restaurant_Manager_Database.TextFileProccesor;
using System;
using System.Collections.Generic;

namespace Restaurant_Manager_Database.UserInterface
{
    public class OrderUI : OrderDataAccess
    {

        public static bool OrderMenu(List<OrderData> orderData, List<MenuData> menuData, List<StockData> stockData)
        {
            Console.Clear();
            Console.WriteLine("Order Manager:");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add an order");
            Console.WriteLine("2) Complete an Order");
            Console.WriteLine("3) Cancel an Order");
            Console.WriteLine("4) Exit");
            Console.WriteLine("Current Orders:");
            if (orderData.Count > 0)
            {
                foreach (OrderData o in orderData)
                {
                    if (o != orderData[0])
                    {
                        Console.Write($"{o.order_id} {o.time} ");
                        foreach (int sk1 in o.order)
                        {
                            Console.Write($"{sk1}");
                        }
                        Console.WriteLine();
                    }

                }
            }
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    OrderCreate.Create(OrderDataAccess.orderData, MenuDataAccess.menuData, stockData);
                    //  GenericTextProccesor.SaveToTextFile<OrderData>(orderData, "Order.csv");
                    return true;
                case "2":
                    OrderComplete.Complete(OrderDataAccess.orderData);
                    //   GenericTextProccesor.SaveToTextFile<OrderData>(orderData, "Order.csv");
                    return true;
                case "3":
                    OrderCancel.Cancel(OrderDataAccess.orderData, MenuDataAccess.menuData, StockDataAccess.stockData);
                    OrderComplete.Complete(OrderDataAccess.orderData);
                    //    GenericTextProccesor.SaveToTextFile<OrderData>(orderData, "Order.csv");
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
    }
}
