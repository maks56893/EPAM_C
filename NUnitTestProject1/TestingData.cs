using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    class TestingData
    {
        static object[] SumCases =
{
            new object[] { 0, 0, 0 },
            new object[] { -5, -2, -7 },
            new object[] { -10, 20, 10 },
            new object[] { 0, -10, -10 }
        };

        static object[] DiffCases =
{
            new object[] { 0, 0, 0 },
            new object[] { -5, -2, -3 },
            new object[] { -10, 20, -30 },
            new object[] { 0, -10, 10 }
        };

        static object[] MultCases =
        {
            new object[] { 10, 0, 0 },
            new object[] { 20, -2, -40 },
            new object[] { -10, -2, 20 },
        };

        static object[] DivCases =
        {
            new object[] { 10, 0, 0 },
            new object[] { 20, -2, -10 },
            new object[] { -10, -2, 5 },
        };



    }
}
