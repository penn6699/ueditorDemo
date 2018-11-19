﻿
/// <summary>
/// Json日期格式化
/// </summary>
public class JsonDateTimeFormat : System.Web.Http.Filters.ActionFilterAttribute
{
    private string FormatString;
    public JsonDateTimeFormat(){
        FormatString = "yyyy-MM-dd";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="FormatString">日期格式，如 yyyy-MM-dd</param>
    public JsonDateTimeFormat(string FormatString) {
        this.FormatString = FormatString;
    }

    public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
    {
        var JsonFormatter = actionContext.ControllerContext.Configuration.Formatters.JsonFormatter;
        if (JsonFormatter != null)
        {
            JsonFormatter.SerializerSettings.DateFormatString = FormatString;
            
        }

        base.OnActionExecuting(actionContext);
    }
}

