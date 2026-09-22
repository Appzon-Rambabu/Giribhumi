using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Http;
using System.Web.Routing;
using ROFR.helper;

namespace ROFR
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
           
        }

        //void Session_start(object sender, EventArgs e)
        //{
        //    Application.Lock();
        //    Application["TotalVisitors"] = (int)Application["TotalVisitors"] + 1;
        //    Application.UnLock();
        //}
        //void Session_End(object sender, EventArgs e)
        //{
        //    Application.Lock();
        //    Application["TotalVisitors"] = (int)Application["TotalVisitors"] - 1;
        //    Application.UnLock();
        //}

        public static void RegisterRoutes(RouteCollection rootes)
        {
            rootes.MapPageRoute("", "", "~/ROFR_HOME_PAGE.aspx");
        }
        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {

            HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");
            HttpContext.Current.Response.Headers.Remove("Server");

            //HttpContext.Current.Response.AddHeader("X-Frame-Options", "DENY");
            //HttpContext.Current.Response.AddHeader("X-XSS-Protection", "1; mode=block");
            //HttpContext.Current.Response.AddHeader("X-Content-Type-Options", "nosniff");
            //HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache,private, no-store, must-revalidate,max-stale=0, post-check=0, pre-check=0");
            //HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            //HttpContext.Current.Response.AddHeader("Expires", "0");

            //HttpContext.Current.Response.AddHeader("X-Permitted-Cross-Domain-Policies", "none");
            //HttpContext.Current.Response.AddHeader("Strict-Transport-Security", "max-age=31536000; includeSubDomains");

            // HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "default-src 'self' ; report-uri: http://localhost:60061;");
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "https://giribhumi.ap.gov.in");
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Accept,Accept-Encoding,Accept-Language,Cache-Control,Content-Type,Host,Origin,Pragma,Referer,User-Agent,username,sessionid");

            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, PUT, POST, OPTIONS");

            //HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "script-src 'self'; report-uri: https://giribhumi.ap.gov.in;");
            //HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "style-src 'self'; report-uri: https://giribhumi.ap.gov.in;");

            //HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "child-src 'self'; report-uri: https://giribhumi.ap.gov.in;");
            //HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "font-src 'self'; report-uri: https://giribhumi.ap.gov.in;");
            //HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "img-src 'self'; report-uri: https://giribhumi.ap.gov.in;");
            //HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "manifest-src 'self'; report-uri: https://giribhumi.ap.gov.in;");
            //HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "object-src 'self'; report-uri: https://giribhumi.ap.gov.in;");
            ////HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "script-src 'self'; report-uri: https://giribhumi.ap.gov.in;");


        }

        void Application_BeginRequest()
        {

            //Response.AddHeader("X-Frame-Options", "DENY");
            Response.AddHeader("X-XSS-Protection", "1; mode=block");
            Response.AddHeader("X-Content-Type-Options", "nosniff");
            Response.Headers.Remove("X-AspNet-Version");
            Response.Headers.Remove("X-AspNetMvc-Version");
            Response.Headers.Remove("X-Powered-By");
            Response.Headers.Remove("Server");
            // HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "script-src 'self'; report-uri:https://giribhumi.ap.gov.in;");
            //  HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "style-src 'self'; report-uri:https://giribhumi.ap.gov.in;");
            // HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "child-src 'self'; report-uri:https://giribhumi.ap.gov.in;");
            // HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "font-src 'self'; report-uri:https://giribhumi.ap.gov.in;");
            // HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "img-src 'self'; report-uri:https://giribhumi.ap.gov.in;");
            // HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "manifest-src 'self'; report-uri:https://giribhumi.ap.gov.in;");
            //HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "object-src 'self'; report-uri:https://giribhumi.ap.gov.in;");


            //// HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "script-src 'unsafe-inline'");
            //HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "script-src 'self'; report-uri:https://giribhumi.ap.gov.in;");
            ////  HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "style-src 'self'");
            //HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "child-src 'self'");
            ////  HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "font-src 'self'");
            //HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "img-src 'self'");
            //HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "manifest-src 'self'");
            //HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "object-src 'self'");
        }

        void Application_Error(object sender, EventArgs e)
        {
            // ReGenerateSessionId();
            Exception exception = Server.GetLastError();
            var httpException = exception as HttpException;
            var val = httpException.GetHttpCode();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.AddHeader("Cache-Control", "no-cache,private, no-store, must-revalidate, pre-check=0, post-check=0,max-stale=0,Accept,Accept-Encoding,Accept-Language,Cache-Control,Content-Type,Host,Origin,Pragma,Referer,User-Agent,username,sessionid");
            Response.AddHeader("Pragma", "no-cache");
            Response.AddHeader("Expires", "0");
            Response.Headers.Remove("X-AspNet-Version");
            Response.Headers.Remove("X-AspNetMvc-Version");
            Response.Headers.Remove("X-Powered-By");
            Response.Headers.Remove("Server");
            string cd = httpException.GetHttpCode().ToString();
            if (exception != null && (httpException.GetHttpCode().ToString() == "404" ||
                httpException.GetHttpCode().ToString() == "403"

                ))
            {
                Response.Headers.Remove("Server");
                Response.Redirect("../Errors/Error404.aspx");

            }
            if (exception != null && (httpException.GetHttpCode().ToString() == "503" ||
               httpException.GetHttpCode().ToString() == "500"
               ))
            {
                // Response.Redirect("~/Error.html");
                Response.Redirect("../Errors/Error.aspx");
                //Response.Redirect("http://localhost:60061/Errors/Error.aspx");

                // Response.Redirect("https://hazaru108n104.ap.gov.in/ambulanceweb/Error.html");
                //log the error
            }
        }

      
    }
   

}
