using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GenerateToken
    {
        public string GenerateTokenId(string AccessToken)
        {
            string reverse = "";
            for(int i=AccessToken.Length-1;i>=0;i--)
            {
                reverse = reverse + AccessToken[i];
            }
            return reverse;
        }
    }
}
