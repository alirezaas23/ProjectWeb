using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectWeb.Application.Statics
{
    public static class PathTools
    {
        public static readonly string ProductImagePath = "/content/product/";
        public static readonly string ProductImageServerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/product/");
    }
}
