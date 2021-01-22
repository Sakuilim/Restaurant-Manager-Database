using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Restaurant_Manager_Database
{
    class Order
    {
        Data DT = new Data();
        public void Create(List<int> order_id,List<int> order, List<int> menu_id, List<Tuple<string, List<int>>> menu, List<string> time, List<int> stock_id, List<string> stock, List<string> unit, List<float> prt_cnt, List<float> prt_sze)
        {
            order_id.Add(order_id.Count + 1);
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
                            order.Add(sk);
                            for(int i=0;i< menu[sk].Item2.Count;i++)
                            {
                                for(int k=0;k<stock_id.Count;k++)
                                {
                                    if (menu[sk].Item2[i] == stock_id[k])
                                    {
                                        if(prt_cnt[k]<=0)
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
    }
}
