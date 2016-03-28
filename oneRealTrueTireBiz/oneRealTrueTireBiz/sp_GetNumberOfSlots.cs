using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void GetNumberOfSlots(DateTime firstDT, DateTime? secondDT)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand CheckSpecificDate = new SqlCommand();
            SqlParameter selectDayParamFirst = new SqlParameter("@SelectedDay", SqlDbType.DateTime);
            SqlParameter selectDayParamSecond = new SqlParameter("@SelectSecondDay", SqlDbType.DateTime);
            selectDayParamFirst.Value = firstDT;
            selectDayParamSecond.Value = secondDT;
            CheckSpecificDate.Parameters.Add(selectDayParamFirst);
            CheckSpecificDate.Parameters.Add(selectDayParamSecond);
            CheckSpecificDate.CommandText = "IF @SelectSecondDay IS NULL BEGIN SELECT COUNT(*) as totalt FROM dbo.TimeSlots INNER JOIN dbo.TireChange ON dbo.TimeSlots.TimeID = dbo.TireChange.TimeID WHERE CAST(SlotTime AS DATE) = @SelectedDay and dbo.TimeSlots.TimeID is not null END ELSE BEGIN SELECT COUNT(*) as totalt FROM dbo.TimeSlots INNER JOIN dbo.TireChange ON dbo.TimeSlots.TimeID = dbo.TireChange.TimeID WHERE CAST(SlotTime AS DATE) BETWEEN @SelectedDay AND @SelectSecondDay and dbo.TimeSlots.TimeID is not null END";
            SqlContext.Pipe.ExecuteAndSend(CheckSpecificDate);
        }
    }
}