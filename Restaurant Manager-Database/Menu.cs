using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Restaurant_Manager_Database
{
    class Menu
    {
        public void Add(List<int> menu_id, List<Tuple<string, List<int>>> menu, List<int> stock_id)
        {
            int cnt = 0;
            int id;
            bool stop = false;
            id = int.Parse(Console.ReadLine());
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
                                cnt++;
                            }
                           
                        }
                    }

                }
                if (stop == false&& cnt == size)
                {
                    menu_id.Add(id);
                    menu.Add(new Tuple<string, List<int>>(dish, prod));
                    addMenu(id, dish, prod, "Menu.csv");
                }
            }
            else
            {
                menu_id.RemoveAt(menu_id.Count-1);
            }
            

        }
        public void Update(List<int> menu_id, List<Tuple<string, List<int>>> menu, List<int> stock_id)
        {
            int cnt = 0;
            int sk = 0;
            int tmp = 0;
            sk = Convert.ToInt32(Console.ReadLine());
            string dish = Console.ReadLine();
            List<int> prod = new List<int>();
            int size = int.Parse(Console.ReadLine());
            for (int i = 0; i < menu_id.Count; i++)
            {
                if (sk == menu_id[i])
                {
                    tmp = i;
                    for (int j = 0; j < size; j++)
                    {
                        int sk2 = int.Parse(Console.ReadLine());
                        for (int k = 0; k < stock_id.Count; k++)
                        {
                            if (sk2 == stock_id[j])
                            {
                                prod.Add(sk2);
                                cnt++;
                            }
                        }
                    }
                }
                else if (i == menu_id.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                    Thread.Sleep(1000);
                }
            }
            if (cnt == size)
            {
                menu[tmp] = Tuple.Create(dish, prod);
                addMenu(sk, dish,prod,"Menu.csv");
            }
            else
            {
                Console.WriteLine("Error");
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
                    deleteMenu(menu_id[i],"Menu.csv",i);
                    break;
                }
                else if (i == menu_id.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                }
            }
        }
        public static void addMenu(int ID, string name, List<int> products, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    file.Write(ID + "," + name + ",");
                    foreach (var prod in products)
                    {
                        file.Write(prod);
                        file.Write(" ");
                    }
                    file.WriteLine();
                     
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error", ex);
            }
        }
        public static void deleteMenu(int ID, string filepath, int pos)
        {
            pos--;
            string tempfile = "temp.csv";
            bool deleted = false;
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@filepath);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    if (!(recordMatches(ID, fields, pos)) || deleted)
                    {
                        addMenu(int.Parse(fields[0]), fields[1], new List<int>(int.Parse(fields[2])), @tempfile);
                    }
                    else
                    {
                        deleted = true;
                        Console.WriteLine("Deleted!");
                    }
                }
                File.Delete(@filepath);
                System.IO.File.Move(tempfile, filepath);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error!", ex);
            }
        }
        public static bool recordMatches(int ID, string[] record, int pos)
        {
            if (record[pos].Equals(ID))
            {
                return true;
            }
            return false;
        }
    }
}
