using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class Page
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();

    public List<Models.Page> PageList(Models.Page p)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", p.CRUD);
        com.Parameters.AddWithValue("@FuncType", p.FuncType);

        com.Parameters.AddWithValue("@PageID", p.PageID);
        com.Parameters.AddWithValue("@PageCode", p.PageCode);
        com.Parameters.AddWithValue("@EncID", p.EncID);
        com.Parameters.AddWithValue("@ModID", p.ModID);
        com.Parameters.AddWithValue("@DepID", p.DepID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spPage");

        return _appConvertDtToList.ConvertDataTable<Models.Page>(dt);
    }

    public Models.Page PageCRUD(Models.Page p)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", p.CRUD);
        com.Parameters.AddWithValue("@FuncType", p.FuncType);

        com.Parameters.AddWithValue("@ModID", p.ModID);
        com.Parameters.AddWithValue("@DepID", p.DepID);
        com.Parameters.AddWithValue("@PageService", p.PageService);

        com.Parameters.AddWithValue("@StorageID", p.StorageID);
        com.Parameters.AddWithValue("@StoragePeriodID", p.StoragePeriodID);
        com.Parameters.AddWithValue("EncID", p.EncID);
        com.Parameters.AddWithValue("@PageID", p.PageID);
        com.Parameters.AddWithValue("@Date", p.Date);
        com.Parameters.AddWithValue("@Date2", p.Date2);
        com.Parameters.AddWithValue("@Date3", p.Date3);
        com.Parameters.AddWithValue("@RefDrID", p.RefDrID);
        com.Parameters.AddWithValue("@DrTechAssist", p.DrTechAssist);

        com.Parameters.AddWithValue("@UserPersID", p.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spPage");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Page>(dRow);
    }

    public DataTable PageSave(int CRUD, int ModID, int DepID, int StorageID, int StoragePeriodID,
        Models.Page page, int UserPersID)

    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@ModID", ModID);
        com.Parameters.AddWithValue("@DepID", DepID);
        com.Parameters.AddWithValue("@StorageID", StorageID);
        com.Parameters.AddWithValue("@StoragePeriodID", StoragePeriodID);
        com.Parameters.AddWithValue("EncID", page.EncID);
        com.Parameters.AddWithValue("@PageID", page.PageID);
        com.Parameters.AddWithValue("@Date", page.Date);
        com.Parameters.AddWithValue("@Date2", page.Date2);
        com.Parameters.AddWithValue("@Date3", page.Date3);
        com.Parameters.AddWithValue("@RefDrID", page.RefDrID);
        com.Parameters.AddWithValue("@DrTechAssist", page.DrTechAssist);

        com.Parameters.AddWithValue("@UserPersID", UserPersID);

        var dalData = new DataService();
        return dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spPage");
    }

    public Models.Page PageCashLoad(int PageID, int DepID, int PageCode)
    {
        var tsql = "SELECT * FROM vPage ";
        var strWhere = "WHERE ";

        var com = new SqlCommand();
        if (PageID > 0)
        {
            strWhere += "PageID = @PageID";
            com.Parameters.AddWithValue("@PageID", PageID);
        }
        else
        {
            strWhere += "DepID=@DepID AND PageCode=@PageCode";
            com.Parameters.AddWithValue("@DepID", DepID);
            com.Parameters.AddWithValue("@PageCode", PageCode);
        }

        tsql += strWhere;

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Page>(dRow);
    }



    public void PageUnlock(int pageID, int userPersID)
    {
        if (pageID <= 0) return;

        var tsql = @"
            UPDATE dbo.Page
               SET IsReadOnly = 0,
                   UserPersID = CASE WHEN @UserPersID > 0 THEN @UserPersID ELSE UserPersID END
             WHERE PageID = @PageID";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@PageID", pageID);
        com.Parameters.AddWithValue("@UserPersID", userPersID);
        new DataService().ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
    }



    public void PageLock(int pageID, int userPersID)
    {
        if (pageID <= 0) return;

        var tsql = @"
            UPDATE dbo.Page
               SET IsReadOnly = 1,
                   UserPersID = CASE WHEN @UserPersID > 0 THEN @UserPersID ELSE UserPersID END
             WHERE PageID = @PageID";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@PageID", pageID);
        com.Parameters.AddWithValue("@UserPersID", userPersID);
        new DataService().ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
    }

    public DataTable PageAmountSave
        (int PageID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@PageID", PageID);

        var dalData = new DataService();
        return dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spPageAmountSave");
    }
}