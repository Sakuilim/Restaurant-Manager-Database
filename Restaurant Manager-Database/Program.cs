using System;

namespace Restaurant_Manager_Database
{
    class Program
    {

        private static void Main(string[] args)
        {
            UI uI = new UI();
            bool showMenu = true;
            while (showMenu)
            {

                showMenu = uI.WholeMenu();
            }
        }

    }
}
