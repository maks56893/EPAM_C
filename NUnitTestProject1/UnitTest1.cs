using NUnit.Framework;

namespace NUnitTestProject1
{
    public class Tests
    {
        [TestCaseSource(typeof(TestingData), "SumCases")]
        public void TestSum(int x, int y, int z)
        {
            int res = Calc.Sum(x, y);
            Assert.AreEqual(z, res);
        }

        [TestCaseSource(typeof(TestingData), "DiffCases")]
        public void TestDiff(int x, int y, int z)
        {
            int res = Calc.Diff(x, y);
            Assert.AreEqual(z, res);
        }

        [TestCaseSource(typeof(TestingData), "MultCases")]
        public void TestMult(int x, int y, int z)
        {
            int res = Calc.Mult(x, y);
            Assert.AreEqual(z, res);
        }

        [TestCaseSource(typeof(TestingData), "DivCases")]
        [TestCase(0, 10, 0)]
        public void TestDiv(int x, int y, int z)
        {
            int res = Calc.Div(x, y);
            Assert.AreEqual(z, res);
        }


    }
}