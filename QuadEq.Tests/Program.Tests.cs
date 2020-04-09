using NUnit.Framework;

namespace QuadEq.Tests
{
    public class Program_Tests
    {
        [TestCase(1, 0, 1)]
        [TestCase(2, 5, -3.5)]
        [TestCase(1, 1, 1)]
        [TestCase(1, 4, 1)]
        [TestCase(0, 4, 1)] //������ ����. �� ����� ���� ����.
        public void Solution_Test(double a, double b, double c)
        {
            bool result = Program.Solution(a, b, c);
            Assert.IsTrue(result);
        }

        #region ��������
        //���� �� ���������� ���� ������
        //����� ������� ���������� ������ ��� out ����������. 
        //�� ������� ����������� ����� ���� ����� � � ������� ��� �� ������ ��������.
        #endregion
        [Test]
        public void CorrectWrite_Test()
        {
            string[] Test = new string[] { "1 2 5", "10 4 2", "11 1 5", "1 1 1", "2 6 4" };
            foreach (string i in Test)
            {
                bool result = Program.CorrectWrite(i, out _, out _, out _);
                Assert.IsTrue(result, $"������ � ������: ({i})");
            }
        }
    }
}