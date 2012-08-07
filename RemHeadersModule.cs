using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;

namespace header
{
    public class RemHeadersModule: IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(HandleEndRequest);
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
                }
            }
        }
    }
}