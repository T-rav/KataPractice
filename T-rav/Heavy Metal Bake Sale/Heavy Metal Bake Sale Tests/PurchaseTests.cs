using System.Collections.Generic;
using System.Linq;
using Heavy_Metal_Bake_Sale;
using NUnit.Framework;

namespace Heavy_Metal_Bake_Sale_Tests
{
    [TestFixture]
    public class PurchaseTests
    {
        // todo : seems like a sub vs mock kata?
        // todo : defering decision, no real console concerns yet.
        // todo : tdd like you mean it, functions first

        [Test]
        public void GetItemsToPurchase_WhenInvoked_ShouldPrintItemsToPurchase()
        {
            //---------------Set up test pack-------------------
            var expected = "Items to Purchase > ";

            var testConsole = new TestConsole(string.Empty);
            var purchase = new Purchase(testConsole);
            //---------------Execute Test ----------------------
            purchase.GetItemsToPurchase();
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, testConsole.Buffer.FirstOrDefault());
        }

        [Test]
        public void GetItemsToPurchase_WhenPurchasingBrownie_ShouldReadB()
        {
            //---------------Set up test pack-------------------
            var testConsole = new TestConsole("B");
            var purchase = new Purchase(testConsole);
            //---------------Execute Test ----------------------
            var result = purchase.GetItemsToPurchase();
            //---------------Test Result -----------------------
            Assert.AreEqual("B", result);
        }
        
        [Test]
        public void GetItemsToPurchase_WhenPurchasingMuffin_ShouldReadM()
        {
            //---------------Set up test pack-------------------
            var testConsole = new TestConsole("M");
            var purchase = new Purchase(testConsole);
            //---------------Execute Test ----------------------
            var result = purchase.GetItemsToPurchase();
            //---------------Test Result -----------------------
            Assert.AreEqual("M", result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingBrownie_ShouldReturnTotal65Cents()
        {
            //---------------Set up test pack-------------------
            var expected = "Total > $0.65";
            var purchase = CreatePurchase();
            //---------------Execute Test ----------------------
            var result = purchase.PrintTotal("B");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingMuffin_ShouldReturnTotalOneDollar()
        {
            //---------------Set up test pack-------------------
            var expected = "Total > $1.00";
            var purchase = CreatePurchase();
            //---------------Execute Test ----------------------
            var result = purchase.PrintTotal("M");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingCakePop_ShouldReturnTotalOneDollar35Cents()
        {
            //---------------Set up test pack-------------------
            var expected = "Total > $1.35";
            var purchase = CreatePurchase();
            //---------------Execute Test ----------------------
            var result = purchase.PrintTotal("C");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingWater_ShouldReturnTotalOneDollar50Cents()
        {
            //---------------Set up test pack-------------------
            var expected = "Total > $1.50";
            var purchase = CreatePurchase();
            //---------------Execute Test ----------------------
            var result = purchase.PrintTotal("W");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingTwoItems_ShouldReturnTotal()
        {
            //---------------Set up test pack-------------------
            var expected = "Total > $2.15";
            var purchase = CreatePurchase();
            //---------------Execute Test ----------------------
            var result = purchase.PrintTotal("W,B");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingThreeItems_ShouldReturnTotal()
        {
            //---------------Set up test pack-------------------
            var expected = "Total > $3.50";
            var purchase = CreatePurchase();
            //---------------Execute Test ----------------------
            var result = purchase.PrintTotal("W,B,C");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        // todo : How to expose the testConsole using the Humaid Principle?!
        private Purchase CreatePurchase()
        {
            var testConsole = new TestConsole();
            var purchase = new Purchase(testConsole);
            return purchase;
        }
    }

    public class TestConsole : IConsole
    {
        private readonly string _lineToRead;

        public List<string> Buffer { get;  }

        public TestConsole(): this(string.Empty)
        {
        }

        public TestConsole(string lineToRead)
        {
            _lineToRead = lineToRead;
            Buffer = new List<string>();
        }

        public string ReadLine()
        {
            return _lineToRead;
        }

        public void WriteLine(string output)
        {
            Buffer.Add(output);
        }
    }
}
