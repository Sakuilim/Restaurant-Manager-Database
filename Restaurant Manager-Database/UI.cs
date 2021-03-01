using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Manager_Database
{
    public class UI
    {
        Data D = new Data();
        Stock S = new Stock();
        Menu M = new Menu();
        Order O = new Order();
        private bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Stock Manager:");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add to the stock");
            Console.WriteLine("2) Remove from the stock");
            Console.WriteLine("3) Update the stock");
            Console.WriteLine("4) Exit");
            Console.WriteLine("Current Stock:");
            Show_stock();
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    S.Add(D.stock_id, D.stock, D.unit, D.prt_cnt, D.prt_sze);
                    return true;
                case "2":
                    S.Remove(D.stock_id, D.stock, D.unit, D.prt_cnt, D.prt_sze);
                    return true;
                case "3":
                    S.Update(D.stock_id, D.stock, D.unit, D.prt_cnt, D.prt_sze);
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
        private void Show_stock()
        {
            int i = 0;
            foreach (var id in D.stock_id)
            {
                Console.Write(id);
                Console.Write(" ");
                Console.Write(D.stock[i]);
                Console.Write(" ");
                Console.Write(D.prt_cnt[i]);
                Console.Write(" ");
                Console.Write(D.unit[i]);
                Console.Write(" ");
                Console.Write(D.prt_sze[i]);
                Console.Write(" ");
                Console.WriteLine();
                i++;
            }
        }
        private bool RestMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu Manager:");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add to the menu");
            Console.WriteLine("2) Remove from the menu");
            Console.WriteLine("3) Update the menu");
            Console.WriteLine("4) Exit");
            Console.WriteLine("Current Menu:");
            Show_menu();
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    M.Add(D.menu_id, D.menu, D.stock_id);
                    return true;
                case "2":
                    M.Remove(D.menu_id, D.menu, D.stock_id);
                    return true;
                case "3":
                    M.Update(D.menu_id, D.menu, D.stock_id);
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
        private void Show_menu()
        {
            int i = 0;
            if (D.menu_id.Count > 0 && D.menu.Count > 0)
            {
                foreach (var id in D.menu_id)
                {
                    Console.Write(id);
                    Console.Write(' ');
                    Console.Write(D.menu[i].Item1);
                    Console.Write(' ');
                    for (int j = 0; j < D.menu[i].Item2.Count; j++)
                    {

                        Console.Write(D.menu[i].Item2[j]);
                        Console.Write(' ');
                    }
                    i++;
                }
            }

        }
        private bool OrderMenu()
        {
            Console.Clear();
            Console.WriteLine("Order Manager:");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add an order");
            Console.WriteLine("2) Complete an Order");
            Console.WriteLine("3) Cancel an Order");
            Console.WriteLine("4) Exit");
            Console.WriteLine("Current Orders:");
            Order_menu();
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    O.Create(D.order_id, D.order, D.menu_id, D.menu, D.time, D.stock_id, D.stock, D.unit, D.prt_cnt, D.prt_sze);
                    return true;
                case "2":
                    O.Complete(D.order_id, D.time, D.order);
                    return true;
                case "3":
                    O.Cancel(D.order_id, D.order, D.menu_id, D.menu, D.time, D.stock_id, D.stock, D.unit, D.prt_cnt, D.prt_sze);
                    O.Complete(D.order_id, D.time, D.order);
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
        private void Order_menu()
        {
            for (int i = 0; i < D.order_id.Count; i++)
            {
                Console.Write(D.order_id[i]);
                Console.Write(" ");
                Console.Write(D.time[i]);
                Console.Write(" ");
                Console.WriteLine(D.order[i].Count);
                Console.WriteLine();

            }

        }
        public bool WholeMenu()
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
                    MainMenu();
                    return true;
                case "2":
                    RestMenu();
                    return true;
                case "3":
                    OrderMenu();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
    }
}
