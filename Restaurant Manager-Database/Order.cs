using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;
using System.IO;

namespace Restaurant_Manager_Database
{
    class Order : GlobalMethods
    {
        public void Create(List<int> order_id, List<List<int>> order, List<int> menu_id, List<Tuple<string, List<int>>> menu, List<string> time, List<int> stock_id, List<string> stock, List<string> unit, List<float> prt_cnt, List<float> prt_sze)
        {
            int cnt = 0;
            bool stop = false;
            List<int> dish = new List<int>();
            string tim = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            int oid = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            {
                for (int j = 0; j < size; j++)
                {
                    int sk = int.Parse(Console.ReadLine());
                    for (int l = 0; l < menu_id.Count; l++)
                    {
                        if (sk == menu_id[l])
                        {
                            dish.Add(sk);
                            cnt++;
                            foreach (var id in menu[l].Item2)
                            {
                                for (int i = 0; i < stock_id.Count; i++)
                                {
                                    if (id == stock_id[i])
                                    {
                                        if (prt_cnt[i] > 0 && prt_cnt[i] - prt_sze[i] > 0)
                                        {
                                            prt_cnt[i] = prt_cnt[i] - prt_sze[i];

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
                    order_id.Add(oid);
                    time.Add(tim);
                    order.Add(new List<int>(dish));
                    Add(oid, tim, dish, "Order.txt");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
        }
        public void Cancel(List<int> order_id, List<List<int>> order, List<int> menu_id, List<Tuple<string, List<int>>> menu, List<string> time, List<int> stock_id, List<string> stock, List<string> unit, List<float> prt_cnt, List<float> prt_sze)
        {
            int sk = int.Parse(Console.ReadLine());
            for (int i = 0; i < order_id.Count; i++)
            {
                if (sk == order_id[i])
                {
                    bool x = true;
                    for (int l = 0; l < order[i].Count; l++)
                    {
                        for (int j = 0; j < menu_id.Count; j++)
                        {
                            if (menu_id[j] == order[i][l])
                            {
                                for (int k = 0; k < menu[j].Item2.Count; k++)
                                {
                                    for (int z = 0; z < stock_id.Count; z++)
                                    {
                                        if (menu[j].Item2[k] == stock_id[z])
                                        {
                                            prt_cnt[z] = prt_cnt[z] + prt_sze[z];
                                            
                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                    if (x == true)
                    {
                        DeleteOrder(sk, "Order.txt", 0);
                        order_id.RemoveAt(i);
                        order.RemoveAt(i);
                        time.RemoveAt(i);
                    }

                }
                else if (i == order_id.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                }
               
            }
            
        }
        public void Complete(List<int> order_id, List<string> time, List<List<int>> order)
        {
            int sk = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < order_id.Count; i++)
            {
                if (sk == order_id[i])
                {
                    DeleteOrder(sk, "Order.txt", 0);
                    order_id.RemoveAt(i);
                    order.RemoveAt(i);
                    time.RemoveAt(i);
                    break;
                }
                else if (i == order_id.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                }
            }

        }
        public void DeleteOrder(int ID, string filepath, int pos)
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
                        Add(int.Parse(fields[0]), fields[1], new List<int>(int.Parse(fields[2])), @tempfile);
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
