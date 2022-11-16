using Adventure.Infrastructure.Util.InfraService;
using Adventure.Service.Interface;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Adventure.Application.Interceptors
{
    public class RequestResponseLogAttribute : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            AddLog(context);
            return next();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        #region Private

        private async void AddLog(ActionExecutingContext context)
        {
            var svc = context.HttpContext.RequestServices;
            var requestLogService = svc.GetService<IRequestResponseLogService>();
            
            await requestLogService!.SaveRequestLogAsync(context.ActionDescriptor.DisplayName!, context.ActionArguments,
                                                            context.ActionDescriptor.RouteValues);
        }

        #endregion
    }
}
