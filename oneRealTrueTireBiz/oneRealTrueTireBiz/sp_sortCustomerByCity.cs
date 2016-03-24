using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void CustomerCity()
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand SortCustomerByCity = new SqlCommand();
            //SqlParameter selectYearParam = new SqlParameter("@year", SqlDbType.Int);
            //selectYearParam.Value = DT.Year;        
            //CheckSpecificDate.Parameters.Add(selectYearParam);

            SortCustomerByCity.CommandText ="SELECT Customer.City, COUNT(*) AS 'Antal' FROM Customer WHERE City IS NOT NULL GROUP BY City ORDER BY 'Antal' DESC";
            SqlContext.Pipe.ExecuteAndSend(SortCustomerByCity);
        }

    }
}
