using Newtonsoft.Json;

namespace Ivteks72.Postman.Models.TestScriptModels
{
    public class Event
    {
        [JsonProperty("listen")]
        public string Type { get; set; }

        [JsonProperty("script")]
        public Script ScriptObject { get; set; }
    }
}
