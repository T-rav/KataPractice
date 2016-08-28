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

        [Test]
        public void Parse_WhenUrlIsHttpAndDoesNotContainPort_ShouldReturnPort80()
        {
            //---------------Set up test pack-------------------
            var expected = "80";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("http://cows.org");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Port);
        }

        [Test]
        public void Parse_WhenUrlIsHttpsAndDoesNotContainPort_ShouldReturnPort80()
        {
            //---------------Set up test pack-------------------
            var expected = "443";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("https://beef.org");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Port);
        }

        [Test]
        public void Parse_WhenUrlIsFtpAndDoesNotContainPort_ShouldReturnPort21()
        {
            //---------------Set up test pack-------------------
            var expected = "21";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("ftp://files.haysales.net");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Port);
        }

        [Test]
        public void Parse_WhenUrlIsSftpAndDoesNotContainPort_ShouldReturnPort21()
        {
            //---------------Set up test pack-------------------
            var expected = "22";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("sftp://uploads.milkprices.org");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Port);
        }

        [Test]
        public void Parse_WhenUrlIsUnhandledProtocolAndDoesNotContainPort_ShouldReturnEmptyStringForPort()
        {
            //---------------Set up test pack-------------------
            var expected = string.Empty;
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("gopher://stuff.um.edu");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Port);
        }

        [Test]
        public void Parse_WhenUrlContainsSpecifiedPortAndNoPath_ShouldReturnPortInUrl()
        {
            //---------------Set up test pack-------------------
            var expected = "8080";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("http://www.mydomain.com:8080");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Port);
        }

        [Test]
        public void Parse_WhenUrlContainsSpecifiedPortAndPath_ShouldReturnPortInUrl()
        {
            //---------------Set up test pack-------------------
            var expected = "8090";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("https://myfiles.com:8090/downloads");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Port);
        }

        [Test]
        public void Parse_WhenUrlContainsMultiPartPath_ShouldReturnFullPath()
        {
            //---------------Set up test pack-------------------
            var expected = "download/tar.gz";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("ftp://ftp.linux.org/download/tar.gz");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Path);
        }

        [Test]
        public void Parse_WhenUrlContainsNoPath_ShouldReturnEmptyString()
        {
            //---------------Set up test pack-------------------
            var expected = string.Empty;
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("http://www.coolstuffz.net");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Path);
        }

        // todo only /
        [Test]
        public void Parse_WhenUrlContainsSinglePartPath_ShouldReturnPath()
        {
            //---------------Set up test pack-------------------
            var expected = "backup.tar.gz";
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("sftp://files.kungfuactiongrip.com/backup.tar.gz");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Path);
        }

        [Test]
        public void Parse_WhenUrlContainsOnlySlash_ShouldReturnEmptyString()
        {
            //---------------Set up test pack-------------------
            var expected = string.Empty;
            var parser = CreateUrlParser();
            //---------------Execute Test ----------------------
            var result = parser.Parse("https://tddbuddy.com/");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.Path);
        }

        private UrlParser CreateUrlParser()
        {
            var parser = new UrlParser();
            return parser;
        }
    }
}
