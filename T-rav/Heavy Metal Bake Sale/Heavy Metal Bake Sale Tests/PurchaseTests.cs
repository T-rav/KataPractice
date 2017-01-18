using System.Linq;
using Heavy_Metal_Bake_Sale;
using NSubstitute;
using NUnit.Framework;

namespace Heavy_Metal_Bake_Sale_Tests
{
    [TestFixture]
    public class PurchaseTests
    {
        // todo : seems like a sub vs mock kata.... More blended.
        // todo : defering decision, no real outputBuffer concerns to start with
        // todo : tdd like you mean it, functions first
        // todo : top-down vertical slicing
        // todo : SOLID, Open/Closed, Single Responsiblity
        // todo : Clean Architecture?

        [Test]
        public void GetItemsToPurchase_WhenInvoked_ShouldPrintItemsToPurchase()
        {
            //---------------Set up test pack-------------------
            var expected = "Items to Purchase > ";
            var outputBuffer = new TestOutputBuffer();
            var purchase = CreatePurchaseWithOutputBuffer(outputBuffer);
            //---------------Execute Test ----------------------
            purchase.GetItemsToPurchase();
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, outputBuffer.Buffer.FirstOrDefault());
        }

        [Test]
        public void GetItemsToPurchase_WhenPurchasingBrownie_ShouldReadB()
        {
            //---------------Set up test pack-------------------
            var inputBuffer = new TestInputBuffer("B");
            var purchase = CreatePurchaseWithInputBuffer(inputBuffer);
            //---------------Execute Test ----------------------
            var result = purchase.GetItemsToPurchase();
            //---------------Test Result -----------------------
            Assert.AreEqual("B", result);
        }

        [Test]
        public void GetItemsToPurchase_WhenPurchasingMuffin_ShouldReadM()
        {
            //---------------Set up test pack-------------------
            var inputBuffer = new TestInputBuffer("M");
            var purchase = CreatePurchaseWithInputBuffer(inputBuffer);
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
            var outputBuffer = new TestOutputBuffer();
            var purchase = CreatePurchaseWithOutputBuffer(outputBuffer);
            //---------------Execute Test ----------------------
            purchase.PrintTotal("B");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, outputBuffer.Buffer.FirstOrDefault());
        }

        [Test]
        public void PrintTotal_WhenPurchasingMuffin_ShouldReturnTotalOneDollar()
        {
            //---------------Set up test pack-------------------
            var expected = "Total > $1.00";
            var outputBuffer = new TestOutputBuffer();
            var purchase = CreatePurchaseWithOutputBuffer(outputBuffer);
            //---------------Execute Test ----------------------
            purchase.PrintTotal("M");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, outputBuffer.Buffer.FirstOrDefault());
        }

        [Test]
        public void PrintTotal_WhenPurchasingCakePop_ShouldReturnTotalOneDollar35Cents()
        {
            //---------------Set up test pack-------------------
            var expected = "Total > $1.35";
            var outputBuffer = new TestOutputBuffer();
            var purchase = CreatePurchaseWithOutputBuffer(outputBuffer);
            //---------------Execute Test ----------------------
            purchase.PrintTotal("C");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, outputBuffer.Buffer.FirstOrDefault());
        }

        [Test]
        public void PrintTotal_WhenPurchasingWater_ShouldReturnTotalOneDollar50Cents()
        {
            //---------------Set up test pack-------------------
            var expected = "Total > $1.50";
            var outputBuffer = new TestOutputBuffer();
            var purchase = CreatePurchaseWithOutputBuffer(outputBuffer);
            //---------------Execute Test ----------------------
            purchase.PrintTotal("W");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, outputBuffer.Buffer.FirstOrDefault());
        }

        [Test]
        public void PrintTotal_WhenPurchasingTwoItems_ShouldReturnTotal()
        {
            //---------------Set up test pack-------------------
            var expected = "Total > $2.15";
            var outputBuffer = new TestOutputBuffer();
            var purchase = CreatePurchaseWithOutputBuffer(outputBuffer);
            //---------------Execute Test ----------------------
            purchase.PrintTotal("W,B");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, outputBuffer.Buffer.FirstOrDefault());
        }

        [Test]
        public void PrintTotal_WhenPurchasingThreeItems_ShouldReturnTotal()
        {
            //---------------Set up test pack-------------------
            var expected = "Total > $3.50";
            var outputBuffer = new TestOutputBuffer();
            var purchase = CreatePurchaseWithOutputBuffer(outputBuffer);
            //---------------Execute Test ----------------------
            purchase.PrintTotal("W,B,C");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, outputBuffer.Buffer.FirstOrDefault());
        }

        [Test]
        public void PrintTotal_WhenPurchasingTwoItemsWithSpaceBetweenComma_ShouldReturnTotal()
        {
            //---------------Set up test pack-------------------
            var expected = "Total > $2.15";
            var outputBuffer = new TestOutputBuffer();
            var purchase = CreatePurchaseWithOutputBuffer(outputBuffer);
            //---------------Execute Test ----------------------
            purchase.PrintTotal("W , B");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, outputBuffer.Buffer.FirstOrDefault());
        }

        private static Purchase CreatePurchaseWithOutputBuffer(IOutputBuffer testOutputBuffer)
        {
            var purchase = new Purchase(Substitute.For<IInputBuffer>(),testOutputBuffer);
            return purchase;
        }

        private static Purchase CreatePurchaseWithInputBuffer(IInputBuffer testInputBuffer)
        {
            var purchase = new Purchase(testInputBuffer, Substitute.For<IOutputBuffer>());
            return purchase;
        }
    }
}
