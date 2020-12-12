using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task1
{
    public class Round <T> : Figure
    {
        internal float r;
        public T x, y;
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

        public override string ToString()
        {
            return String.Format($"Радиус = {r}, Площадь = {Square()}, длина окружности = {Perimeter()}\nКоординаты центра окружности: [{x},{y}]");
        }

        public override bool Equals(object obj)
        {
            return obj is Round<T> round &&
                   r == round.r;
        }

        public Round(float R, T x, T y)
        {
            this.R = R;
            this.x = x;
            this.y = y;
        }

    }
}
