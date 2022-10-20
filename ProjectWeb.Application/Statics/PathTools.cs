﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectWeb.Application.Statics
{
    public static class PathTools
    {
        #region Product

        public static readonly string ProductImagePath = "/content/product/";
        public static readonly string ProductImageServerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/product/");

        #endregion

        #region User

        public static readonly string UserAvatar = "DefaultAvatar.png";

        #endregion

        #region Site Address

        public static readonly string SiteAddress = "https://localhost:44349";

        #endregion
    }
}
