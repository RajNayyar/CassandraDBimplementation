using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    [Exception]
    public class Game
    {
        public static string playerOne = "";
        public static string playerTwo = "";
        List<List<int>> WinningPOS = new List<List<int>>();
        static int[] checkboard = new int[9];
        static int turnOf = 1;
        static int gameOver = 0;
        public static string GameStatus = "In Progress";
        public string game(string accesstoken, int move)
        {
            GameStatus = "In Progress";
            WinningPOSBoard();
            if(accesstoken!= playerOne && accesstoken!= playerTwo && (playerOne!="" && playerTwo!=""))
            {
                throw new Exception ("Game Already Under Progress, Can't add extra players");
            }
            if(playerOne=="")
            {
                playerOne = accesstoken;
            }
            else if(playerOne!=accesstoken && playerTwo=="")
            {
                playerTwo = accesstoken;
            }

            if(turnOf == 1 && accesstoken == playerOne )
            {
                int exception = fillGameBoard(turnOf, move);
                if(exception==-1)
                {
                    return "You can't make same move again!";
                }
                turnOf = 2;
            }
            else if( turnOf==2 && accesstoken == playerTwo)
            {
                int exception = fillGameBoard(turnOf, move);
                if (exception == -1)
                {
                    return "You can't make same move again!";
                }
                turnOf = 1;
            }
            else
            {
                return ("It's not your turn");
            }
            int count1 = 0;
            int count2 = 0;
            int count0 = 0;
            for(int i=0;i<WinningPOS.Count;i++)
            {

                if (count1 == 3)
                    break;
                else if (count2 == 3)
                    break;
                count2 = 0;
                count1 = 0;
                for (int j=0;j<WinningPOS[0].Count;j++)
                {
                    if(checkboard[WinningPOS[i][j]]==1)
                    {
                        count1++;
                    }
                    if (checkboard[WinningPOS[i][j]] == 2)
                    {
                        count2++;
                    }
                    if (checkboard[WinningPOS[i][j]] == 0)
                    {
                        count0++;
                    }
                }
            }

            if(count1 == 3)
            {
                playerOne = "";
                playerTwo = "";
               // gameOver = 1;
                turnOf = 1;
                checkboard = new int[9];
                GameStatus = "Not In Progress";
                return "Player One" + " Won.. Game About to refresh";
            }
            if(count2 == 3)
            {
                playerOne = "";
                playerTwo = "";
               // gameOver = 1;
                turnOf = 1;
                checkboard = new int[9];
                GameStatus = "Not In Progress";
                return "player Two" + " Won.. Game About to refresh";
            }
            if(count0==0)
            {
                playerOne = "";
                playerTwo = "";
                // gameOver = 1;
                turnOf = 1;
                checkboard = new int[9];
                GameStatus = "Not In Progress";
                return "Game draw";
            }
            return "Move Completed Successful";
        }

        private void WinningPOSBoard()
        {
            List<int> pos0 = new List<int>() { 0, 1, 2 };
            List<int> pos1 = new List<int>() { 3, 4, 5};
            List<int> pos2 = new List<int>() { 6, 7, 8 };
            List<int> pos3 = new List<int>() { 0, 3, 6 };
            List<int> pos4 = new List<int>() { 1, 4, 7 };
            List<int> pos5 = new List<int>() { 2, 5, 8 };
            List<int> pos6 = new List<int>() { 0, 4, 8 };
            List<int> pos7 = new List<int>() { 2 ,4 ,6 };
            WinningPOS.Add(pos0);
            WinningPOS.Add(pos1);
            WinningPOS.Add(pos2);
            WinningPOS.Add(pos3);
            WinningPOS.Add(pos4);
            WinningPOS.Add(pos5);
            WinningPOS.Add(pos6);
            WinningPOS.Add(pos7);
        }

        private int fillGameBoard(int turnOf, int move)
        {
            if(checkboard[move]==0)
            {
                checkboard[move] = turnOf;
            }
            else
            {
                return -1;
            }
            return 0;
        }
    }
}
