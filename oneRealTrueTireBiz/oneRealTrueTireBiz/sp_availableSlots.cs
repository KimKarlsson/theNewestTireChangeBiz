using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void AvailableSlots(DateTime DT)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand CheckSpecificDate = new SqlCommand();
            SqlParameter selectYearParam = new SqlParameter("@year", SqlDbType.Int);
            SqlParameter selectMonthParam = new SqlParameter("@month", SqlDbType.Int);
            SqlParameter selectDayParam = new SqlParameter("@day", SqlDbType.Int);
            SqlParameter selectBeforeParam = new SqlParameter("@beforeHour", SqlDbType.Int);
            SqlParameter selectAfterParam = new SqlParameter("@afterHour", SqlDbType.Int);
            selectYearParam.Value = DT.Year;
            selectMonthParam.Value = DT.Month;
            selectDayParam.Value = DT.Day;
            selectAfterParam.Value = 7;
            selectBeforeParam.Value = 17;

            CheckSpecificDate.Parameters.Add(selectYearParam);
            CheckSpecificDate.Parameters.Add(selectMonthParam);
            CheckSpecificDate.Parameters.Add(selectDayParam);
            CheckSpecificDate.Parameters.Add(selectAfterParam);
            CheckSpecificDate.Parameters.Add(selectBeforeParam);

            CheckSpecificDate.CommandText ="SELECT TimeSlots.SlotTime FROM TimeSlots LEFT JOIN TireChange ON TimeSlots.TimeID = TireChange.TimeID WHERE TireChange.TimeID IS NULL AND SlotTime BETWEEN DATETIMEFROMPARTS(@year, @month, @day, @afterHour, 0, 0, 0) AND DATETIMEFROMPARTS(@year, @month, @day, @beforeHour, 0, 0, 0) ORDER BY SlotTime";
            SqlContext.Pipe.ExecuteAndSend(CheckSpecificDate);
        }

    }
}
