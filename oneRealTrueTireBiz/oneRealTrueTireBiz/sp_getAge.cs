using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    // parameter string Age, Antal, Null, för att sortera och få fram ålder. 
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void sp_getAge (string ageOrder)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand CheckSpecificDate = new SqlCommand();
            SqlParameter selectDayParamFirst = new SqlParameter("@SelectedOrder", SqlString.Null);
            selectDayParamFirst.Value = ageOrder;
            CheckSpecificDate.Parameters.Add(selectDayParamFirst);
         
            CheckSpecificDate.CommandText = "IF @SelectedOrder = 'Antal' SELECT Age, COUNT(*) as 'Antal' FROM[dbo].[Customer] WHERE Age Is NOT NULL Group by Age ORDER BY 'Antal' DESC ELSE IF @SelectedOrder = 'Age' SELECT Age, COUNT(*) as 'Antal' FROM[dbo].[Customer] WHERE Age Is NOT NULL Group by Age ORDER BY 'Age' DESC ELSE SELECT Age, COUNT(*) as 'Antal' FROM[dbo].[Customer] WHERE Age Is NOT NULL Group by Age";

            SqlContext.Pipe.ExecuteAndSend(CheckSpecificDate);
        }
    }
}
