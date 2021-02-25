using System;
using System.Collections.Generic;
using System.Text;

namespace Ivteks72.Postman.Models
{
    public class RequestContent
    {
        private string method;
        private List<PostmanHeaderSection> headers;
        private PostmanBodySection postmanBody;
        private PostmanUrlSection postmanUrl;

        public string Method { get => method; set => method = value; }
        public List<PostmanHeaderSection> Headers { get => headers; set => headers = value; }
        public PostmanUrlSection PostmanUrl { get => postmanUrl; set => postmanUrl = value; }
        internal PostmanBodySection PostmanBody { get => postmanBody; set => postmanBody = value; }
    }
}
