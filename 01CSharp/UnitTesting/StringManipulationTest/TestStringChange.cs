using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringManipulationLib;

namespace StringManipulationTest
{
    [TestClass] // Attributes
    public class TestStringChange
    {
        StringChange stringChange = new StringChange();


        [TestMethod]
        public void TestChangeToUpper()
        {
            // Arrange
            string expected = "FRED";
            // Act
            string actual = stringChange.ChangeToUpper("fred");
            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestInstanceType()
        {
            string actual = stringChange.ChangeToUpper("FRED");
            Assert.IsInstanceOfType(actual, typeof(string));
        }

        [TestMethod]
        public void TestReverse()
        {
            string expected = "derf";
            string actual = stringChange.Reverse("fred");
            Assert.AreEqual(expected, actual);

        }
    }
}
