using Cassandra;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class DatabaseRepository : IRepository
    {
        List<User> AllUsers = new List<User>();
        IRepository repo;
        public Boolean CreateUser(User user)
        {
           // SqlConnection sqlConnection = null;
            //try
            //{
                // Connect to the TicTacToe keyspace on our cluster running at 127.0.0.1
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                ISession session = cluster.Connect("tictactoe");

                //Prepare a statement once
                var ps = session.Prepare("INSERT INTO \"userdetails\" (\"username\", \"access\", \"name\") VALUES (?,?,?)");

                //...bind different parameters every time you need to execute
                var statement = ps.Bind(user.UserName, user.AccessToken, user.Name);
                //Execute the bound statement with the provided parameters
                session.Execute(statement);
                return true;



                //sqlConnection = new SqlConnection();
                //sqlConnection.ConnectionString = @"Data Source=TAVDESK154;Initial Catalog=TictactoeUser;User Id=sa; Password=test123!@#";
                //sqlConnection.Open();
                //// string query = "Insert into User( Name , UserName , AccessToken ) values"+"'@name'"+" "+"''"
                //string query = "Insert into  UserDetails ( Name , UserName , AccessToken ) values ( @name ,@username , @acesstoken )";
                //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //sqlCommand.Parameters.Add(new SqlParameter("@name", user.Name));
                //sqlCommand.Parameters.Add(new SqlParameter("@username", user.UserName));
                //sqlCommand.Parameters.Add(new SqlParameter("@acesstoken", user.AccessToken));
                //sqlCommand.ExecuteNonQuery();
                //Console.WriteLine("Data Saved");
            //}
            //catch (SqlException e)
            //{
            //    throw new Exception(e.StackTrace);
            //}
            //finally
            //{
            //    sqlConnection.Close();
            //}
        }
        public bool IsAccessTokenValid(string AccessToken)
        {
            try
            {
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                ISession session = cluster.Connect("tictactoe");

                //Prepare a statement once
                Row ps = session.Execute("select * from userdetails where access = '" + AccessToken + "' allow filtering").First();

                if(Convert.ToString(ps["access"]) == AccessToken)
                {
                    return true;
                }
                throw new Exception("Does Not exist");
                return false;
                //...bind different parameters every time you need to execute
                //Execute the bound statement with the provided parameters
            }
            catch(Exception ex)
            {
                return false;
            }



                //sqlConnection = new SqlConnection();
                //sqlConnection.ConnectionString = @"Data Source=TAVDESK154;Initial Catalog=TictactoeUser;User Id=sa; Password=test123!@#";
                //sqlConnection.Open();
                //// string query = "Insert into User( Name , UserName , AccessToken ) values"+"'@name'"+" "+"''"
                //string query = "select * from userdetails where access = '"+AccessToken+"'";
                //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //SqlDataReader reader = sqlCommand.ExecuteReader();
                //while (reader.Read())
                //{
                //    if(AccessToken == reader["AccessToken"].ToString())
                //    {
                //        return true;
                //    }
                //}
                //return false;

        
        }
    }
}
