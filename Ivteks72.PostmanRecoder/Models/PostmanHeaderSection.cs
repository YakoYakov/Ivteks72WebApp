using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ivteks72.Postman.Models
{
    public class PostmanHeaderSection
    {
        private string key;
        private JToken value;

        public string Key { get => key; set => key = value; }
        public JToken Value { get => value; set => this.value = value; }
    }
}
