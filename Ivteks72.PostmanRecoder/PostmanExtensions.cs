using Ivteks72.Postman;
using Microsoft.AspNetCore.Builder;

namespace Ivteks72.PostmanRecoder
{
    public static class PostmanExtensions
    {
        public static IApplicationBuilder UsePostmanRecoder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PostmanImp>();
        }
    }
}
