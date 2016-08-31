using NUnit.Framework;

namespace Numbers_to_Words
{
    [TestFixture]
    public class NumberToWordConverterTests
    {

        [Test]
        public void Convert_WhenNumberZero_ShouldReturnTextZero()
        {
            //---------------Set up test pack-------------------
            var numberToWordConverter = CreateNumberToWordConverter();
            //---------------Execute Test ----------------------
            var result = numberToWordConverter.Convert(0);
            //---------------Test Result -----------------------
            Assert.AreEqual("zero",result);
        }

        private NumberToWordConverter CreateNumberToWordConverter()
        {
            var numberToWordConverter = new NumberToWordConverter();
            return numberToWordConverter;
        }

        // I wrote three test beyond zero, saw pattern and refactored back into test cases. 
        // I have not included zero because it is a special case

        [TestCase(1, "one")]
        [TestCase(2, "two")]
        [TestCase(3, "three")]
        [TestCase(4, "four")]
        [TestCase(5, "five")]
        [TestCase(6, "six")]
        [TestCase(7, "seven")]
        [TestCase(8, "eight")]
        [TestCase(9, "nine")]
        public void Convert_WhenNumberSingleNonZeroDigit_ShouldReturnTextOfNumber(int input, string expected)
        {
            //---------------Set up test pack-------------------
            var numberToWordConverter = CreateNumberToWordConverter();
            //---------------Execute Test ----------------------
            var result = numberToWordConverter.Convert(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        // had odd spacing where some where ," others where , "
        // this seemed to cause my brain to register a fault / threat that distracted me

        [TestCase(10, "ten")]
        [TestCase(20, "twenty")]
        [TestCase(30, "thirty")]
        [TestCase(40, "fourty")]
        [TestCase(50, "fifty")]
        [TestCase(60, "sixty")]
        [TestCase(70, "seventy")]
        [TestCase(80, "eighty")]
        [TestCase(90, "ninety")]
        public void Convert_WhenTwoDigitNumberEndingInZero_ShouldReturnTextOfNumberWithoutHyphen(int input, string expected)
        {
            //---------------Set up test pack-------------------
            var numberToWordConverter = CreateNumberToWordConverter();
            //---------------Execute Test ----------------------
            var result = numberToWordConverter.Convert(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        // note disharmony with -> // todo : when not in the correct cycle

        [TestCase(21, "twenty-one")]
        [TestCase(32, "thirty-two")]
        [TestCase(67, "sixty-seven")]
        [TestCase(99, "ninety-nine")]
        public void Convert_WhenTwoDigitNumberNotEndingInZero_ShouldReturnTextWithHyphenatedNumber(int input, string expected)
        {
            //---------------Set up test pack-------------------
            var numberToWordConverter = CreateNumberToWordConverter();
            //---------------Execute Test ----------------------
            var result = numberToWordConverter.Convert(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        // 100, 200, 300, 400, etc
        // 201, 505, 607, 708, etc ( Non hyphen numbers )
        // 222, 333, 444, 555, etc ( Hyphenated numbers )

    }
}
