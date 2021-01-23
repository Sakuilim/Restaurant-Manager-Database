using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Restaurant_Manager_Database
{
    class Order
    {
        Data DT = new Data();
        public void Create(List<int> order_id,List<List<int>> order, List<int> menu_id, List<Tuple<string, List<int>>> menu, List<string> time, List<int> stock_id, List<string> stock, List<string> unit, List<float> prt_cnt, List<float> prt_sze)
        {
            int oid = int.Parse(Console.ReadLine());
            order_id.Add(oid);
            time.Add(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            int size = int.Parse(Console.ReadLine());
            {
                for(int j =0;j<size;j++)
                {
                    int sk = int.Parse(Console.ReadLine());
                    foreach (var id in menu_id)
                    {
                        if (sk == id)
                        {
                            order[order_id.Count+1].Add(sk);
                            for(int i=0;i< menu[sk].Item2.Count;i++)
                            {
                                for(int k=0;k<stock_id.Count;k++)
                                {
                                    if (menu[sk].Item2[i] == stock_id[k])
                                    {
                                        if(prt_cnt[k]<=0&& prt_cnt[k] - prt_sze[k]>0)
                                        {
                                            order_id.RemoveAt(order_id.Count + 1);
                                            time.RemoveAt(order_id.Count + 1);
                                            order.RemoveAt(order_id.Count + 1);
                                            break;
                                        }
                                        else
                                        {
                                            prt_cnt[k] = prt_cnt[k] - prt_sze[k];
                                        }
                                    }
                                    else
                                    {
                                        order_id.RemoveAt(order_id.Count + 1);
                                        time.RemoveAt(order_id.Count + 1);
                                        order.RemoveAt(order_id.Count + 1);
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("There's no such ID in menu, try again");
                            j--;
                        }
                    }
                }
            }
        }
        public void Complete(List<int> order_id, List<string> time, List<int> order)
        {
            int sk = int.Parse(Console.ReadLine());
            for(int i=0;i<order_id.Count;i++)
            {
                if(sk==order_id[i])
                {
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
        public void Cancel(List<int> order_id, List<string> time, List<int> order)
        {
            int sk = int.Parse(Console.ReadLine());
            for (int i = 0; i < order_id.Count; i++)
            {
                if (sk == order_id[i])
                {
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
    }
}
