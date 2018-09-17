using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class LoggingDatabase 
    {
        public void UpdateLogDB(Log log)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = @"Data Source=TAVDESK154;Initial Catalog=TictactoeUser;User Id=sa; Password=test123!@#";
                sqlConnection.Open();
                // string query = "Insert into User( Name , UserName , AccessToken ) values"+"'@name'"+" "+"''"
                string query = "Insert into  Logger (Request , Response, Exception ) values (@request , @response, @exception )";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@request", log.Request));
                sqlCommand.Parameters.Add(new SqlParameter("@response", log.Response));
                sqlCommand.Parameters.Add(new SqlParameter("@exception", log.Exception));
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Data Saved");
            }
            catch (SqlException e)
            {
               throw new Exception (e.StackTrace);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
