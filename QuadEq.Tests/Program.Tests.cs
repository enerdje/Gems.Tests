using NUnit.Framework;
using System;

namespace QuadEq.Tests
{
    public class Program_Tests
    {
        [TestCase("1 0 1")]
        [TestCase("2 5 -3,5")]
        [TestCase("1 1 1")]
        [TestCase("1 4 1")]
        [TestCase("0 4 1")]
        public void Solution_Test(string input)
        {
            bool result = Program.Solution(input);
            Assert.IsTrue(result);
        }

        [TestCase("1 0 1", 0, ExpectedResult = "Уравнение не имеет действительных решений.")]
        [TestCase("2 5 -3,5", 0, ExpectedResult = "-3,0700274723201293 0,5700274723201295")]
        [TestCase("1 1 1", 0, ExpectedResult = "Уравнение не имеет действительных решений.")]
        [TestCase("1 4 1", 0, ExpectedResult = "-3,732050807568877 -0,2679491924311228")]
        [TestCase("0 4 1", 0, ExpectedResult = "Ошибка. Первый коэф. не может быть 0.")]
        public string Solution_Test_Values(string values, int _)
        {
            string result = Program.Solution(values, 0);
            return result;
        }
    }
}
