using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.Interfaces
{
    public interface IUploadFileInterface
    {
        string uploadPhoto(IFormFile file);
    }
}
