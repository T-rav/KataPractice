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

        private string GetDomainName(string url)
        {
            var domainName = GetDomainNameWhenUrlContainsNoSubdomain(url);
            if (HasSubdomain(url))
            {
                domainName = GetDomainNameWhenUrlContainsSubdomain(url);
            }
            return domainName;
        }

        private string GetDomainNameWhenUrlContainsSubdomain(string url)
        {
            var result = url.SkipWhile(c => c != '.').Skip(1).TakeWhile(c => c != '.').ToArray();
            return new string(result);
        }

        private string GetDomainNameWhenUrlContainsNoSubdomain(string url)
        {
            var result = url.SkipWhile(c => c != '/').Skip(2).TakeWhile(c => c != '.').ToArray();
            return new string(result);
        }

        private string GetProtocol(string url)
        {
            var protocol = url.TakeWhile(c => c != ':');
            return new string(protocol.ToArray());
        }

        private string GetSubdomain(string url)
        {
            if (!HasSubdomain(url)) return string.Empty;

            var subdomain = url.SkipWhile(c => c != '/').Skip(2).TakeWhile(c => c != '.').ToArray();
            return new string(subdomain);
        }

        private bool HasSubdomain(string url)
        {
            return url.IndexOf(".", StringComparison.InvariantCulture) != url.LastIndexOf(".", StringComparison.InvariantCulture);
        }
    }
}
