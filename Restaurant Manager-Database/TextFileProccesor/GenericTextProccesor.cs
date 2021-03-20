using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Restaurant_Manager_Database.TextFileProccesor
{
    public static class GenericTextProccesor
    {
        public static List<T> LoadFromTextFile<T>(string filePath) where T : class, new()
        {
            List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();

            //Console.WriteLine(lines);
            List<T> output = new List<T>();
            T entry = new T();
            PropertyInfo[] cols = entry.GetType().GetProperties();

            if (lines.Count < 1)
            {
                throw new IndexOutOfRangeException("The file was either empty or missing");
            }
            string[] headers = lines[0].Split(',');

            lines.RemoveAt(0);

            foreach (string row in lines)
            {
                entry = new T();

                string[] vals = row.Split(',');

                for (int i = 0; i < headers.Length; i++)
                {
                    foreach (PropertyInfo col in cols)
                    {

                        if (col.Name == headers[i])
                        {
                            {

                                if (col.PropertyType != typeof(List<int>))
                                {
                                    col.SetValue(entry, Convert.ChangeType(vals[i], col.PropertyType));
                                }
                                else
                                {
                                    List<int> list = vals[i].Split(' ').Select(n => Convert.ToInt32(n)).ToList();
                                    if (list != null)
                                    {
                                        col.SetValue(entry, list);
                                    }

                                }

                            }

                        }
                    }
                }

                output.Add(entry);
            }
            return output;
        }
        public static void SaveToTextFile<T>(List<T> data, string filePath) where T : class
        {
            List<string> lines = new List<string>();
            StringBuilder line = new StringBuilder();

            if (data == null || data.Count == 0)
            {
                throw new ArgumentNullException("data", "You must populate the data parameter with at least one value.");
            }

            PropertyInfo[] cols = data[0].GetType().GetProperties();



            // Loops through each column and gets the name so it can comma 
            // separate it into the header row.
            foreach (PropertyInfo col in cols)
            {
                line.Append(col.Name);
                line.Append(",");
            }
            // Adds the column header entries to the first line (removing
            // the last comma from the end first).
            lines.Add(line.ToString().Substring(0, line.Length - 1));

            foreach (T row in data)
            {
                line = new StringBuilder();
                foreach (PropertyInfo col in cols)
                {
                    if (col.PropertyType != typeof(List<int>))
                    {
                        line.Append(col.GetValue(row));
                        line.Append(",");
                    }
                    else
                    {
                        List<int> list = col.GetValue(row, null) as List<int>;
                        if (list != null)
                        {
                            foreach (int l in list)
                            {
                                line.Append(l);
                                line.Append(" ");
                            }
                        }
                    }
                }
                // Adds the row to the set of lines (removing
                // the last comma from the end first).
                {
                    lines.Add(line.ToString().Substring(0, line.Length - 1));

                }
            }
            System.IO.File.WriteAllLines(filePath, lines);
        }
    }
}
