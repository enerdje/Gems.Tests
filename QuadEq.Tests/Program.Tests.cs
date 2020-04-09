using NUnit.Framework;

namespace QuadEq.Tests
{
    public class Program_Tests
    {
        [TestCase(1, 0, 1)]
        [TestCase(2, 5, -3.5)]
        [TestCase(1, 1, 1)]
        [TestCase(1, 4, 1)]
        [TestCase(0, 4, 1)] //Первый коэф. не может быть нулём.
        public void Solution_Test(double a, double b, double c)
        {
            bool result = Program.Solution(a, b, c);
            Assert.IsTrue(result);
        }

        [TestCase(1, 0, 1, ExpectedResult = "Уравнение не имеет действительных решений.")]
        [TestCase(2, 5, -3.5d, ExpectedResult = "-3,0700274723201293 0,5700274723201295")]
        [TestCase(1, 1, 1, ExpectedResult = "Уравнение не имеет действительных решений.")]
        [TestCase(1, 4, 1, ExpectedResult = "-3,732050807568877 -0,2679491924311228")]
        [TestCase(0, 4, 1, ExpectedResult = "Ошибка. Первый коэф. не может быть 0.")]
        public string Solution_Test_2(double a, double b, double c)
        {
            string result = Program.Solution(a, b, c, 0);
            return result;
        }

        //Тест на корректный вход данных
        [Test]
        public void CorrectWrite_Test()
        {
            string[] Test = new string[] { "1 2 5", "10 4 2", "11 1 5", "1 1 1", "2 6 4" };
            foreach (string i in Test)
            {
                bool result = Program.CorrectWrite(i, out _, out _, out _);
                Assert.IsTrue(result, $"Ошибка в строке: ({i})");
            }
        }
    }
}
