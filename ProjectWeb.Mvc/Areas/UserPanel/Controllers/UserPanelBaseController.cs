using Microsoft.AspNetCore.Mvc;

namespace ProjectWeb.Mvc.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class UserPanelBaseController : Controller
    {
        public const string ErrorMessage = "ErrorMessage";
        public const string SuccessMessage = "SuccessMessage";
        public const string InfoMessage = "InfoMessage";
        public const string WarningMessage = "WarningMessage";
    }
}
