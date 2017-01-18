﻿using System.Collections.Generic;
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
            var result = GetItemsToPurchase();
            //---------------Test Result -----------------------
            Assert.AreEqual("Items to Pruchase > ", result);
        }

        [Test]
        public void GetItemsToPurchase_WhenPurchasingBrownie_ShouldReadB()
        {
            //---------------Set up test pack-------------------
            var consoleLineReader = new TestConsoleLineReader("B");
            //---------------Execute Test ----------------------
            var result = GetItemsToPurchase(consoleLineReader);
            //---------------Test Result -----------------------
            Assert.AreEqual("B", result);
        }
        
        [Test]
        public void GetItemsToPurchase_WhenPurchasingMuffin_ShouldReadM()
        {
            //---------------Set up test pack-------------------
            var consoleLineReader = new TestConsoleLineReader("M");
            //---------------Execute Test ----------------------
            var result = GetItemsToPurchase(consoleLineReader);
            //---------------Test Result -----------------------
            Assert.AreEqual("M", result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingBrownie_ShouldReturnTotal65Cents()
        {
            //---------------Set up test pack-------------------
            //---------------Execute Test ----------------------
            var result = PrintTotal("B");
            //---------------Test Result -----------------------
            Assert.AreEqual("Total > $0.65", result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingMuffin_ShouldReturnTotalOneDollar()
        {
            //---------------Set up test pack-------------------
            //---------------Execute Test ----------------------
            var result = PrintTotal("M");
            //---------------Test Result -----------------------
            Assert.AreEqual("Total > $1.00", result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingCakePop_ShouldReturnTotalOneDollar35Cents()
        {
            //---------------Set up test pack-------------------
            //---------------Execute Test ----------------------
            var result = PrintTotal("C");
            //---------------Test Result -----------------------
            Assert.AreEqual("Total > $1.35", result);
        }

        [Test]
        public void PrintTotal_WhenPurchasingWater_ShouldReturnTotalOneDollar50Cents()
        {
            //---------------Set up test pack-------------------
            //---------------Execute Test ----------------------
            var result = PrintTotal("W");
            //---------------Test Result -----------------------
            Assert.AreEqual("Total > $1.50", result);
        }

        private string PrintTotal(string itemsPurchased)
        {
            var items = new Dictionary<string, double>
            {
                { "B", 0.65 },
                { "M", 1.00 },
                { "C", 1.35 },
                { "W", 1.50 }
            };

            double itemPrice;
            items.TryGetValue(itemsPurchased, out itemPrice);

            var printTotal = itemPrice.ToString("F2");
            return $"Total > ${printTotal}";
        }

        private string GetItemsToPurchase()
        { 
                return "Items to Pruchase > ";
        }

        private string GetItemsToPurchase(IConsole consoleLineReader)
        {
            return consoleLineReader.ReadLine();
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
