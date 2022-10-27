﻿#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ProjectWeb.Application.Extensions
{
    public static class FileExtensions
    {
        public static bool UploadFile(this IFormFile file, string fileName, string path, List<string>? validFormats = null)
        {
            if (validFormats != null && validFormats.Any())
            {
                var fileFormat = Path.GetExtension(file.FileName);

                if (validFormats.All(v => v != fileFormat))
                {
                    return false;
                }
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var finalPath = path + fileName;

            using (var stream = new FileStream(finalPath, FileMode.Create))
            {
                 file.CopyTo(stream);
            }

            return true;
        }
    }
}
