using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Restaurant_Manager_Database
{
    class Stock
    {
        public void Add(List<int> stock_id, List<string> stock, List<string> unit, List<float> prt_cnt, List<float> prt_sze)
        {
            stock_id.Add(int.Parse(Console.ReadLine()));
            stock.Add(Console.ReadLine());
            prt_cnt.Add(float.Parse(Console.ReadLine()));
            unit.Add(Console.ReadLine());
            prt_sze.Add(float.Parse(Console.ReadLine()));
            AddStock(stock_id[stock_id.Count - 1], stock[stock_id.Count - 1], prt_cnt[stock_id.Count - 1], unit[stock_id.Count - 1], prt_sze[stock_id.Count - 1], "Stock.txt");
        }
        public void Update(List<int> stock_id, List<string> stock, List<string> unit, List<float> prt_cnt, List<float> prt_sze)
        {
            int sk = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < stock_id.Count; i++)
            {
                if (0 == stock_id[i])
                {
                    int tmp = i;
                    DeleteStock(stock_id[i], "Stock.txt", 0);
                    stock[tmp] = Console.ReadLine();
                    prt_cnt[tmp] = float.Parse(Console.ReadLine());
                    unit[tmp] = Console.ReadLine();
                    prt_sze[tmp] = float.Parse(Console.ReadLine());
                    AddStock(stock_id[tmp], stock[tmp], prt_cnt[tmp], unit[tmp], prt_sze[tmp], "Stock.txt");
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
            for (int i = 0; i < stock_id.Count; i++)
            {
                if (sk == stock_id[i])
                {
                    DeleteStock(stock_id[i], "Stock.txt", 0);
                    tmp = i;

                    stock_id.RemoveAt(tmp);
                    stock.RemoveAt(tmp);
                    prt_cnt.RemoveAt(tmp);
                    unit.RemoveAt(tmp);
                    prt_sze.RemoveAt(tmp);
                }
                else if (i == stock_id.Count - 1)
                {
                    Console.WriteLine("There's no such ID, try again");
                }
            }
        }
        public static void AddStock(int ID, string name, float portion, string unit, float prtsize, string filepath)
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
        public static void DeleteStock(int stock_id, string filepath, int pos)
        {
            string tempfile = "temp.txt";
            bool deleted = false;
            {

                string[] lines = System.IO.File.ReadAllLines(@filepath);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    if (RecordMatches(stock_id, fields, pos) == false || deleted)
                    {
                        AddStock(int.Parse(fields[0]), fields[1], float.Parse(fields[2]), fields[3], float.Parse(fields[4]), @tempfile);
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
        public static bool RecordMatches(int ID, string[] record, int pos)
        {
            if (record[pos] == Convert.ToString(ID))
            {
                return true;
            }
            return false;
        }
    }
}
