using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void CustomersPerDay()
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand CheckCustomersPerDay = new SqlCommand();

            CheckCustomersPerDay.CommandText ="SELECT CAST(SlotTime AS DATE) as DateField, COUNT(TireChange.TimeID) as CountField FROM TimeSlots LEFT JOIN TireChange ON TimeSlots.TimeID = TireChange.TimeID WHERE TireChange.TimeID IS NOT NULL GROUP BY CAST(SlotTime AS DATE) ORDER BY CountField DESC"; 
            SqlContext.Pipe.ExecuteAndSend(CheckCustomersPerDay);
        }

    }
}
