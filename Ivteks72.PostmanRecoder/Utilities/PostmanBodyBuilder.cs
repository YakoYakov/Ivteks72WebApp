using Ivteks72.Postman.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ivteks72.Postman.Utilities
{
    public class PostmanBodyBuilder : PostmanBuilder
    {
        public PostmanBodyBuilder(RequestContent postmanRequestContent)
        {
            this.postmanRequestContent = postmanRequestContent;
        }

        public PostmanBodyBuilder AddBody(string mode, string raw)
        {
            PostmanBodySection body = new PostmanBodySection();

            if (mode == null && raw == null)
            {
                body.Raw = string.Empty;
                body.Mode = string.Empty;
            }

            body.Raw = raw;
            body.Mode = mode;

            return this;
        }
    }
}
