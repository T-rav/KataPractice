using System;
using System.Linq;

namespace _28._08._2016___Url_Parts_Parser
{
    public class UrlParser
    {
        public UrlParts Parse(string url)
        {
            var protocolString = GetProtocol(url);
            var subdomainString = GetSubdomain(url);
            var domainNameString = GetDomainName(url);
            return new UrlParts(protocolString, subdomainString, domainNameString);
        }

        private static string GetDomainName(string url)
        {
            var domainName = url.SkipWhile(c => c != '/').Skip(2).TakeWhile(c => c != '.').ToArray();
            if (HasSubdomain(url))
            {
                domainName = url.SkipWhile(c => c != '.').Skip(1).TakeWhile(c => c != '.').ToArray();
            }
            var domainNameString = new string(domainName);
            return domainNameString;
        }

        private string GetProtocol(string url)
        {
            var protocol = url.TakeWhile(c => c != ':');
            var protocolString = new string(protocol.ToArray());
            return protocolString;
        }

        private string GetSubdomain(string url)
        {
            var subdomainString = string.Empty;
            if (HasSubdomain(url))
            {
                var subdomain = url.SkipWhile(c => c != '/').Skip(2).TakeWhile(c => c != '.').ToArray();
                subdomainString = new string(subdomain);
            }
            return subdomainString;
        }

        private static bool HasSubdomain(string url)
        {
            return url.IndexOf(".", StringComparison.InvariantCulture) != url.LastIndexOf(".", StringComparison.InvariantCulture);
        }
    }

    public class UrlParts
    {
        public UrlParts(string protocol, string subdomain, string domainName)
        {
            Protocol = protocol;
            Subdomain = subdomain;
            DomainName = domainName;
        }

        public string Protocol { get; private set; }
        public string Subdomain { get; private set; }
        public string DomainName { get; private set; }
    }
}
