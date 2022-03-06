using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string ErrorMessage = "ErrorMessage";
        protected string InfoMessage = "InfoMessage";
        protected string WarningMessage = "WarningMessage";
        protected string SuccessMessage = "SuccessMessage";
    }
}
