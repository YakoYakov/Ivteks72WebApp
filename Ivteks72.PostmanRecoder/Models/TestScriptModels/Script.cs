using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ivteks72.Postman.Models.TestScriptModels
{
    public class Script
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("exec")]
        public List<string> Executions { get; set; }
    }
}