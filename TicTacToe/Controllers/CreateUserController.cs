using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TicTacToe;

namespace TicTacToe.Controllers
{

    [Produces("application/json")]

    [Route("api/CreateUser")]
    public class CreateUserController : Controller
    {
        List<User> AllUsers = new List<User>();
        IRepository repo;

        [Logging]
        [Exception]
        [HttpPost]
        public string CreateUser1([FromBody]User x)
        {
            GenerateToken token = new GenerateToken();
            var AccessToken = token.GenerateTokenId(x.UserName);
            x.AccessToken = AccessToken;
            IRepository repo = new DatabaseRepository();
            repo.CreateUser(x);
            return AccessToken;
        }

        [Authorize]
        [Logging]
        [Exception]
        [HttpGet]
        public string LogInUser()
        {
            return("Login Successful");
        }

    }
}