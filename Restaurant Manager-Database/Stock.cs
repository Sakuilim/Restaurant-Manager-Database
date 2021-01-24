﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Manager_Database
{
    class Stock
    {
        public void Add(List<int> stock_id, List<string> stock,List<string> unit, List<float> prt_cnt, List<float> prt_sze)
        {
            stock_id.Add(int.Parse(Console.ReadLine()));
            stock.Add(Console.ReadLine());
            prt_cnt.Add(float.Parse(Console.ReadLine()));
            unit.Add(Console.ReadLine());
            prt_sze.Add(float.Parse(Console.ReadLine()));
            addStock(stock_id[stock_id.Count-1], stock[stock_id.Count - 1], prt_cnt[stock_id.Count - 1], unit[stock_id.Count - 1], prt_sze[stock_id.Count - 1], "Stock.csv");
        }
        public void Update(List<int> stock_id, List<string> stock, List<string> unit, List<float> prt_cnt, List<float> prt_sze)
        {
            int sk = 0;
            int tmp = 0;
            sk = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < stock_id.Count; i++)
            {
                if (sk == stock_id[i])
                {
                    tmp = i;
                    stock[tmp] = Console.ReadLine();
                    prt_cnt[tmp] = float.Parse(Console.ReadLine());
                    unit[tmp] = Console.ReadLine();
                    prt_sze[tmp] = float.Parse(Console.ReadLine());
                    addStock(stock_id[tmp], stock[tmp], prt_cnt[tmp], unit[tmp], prt_sze[tmp],"Stock.csv");
                    break;
                }
                else if (i == stock_id.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                }
            }
        }
        public void Remove(List<int> stock_id, List<string> stock, List<string> unit, List<float> prt_cnt, List<float> prt_sze)
        {
            int sk = 0;
            int tmp = 0;
            sk = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<stock_id.Count;i++)
            {
                if(sk == stock_id[i])
                {
                    tmp = i;
                    stock_id.RemoveAt(tmp);
                    stock.RemoveAt(tmp);
                    prt_cnt.RemoveAt(tmp);
                    unit.RemoveAt(tmp);
                    prt_sze.RemoveAt(tmp);
                    break;
                }
                else if (i == stock_id.Count-1)
                {
                    Console.WriteLine("There's no such ID, try again");
                }
            }
        }
        public static void addStock(int ID, string name, float portion, string unit, float prtsize, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    file.WriteLine(ID + "," + name + "," + portion + "," + unit + "," + prtsize);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error", ex);
            }
        }
    }
}