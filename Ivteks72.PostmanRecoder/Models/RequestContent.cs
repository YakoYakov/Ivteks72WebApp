using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ivteks72.Postman.Models
{
    public class RequestContent
    {
        public string Method { get; set; }

        [JsonProperty("header")]
        public List<PostmanHeaderSection> Headers { get; set; }

        [JsonProperty("body")]
        public PostmanBodySection PostmanBody { get; set; }

        [JsonProperty("url")]
        public PostmanUrlSection PostmanUrl { get; set; }
    }
}
