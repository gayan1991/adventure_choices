using Adventure.Service.Interface;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Adventure.Application.Interceptors
{
    public class RequestResponseLogAttribute : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var svc = context.HttpContext.RequestServices;
            var requestLogService = svc.GetService<IRequestLogService>();

            var ss = context.ActionDescriptor.Parameters.ToDictionary(x => x.Name, x => x).FirstOrDefault();



            Task.Run(async () => await requestLogService!.SaveRequestLogAsync(context.ActionDescriptor.DisplayName!, context.ActionDescriptor.Parameters,
                context.ActionDescriptor.RouteValues));

            return next();
        }
    }
}
