using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class rectangle : Figure
    {
        private float a, b;
        public float A
        {
            get
            {
                return a;
            }
            set
            {
                if (value > 0)
                {
                    a = value;
                }
                else
                {
                    Console.WriteLine("Длина стороны не может быть отрицательной");
                }
            }
        }
        public float B
        {
            get
            {
                return b;
            }
            set
            {
                if (value > 0)
                {
                    b = value;
                }
                else
                {
                    Console.WriteLine("Длина стороны не может быть отрицательной");
                }
            }
        }
        public override double Square()
        {
            double S = a * b;
            return S;
        }

        public override double Perimeter()
        {
            double P = 2 * (a + b);
            return P;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Сторона А = {a},сторона В = {b}, Площадь = {Square()}, длина окружности = {Perimeter()}");
        }

        public rectangle(float A, float B)
        {
            this.A = A;
            this.B = B;
        }

    }
}
