using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {           
            float x = 0;
            float y = 0;

            bool SucsX = false;         
            while (!SucsX)
            {
                Console.WriteLine("Введите первое число");
                string xInString = Console.ReadLine();
                SucsX = float.TryParse(xInString, out x);
                if (!SucsX)
                {
                    Console.WriteLine("Не правильно введено число");
                }
            }

            bool SucsY = false;
            while (!SucsY)
            {
                Console.WriteLine("Введите второе число");
                string yInString = Console.ReadLine();
                SucsY = float.TryParse(yInString, out y);
                if (!SucsX)
                {
                    Console.WriteLine("Не правильно введено число");
                }
            }

            bool success = false;
            while (!success)
            {
                Console.WriteLine("Выберете операцию. \nДоступные операции: +, -, *, /");
                string operation = Console.ReadLine();
                switch (operation)
                {
                    case "+":
                        float resultSum = x + y;
                        Console.Clear();
                        Console.WriteLine($"Результат операции: {resultSum}");
                        success = true;
                        break;
                    case "-":
                        float resultSub = x - y;
                        Console.Clear();
                        Console.WriteLine($"Результат операции: {resultSub}");
                        success = true;
                        break;
                    case "*":
                        float resultMult = x * y;
                        Console.Clear();
                        Console.WriteLine($"Результат операции: {resultMult}");
                        success = true;
                        break;
                    case "/":
                        float resultDiv = x / y;
                        Console.Clear();
                        Console.WriteLine($"Результат операции: {resultDiv}");
                        success = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Выбрана неизвестная операция, повторите попытку");     
                        break;
                }
            }

            Console.ReadKey();

        }
    }
}
