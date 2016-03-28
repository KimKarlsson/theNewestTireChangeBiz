using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void sp_CLRNumberTwo ()
    {
        // Put your code here
        using(SqlConnection connection = new SqlConnection("context connection=true"))
      {
            connection.Open();
            SqlCommand command = new SqlCommand("select @@version as 'Version'", connection);
            SqlDataReader r = command.ExecuteReader();
            SqlContext.Pipe.Send(r);
            connection.Close();
        }
    }
}
