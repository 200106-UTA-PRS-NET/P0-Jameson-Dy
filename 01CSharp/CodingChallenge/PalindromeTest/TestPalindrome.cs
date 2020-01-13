using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromeLib;

namespace PalindromeTest
{
    [TestClass]
    public class TestPalindrome
    {
        Palindrome p = new Palindrome();

        [TestMethod]
        public void TestIsPalindrome()
        {
            bool expected = true;
            bool actual = p.IsPalindrome("never odd, or even.");

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestInstanceType()
        {
            bool actual = p.IsPalindrome("never odd, or even.");
            Assert.IsInstanceOfType(actual, typeof(bool));
        }
    }
}
