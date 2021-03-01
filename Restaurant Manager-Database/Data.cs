using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Restaurant_Manager_Database
{
    public class Data
    {
        public List<int> stock_id = new List<int>();
        public List<float> prt_cnt = new List<float>();
        public List<float> prt_sze = new List<float>();
        public List<string> stock = new List<string>();
        public List<string> unit = new List<string>();

        public List<int> menu_id = new List<int>();
        public List<Tuple<string, List<int>>> menu = new List<Tuple<string, List<int>>>();

        public List<int> order_id = new List<int>();
        public List<string> time = new List<string>();
        public List<List<int>> order = new List<List<int>>();

    }
}
