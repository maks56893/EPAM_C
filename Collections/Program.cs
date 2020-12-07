using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Phones p1 = new Phones(1, "Apple", "USA");
            Phones p2 = new Phones(2, "Samsug", "Korea");
            Phones p3 = new Phones(3, "Sony", "Japan");
            Phones p4 = new Phones(4, "Xiaomi", "China");
            Phones p5 = new Phones(5, "Motorola", "USA");
            Phones p6 = new Phones(6, "Google", "USA");

            List<Phones> list = new List<Phones>() { p1, p2, p3, p4, p5, p6 };
            List<Phones> sortList = list.Where(x => x.counry == "USA").ToList();

            try
            {
                Console.WriteLine("Введите целое число");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("------------------");
                Console.WriteLine(x);
            }
            catch(FormatException)
            {
                Console.WriteLine("Ошибка. Введены данные не целочисленного типа");
            }
            Console.ReadKey();
        }
    }
}
