using System.Collections.Generic;
using Heavy_Metal_Bake_Sale;
using NUnit.Framework;

namespace Heavy_Metal_Bake_Sale_Tests
{
    [TestFixture]
    public class ItemsToPurchaseTests
    {
        // todo : seems like a sub vs mock kata?
        // todo : defering decision, no real console concerns yet.
        // todo : tdd like you mean it, functions first

        [Test]
        public void GetItemsToPurchase_WhenInvoked_ShouldPrintItemsToPurchase()
        {
            //---------------Set up test pack-------------------
            var purchase = new Purchase();
            //---------------Execute Test ----------------------
            var result = purchase.GetItemsToPurchase();
            //---------------Test Result -----------------------
            Assert.AreEqual("Items to Pruchase > ", result);
        }

        [Test]
        public void GetItemsToPurchase_WhenPurchasingBrownie_ShouldReadB()
        {
            //---------------Set up test pack-------------------
            var purchase = new Purchase();
            var consoleLineReader = new TestConsoleLineReader("B");
            //---------------Execute Test ----------------------
            var result = purchase.GetItemsToPurchase(consoleLineReader);
            //---------------Test Result -----------------------
            Assert.AreEqual("B", result);
        }
        
        [Test]
        public void GetItemsToPurchase_WhenPurchasingMuffin_ShouldReadM()
        {
            //---------------Set up test pack-------------------
            var purchase = new Purchase();
            var consoleLineReader = new TestConsoleLineReader("M");
            //---------------Execute Test ----------------------
            var result = purchase.GetItemsToPurchase(consoleLineReader);
            //---------------Test Result -----------------------
            Assert.AreEqual("M", result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingBrownie_ShouldReturnTotal65Cents()
        {
            //---------------Set up test pack-------------------
            var purchase = new Purchase();
            //---------------Execute Test ----------------------
            var result = purchase.PrintTotal("B");
            //---------------Test Result -----------------------
            Assert.AreEqual("Total > $0.65", result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingMuffin_ShouldReturnTotalOneDollar()
        {
            //---------------Set up test pack-------------------
            var purchase = new Purchase();
            //---------------Execute Test ----------------------
            var result = purchase.PrintTotal("M");
            //---------------Test Result -----------------------
            Assert.AreEqual("Total > $1.00", result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingCakePop_ShouldReturnTotalOneDollar35Cents()
        {
            //---------------Set up test pack-------------------
            var purchase = new Purchase();
            //---------------Execute Test ----------------------
            var result = purchase.PrintTotal("C");
            //---------------Test Result -----------------------
            Assert.AreEqual("Total > $1.35", result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingWater_ShouldReturnTotalOneDollar50Cents()
        {
            //---------------Set up test pack-------------------
            var purchase = new Purchase();
            //---------------Execute Test ----------------------
            var result = purchase.PrintTotal("W");
            //---------------Test Result -----------------------
            Assert.AreEqual("Total > $1.50", result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingTwoItems_ShouldReturnTotal()
        {
            //---------------Set up test pack-------------------
            var purchase = new Purchase();
            //---------------Execute Test ----------------------
            var result = purchase.PrintTotal("W,B");
            //---------------Test Result -----------------------
            Assert.AreEqual("Total > $2.15", result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingThreeItems_ShouldReturnTotal()
        {
            //---------------Set up test pack-------------------
            var purchase = new Purchase();
            //---------------Execute Test ----------------------
            var result = purchase.PrintTotal("W,B,C");
            //---------------Test Result -----------------------
            Assert.AreEqual("Total > $3.50", result);
        }
    }

    public class TestConsoleLineReader : IConsole
    {
        private readonly string _lineToRead;

        public TestConsoleLineReader(string lineToRead)
        {
            _lineToRead = lineToRead;
        }

        public string ReadLine()
        {
            return _lineToRead;
        }
    }
}
