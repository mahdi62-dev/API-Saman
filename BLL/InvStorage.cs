using System.Data;
using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class InvStorage
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();
    private readonly DataService _dalDataService = new();

    public List<Models.InvStorage> GetStorageList(string strWhere)
    {
        var dt = _dalDataService.LoadData(CSet.cnStringERP, "StorageID,Name", "InvStorage", strWhere, null);

        var StorageList = new List<Models.InvStorage>();

        StorageList = _appConvertDtToList.ConvertDataTable<Models.InvStorage>(dt);
        return StorageList;
    }

    public int StoragePeriodIDLoad(int StorageID)
    {
        var tsql = @"
                                SELECT TOP(1) StoragePeriodID
                                FROM [SamanERP].[dbo].[InvStoragePeriod]
                                WHERE IsDisable=0
                                AND EndDate IS null
                                AND StorageID=@StorageID
                                ";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@StorageID", StorageID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringERP, com, tsql);

        var StoragePeriodID = 0;
        if (dt.Rows.Count > 0) StoragePeriodID = Convert.ToInt32(dt.Rows[0]["StoragePeriodId"]);

        return StoragePeriodID;
    }

    public int InvPageCodeLast(object StorageID)
    {
        const string tsql = @"
                                SELECT TOP(1) InvPageCode
                                FROM SamanERP.dbo.InvPage
                                WHERE StorageID = @StorageID AND InvType=1
                                ORDER BY InvPageID DESC";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@StorageID", StorageID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringERP, com, tsql);

        var invPageCode = 0;
        if (dt.Rows.Count > 0) invPageCode = Convert.ToInt32(dt.Rows[0]["InvPageCode"]);

        return invPageCode;
    }

    public InvPage PageDataLoad(int StorageID, int InvPageCode)
    {
        var tsql = @"
                        SELECT *
                        FROM [SamanERP].[dbo].[InvPage]
                        WHERE InvType=1
                        AND StorageID=@StorageID AND InvType=1
                        AND InvPageCode=@InvPageCode
                        ";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@StorageID", StorageID);
        com.Parameters.AddWithValue("@InvPageCode", InvPageCode);


        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<InvPage>(dRow);
    }

    public InvPage GetItemData(int StorageID, int StoragePeriodID, object ServiceCategory, object ServiceCode)
    {
        var tsql = @"
                        SELECT 
                        ISNULL( SamanERP.dbo.InvStockNum(@StorageID,@StoragePeriodID, @ServiceCategory, @ServiceCode),0) AS StockNum
                        ,ISNULL( SamanERP.dbo.InvBuyAmountLast(@ServiceCategory, @ServiceCode) , 0)  AS BuyAmountLast
                        ,s.Price AS SellAmountLast

                        FROM SamanHIS.dbo.vService s
                        WHERE 1=1
                        AND s.ServiceType=2
                        AND s.EndDate IS NULL
                        AND s.ServiceCategory=@ServiceCategory AND s.ServiceCode=@ServiceCode
                            ";

        var com = new SqlCommand();

        com.Parameters.AddWithValue("@StorageID", StorageID);
        com.Parameters.AddWithValue("@StoragePeriodID", StoragePeriodID);
        com.Parameters.AddWithValue("@ServiceCategory", ServiceCategory);
        com.Parameters.AddWithValue("@ServiceCode", ServiceCode);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<InvPage>(dRow);
    }

    public List<InvPageItem> InvServiceRegLoad(int InvPageID)
    {
        var tql = @"
                            SELECT 
                            ROW_NUMBER() OVER (PARTITION BY InvPageID ORDER BY InvDID) AS RecNO,
                            2 AS CRUD,
                            InvDID,
                            ipi.ServiceID,
                            s.ServiceCode,
                            CAST(s.Name AS NVARCHAR(max)) AS ServiceName,
                            Num2,
                            Unit2,
                            unit2.Name AS Unit2Name,
                            UnitKNum,
                            ipi.Unit,
                            unit.Name AS UnitName,
                            Num,
                            ExpirationDate,
                            StockNum,
                            StockNumAll,
                            IsBonus,
                            BuyFeeAmount2,
                            BuyAmount2,
                            SellPer,
                            SellFeeAmount,
                            SellFeeAmount2,
                            BuyFeeAmount,
                            BuyAmount,
                            DiscountAmount,
                            TaxAmount,
                            BuyAmountLast,
                            SellAmount,
                            SellAmount2,
                            SellAmountLast,
                            ResultAmount


                            FROM SamanERP.dbo.InvPageItem ipi
                            INNER JOIN SamanHIS.dbo.Service s on s.ServiceID=ipi.ServiceID
                            INNER JOIN SamanERP.dbo.vADR unit on unit.ID = ipi.Unit
                            INNER JOIN SamanERP.dbo.vADR unit2 on unit2.ID = ipi.Unit2

                            WHERE 1=1
                            AND InvPageID=@InvPageID
                            AND unit.ADName='Unit'
                            AND unit2.ADName='Unit'

                        ";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@InvPageID", InvPageID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringERP, com, tql);

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDtToList.ConvertDataTable<InvPageItem>(dt);
    }

    public void InvPageSign(object InvPageID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@InvPageID", InvPageID);

        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringERP, com, "spInvPageSign");
    }
}