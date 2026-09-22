using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;

namespace ROFR.helper
{
    public class RequireHttps: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                //actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                //{
                //    ReasonPhrase = "HTTPS Required"
                //};
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Found);
                actionContext.Response.Content = new StringContent("<p>Use https instead of http</p>");

                UriBuilder uribuilder = new UriBuilder(actionContext.Request.RequestUri);
                uribuilder.Scheme = Uri.UriSchemeHttps;
                uribuilder.Port = 443;
                actionContext.Response.Headers.Location = uribuilder.Uri;
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}