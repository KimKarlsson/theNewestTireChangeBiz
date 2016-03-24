using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void TotalCustomers()
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand CheckTotalCustomers = new SqlCommand();
            CheckTotalCustomers.CommandText = "SELECT Count(TimeID) AS 'Antal' FROM TireChange WHERE TimeID IS NOT NULL";
            SqlContext.Pipe.ExecuteAndSend(CheckTotalCustomers);
        }
    }
}
