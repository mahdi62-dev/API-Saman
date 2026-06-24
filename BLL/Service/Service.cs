using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.Service;

public class Service
{
    private readonly ConvertDtToList _appConvertDtToList = new();

    public List<Models.Service> ServiceCRUD(Models.Service s)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", s.CRUD);
        com.Parameters.AddWithValue("@FuncType", s.FuncType);
        com.Parameters.AddWithValue("@DepID", s.DepID);

        com.Parameters.AddWithValue("@CentID", s.CenterID);
        com.Parameters.AddWithValue("@ServiceID", s.ServiceID);
        com.Parameters.AddWithValue("@ServiceType", s.ServiceType);
        com.Parameters.AddWithValue("@ServiceCategory", s.ServiceCategory);
        com.Parameters.AddWithValue("@ServiceCode", s.ServiceCode);
        com.Parameters.AddWithValue("@ServiceCode2", s.ServiceCode2);
        com.Parameters.AddWithValue("@Name", s.Name);
        com.Parameters.AddWithValue("@Namelong", s.Namelong);
        com.Parameters.AddWithValue("@Price", s.Price);
        com.Parameters.AddWithValue("@PriceB", s.PriceB);
        com.Parameters.AddWithValue("@PriceC", s.PriceC);
        com.Parameters.AddWithValue("@PriceD", s.PriceD);
        com.Parameters.AddWithValue("@PricePro", s.PricePro);
        com.Parameters.AddWithValue("@PriceTech", s.PriceTech);
        com.Parameters.AddWithValue("@MapIDA", s.MapIDA);
        com.Parameters.AddWithValue("@MapIDB", s.MapIDB);
        com.Parameters.AddWithValue("@StartDate", s.StartDate);
        com.Parameters.AddWithValue("@EndDate", s.EndDate);
        com.Parameters.AddWithValue("@IsTech", s.IsTech);
        com.Parameters.AddWithValue("@IsManualPrice", s.IsManualPrice);
        com.Parameters.AddWithValue("@ServicePriceType", s.ServicePriceType);
        com.Parameters.AddWithValue("@ServiceUnit", s.ServiceUnit);
        com.Parameters.AddWithValue("@ServiceUnit2", s.ServiceUnit2);
        com.Parameters.AddWithValue("@ServiceStatus", s.ServiceStatus);
        com.Parameters.AddWithValue("@IsDisable", s.IsDisable);
        com.Parameters.AddWithValue("@IsOIC", s.IsOIC);
        com.Parameters.AddWithValue("@UserPersID", s.UserPersID);

        var dalData = new DataService();

        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spService");
        return _appConvertDtToList.ConvertDataTable<Models.Service>(dt);
    }

    public List<Models.Service> ServicePakageItem(int ServicePackageID)
    {
        var tsql = @"
                            SELECT [PackageID],[ServiceCode],[ServiceNum]
                            FROM [SamanHIS].[dbo].[ServicePackageItem]
                            WHERE PackageID = @PackageID
                            ";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@PackageID", ServicePackageID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);

        return _appConvertDtToList.ConvertDataTable<Models.Service>(dt);
    }


    public List<Models.Service> ServiceCRUDPortal(Models.Service s)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", s.CRUD);
        com.Parameters.AddWithValue("@FuncType", s.FuncType);
        com.Parameters.AddWithValue("@MasterID", s.MasterID);
        com.Parameters.AddWithValue("@DepID", s.DepID);

        com.Parameters.AddWithValue("@CentID", s.CenterID);
        com.Parameters.AddWithValue("@ServiceID", s.ServiceID);
        com.Parameters.AddWithValue("@ServiceType", s.ServiceType);
        com.Parameters.AddWithValue("@ServiceCategory", s.ServiceCategory);
        com.Parameters.AddWithValue("@ServiceCode", s.ServiceCode);
        com.Parameters.AddWithValue("@ServiceCode2", s.ServiceCode2);
        com.Parameters.AddWithValue("@Name", s.Name);
        com.Parameters.AddWithValue("@Namelong", s.Namelong);
        com.Parameters.AddWithValue("@Price", s.Price);
        com.Parameters.AddWithValue("@PriceB", s.PriceB);
        com.Parameters.AddWithValue("@PriceC", s.PriceC);
        com.Parameters.AddWithValue("@PriceD", s.PriceD);
        com.Parameters.AddWithValue("@PricePro", s.PricePro);
        com.Parameters.AddWithValue("@PriceTech", s.PriceTech);
        com.Parameters.AddWithValue("@MapIDA", s.MapIDA);
        com.Parameters.AddWithValue("@MapIDB", s.MapIDB);
        com.Parameters.AddWithValue("@StartDate", s.StartDate);
        com.Parameters.AddWithValue("@EndDate", s.EndDate);
        com.Parameters.AddWithValue("@IsTech", s.IsTech);
        com.Parameters.AddWithValue("@IsManualPrice", s.IsManualPrice);
        com.Parameters.AddWithValue("@ServicePriceType", s.ServicePriceType);
        com.Parameters.AddWithValue("@ServiceUnit", s.ServiceUnit);
        com.Parameters.AddWithValue("@ServiceUnit2", s.ServiceUnit2);
        com.Parameters.AddWithValue("@ServiceStatus", s.ServiceStatus);
        com.Parameters.AddWithValue("@IsDisable", s.IsDisable);
        com.Parameters.AddWithValue("@IsOIC", s.IsOIC);
        com.Parameters.AddWithValue("@UserPersID", s.UserPersID);

        var dalData = new DataService();

        var dt = dalData.GetDataTableBySP(CSet.cnStringPortal, com, "spService");
        return _appConvertDtToList.ConvertDataTable<Models.Service>(dt);
    }
}