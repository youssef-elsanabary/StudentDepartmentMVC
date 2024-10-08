using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstProject.FilterAction
{
    public class ExeptionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null) {
                context.ExceptionHandled = true;
                context.Result = new ContentResult() { Content = "error occured" };
            }
            base.OnActionExecuted(context);
        }
    }
}
