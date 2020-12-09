using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatingBillForProducts
{
    class ConsoleOutput : ConsoleManager
    {
        public static void Main(string[] args)
        {
            ConsoleManager consoleManager = new ConsoleManager();
            consoleManager.DisplayMenu();
            consoleManager.GetTotalBill();
        }
    }






}

