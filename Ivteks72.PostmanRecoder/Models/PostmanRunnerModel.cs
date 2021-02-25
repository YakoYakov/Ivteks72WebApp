using System;
using System.Collections.Generic;
using System.Text;

namespace Ivteks72.Postman.Models
{
    public class PostmanRunnerModel
    {
        private Dictionary<string, string> info;

        private List<PostmanRequest> postmanItemRequests;

        private PostmanAuthenticationSection authenticationSection;

        public PostmanRunnerModel()
        {
            this.Info = new Dictionary<string, string>()
            {
                { "_postman_id", Guid.NewGuid().ToString() },
                { "name", "PostmanAutomationTests" },
                { "schema", @"https://schema.getpostman.com/json/collection/v2.1.0/collection.json" }
            };

            this.PostmanItemRequests = new List<PostmanRequest>();

            this.AuthenticationSection = new PostmanAuthenticationSection()
            {
                Type = "oauth2",
                TypeDefinitions = new List<PostmanTypeDefinition>()
                {
                    new PostmanTypeDefinition
                    {
                        Key = "addTokenTo",
                        Value = "header",
                        Type = "string"
                    }
                }
            };
        }

        public Dictionary<string, string> Info { get => info; private set => info = value; }
        public PostmanAuthenticationSection AuthenticationSection { get => authenticationSection; private set => authenticationSection = value; }
        public List<PostmanRequest> PostmanItemRequests { get => postmanItemRequests; set => postmanItemRequests = value; }
    }
}
