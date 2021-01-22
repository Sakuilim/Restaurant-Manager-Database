using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Manager_Database
{
    class UI
    {
        Data D = new Data();
        Stock S = new Stock();
        Menu M = new Menu();
        public bool MainMenu()
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
                    S.Add(D.stock_id, D.stock,D.unit,D.prt_cnt,D.prt_sze);
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
        public void Show_stock()
        {
            int i = 0;
            foreach (var id in D.stock_id)
            {
                Console.Write(id);
                Console.WriteLine(D.stock[i]);
                i++;
            }
        }
        public bool RestMenu()
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
                    M.Add(D.menu_id, D.menu,D.stock_id);
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
        public void Show_menu()
        {
            int i = 0;
            if(D.menu_id.Count>0&&D.menu.Count>0)
            {
                foreach (var id in D.menu_id)
                {
                    Console.Write(id);
                    Console.Write(' ');
                    Console.Write(D.menu[i].Item1);
                    Console.Write(' ');
                    Console.Write(D.menu[i].Item2.Count);
                    for (int j = 0; j < D.menu[i].Item2.Count; j++)
                    {

                        Console.Write(D.menu[i].Item2[j]);
                        Console.Write(' ');
                    }
                    i++;
                }
            }
           
        }
    }
}
