using System.Data;
using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.ServiceInv;

public class ServiceInv
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public InvPage InvPageCRUD(InvPage ip)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", ip.CRUD);

        com.Parameters.AddWithValue("@InvPageID", ip.InvPageID);
        com.Parameters.AddWithValue("@InvType", ip.InvType);
        com.Parameters.AddWithValue("@InvCategoryType", ip.InvCategoryType);
        com.Parameters.AddWithValue("@StorageID", ip.StorageID);
        com.Parameters.AddWithValue("@StoragePeriodID", ip.StoragePeriodID);
        com.Parameters.AddWithValue("@InvPageCode2", ip.InvPageCode2);
        com.Parameters.AddWithValue("@Date2", ip.Date2 + " 00:00");
        com.Parameters.AddWithValue("@SellerID", ip.SellerID);
        com.Parameters.AddWithValue("@TransfereeID", ip.TransfereeID);
        com.Parameters.AddWithValue("@DiscountAmount2", ip.DiscountAmount2);
        com.Parameters.AddWithValue("@OtherAmount", ip.OtherAmount);
        com.Parameters.AddWithValue("@Description", ip.Description);
        com.Parameters.AddWithValue("@TaxAmount2", ip.TaxAmount2);
        com.Parameters.AddWithValue("@UserPersID", ip.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringERP, com, "spInvPageSave");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<InvPage>(dRow);
    }


    public InvPageItem InvPageItemCRUD(InvPageItem ipi)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", ipi.CRUD);
        com.Parameters.AddWithValue("@InvPageID", ipi.InvPageID);
        com.Parameters.AddWithValue("@InvDID", ipi.InvDID);
        com.Parameters.AddWithValue("@InvType", ipi.InvType);
        com.Parameters.AddWithValue("@InvCategoryType", ipi.InvCategoryType);
        com.Parameters.AddWithValue("@StorageID", ipi.StorageID);
        com.Parameters.AddWithValue("@StoragePeriodID", ipi.StoragePeriodID);

        com.Parameters.AddWithValue("@ServiceID", ipi.ServiceID);
        com.Parameters.AddWithValue("@Num2", ipi.Num2);
        com.Parameters.AddWithValue("@Unit2", ipi.Unit2);
        com.Parameters.AddWithValue("@UnitKNum", ipi.UnitKNum);
        com.Parameters.AddWithValue("@Unit", ipi.Unit);
        com.Parameters.AddWithValue("@Num", ipi.Num);
        com.Parameters.AddWithValue("@ExpirationDate", ipi.ExpirationDate);
        com.Parameters.AddWithValue("@StockNum", ipi.StockNum);
        com.Parameters.AddWithValue("@StockNumAll", ipi.StockNumAll);
        com.Parameters.AddWithValue("@IsBonus", ipi.IsBonus);
        com.Parameters.AddWithValue("@BuyFeeAmount2", ipi.BuyFeeAmount2);
        com.Parameters.AddWithValue("@BuyAmount2", ipi.BuyAmount2);
        com.Parameters.AddWithValue("@SellPer", ipi.SellPer);
        com.Parameters.AddWithValue("@SellFeeAmount", ipi.SellFeeAmount);
        com.Parameters.AddWithValue("@SellFeeAmount2", ipi.SellFeeAmount2);
        com.Parameters.AddWithValue("@BuyFeeAmount", ipi.BuyFeeAmount);
        com.Parameters.AddWithValue("@BuyAmount", ipi.BuyAmount);
        com.Parameters.AddWithValue("@DiscountAmount", ipi.DiscountAmount);
        com.Parameters.AddWithValue("@TaxAmount", ipi.TaxAmount);
        com.Parameters.AddWithValue("@BuyAmountLast", ipi.BuyAmountLast);
        com.Parameters.AddWithValue("@SellAmount", ipi.SellAmount);
        com.Parameters.AddWithValue("@SellAmount2", ipi.SellAmount2);
        com.Parameters.AddWithValue("@SellAmountLast", ipi.SellAmountLast);
        com.Parameters.AddWithValue("@ResultAmount", ipi.ResultAmount);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringERP, com, "spInvPageItemSave");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<InvPageItem>(dRow);
    }

    public void InvPageAmountSave(object InvPageID, object UserPersID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@InvPageId", InvPageID);
        com.Parameters.AddWithValue("@UserPersID", UserPersID);

        var dalData = new DataService();
        dalData.GetDataTableBySP(CSet.cnStringERP, com, "spInvPageAmountSave");
    }
}