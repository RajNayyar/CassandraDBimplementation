using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IRepository
    {
      Boolean CreateUser(User user);

        bool IsAccessTokenValid(string apiKey);
    }
}
