using Microsoft.AspNetCore.Http;

namespace ProjectWeb.Application.Interfaces
{
    public interface IUploadFileInterface
    {
        string uploadPhoto(IFormFile file);
    }
}
