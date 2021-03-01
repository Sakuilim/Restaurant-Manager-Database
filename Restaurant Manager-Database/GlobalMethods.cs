using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Restaurant_Manager_Database
{
    class GlobalMethods
    {

        protected bool RecordMatches(int ID, string[] record, int pos)
        {
            if (record[pos] == Convert.ToString(ID))
            {
                return true;
            }
            return false;
        }
        public static void Add(int ID, string time, List<int> products, string filepath)
        {
            try
            {
                using System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true);
                file.Write(ID + "," + time + ",");
                foreach (var prod in products)
                {
                    file.Write(prod);
                    file.Write(" ");
                }
                file.WriteLine();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error", ex);
            }
        }
        
    }
}
