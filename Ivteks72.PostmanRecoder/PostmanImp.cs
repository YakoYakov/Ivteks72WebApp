using Ivteks72.Postman.Models;
using Ivteks72.Postman.Models.TestScriptModels;
using Ivteks72.Postman.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivteks72.Postman
{
    public class PostmanImp : IRequestRecorder
    {
        private static PostmanRunnerModel _RunnerModel = new();
        public readonly RequestDelegate _next;
        private bool IsRunning { get; set; }
        public PostmanImp(RequestDelegate next, bool isRecording) 
        {
            _next = next;
            this.IsRunning = isRecording;
        }

        public Task<StringBuilder> GetFinalResult()
        {
            StringBuilder result = GetJsonString(_RunnerModel);
            _RunnerModel = new PostmanRunnerModel();
            return Task.FromResult(result);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            #region Setting up required data from the HttpRequest
            string body = await GetBodyAsync(request);

            string method = request.Method;

            List<PostmanHeaderSection> pHeaders = new();
            JObject headers = JObject.Parse(GetJsonString(request.Headers).ToString());


            string url = request.GetEncodedUrl();
            List<string> hostSegments = request.Host.Value.Split('/', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> pathSegments = request.Path.Value.Split('/', StringSplitOptions.RemoveEmptyEntries).ToList();

            List<PostmanQuerySection> queries = request.Query.Select(k => new PostmanQuerySection
            {
                Key = k.Key,
                Value = k.Value.ToString()
            }).ToList();

            foreach (var header in headers)
            {
                pHeaders.Add(new PostmanHeaderSection
                {
                    Key = header.Key.StartsWith(':') ? header.Key.TrimStart(':') : header.Key,
                    Value = header.Value.First.ToString()
                });
            }
            #endregion

            PostmanBuilder builder = new();

            // Construct the Request entity
            RequestContent requestContent = builder
                .MethodBuilder
                    .AddMethod(method)
                .HeaderBuilder
                    .AddHeader(pHeaders)
                .BodyBuilder
                    .AddBody("raw", body)
                .UrlBuilder
                    .AddUrlData(url, request.Scheme, pathSegments, hostSegments, queries);

            // Add the first event for script to the first request
            if (_RunnerModel.PostmanItemRequests.Count < 1)
            {
                var firstRequestEvent = JsonConvert.DeserializeObject<List<Event>>(ResourceReader.GetResource("FirstRequest"));

                _RunnerModel.PostmanItemRequests.Add(new PostmanRequest
                {
                    Name = url,
                    FirstRequestEvent = firstRequestEvent,
                    RequestContent = requestContent
                });

                return;
            }

            // Add newly constructed Request and the url to the Runner Model 
            _RunnerModel.PostmanItemRequests.Add(new PostmanRequest
            {
                Name = url,
                RequestContent = requestContent
            });
            await _next(context);
        }

        private static async Task<string> GetBodyAsync(HttpRequest request)
        {
            request.EnableBuffering();
            string body = string.Empty;

            // Leave the body open so the next middleware can read it.
            using (var reader = new StreamReader(
                request.Body,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: 1024,
                leaveOpen: true))
            {
                body = await reader.ReadToEndAsync();
                // Do some processing with body…
                // Reset the request body stream position so the next middleware can read it
                request.Body.Position = 0;
            }
            request.EnableBuffering();
            return body;
        }

        private static StringBuilder GetJsonString(object model)
        {
            string jsonString = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            StringBuilder builder = new(jsonString);

            return builder;
        }

    }
}
