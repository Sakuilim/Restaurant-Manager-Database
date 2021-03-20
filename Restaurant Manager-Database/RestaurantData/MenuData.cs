using System.Collections.Generic;

namespace Restaurant_Manager_Database.RestaurantData
{
    public class MenuData
    {
        public int menu_id { get; set; }
        public string name { get; set; }
        public List<int> menu { get; set; }

        public MenuData()
        {
            menu = new List<int>();
        }
    }
}
