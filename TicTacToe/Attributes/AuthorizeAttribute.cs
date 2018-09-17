using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    [Exception]
    public class AuthorizeAttribute : ResultFilterAttribute, IActionFilter
    {
        IRepository repo = new DatabaseRepository();
        public void OnActionExecuted(ActionExecutedContext context)
        {
           // throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string Token = context.HttpContext.Request.Headers["AccessToken"].ToString();
            if (string.IsNullOrEmpty(Token))
            {
                throw new UnauthorizedAccessException("Access Token not passed");
            }
            else if(repo.IsAccessTokenValid(Token)==false)
            {
                throw new Exception("Invalid AccessToken");
            }
           
        }
    }
}
