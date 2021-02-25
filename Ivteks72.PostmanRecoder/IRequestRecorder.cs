using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ivteks72.Postman
{
    public interface IRequestRecorder
    {
        Task InvokeAsync(HttpContext context);
        Task<StringBuilder> GetFinalResult();
    }
}
