namespace _28._08._2016___Url_Parts_Parser
{
    public class UrlParts
    {
        public string Protocol { get; private set; }
        public string Subdomain { get; private set; }
        public string DomainName { get; private set; }
        public string Port { get; private set; }
        public string Path { get; private set; }

        public UrlParts(string protocol, string subdomain, string domainName, string port, string path)
        {
            Protocol = protocol;
            Subdomain = subdomain;
            DomainName = domainName;
            Port = port;
            Path = path;
        }
    }
}