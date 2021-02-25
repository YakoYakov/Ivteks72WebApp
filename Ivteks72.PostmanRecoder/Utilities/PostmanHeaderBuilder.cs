using Ivteks72.Postman.Models;
using System.Collections.Generic;

namespace Ivteks72.Postman.Utilities
{
    public class PostmanHeaderBuilder : PostmanBuilder
    {
        public PostmanHeaderBuilder(RequestContent postmanRequestContent)
        {
            this.postmanRequestContent = postmanRequestContent;
        }

        public PostmanHeaderBuilder AddHeader(List<PostmanHeaderSection> postmanHeaderSections)
        {
            this.postmanRequestContent.Headers = postmanHeaderSections;
            return this;
        }
    }
}
