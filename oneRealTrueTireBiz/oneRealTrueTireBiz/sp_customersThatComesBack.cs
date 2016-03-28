using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void sp_customersThatComesBack()
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand customersThatReturns = new SqlCommand();
            customersThatReturns.CommandText = "SELECT CONCAT(Customer.FirstName, ' ', Customer.LastName) AS Name, COUNT(1) as Antal FROM TireChange INNER JOIN Customer ON TireChange.CustomerID = Customer.CustomerID GROUP BY LastName, FirstName HAVING COUNT(1) > 1 ORDER BY Antal DESC";
            SqlContext.Pipe.ExecuteAndSend(customersThatReturns);
        }
    }
}
