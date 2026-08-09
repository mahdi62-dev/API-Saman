using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class Discount
{
    private readonly ConvertDtToList _appConvertDtToList = new();
    private ConvertDRowToModel _appConvertDRowToModel = new();

    public List<Models.Discount> DiscountCRUD(Models.Discount discount)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", discount.CRUD);
        com.Parameters.AddWithValue("@ModID", discount.ModID);
        com.Parameters.AddWithValue("@DiscountID", discount.DiscountID);
        com.Parameters.AddWithValue("@EncID", discount.EncID);
        com.Parameters.AddWithValue("@PageID", discount.PageID);
        com.Parameters.AddWithValue("@IsDisable", discount.IsDisable);
        com.Parameters.AddWithValue("@DiscountEncType", discount.DiscountEncType);
        com.Parameters.AddWithValue("@DiscountReferType", discount.DiscountReferType);
        com.Parameters.AddWithValue("@DiscountActionTaken", discount.DiscountActionTaken);
        com.Parameters.AddWithValue("@DiscountType", discount.DiscountType);
        com.Parameters.AddWithValue("@DepID", discount.DepID);
        com.Parameters.AddWithValue("@Date", discount.Date);
        com.Parameters.AddWithValue("@DiscountAmount", discount.DiscountAmount);
        com.Parameters.AddWithValue("@Note", discount.Note);
        com.Parameters.AddWithValue("@UserPersID", discount.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDiscount");
        return _appConvertDtToList.ConvertDataTable<Models.Discount>(dt);
    }

    public void DiscountPageRowUpdate(Models.Discount discount, int userPersID)
    {
        if (discount == null || discount.DiscountID <= 0) return;

        const string tsql = @"
            DECLARE @Now NCHAR(16);
            DECLARE @PageID INT;
            DECLARE @TotalDiscountAmount BIGINT = 0;

            SELECT @Now = SamanERP.dbo.SCurdatetime();

            UPDATE dbo.Discount
               SET IsDisable = @IsDisable,
                   DiscountReferType = @DiscountReferType,
                   DiscountActionTaken = @DiscountActionTaken,
                   DiscountType = @DiscountType,
                   [Date] = CASE WHEN @Date IS NULL OR LTRIM(RTRIM(@Date)) = N'' THEN [Date] ELSE @Date END,
                   DiscountAmount = @DiscountAmount,
                   Note = @Note,
                   UserPersID = CASE WHEN @UserPersID > 0 THEN @UserPersID ELSE UserPersID END,
                   ActionDate = @Now
             WHERE DiscountID = @DiscountID;

            SELECT @PageID = PageID
              FROM dbo.Discount
             WHERE DiscountID = @DiscountID;

            IF ISNULL(@PageID, 0) > 0
            BEGIN
                SELECT @TotalDiscountAmount = ISNULL(SUM(DiscountAmount), 0)
                  FROM dbo.Discount
                 WHERE IsDisable = 0
                   AND PageID = @PageID;

                UPDATE dbo.Page
                   SET DiscountAmount = @TotalDiscountAmount,
                       IsReadOnly = 1
                 WHERE PageID = @PageID;

                EXEC dbo.spPageAmountSave @PageID = @PageID;
                EXEC dbo.spServiceRegCalcDiscountPrice @PageID = @PageID;
            END";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@DiscountID", discount.DiscountID);
        com.Parameters.AddWithValue("@IsDisable", discount.IsDisable);
        com.Parameters.AddWithValue("@DiscountReferType", discount.DiscountReferType);
        com.Parameters.AddWithValue("@DiscountActionTaken", discount.DiscountActionTaken);
        com.Parameters.AddWithValue("@DiscountType", discount.DiscountType);
        com.Parameters.AddWithValue("@Date", (object?)discount.Date ?? DBNull.Value);
        com.Parameters.AddWithValue("@DiscountAmount", discount.DiscountAmount);
        com.Parameters.AddWithValue("@Note", (object?)discount.Note ?? DBNull.Value);
        com.Parameters.AddWithValue("@UserPersID", userPersID);

        new DataService().ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
    }

}