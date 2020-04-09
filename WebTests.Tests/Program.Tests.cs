using NUnit.Framework;

namespace WebTests.Tests
{
    public class Tests
    {
        [Test]
        public void ContentBlocks_Test()
        {
            string[] blocks = new string[] { "my-150", "gos-system", "urban-analytics", "other-products" };
            bool result = Program.ContentBlocks(blocks);
            Assert.IsTrue(result, "�� ��� �������� ���� �� ��������");
        }

        [TestCase(@"https://xn--c1aaceme9acfqh.xn--p1ai/", "gos-system")]
        [TestCase(@"https://xn--c1aaceme9acfqh.xn--p1ai/", "bad-block")] //�������� ����
        [TestCase(@"https://bad-link-c1aaceme9acfqh--p1", "gos-system")] //�������� ������
        public void IsLinkExists_Test(string url, string block)
        {     
            bool result = Program.IsLinkExists(url, block);
            Assert.IsTrue(result);
        }
    }
}