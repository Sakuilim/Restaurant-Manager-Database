using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Restaurant_Manager_Database
{
    class Menu : GlobalMethods
    {
        //GlobalMethods GB = new GlobalMethods();
        public void Add(List<int> menu_id, List<Tuple<string, List<int>>> menu, List<int> stock_id)
        {
            int cnt = 0;
            bool stop = false;
            int id = int.Parse(Console.ReadLine());
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
                if (stop == false && cnt == size)
                {
                    menu_id.Add(id);
                    menu.Add(new Tuple<string, List<int>>(dish, prod));
                    AddMenu(id, dish, prod, "Menu.txt");
                }
            }
            else
            {
                menu_id.RemoveAt(menu_id.Count - 1);
            }
        }
        public void Update(List<int> menu_id, List<Tuple<string, List<int>>> menu, List<int> stock_id)
        {
            int sk = Convert.ToInt32(Console.ReadLine());
            int cnt = 0;
            Console.WriteLine(menu.Count);
            for (int i = 0; i < menu_id.Count; i++)
            {
                if (sk == menu_id[i])
                {
                   
                    string dish = Console.ReadLine();
                    List<int> prod = new List<int>();
                    int size = int.Parse(Console.ReadLine());
                    for (int j = 0; j < size; j++)
                    {
                        int sk2 = int.Parse(Console.ReadLine());
                       // for (int k = 0; k < stock_id.Count; k++)
                        {
                            if (size > stock_id.Count)
                            {
                                Console.WriteLine("Size is more than the size of stock");
                                break;
                            }
                            if (sk2 == stock_id[j])
                            {
                                prod.Add(sk2);
                                cnt++;
                            }
                        }
                    }
                    if (cnt == size)
                    {
                        menu[sk-1] = Tuple.Create(dish, prod);
                        DeleteMenu(sk, "Menu.txt", 0);
                        AddMenu(sk, dish, prod, "Menu.txt");
                    }
                }
            }
        }
        public void Remove(List<int> menu_id, List<Tuple<string, List<int>>> menu, List<int> stock_id)
        {
            int sk = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < menu_id.Count; i++)
            {
                if (sk == menu_id[i])
                {
                    DeleteMenu(menu_id[i], "Menu.txt", 0);
                    menu.RemoveAt(i);
                    menu_id.RemoveAt(i);
                }
                else if (i == menu_id.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                }
            }
        }
        public static void AddMenu(int ID, string name, List<int> products, string filepath)
        {
            try
            {
                using System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true);
                file.Write(ID + "," + name + ",");
                foreach (var prod in products)
                {
                    file.Write(prod);
                    file.Write(",");
                }
                file.WriteLine();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error", ex);
            }
        }
        public void DeleteMenu(int ID, string filepath, int pos)
        {
            string tempfile = "temp.txt";
            bool deleted = false;
            {
                string[] lines = System.IO.File.ReadAllLines(@filepath);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    if (RecordMatches(ID, fields, pos) == false || deleted)
                    {
                        AddMenu(int.Parse(fields[0]), fields[1], new List<int>(int.Parse(fields[2])), @tempfile);
                    }
                    else
                    {
                        deleted = true;     
                        Console.WriteLine("Deleted!");
                    }
                }
                if (lines.Length > 1)
                {
                    File.Delete(@filepath);
                    System.IO.File.Move(tempfile, filepath);
                }
                else
                {
                    File.Create(filepath).Close();
                }
            }
        }
    }
}
