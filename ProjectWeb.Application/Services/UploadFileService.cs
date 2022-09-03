using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProjectWeb.Application.Interfaces;
using System.IO;

namespace ProjectWeb.Application.Services
{
    public class UploadFileService : IUploadFileInterface
    {
        private readonly IHostingEnvironment _environment;

        public UploadFileService(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public string uploadPhoto(IFormFile file)
        {
            if (file == null) return "";
            var path = _environment.WebRootPath + "\\Images\\Product\\" + file.FileName;
            using (FileStream f = new FileStream(path, FileMode.Open, FileAccess.Write))
            {
                file.CopyTo(f);
                path = path.Split("wwwroot")[1];
                return path;
            }
        }
    }
}
