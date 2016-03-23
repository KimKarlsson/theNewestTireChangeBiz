using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void StoredProcedureOne(SqlDateTime DT)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand CheckSpecificDate = new SqlCommand();
            SqlParameter selectDayParam = new SqlParameter("@SelectedDay", SqlDbType.Date);
            selectDayParam.Value = DT;


            CheckSpecificDate.Parameters.Add(selectDayParam);


            CheckSpecificDate.CommandText = "SELECT dbo.TimeSlots.SlotTime, dbo.TireChange.TimeID" +
                                                "FROM dbo.TimeSlots INNER JOIN" +
                                                "dbo.TireChange ON dbo.TimeSlots.TimeID = dbo.TireChange.TimeID" +
                                                "WHERE dbo.TimeSlots.SlotTime < @SelectedDay" +
                                                "ORDER BY SlotTime ASC";

            CheckSpecificDate.Connection = conn;

            conn.Open();
            CheckSpecificDate.ExecuteNonQuery();
            conn.Close();
        }

    }
}
