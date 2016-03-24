using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void RepeatCustomers()
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand CheckRepeatCustomers = new SqlCommand();
            //SqlParameter selectYearParam = new SqlParameter("@year", SqlDbType.Int);
            //selectYearParam.Value = DT.Year;        
            //CheckSpecificDate.Parameters.Add(selectYearParam);

            CheckRepeatCustomers.CommandText = "SELECT CONCAT(Customer.FirstName, ' ', Customer.LastName) AS Name, COUNT(1) as Antal FROM TireChange INNER JOIN Customer ON TireChange.CustomerID = Customer.CustomerID GROUP BY LastName, FirstName HAVING COUNT(1) > 2 ORDER BY Antal DESC";
            SqlContext.Pipe.ExecuteAndSend(CheckRepeatCustomers);
        }

    }
}
