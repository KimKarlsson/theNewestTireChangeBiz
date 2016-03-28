using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void sp_getAgeGroup()
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand CheckAgeGroupCount = new SqlCommand();
            CheckAgeGroupCount.CommandText = "SELECT count(*) AS 'Antal', * FROM (select CASE WHEN Age BETWEEN 18 and 24 THEN '18-24' WHEN Age BETWEEN 25 and 34 THEN '25-34' WHEN Age BETWEEN 35 and 44 THEN '35-44' WHEN Age BETWEEN 45 and 54 THEN '45-54' WHEN Age BETWEEN 55 and 64 THEN '55-64' WHEN Age BETWEEN 65 and 80 THEN '65+' END AS age_range FROM[dbo].[Customer] WHERE Age Is NOT NULL ) t group by age_range order by age_range ";
            SqlContext.Pipe.ExecuteAndSend(CheckAgeGroupCount);
        }
    }
}
