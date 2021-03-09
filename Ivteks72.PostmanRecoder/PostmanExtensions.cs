using Ivteks72.Postman;
using Microsoft.AspNetCore.Builder;

namespace Ivteks72.PostmanRecoder
{
    public static class PostmanExtensions
    {
        public static IApplicationBuilder UsePostmanRecoder(this IApplicationBuilder builder, bool isRecording)
        {
            return builder.UseMiddleware<PostmanImp>(isRecording);
        }
    }
}
