using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL;

public class Cash
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();

    public Models.Cash CashCRUD(Models.Cash cash)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", cash.CRUD);
        com.Parameters.AddWithValue("@ModID", cash.ModID);
        com.Parameters.AddWithValue("@CashID", cash.CashID);
        //com.Parameters.AddWithValue("@IsEdited", cash.IsEdited);
        com.Parameters.AddWithValue("@CashType", cash.CashType);
        com.Parameters.AddWithValue("@EncID", cash.EncID);
        com.Parameters.AddWithValue("@PageID", cash.PageID);
        com.Parameters.AddWithValue("@CashDate", cash.CashDate);
        com.Parameters.AddWithValue("@PayType", cash.PayType);
        com.Parameters.AddWithValue("@PayGroup", cash.PayGroup);
        com.Parameters.AddWithValue("@TransType", cash.TransType);
        com.Parameters.AddWithValue("@PayAmount", cash.PayAmount);
        com.Parameters.AddWithValue("@Bank", cash.Bank);
        com.Parameters.AddWithValue("@BankNumber", cash.BankNumber);
        com.Parameters.AddWithValue("@BankDate", cash.BankDate);
        com.Parameters.AddWithValue("@DepID", cash.DepID);
        com.Parameters.AddWithValue("@Note", cash.Note);
        com.Parameters.AddWithValue("@DrID", cash.DrID);
        com.Parameters.AddWithValue("@Receiver", cash.Receiver);
        //com.Parameters.AddWithValue("@IsClosed", cash.IsClosed);
        com.Parameters.AddWithValue("@About", cash.About);
        com.Parameters.AddWithValue("@UserPersID", cash.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spCash");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Cash>(dRow);
    }


    public DataTable CashWaitListLoad(object CRUD, object CashType, bool IsOtherDays)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@CashType", CashType);
        com.Parameters.AddWithValue("@IsOtherDays", IsOtherDays);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spCashWait");
        return dt;
    }



    public void CashPageReceiptUpdate(Models.Cash cash, int userPersID)
    {
        if (cash == null || cash.CashID <= 0) return;

        const string tsql = @"
            DECLARE @Now NCHAR(16);
            SELECT @Now = SamanHIS.dbo.SCurdatetime();

            UPDATE dbo.Cash
               SET CashDate = CASE WHEN @CashDate IS NULL OR LTRIM(RTRIM(@CashDate)) = N'' THEN CashDate ELSE @CashDate END,
                   PayType = @PayType,
                   PayGroup = @PayGroup,
                   Bank = @Bank,
                   PayAmount = @PayAmount,
                   Note = @Note,
                   BankNumber = @BankNumber,
                   BankDate = @BankDate,
                   UserPersID = CASE WHEN @UserPersID > 0 THEN @UserPersID ELSE UserPersID END,
                   ActionDate = @Now
             WHERE CashID = @CashID;

            IF @PageID > 0
                EXEC dbo.spPageAmountSave @PageID = @PageID, @IsCash = 1;";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CashID", cash.CashID);
        com.Parameters.AddWithValue("@PageID", cash.PageID);
        com.Parameters.AddWithValue("@CashDate", (object?)cash.CashDate ?? DBNull.Value);
        com.Parameters.AddWithValue("@PayType", cash.PayType);
        com.Parameters.AddWithValue("@PayGroup", cash.PayGroup);
        com.Parameters.AddWithValue("@Bank", cash.Bank ?? 0);
        com.Parameters.AddWithValue("@PayAmount", cash.PayAmount);
        com.Parameters.AddWithValue("@Note", (object?)cash.Note ?? DBNull.Value);
        com.Parameters.AddWithValue("@BankNumber", (object?)cash.BankNumber ?? DBNull.Value);
        com.Parameters.AddWithValue("@BankDate", (object?)cash.BankDate ?? DBNull.Value);
        com.Parameters.AddWithValue("@UserPersID", userPersID);
        new DataService().ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
    }

    public List<Models.Cash> CashListCRUD(Models.Cash cash)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", cash.CRUD);
        com.Parameters.AddWithValue("@FuncType", cash.FuncType);
        com.Parameters.AddWithValue("@ModID", cash.ModID);
        com.Parameters.AddWithValue("@CashID", cash.CashID);
        //com.Parameters.AddWithValue("@IsEdited", cash.IsEdited);
        com.Parameters.AddWithValue("@CashType", cash.CashType);
        com.Parameters.AddWithValue("@EncID", cash.EncID);
        com.Parameters.AddWithValue("@PageID", cash.PageID);
        com.Parameters.AddWithValue("@CashDate", cash.CashDate);
        com.Parameters.AddWithValue("@PayType", cash.PayType);
        com.Parameters.AddWithValue("@PayGroup", cash.PayGroup);
        com.Parameters.AddWithValue("@TransType", cash.TransType);
        com.Parameters.AddWithValue("@PayAmount", cash.PayAmount);
        com.Parameters.AddWithValue("@Bank", cash.Bank);
        com.Parameters.AddWithValue("@BankNumber", cash.BankNumber);
        com.Parameters.AddWithValue("@BankDate", cash.BankDate);
        com.Parameters.AddWithValue("@DepID", cash.DepID);
        com.Parameters.AddWithValue("@Note", cash.Note);
        com.Parameters.AddWithValue("@DrID", cash.DrID);
        com.Parameters.AddWithValue("@Receiver", cash.Receiver);
        //com.Parameters.AddWithValue("@IsClosed", cash.IsClosed);
        com.Parameters.AddWithValue("@About", cash.About);
        com.Parameters.AddWithValue("@UserPersID", cash.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spCash");


        return _appConvertDtToList.ConvertDataTable<Models.Cash>(dt);
    }

    public List<Models.Cash> CashListCRUDPortal(Models.Cash cash)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", cash.CRUD);
        com.Parameters.AddWithValue("@FuncType", cash.FuncType);
        com.Parameters.AddWithValue("@ModID", cash.ModID);
        com.Parameters.AddWithValue("@WEncID", cash.WEncID);
        com.Parameters.AddWithValue("@WProfileID", cash.WProfileID);
        com.Parameters.AddWithValue("@CashID", cash.CashID);
        com.Parameters.AddWithValue("@SchID", cash.SchID);
        com.Parameters.AddWithValue("@CashType", cash.CashType);
        com.Parameters.AddWithValue("@EncID", cash.EncID);
        com.Parameters.AddWithValue("@PageID", cash.PageID);
        com.Parameters.AddWithValue("@CashDate", cash.CashDate);
        com.Parameters.AddWithValue("@PayType", cash.PayType);
        com.Parameters.AddWithValue("@PayGroup", cash.PayGroup);
        com.Parameters.AddWithValue("@TransType", cash.TransType);
        com.Parameters.AddWithValue("@PayAmount", cash.PayAmount);
        com.Parameters.AddWithValue("@OGPayAmount", cash.OGPayAmount);
        com.Parameters.AddWithValue("@OGRefID", cash.OGRefID);
        com.Parameters.AddWithValue("@Bank", cash.Bank);
        com.Parameters.AddWithValue("@BankNumber", cash.BankNumber);
        com.Parameters.AddWithValue("@BankDate", cash.BankDate);
        com.Parameters.AddWithValue("@DepID", cash.DepID);
        com.Parameters.AddWithValue("@Note", cash.Note);
        com.Parameters.AddWithValue("@DrID", cash.DrID);
        com.Parameters.AddWithValue("@Receiver", cash.Receiver);
        //com.Parameters.AddWithValue("@IsClosed", cash.IsClosed);
        com.Parameters.AddWithValue("@About", cash.About);
        com.Parameters.AddWithValue("@UserPersID", cash.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringPortal, com, "spCash");


        return _appConvertDtToList.ConvertDataTable<Models.Cash>(dt);
    }

    public List<Models.Cash> CashModelCRUD(Models.Cash cash)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", cash.CRUD);
        com.Parameters.AddWithValue("@FuncType", cash.FuncType);
        com.Parameters.AddWithValue("@ModID", cash.ModID);
        com.Parameters.AddWithValue("@CashID", cash.CashID);
        com.Parameters.AddWithValue("@CashType", cash.CashType);
        com.Parameters.AddWithValue("@UserPersID", cash.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spCash");


        return _appConvertDtToList.ConvertDataTable<Models.Cash>(dt);
    }

    public List<Models.Cash> CashSearch(Models.Cash cash)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", cash.CRUD);
        com.Parameters.AddWithValue("@FuncType", cash.FuncType);
        com.Parameters.AddWithValue("@ModID", cash.ModID);
        com.Parameters.AddWithValue("@CashID", cash.CashID);
        com.Parameters.AddWithValue("@CashType", cash.CashType);
        com.Parameters.AddWithValue("@EncID", cash.EncID);
        com.Parameters.AddWithValue("@PageID", cash.PageID);
        com.Parameters.AddWithValue("@CashDate", cash.CashDate);
        com.Parameters.AddWithValue("@PayType", cash.PayType);
        com.Parameters.AddWithValue("@PayGroup", cash.PayGroup);
        com.Parameters.AddWithValue("@TransType", cash.TransType);
        com.Parameters.AddWithValue("@PayAmount", cash.PayAmount);
        com.Parameters.AddWithValue("@Bank", cash.Bank);
        com.Parameters.AddWithValue("@BankNumber", cash.BankNumber);
        com.Parameters.AddWithValue("@BankDate", cash.BankDate);
        com.Parameters.AddWithValue("@DepID", cash.DepID);
        com.Parameters.AddWithValue("@Note", cash.Note);
        com.Parameters.AddWithValue("@DrID", cash.DrID);
        com.Parameters.AddWithValue("@Receiver", cash.Receiver);
        com.Parameters.AddWithValue("@About", cash.About);
        com.Parameters.AddWithValue("@UserPersID", cash.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spReceiptCashSearch");


        return _appConvertDtToList.ConvertDataTable<Models.Cash>(dt);
    }


    public List<Models.Cash> GetCashDataReport(string Date1, string Date2)
    {
        var tsql = @"
                SELECT *
                FROM [dbo].[vCashReport]
                  WHERE CashDate between @Date1 AND @Date2
                  Order by CashDate
                ";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@Date1", Date1);
        com.Parameters.AddWithValue("@Date2", Date2);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);

        return _appConvertDtToList.ConvertDataTable<Models.Cash>(dt);
    }
}