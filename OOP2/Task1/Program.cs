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
            Round<int> round = new Round<int>(5, 0, 0); // Обобщенный класс с типом данных int
            Round<string> round1 = new Round<string>(10, "1", "1"); // Обобщенный класс с типом данных string
            Round<int> round2 = new Round<int>(5, 2, 2);
            Console.WriteLine(round.ToString()); // Заменил метод GetInfo на переопределнный метод ToString
            Console.WriteLine(round.Equals(round1));
            Console.WriteLine(round.Equals(round2));
            Console.WriteLine("-------------------------------");

            rectangle rct = new rectangle(5, 10);
            rectangle rct1 = new rectangle(50, 100);
            rectangle rct2 = new rectangle(5, 10);
            Console.WriteLine(rct.ToString()); // Заменил метод GetInfo на переопределнный метод ToString
            Console.WriteLine(rct.Equals(rct1));
            Console.WriteLine(rct.Equals(rct2));

            Console.ReadKey();

        }
    }
}
