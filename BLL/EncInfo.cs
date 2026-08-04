using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class EncInfo
{
    private readonly ConvertDtToList _appConvertDtToList = new();

    public List<Models.EncInfo> EncInfoCRUD(Models.EncInfo encinfo)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", encinfo.CRUD);
        com.Parameters.AddWithValue("@EncID", encinfo.EncID);
        com.Parameters.AddWithValue("@DepID", encinfo.DepID);
        com.Parameters.AddWithValue("@InfoStatus", encinfo.InfoStatus);
        com.Parameters.AddWithValue("@UserPersID", encinfo.UserPersID);
        com.Parameters.AddWithValue("@StartDate", encinfo.StartDate);
        //com.Parameters.AddWithValue("@EndDate", encinfo.EndDate);

        //com.Parameters.AddWithValue("@EncInfoID", encinfo.EncInfoID);
        //com.Parameters.AddWithValue("@EncID", encinfo.EncID);
        //com.Parameters.AddWithValue("@StartDate", encinfo.StartDate);
        //com.Parameters.AddWithValue("@EndDate", encinfo.EndDate);
        //com.Parameters.AddWithValue("@IsDisable", encinfo.IsDisable);
        //com.Parameters.AddWithValue("@DepID", encinfo.DepID);
        //com.Parameters.AddWithValue("@DrID", encinfo.DrID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spEncInfo");
        return _appConvertDtToList.ConvertDataTable<Models.EncInfo>(dt);
    }



    public List<Models.EncInfo> LoadDrDeskList(int depID, string date)
    {
        var date1 = string.IsNullOrWhiteSpace(date) ? null : date.Substring(0, Math.Min(10, date.Length)) + " 00:00";
        var date2 = string.IsNullOrWhiteSpace(date) ? null : date.Substring(0, Math.Min(10, date.Length)) + " 23:59";

        const string tsql = @"
            SELECT ROW_NUMBER() OVER (ORDER BY ISNULL(ei.SortID, 1000000), ei.EncInfoID) AS RecNO,
                   ei.EncInfoID,
                   ei.EncID,
                   p.FirstName + N' ' + p.LastName AS FullName,
                   ei.InfoStatus,
                   TInfoStatus.Name AS InfoStatusName,
                   ei.StartDate,
                   ei.EndDate,
                   ei.IsDisable,
                   ei.DepID,
                   ei.DrID,
                   ISNULL(dr.Name, N'') AS DrName,
                   ei.UserPersID,
                   e.StartDate AS EncStartDate,
                   ISNULL(s.Name, N'') AS ServiceName,
                   ISNULL(ei.Note, N'') AS Note,
                   ISNULL(ei.SortID, ei.EncInfoID) AS SortID
            FROM dbo.EncInfo ei
            INNER JOIN dbo.Enc e ON e.EncID = ei.EncID
            INNER JOIN dbo.Patient p ON p.PatientID = e.PatientID
            INNER JOIN dbo.ADR TInfoStatus ON TInfoStatus.ID = ei.InfoStatus AND TInfoStatus.ADID = 43
            LEFT JOIN dbo.vDr dr ON dr.DrID = ei.DrID
            OUTER APPLY
            (
                SELECT TOP 1 s.Name
                FROM dbo.Page pg
                INNER JOIN dbo.ServiceReg sr ON sr.PageID = pg.PageID
                INNER JOIN dbo.Service s ON s.ServiceID = sr.ServiceID
                WHERE pg.EncID = ei.EncID
                ORDER BY pg.PageID DESC, sr.SRID DESC
            ) s
            WHERE ISNULL(ei.IsDisable, 0) = 0
              AND ei.InfoStatus IN (101, 102, 103)
              AND (@DepID <= 0 OR ei.DepID = @DepID)
              AND (@Date1 IS NULL OR ei.StartDate >= @Date1)
              AND (@Date2 IS NULL OR ei.StartDate <= @Date2)
            ORDER BY ISNULL(ei.SortID, 1000000), ei.EncInfoID";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@DepID", depID);
        com.Parameters.AddWithValue("@Date1", (object?)date1 ?? DBNull.Value);
        com.Parameters.AddWithValue("@Date2", (object?)date2 ?? DBNull.Value);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return _appConvertDtToList.ConvertDataTable<Models.EncInfo>(dt);
    }

    public void UpdateNote(int encInfoID, string? note, int userPersID)
    {
        const string tsql = @"
            UPDATE dbo.EncInfo
               SET Note = @Note,
                   UserPersID = CASE WHEN @UserPersID > 0 THEN @UserPersID ELSE UserPersID END
             WHERE EncInfoID = @EncInfoID";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@EncInfoID", encInfoID);
        com.Parameters.AddWithValue("@Note", (object?)note ?? DBNull.Value);
        com.Parameters.AddWithValue("@UserPersID", userPersID);

        new DataService().ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
    }



    public void SwapSort(int encInfoID1, int encInfoID2)
    {
        if (encInfoID1 <= 0 || encInfoID2 <= 0 || encInfoID1 == encInfoID2) return;

        const string tsql = @"
            DECLARE @Sort1 INT, @Sort2 INT;
            SELECT @Sort1 = ISNULL(SortID, EncInfoID) FROM dbo.EncInfo WHERE EncInfoID = @EncInfoID1;
            SELECT @Sort2 = ISNULL(SortID, EncInfoID) FROM dbo.EncInfo WHERE EncInfoID = @EncInfoID2;

            UPDATE dbo.EncInfo SET SortID = @Sort2 WHERE EncInfoID = @EncInfoID1;
            UPDATE dbo.EncInfo SET SortID = @Sort1 WHERE EncInfoID = @EncInfoID2;";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@EncInfoID1", encInfoID1);
        com.Parameters.AddWithValue("@EncInfoID2", encInfoID2);
        new DataService().ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
    }

    public void MoveSort(int encInfoID, int direction)
    {
        if (encInfoID <= 0 || direction == 0) return;

        const string normalizeSql = @"
            ;WITH x AS
            (
                SELECT EncInfoID, ROW_NUMBER() OVER (ORDER BY ISNULL(SortID, 1000000), EncInfoID) AS rn
                FROM dbo.EncInfo
                WHERE ISNULL(IsDisable, 0) = 0
            )
            UPDATE ei SET SortID = x.rn
            FROM dbo.EncInfo ei
            INNER JOIN x ON x.EncInfoID = ei.EncInfoID
            WHERE ei.SortID IS NULL OR ei.SortID = 0;";
        new DataService().ExecuteNonQueryByText(CSet.cnStringHIS, new SqlCommand(), normalizeSql);

        const string tsql = @"
            DECLARE @SortID INT, @OtherEncInfoID INT, @OtherSortID INT;
            SELECT @SortID = ISNULL(SortID, EncInfoID) FROM dbo.EncInfo WHERE EncInfoID = @EncInfoID;

            IF @Direction < 0
            BEGIN
                SELECT TOP 1 @OtherEncInfoID = EncInfoID, @OtherSortID = ISNULL(SortID, EncInfoID)
                FROM dbo.EncInfo
                WHERE ISNULL(IsDisable, 0) = 0 AND ISNULL(SortID, EncInfoID) < @SortID
                ORDER BY ISNULL(SortID, EncInfoID) DESC;
            END
            ELSE
            BEGIN
                SELECT TOP 1 @OtherEncInfoID = EncInfoID, @OtherSortID = ISNULL(SortID, EncInfoID)
                FROM dbo.EncInfo
                WHERE ISNULL(IsDisable, 0) = 0 AND ISNULL(SortID, EncInfoID) > @SortID
                ORDER BY ISNULL(SortID, EncInfoID);
            END

            IF @OtherEncInfoID IS NOT NULL
            BEGIN
                UPDATE dbo.EncInfo SET SortID = @OtherSortID WHERE EncInfoID = @EncInfoID;
                UPDATE dbo.EncInfo SET SortID = @SortID WHERE EncInfoID = @OtherEncInfoID;
            END";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@EncInfoID", encInfoID);
        com.Parameters.AddWithValue("@Direction", direction);
        new DataService().ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
    }

        public List<Models.EncInfo> EncInfoCRUDMonitor(Models.EncInfo encinfo)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", encinfo.CRUD);
        //com.Parameters.AddWithValue("@FuncType", encinfo.FuncType);

        //com.Parameters.AddWithValue("@EncInfoID", encinfo.EncInfoID);
        //com.Parameters.AddWithValue("@EncID", encinfo.EncID);
        //com.Parameters.AddWithValue("@StartDate", encinfo.StartDate);
        //com.Parameters.AddWithValue("@EndDate", encinfo.EndDate);
        //com.Parameters.AddWithValue("@IsDisable", encinfo.IsDisable);
        //com.Parameters.AddWithValue("@DepID", encinfo.DepID);
        //com.Parameters.AddWithValue("@DrID", encinfo.DrID);
        //com.Parameters.AddWithValue("@UserPersID", encinfo.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spEncInfo");
        return _appConvertDtToList.ConvertDataTable<Models.EncInfo>(dt);
    }

    public List<TvSubtitle> TvSubtitleCRUD(TvSubtitle tvSubtitle)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", tvSubtitle.CRUD);
        //com.Parameters.AddWithValue("@FuncType", tvSubtitle.FuncType);

        //com.Parameters.AddWithValue("@EncInfoID", encinfo.EncInfoID);
        //com.Parameters.AddWithValue("@EncID", encinfo.EncID);
        //com.Parameters.AddWithValue("@StartDate", encinfo.StartDate);
        //com.Parameters.AddWithValue("@EndDate", encinfo.EndDate);
        //com.Parameters.AddWithValue("@IsDisable", encinfo.IsDisable);
        //com.Parameters.AddWithValue("@DepID", encinfo.DepID);
        //com.Parameters.AddWithValue("@DrID", encinfo.DrID);
        //com.Parameters.AddWithValue("@UserPersID", encinfo.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spEncInfo");
        return _appConvertDtToList.ConvertDataTable<TvSubtitle>(dt);
    }
}