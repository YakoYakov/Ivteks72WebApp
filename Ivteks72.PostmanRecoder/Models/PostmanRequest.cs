using System.Collections.Generic;

namespace Ivteks72.Postman.Models
{
    public class PostmanRequest
    {
        private string name;

        private RequestContent requestContent;

        private List<string> response = new List<string>();

        public string Name { get => name; set => name = value; }
        public RequestContent RequestContent { get => requestContent; set => requestContent = value; }
    }
}
