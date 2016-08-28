using NUnit.Framework;
using _28._08._2016___Url_Parts_Parser;

namespace UrlPartsParserTests
{
    [TestFixture]
    public class UrlParserTests
    {

        [Test]
        public void Parse_WhenUrlContainsHttpProtocol_ShouldReturnHttpForProtocol()
        {
            //---------------Set up test pack-------------------
            var expected = "http";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("http://www.google.com");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Protocol);
        }

        [Test]
        public void Parse_WhenUrlContainsFtpProtocol_ShouldReturnFtpForProtocol()
        {
            //---------------Set up test pack-------------------
            var expected = "ftp";
            var parser = new UrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("ftp://kungfuactiongrip.com");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Protocol);
        }

        [Test]
        public void Parse_WhenUrlContainsHttpsProtocol_ShouldReturnHttpsForProtocol()
        {
            //---------------Set up test pack-------------------
            var expected = "https";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("https://bar.com");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Protocol);
        }

        [Test]
        public void Parse_WhenUrlContainsNoSubdomain_ShouldReturnEmptyStringForSubdomain()
        {
            //---------------Set up test pack-------------------
            var expected = string.Empty;
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("https://takealot.com");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Subdomain);
        }

        [Test]
        public void Parse_WhenUrlContainsWwwSubdomain_ShouldReturnWwwSubdomain()
        {
            //---------------Set up test pack-------------------
            var expected = "www";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("https://www.goodstuff.com");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Subdomain);
        }

        [Test]
        public void Parse_WhenUrlContainsBarSubdomain_ShouldReturnBarSubdomain()
        {
            //---------------Set up test pack-------------------
            var expected = "bar";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("ftp://bar.foo.com");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Subdomain);
        }

        [Test]
        public void Parse_WhenUrlContainsSubdomainAndFoobarDomainName_ShouldReturnFoobarDomainName()
        {
            //---------------Set up test pack-------------------
            var expected = "foobar";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("sftp://stuff.foobar.net");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.DomainName);
        }

        [Test]
        public void Parse_WhenUrlContainsNoSubDomainAndMooDomainName_ShouldReturnMooDomainName()
        {
            //---------------Set up test pack-------------------
            var expected = "moo";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("http://moo.co");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.DomainName);
        }


        private UrlParser CreateUrlParser()
        {
            var parser = new UrlParser();
            return parser;
        }

        //[Test]
        //public void Parse_WhenUrlNoSubdomain_ShouldEmptyStringForSubdomain()
        //{
        //    //---------------Set up test pack-------------------
        //    var parser = new UrlParser();
        //    //---------------Assert Precondition----------------

        //    //---------------Execute Test ----------------------
        //    var result = parser.Parse("http://bar.com");
        //    //---------------Test Result -----------------------
        //    Assert.AreEqual(string.Empty, result[1]);
        //}
    }
}
