using Grobund.WPF.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.Tests
{
    [TestClass]
    public class DecimalToStringConverterTest
    {
        [TestMethod]
        public void ConvertTest()
        {
            // Arrange
            decimal number = 14321.0000M;

            var converter = new DecimalToStringConverter();

            // Act
            var output = (string)converter.Convert(number, typeof(decimal), null, null);

            // Assert
            Assert.AreEqual(output, "14321 kr.");

        }

        [TestMethod]
        public void ConvertFromDecimalWithDecimalsTest()
        {
            // Arrange
            decimal number = 14321.752M;

            var converter = new DecimalToStringConverter();

            // Act
            var output = (string)converter.Convert(number, typeof(decimal), null, null);

            // Assert
            Assert.AreEqual(output, "14321 kr.");
        }
    }
}
