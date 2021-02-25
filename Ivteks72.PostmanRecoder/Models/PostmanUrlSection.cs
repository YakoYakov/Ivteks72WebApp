using System.Collections.Generic;

namespace Ivteks72.Postman.Models
{
    public class PostmanUrlSection
    {
        private string raw;
        private string protocol;
        private List<string> hostSegments;
        private List<string> pathSegments;

        public List<Dictionary<string, string>> Queries = new List<Dictionary<string, string>>();
        public string Raw { get => raw; set => raw = value; }
        public string Protocol { get => protocol; set => protocol = value; }
        public List<string> HostSegments { get => hostSegments; set => hostSegments = value; }
        public List<string> PathSegments { get => pathSegments; set => pathSegments = value; }
    }
}