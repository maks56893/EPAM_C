using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    static class Calc
    {
        static public int Sum(int x, int y)
        {
            return x + y;
        }

        static public int Diff(int x, int y)
        {
            return x - y;
        }

        static public int Mult(int x, int y)
        {
            return x * y;
        }

        static public int Div(int x, int y)
        {
            if (y == 0)
                return 0;
            return x / y;
        }


    }
}
