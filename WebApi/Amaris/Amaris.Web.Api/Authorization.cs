using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Amaris.Web.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class Authorization : AuthorizationFilterAttribute
    {
        public string Roles { get; set; }

        public override void OnAuthorization(HttpActionContext filterContext)
        {
            try
            {
                //var rol = new List<cRoles>();
                var autorization = filterContext.Request.Headers.Authorization.Parameter;
                if (filterContext.Request.Headers.Authorization.Scheme != "Basic")
                {
                    filterContext.Response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                    return;
                }
                //var encoding = Encoding.GetEncoding("iso-8859-1");
                //string autorization = encoding.GetString(Convert.FromBase64String(parameter));
                //int separator = autorization.IndexOf(':');
                //autorization = autorization.Substring(0, separator);
                //var GetRol = new Auth();
                //rol = GetRol.GetRolByUserName(name);
                if (!string.IsNullOrEmpty(autorization))
                {
                    //var filtered = rol.Where(x => x.rol == Roles).ToList();

                    if (Roles.Contains(autorization))
                    {
                        base.OnAuthorization(filterContext);
                    }
                    else
                    {
                        filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        return;
                    }
                }
                else
                {
                    filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    return;
                }
            }
            catch (Exception)
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                return;
            }
        }

    }
}
