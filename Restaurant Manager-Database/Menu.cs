using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Restaurant_Manager_Database
{
    class Menu
    {
        public void Add(List<int> menu_id, List<Tuple<string, List<int>>> menu, List<int> stock_id)
        {
            bool stop = false;
            menu_id.Add(int.Parse(Console.ReadLine()));
            string dish = Console.ReadLine();
            int size = int.Parse(Console.ReadLine());
            List<int> prod = new List<int>();
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    int sk = int.Parse(Console.ReadLine());
                    if (stock_id.Count <= 0)
                    {
                        Console.WriteLine("There's no such ID in menu, try again");
                        Thread.Sleep(1000);
                        stop = true;
                        break;
                    }
                    else
                    {
                        for (int j = 0; j < stock_id.Count; j++)
                        {
                            if (sk == stock_id[j])
                            {
                                prod.Add(sk);
                            }
                            else
                            {
                                Console.WriteLine("There's no such ID in menu, try again");
                                Thread.Sleep(1000);
                                stop = true;
                                break;
                            }
                        }
                    }

                }
                if (stop == false)
                {
                    menu.Add(new Tuple<string, List<int>>(dish, prod));
                }
            }
            else
            {
                menu_id.RemoveAt(menu_id.Count-1);
            }
            

        }
        public void Update(List<int> menu_id, List<Tuple<string, List<int>>> menu, List<int> stock_id)
        {
            int sk = 0;
            int tmp = 0;
            sk = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < menu_id.Count; i++)
            {
                if (sk == menu_id[i])
                {
                    tmp = i;
                    string dish = Console.ReadLine();
                    int size = int.Parse(Console.ReadLine());
                    List<int> prod = new List<int>();
                    for (int j = 0; j < size; j++)
                    {
                        int sk2 = int.Parse(Console.ReadLine());
                        for (int k = 0; k < stock_id.Count; k++)
                        {
                            if (sk2 == stock_id[j])
                            {
                                prod.Add(sk2);
                            }
                            else
                            {
                                Console.WriteLine("There's no such ID in menu, try again");
                                Thread.Sleep(1000);
                                menu.RemoveAt(menu_id.Count-1);
                                menu_id.RemoveAt(menu_id.Count-1);
                                break;
                            }
                        }
                        
                    }
                    menu[tmp] = Tuple.Create(dish, prod);
                    
                }
                else if (i == menu_id.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                    Thread.Sleep(1000);
                }
            }
            
        }
        public void Remove(List<int> menu_id, List<Tuple<string, List<int>>> menu, List<int> stock_id)
        {
            int sk = 0;
            int tmp = 0;
            sk = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < menu_id.Count; i++)
            {
                if (sk == menu_id[i])
                {
                    tmp = i;
                    menu.RemoveAt(tmp);
                    menu_id.RemoveAt(tmp);
                    break;
                }
                else if (i == menu_id.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                }
            }
            
        }
    }
}
