using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Round round = new Round(5);
            round.GetInfo();

            rectangle rct = new rectangle(5, 10);
            rct.GetInfo();

            Console.ReadKey();

        }
    }
}
