using Ivteks72.Postman.Models;

namespace Ivteks72.Postman.Utilities
{
    public class PostmanMethodBuilder : PostmanBuilder
    {
        public PostmanMethodBuilder (RequestContent postmanRequestContent)
        {
            this.postmanRequestContent = postmanRequestContent;
        }

        public PostmanMethodBuilder AddMethod(string methodName)
        {
            this.postmanRequestContent.Method = methodName;
            return this;
        }
    }
}
