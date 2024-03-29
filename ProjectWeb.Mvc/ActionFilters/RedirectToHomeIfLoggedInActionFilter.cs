﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjectWeb.Mvc.ActionFilters
{
    public class RedirectToHomeIfLoggedInActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.HttpContext.Response.Redirect("/");
            }
        }
    }
}
