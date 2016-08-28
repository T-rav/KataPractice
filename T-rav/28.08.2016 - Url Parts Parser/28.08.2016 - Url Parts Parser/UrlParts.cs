namespace _28._08._2016___Url_Parts_Parser
{
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