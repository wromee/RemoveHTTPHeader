using System;
using System.Web;
using System.Collections.Specialized;

namespace header
{
    public class HeadRemove : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.LogRequest += new EventHandler(HandleEndRequest);
        }

        protected void HandleEndRequest(Object sender, EventArgs e)
        {
            HttpResponse oResp = System.Web.HttpContext.Current.Response;
            if (oResp != null)
            {
                NameValueCollection oRespHeaders = oResp.Headers;
                if (oRespHeaders != null)
                {
                    oRespHeaders.Remove("X-AspNet-Version");
                    oRespHeaders.Remove("Server");
                    oRespHeaders.Remove("ETag");
                    oRespHeaders.Remove("X-AspNetMvc-Version");
                }
            }
        }
    }
}
