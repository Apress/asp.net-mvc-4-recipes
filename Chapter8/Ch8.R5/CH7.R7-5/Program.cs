using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH7.R7_5
{
    class Program
    {
        static void Main(string[] args)
        {
            sayWassup().Wait();
        }
        private async static Task sayWassup()
        {
            Console.WriteLine("Wassup...... World");
        }

    }
}
