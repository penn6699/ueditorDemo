using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Web.Http;
using System.Net.Http;


/// <summary>
/// 验证用户在线
/// </summary>
public class AuthFilterAttribute : AuthorizeAttribute//AuthorizationFilterAttribute
{
    public override void OnAuthorization(HttpActionContext actionContext)
    {
        //base.OnAuthorization(actionContext);

        //如果用户方位的Action带有AllowAnonymousAttribute，则不进行授权验证
        if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
        {
            return;
        }

        //string _jwt = JwtHelper.Jwt, msg = string.Empty;

        //if (string.IsNullOrEmpty(_jwt) || _jwt == "null")
        //{
        //    //throw new Exception("Token为空");
        //    msg = "Token为空";
        //}
        //if (!JwtHelper.IsVerifySigned(_jwt))
        //{
        //    //throw new Exception("Token签名不正确");
        //    msg = "Token签名不正确";
        //}
        bool u = SessionHelper.IsOnline();

        if (!SessionHelper.IsOnline())
        {
            
            //throw new UnauthorizedAccessException("请登录后，再操作");
            // 重新打包回传的讯息
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new AjaxResult
            {
                success = false,
                message = "请登录后，再操作"
            });

        }


    }


    //protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
    //{
    //    base.HandleUnauthorizedRequest(filterContext);

    //    //var response = filterContext.Response = filterContext.Response ?? new HttpResponseMessage();
    //    //response.StatusCode = HttpStatusCode.Forbidden;
    //    //var content = new Result
    //    //{
    //    //    success = false,
    //    //    errs = new[] { "服务端拒绝访问：你没有权限，或者掉线了" }
    //    //};
    //    //response.Content = new StringContent(Json.Encode(content), Encoding.UTF8, "application/json");
    //}
}