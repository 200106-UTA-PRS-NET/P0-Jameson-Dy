using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromeLib;

namespace PalindromeTest
{
    [TestClass]
    public class TestPalindrome
    {
        Palindrome p = new Palindrome();

        [TestMethod]
        public void TestIsPalindromeTrue()
        {
            bool expected = true;
            bool actual = p.IsPalindrome("never odd, or even.");

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestIsPalindromeFalse()
        {
            bool expected = false;
            bool actual = p.IsPalindrome("one two one");

            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void TestInstanceType()
        {
            bool actual = p.IsPalindrome("one two one");
            Assert.IsInstanceOfType(actual, typeof(bool));
        }
    }
}
