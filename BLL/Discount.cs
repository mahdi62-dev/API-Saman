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
}