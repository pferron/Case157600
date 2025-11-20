using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WOW.WoodmenIllustrationService.Code
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1018:MarkAttributesWithAttributeUsage")]
    public sealed class ValidateMimeMultipartContentFilterAttribute : ActionFilterAttribute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {

        }
    }
}