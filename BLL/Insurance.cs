using APP;
using DAL;

namespace BLL;

public class Insurance
{
    private readonly ConvertDtToList _appConvertDtToList = new();
    private readonly DataService _dalDataService = new();

    public List<Models.Insurance> GetInsuranceList(string strWehere)
    {
        var dt = _dalDataService.LoadData(CSet.cnStringHIS, "*", "Insurance",
            "IsDisable = 0 AND InsuranceType = 0", null);

        List<Models.Insurance> list = new();
        list = _appConvertDtToList.ConvertDataTable<Models.Insurance>(dt);

        return list;
    }

    public List<Models.Insurance> GetInsurance2List(string strWehere)
    {
        var dt = _dalDataService.LoadData(CSet.cnStringHIS, "*", "Insurance",
            "IsDisable = 0 AND InsuranceType = 1 OR InsuranceID = 1", null);

        List<Models.Insurance> list = new();
        list = _appConvertDtToList.ConvertDataTable<Models.Insurance>(dt);

        return list;
    }
}