using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task1
{
    class Round : Figure
    {
        private float r;
        public float R
        {
            get
            {
                return r;
            }
            set
            {

                    if (value > 0)
                    {
                        r = value;
                    }
                    else
                    {
                        Console.WriteLine("Радиус не может быть отрицательным");
                    }

            }
        }
        public override double Square()
        {
            double S = Math.PI * Math.Pow(r, 2);
            return S;
        }

        public override double Perimeter()
        {
            double P = 2 * Math.PI * r;
            return P;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Радиус = {r}, Площадь = {Square()}, длина окружности = {Perimeter()}");
        }

        public Round(float R)
        {
            this.R = R;
        }

    }
}
