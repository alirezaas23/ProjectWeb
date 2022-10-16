using Microsoft.AspNetCore.Mvc;

namespace ProjectWeb.Mvc.Controllers
{
    public class BaseController : Controller
    {
        public const string ErrorMessage = "ErrorMessage";
        public const string SuccessMessage = "SuccessMessage";
        public const string InfoMessage = "InfoMessage";
        public const string WarningMessage = "WarningMessage";
    }
}
