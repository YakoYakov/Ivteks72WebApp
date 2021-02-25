using Ivteks72.Postman.Models;
using Ivteks72.Postman.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private readonly RequestDelegate _next;
        private StringBuilder _Builder = new StringBuilder();
        private static PostmanImp postmanInstance;

        public PostmanImp(RequestDelegate next) 
        {
            _next = next;
        }

        public Task<StringBuilder> GetFinalResult()
        {
            throw new NotImplementedException();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            PostmanRunnerModel resultTest = new PostmanRunnerModel();

            var url = context.Request.GetEncodedUrl(); // raw Uri for Name in Jsons
            var settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            var headers =JObject.Parse(JsonConvert.SerializeObject(context.Request.Headers, settings));
            var serializer = JsonSerializer.CreateDefault();
            List<PostmanHeaderSection> pHeaders = new List<PostmanHeaderSection>();
            List<string> pathSegments = context.Request.Path.Value.Split('/').ToList(); //inputModel.Client[":path"].ToString().Split("/").ToList(); //request.Path.Value.Split('/').ToList();
            List<string> hostSegments = context.Request.Host.Value.Split('/').ToList(); //inputModel.Client["Host"].ToString().Split("/").ToList();//request.Host.Value.Split('/').ToList();

            foreach (var header in headers)
            {
                pHeaders.Add(new PostmanHeaderSection
                {
                    Key = header.Key,
                    Value = header.Value
                });
            }

            var body = await GetBodyAsync(context.Request);
                //JObject.Parse(JsonConvert.SerializeObject(inputModel.Data, settings)).ToString();

            var builder = new PostmanBuilder();
            var requestTest = builder
                .MethodBuilder
                    .AddMethod("POST")
                .HeaderBuilder
                    .AddHeader(pHeaders)
                .BodyBuilder
                    .AddBody("raw", body)
                .UrlBuilder
                    .AddUrlData(url, context.Request.Scheme, pathSegments, hostSegments);

           var a = JsonConvert.SerializeObject(requestTest);
            //_Builder.AppendLine(headers.ToString());
            ;
            //WriteToFile(_Builder);
            await _next(context);
        }

        //public static PostmanImp GetInstance()
        //{
        //    if (postmanInstance == null)
        //    {
        //        postmanInstance = new PostmanImp();
        //    }

        //    return postmanInstance;
        //}

        private void WriteToFile(StringBuilder content)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"D:\Old_Desktop\TrainigWorkFor\test.json", true))
            {
                file.WriteLine(content);
            }
        }

        private async Task<string> GetBodyAsync(HttpRequest request)
        {
            //request.EnableBuffering();
            string body = string.Empty;

            // Leave the body open so the next middleware can read it.
            using (var reader = new StreamReader(
                request.Body,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                leaveOpen: true))
            {
                body = await reader.ReadToEndAsync();
                // Do some processing with body…
                // Reset the request body stream position so the next middleware can read it
                request.Body.Position = 0;
            }

            return body;
        }

    }
}
