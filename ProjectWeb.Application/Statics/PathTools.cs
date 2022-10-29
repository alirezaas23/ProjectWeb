using System.IO;

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
        public static readonly string UserAvatarPath = "/content/user/";
        public static readonly string UserAvatarServerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/user/");

        #endregion

        #region Site Address

        public static readonly string SiteAddress = "https://localhost:44349";

        #endregion

        #region ckeditor

        public static readonly string EditorServerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/ckeditor/");
        public static readonly string EditorPath = "/content/ckeditor/";

        #endregion

        #region My Email

        public static readonly string MyEmail = "alirezaasgari683@gmail.com";

        #endregion
    }
}
