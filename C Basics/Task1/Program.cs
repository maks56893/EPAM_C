using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_Basics
{
    class Program
    {
        static void Swap(ref int x1, ref int x2)
        {
            int temp = x1;
            x1 = x2;
            x2 = temp;
        }
        static void Main(string[] args)
        {
            int[] array = new int[] { 5, 15, 34, 1, 76, 150, 46, 43 };
            Console.WriteLine("---------------");
            Console.WriteLine("Инициаллизированный массив");
            Console.WriteLine("---------------");
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        Swap(ref array[j], ref array[i]);

                    }
                }
            }
            Console.WriteLine("---------------");
            Console.WriteLine("Отсортированный массив");
            Console.WriteLine("---------------");

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadKey();
        }
        
    }
}
