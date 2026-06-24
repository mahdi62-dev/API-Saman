using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class SFVaricoseVeins
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public Models.SFVaricoseVeins SFVaricoseVeinsCRUD(Models.SFVaricoseVeins SFVaricoseVeins)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", SFVaricoseVeins.CRUD);
        com.Parameters.AddWithValue("@SFVaricoseVeinsID", SFVaricoseVeins.SFVaricoseVeinsID);
        com.Parameters.AddWithValue("@EncID", SFVaricoseVeins.EncID);
        com.Parameters.AddWithValue("@PageID", SFVaricoseVeins.PageID);
        com.Parameters.AddWithValue("@ServiceCode", SFVaricoseVeins.ServiceCode);

        com.Parameters.AddWithValue("@LSFJIntact", SFVaricoseVeins.LSFJIntact);
        com.Parameters.AddWithValue("@LSFJInsufficient", SFVaricoseVeins.LSFJInsufficient);
        com.Parameters.AddWithValue("@LGSVUpperKneeSize", SFVaricoseVeins.LGSVUpperKneeSize);
        com.Parameters.AddWithValue("@LGSVUpperKneeIntact", SFVaricoseVeins.LGSVUpperKneeIntact);
        com.Parameters.AddWithValue("@LGSVUpperKneeInsufficient", SFVaricoseVeins.LGSVUpperKneeInsufficient);

        com.Parameters.AddWithValue("@LGSVMidKneeSize", SFVaricoseVeins.LGSVMidKneeSize);
        com.Parameters.AddWithValue("@LGSVMidKneeIntact", SFVaricoseVeins.LGSVMidKneeIntact);
        com.Parameters.AddWithValue("@LGSVMidKneeInsufficient", SFVaricoseVeins.LGSVMidKneeInsufficient);

        com.Parameters.AddWithValue("@LGSVLowerKneeSize", SFVaricoseVeins.LGSVLowerKneeSize);
        com.Parameters.AddWithValue("@LGSVLowerKneeIntact", SFVaricoseVeins.LGSVLowerKneeIntact);
        com.Parameters.AddWithValue("@LGSVLowerKneeInsufficient", SFVaricoseVeins.LGSVLowerKneeInsufficient);

        com.Parameters.AddWithValue("@LGSVBelowKneeSize", SFVaricoseVeins.LGSVBelowKneeSize);
        com.Parameters.AddWithValue("@LGSVBelowKneeIntact", SFVaricoseVeins.LGSVBelowKneeIntact);
        com.Parameters.AddWithValue("@LGSVBelowKneeInsufficient", SFVaricoseVeins.LGSVBelowKneeInsufficient);

        com.Parameters.AddWithValue("@LGSVAboveKneeSize", SFVaricoseVeins.LGSVAboveKneeSize);
        com.Parameters.AddWithValue("@LGSVAboveKneeIntact", SFVaricoseVeins.LGSVAboveKneeIntact);
        com.Parameters.AddWithValue("@LGSVAboveKneeInsufficient", SFVaricoseVeins.LGSVAboveKneeInsufficient);

        com.Parameters.AddWithValue("@LAAGSVSize", SFVaricoseVeins.LAAGSVSize);
        com.Parameters.AddWithValue("@LAAGSVIntact", SFVaricoseVeins.LAAGSVIntact);
        com.Parameters.AddWithValue("@LAAGSVInsufficient", SFVaricoseVeins.LAAGSVInsufficient);

        com.Parameters.AddWithValue("@LPAGSVSize", SFVaricoseVeins.LPAGSVSize);
        com.Parameters.AddWithValue("@LPAGSVIntact", SFVaricoseVeins.LPAGSVIntact);
        com.Parameters.AddWithValue("@LPAGSVInsufficient", SFVaricoseVeins.LPAGSVInsufficient);

        com.Parameters.AddWithValue("@LSPJSize", SFVaricoseVeins.LSPJSize);
        com.Parameters.AddWithValue("@LSPJIntact", SFVaricoseVeins.LSPJIntact);
        com.Parameters.AddWithValue("@LSPJInsufficient", SFVaricoseVeins.LSPJInsufficient);

        com.Parameters.AddWithValue("@LSSVLowerKneeSize", SFVaricoseVeins.LSSVLowerKneeSize);
        com.Parameters.AddWithValue("@LSSVLowerKneeIntact", SFVaricoseVeins.LSSVLowerKneeIntact);
        com.Parameters.AddWithValue("@LSSVLowerKneeInsufficient", SFVaricoseVeins.LSSVLowerKneeInsufficient);
        com.Parameters.AddWithValue("@LSSVUpperAnkleSize", SFVaricoseVeins.LSSVUpperAnkleSize);
        com.Parameters.AddWithValue("@LSSVUpperAnkleIntact", SFVaricoseVeins.LSSVUpperAnkleIntact);
        com.Parameters.AddWithValue("@LSSVUpperAnkleInsufficient", SFVaricoseVeins.LSSVUpperAnkleInsufficient);
        com.Parameters.AddWithValue("@LPerforatorsSize", SFVaricoseVeins.LPerforatorsSize);
        com.Parameters.AddWithValue("@LPerforatorsIntact", SFVaricoseVeins.LPerforatorsIntact);
        com.Parameters.AddWithValue("@LPerforatorsInsufficient", SFVaricoseVeins.LPerforatorsInsufficient);

        com.Parameters.AddWithValue("@LNumber", SFVaricoseVeins.LNumber);
        com.Parameters.AddWithValue("@LLocation", SFVaricoseVeins.LLocation);

        com.Parameters.AddWithValue("@LTributaryVeinsSize", SFVaricoseVeins.LTributaryVeinsSize);
        com.Parameters.AddWithValue("@LTributaryVeinsIntact", SFVaricoseVeins.LTributaryVeinsIntact);
        com.Parameters.AddWithValue("@LTributaryVeinsInsufficient", SFVaricoseVeins.LTributaryVeinsInsufficient);
        com.Parameters.AddWithValue("@LTributaryVeinsLocation", SFVaricoseVeins.LTributaryVeinsLocation);

        com.Parameters.AddWithValue("@LNote", SFVaricoseVeins.LNote);


        com.Parameters.AddWithValue("@RSFJIntact", SFVaricoseVeins.RSFJIntact);
        com.Parameters.AddWithValue("@RSFJInsufficient", SFVaricoseVeins.RSFJInsufficient);
        com.Parameters.AddWithValue("@RGSVUpperKneeSize", SFVaricoseVeins.RGSVUpperKneeSize);
        com.Parameters.AddWithValue("@RGSVUpperKneeIntact", SFVaricoseVeins.RGSVUpperKneeIntact);
        com.Parameters.AddWithValue("@RGSVUpperKneeInsufficient", SFVaricoseVeins.RGSVUpperKneeInsufficient);

        com.Parameters.AddWithValue("@RGSVMidKneeSize", SFVaricoseVeins.RGSVMidKneeSize);
        com.Parameters.AddWithValue("@RGSVMidKneeIntact", SFVaricoseVeins.RGSVMidKneeIntact);
        com.Parameters.AddWithValue("@RGSVMidKneeInsufficient", SFVaricoseVeins.RGSVMidKneeInsufficient);

        com.Parameters.AddWithValue("@RGSVLowerKneeSize", SFVaricoseVeins.RGSVLowerKneeSize);
        com.Parameters.AddWithValue("@RGSVLowerKneeIntact", SFVaricoseVeins.RGSVLowerKneeIntact);
        com.Parameters.AddWithValue("@RGSVLowerKneeInsufficient", SFVaricoseVeins.RGSVLowerKneeInsufficient);

        com.Parameters.AddWithValue("@RGSVBelowKneeSize", SFVaricoseVeins.RGSVBelowKneeSize);
        com.Parameters.AddWithValue("@RGSVBelowKneeIntact", SFVaricoseVeins.RGSVBelowKneeIntact);
        com.Parameters.AddWithValue("@RGSVBelowKneeInsufficient", SFVaricoseVeins.RGSVBelowKneeInsufficient);

        com.Parameters.AddWithValue("@RGSVAboveKneeSize", SFVaricoseVeins.RGSVAboveKneeSize);
        com.Parameters.AddWithValue("@RGSVAboveKneeIntact", SFVaricoseVeins.RGSVAboveKneeIntact);
        com.Parameters.AddWithValue("@RGSVAboveKneeInsufficient", SFVaricoseVeins.RGSVAboveKneeInsufficient);


        com.Parameters.AddWithValue("@RAAGSVSize", SFVaricoseVeins.RAAGSVSize);
        com.Parameters.AddWithValue("@RAAGSVIntact", SFVaricoseVeins.RAAGSVIntact);
        com.Parameters.AddWithValue("@RAAGSVInsufficient", SFVaricoseVeins.RAAGSVInsufficient);

        com.Parameters.AddWithValue("@RPAGSVSize", SFVaricoseVeins.RPAGSVSize);
        com.Parameters.AddWithValue("@RPAGSVIntact", SFVaricoseVeins.RPAGSVIntact);
        com.Parameters.AddWithValue("@RPAGSVInsufficient", SFVaricoseVeins.RPAGSVInsufficient);

        com.Parameters.AddWithValue("@RSPJSize", SFVaricoseVeins.RSPJSize);
        com.Parameters.AddWithValue("@RSPJIntact", SFVaricoseVeins.RSPJIntact);
        com.Parameters.AddWithValue("@RSPJInsufficient", SFVaricoseVeins.RSPJInsufficient);

        com.Parameters.AddWithValue("@RSSVLowerKneeSize", SFVaricoseVeins.RSSVLowerKneeSize);
        com.Parameters.AddWithValue("@RSSVLowerKneeIntact", SFVaricoseVeins.RSSVLowerKneeIntact);
        com.Parameters.AddWithValue("@RSSVLowerKneeInsufficient", SFVaricoseVeins.RSSVLowerKneeInsufficient);
        com.Parameters.AddWithValue("@RSSVUpperAnkleSize", SFVaricoseVeins.RSSVUpperAnkleSize);
        com.Parameters.AddWithValue("@RSSVUpperAnkleIntact", SFVaricoseVeins.RSSVUpperAnkleIntact);
        com.Parameters.AddWithValue("@RSSVUpperAnkleInsufficient", SFVaricoseVeins.RSSVUpperAnkleInsufficient);
        com.Parameters.AddWithValue("@RPerforatorsSize", SFVaricoseVeins.RPerforatorsSize);
        com.Parameters.AddWithValue("@RPerforatorsIntact", SFVaricoseVeins.RPerforatorsIntact);
        com.Parameters.AddWithValue("@RPerforatorsInsufficient", SFVaricoseVeins.RPerforatorsInsufficient);

        com.Parameters.AddWithValue("@RNumber", SFVaricoseVeins.RNumber);
        com.Parameters.AddWithValue("@RLocation", SFVaricoseVeins.RLocation);

        com.Parameters.AddWithValue("@RTributaryVeinsSize", SFVaricoseVeins.RTributaryVeinsSize);
        com.Parameters.AddWithValue("@RTributaryVeinsIntact", SFVaricoseVeins.RTributaryVeinsIntact);
        com.Parameters.AddWithValue("@RTributaryVeinsInsufficient", SFVaricoseVeins.RTributaryVeinsInsufficient);

        com.Parameters.AddWithValue("@RTributaryVeinsLocation", SFVaricoseVeins.RTributaryVeinsLocation);

        com.Parameters.AddWithValue("@RNote", SFVaricoseVeins.RNote);

        com.Parameters.AddWithValue("@ThrombusVisualized", SFVaricoseVeins.ThrombusVisualized);
        com.Parameters.AddWithValue("@DeepVeinObstruction", SFVaricoseVeins.DeepVeinObstruction);
        com.Parameters.AddWithValue("@DeepVeinInsufficiency", SFVaricoseVeins.DeepVeinInsufficiency);

        com.Parameters.AddWithValue("@VaricoseVeinsPlan", SFVaricoseVeins.VaricoseVeinsPlan);

        com.Parameters.AddWithValue("@UserPersID", SFVaricoseVeins.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSFVaricoseVeins");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.SFVaricoseVeins>(dRow);
    }
}