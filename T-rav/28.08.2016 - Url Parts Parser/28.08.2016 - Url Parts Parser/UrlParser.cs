using System;
using System.Collections.Generic;
using System.Linq;

namespace _28._08._2016___Url_Parts_Parser
{
    public class UrlParser
    {
        private readonly IDictionary<string, string> _portLookup = new Dictionary<string, string>
                                                                    {
                                                                        {"http", "80"},
                                                                        {"https", "443"},
                                                                        {"ftp", "21"},
                                                                        {"sftp", "22"}
                                                                    };
        public UrlParts Parse(string url)
        {
            var protocol = GetProtocol(url);
            var subdomain = GetSubdomain(url);
            var domainName = GetDomainName(url);
            var port = GetPort(url, protocol);
            var path = GetPath(url);
            return new UrlParts(protocol, subdomain, domainName, port, path);
        }

        private string GetPath(string url)
        {
            var pathString = string.Empty;
            if (!HasPath(url)) return pathString;

            var path = url.SkipWhile(c => c != '/').Skip(2).SkipWhile(c => c != '/').Skip(1).ToArray();
            return new string(path);
        }

        private static bool HasPath(string url)
        {
            return url.IndexOf("/", StringComparison.InvariantCulture) + 1 !=
                   url.LastIndexOf("/", StringComparison.InvariantCulture);
        }

        private string GetPort(string url, string protocolString)
        {
            return !UrlContainsCustomPort(url) ? GetDefaultPort(protocolString) : GetCustomPort(url);
        }

        private static string GetCustomPort(string url)
        {
            var portIndex = url.LastIndexOf(":", StringComparison.InvariantCulture);
            if (portIndex <= 0) return string.Empty;

            var portAndPath = url.Substring(portIndex + 1);
            var port = portAndPath.TakeWhile(c => c != '/').ToArray();
            return new string(port);
        }

        private static bool UrlContainsCustomPort(string url)
        {
            return url.IndexOf(":", StringComparison.InvariantCulture) != url.LastIndexOf(":", StringComparison.InvariantCulture);
        }

        private string GetDefaultPort(string protocolString)
        {
            var port = string.Empty;
            return _portLookup.TryGetValue(protocolString, out port) ? port : string.Empty;
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
