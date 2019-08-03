namespace Ivteks72.Service
{
    using Microsoft.AspNetCore.Http;

    using System.Threading.Tasks;

    public interface ICloudinaryService
    {
        Task<string> UploadDiagramImage(IFormFile file, string fileName);
    }
}
