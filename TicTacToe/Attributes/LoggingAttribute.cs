using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class LoggingAttribute : ResultFilterAttribute, IActionFilter
    {
        IRepository repo = new DatabaseRepository();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Log log = new Log();
            LoggingDatabase logDB = new LoggingDatabase();
            log.Request = "["+context.HttpContext.Request.Method+"]"+context.HttpContext.Request.Path;
            log.Response = context.HttpContext.Response.StatusCode.ToString();
            log.Exception = "N/A";
            logDB.UpdateLogDB(log);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Log log = new Log();
            LoggingDatabase logDB = new LoggingDatabase();
            log.Request = "[" + context.HttpContext.Request.Method + "]" + context.HttpContext.Request.Path;
            log.Response = context.HttpContext.Response.StatusCode.ToString(); ;
            log.Exception = "N/A";
            logDB.UpdateLogDB(log);
        }
    }
}
