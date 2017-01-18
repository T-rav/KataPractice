using NUnit.Framework;

namespace Heavy_Metal_Bake_Sale_Tests
{
    [TestFixture]
    public class ItemsToPurchaseTests
    {
        // todo : seems like a sub vs mock kata?

        [Test]
        public void GetItemsToPurchase_WhenInvoked_ShouldPrintItemsToPurchase()
        {
            //---------------Set up test pack-------------------
            //---------------Execute Test ----------------------
            var result = GetItemsToPurchase(string.Empty);
            //---------------Test Result -----------------------
            Assert.AreEqual("Items to Pruchase > ", result);
        }

        [Test]
        public void GetItemsToPurchase_WhenPurchasingBrownie_ShouldReadB()
        {
            //---------------Set up test pack-------------------
            var consoleLineReader = new ConsoleLineReader("B");
            //---------------Execute Test ----------------------
            var result = GetItemsToPurchase(consoleLineReader);
            //---------------Test Result -----------------------
            Assert.AreEqual("B", result);
        }
        
        [Test]
        public void GetItemsToPurchase_WhenPurchasingMuffin_ShouldReadM()
        {
            //---------------Set up test pack-------------------
            var consoleLineReader = new ConsoleLineReader("M");
            //---------------Execute Test ----------------------
            var result = GetItemsToPurchase(consoleLineReader);
            //---------------Test Result -----------------------
            Assert.AreEqual("M", result);
        }

        private string GetItemsToPurchase(string inputToReturn)
        {
            if (string.IsNullOrEmpty(inputToReturn))
            {
                return "Items to Pruchase > ";
            }

            return inputToReturn;
        }

        private string GetItemsToPurchase(ConsoleLineReader consoleLineReader)
        {
            return consoleLineReader.ReadLine();
        }
    }

    public class ConsoleLineReader
    {
        private readonly string _lineToRead;

        public ConsoleLineReader(string lineToRead)
        {
            _lineToRead = lineToRead;
        }

        public string ReadLine()
        {
            return _lineToRead;
        }
    }
}
