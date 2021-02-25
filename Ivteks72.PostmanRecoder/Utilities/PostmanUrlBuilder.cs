using Ivteks72.Postman.Models;
using System.Collections.Generic;

namespace Ivteks72.Postman.Utilities
{
    public class PostmanUrlBuilder : PostmanBuilder
    {
        public PostmanUrlBuilder(RequestContent postmanRequestContent)
        {
            this.postmanRequestContent = postmanRequestContent;
        }

        public PostmanUrlBuilder AddUrlData(string url, string protocol, List<string> segments, List<string> hostSegments)
        {
            this.postmanRequestContent.PostmanUrl.Raw = url;
            this.postmanRequestContent.PostmanUrl.Protocol = protocol;
            this.postmanRequestContent.PostmanUrl.PathSegments = segments;
            this.postmanRequestContent.PostmanUrl.HostSegments = hostSegments;

            return this;
        }
    }
}
