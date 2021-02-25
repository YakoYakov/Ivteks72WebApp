using System;
using System.Collections.Generic;
using System.Text;

namespace Ivteks72.Postman.Models
{
    public class PostmanAuthenticationSection
    {
        private string type;
        private List<PostmanTypeDefinition> typeDefinitions;
        private string protocolProfileBehavior;


        public PostmanAuthenticationSection()
        {
            this.protocolProfileBehavior = string.Empty;
        }

        public string Type { get => type; set => type = value; }
        internal List<PostmanTypeDefinition> TypeDefinitions { get => typeDefinitions; set => typeDefinitions = value; }
    }
}
