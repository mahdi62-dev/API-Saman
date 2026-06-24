using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("SFVaricoseVeins")]
public class SFVaricoseVeins
{
    public SFVaricoseVeins()
    {
        CRUD = 0;
        EncID = 0;
        PageID = 0;
        ServiceCode = 0;
        UserPersID = 0;
        Date = null;

        LSFJIntact = false;
        LSFJInsufficient = false;
        LGSVUpperKneeIntact = false;
        LGSVUpperKneeInsufficient = false;
        LGSVMidKneeIntact = false;
        LGSVMidKneeInsufficient = false;
        LGSVLowerKneeIntact = false;
        LGSVLowerKneeInsufficient = false;
        LGSVBelowKneeIntact = false;
        LGSVBelowKneeInsufficient = false;
        LGSVAboveKneeIntact = false;
        LGSVAboveKneeInsufficient = false;
        LAAGSVIntact = false;
        LAAGSVInsufficient = false;
        LPAGSVIntact = false;
        LPAGSVInsufficient = false;
        LSPJIntact = false;
        LSPJInsufficient = false;
        LSSVLowerKneeIntact = false;
        LSSVLowerKneeInsufficient = false;
        LSSVUpperAnkleIntact = false;
        LSSVUpperAnkleInsufficient = false;
        LPerforatorsIntact = false;
        LPerforatorsInsufficient = false;
        LTributaryVeinsIntact = false;
        LTributaryVeinsInsufficient = false;

        RSFJIntact = false;
        RSFJInsufficient = false;
        RGSVUpperKneeIntact = false;
        RGSVUpperKneeInsufficient = false;
        RGSVMidKneeIntact = false;
        RGSVMidKneeInsufficient = false;
        RGSVLowerKneeIntact = false;
        RGSVLowerKneeInsufficient = false;
        RGSVBelowKneeIntact = false;
        RGSVBelowKneeInsufficient = false;
        RGSVAboveKneeIntact = false;
        RGSVAboveKneeInsufficient = false;
        RAAGSVIntact = false;
        RAAGSVInsufficient = false;
        RPAGSVIntact = false;
        RPAGSVInsufficient = false;
        RSPJIntact = false;
        RSPJInsufficient = false;
        RSSVLowerKneeIntact = false;
        RSSVLowerKneeInsufficient = false;
        RSSVUpperAnkleIntact = false;
        RSSVUpperAnkleInsufficient = false;
        RPerforatorsIntact = false;
        RPerforatorsInsufficient = false;
        RTributaryVeinsIntact = false;
        RTributaryVeinsInsufficient = false;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CRUD { get; set; } // int, not null

    public int SFVaricoseVeinsID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public int PageID { get; set; } // int, not null
    public int ServiceCode { get; set; } // int, not null
    public string Date { get; set; }

    public bool? LSFJIntact { get; set; } // bit, null
    public bool? LSFJInsufficient { get; set; } // bit, null

    public double? LGSVUpperKneeSize { get; set; } // int, null
    public bool? LGSVUpperKneeIntact { get; set; } // bit, null
    public bool? LGSVUpperKneeInsufficient { get; set; } // bit, null

    public double? LGSVMidKneeSize { get; set; } // int, null
    public bool? LGSVMidKneeIntact { get; set; } // bit, null
    public bool? LGSVMidKneeInsufficient { get; set; } // bit, null

    public double? LGSVLowerKneeSize { get; set; } // int, null
    public bool? LGSVLowerKneeIntact { get; set; } // bit, null
    public bool? LGSVLowerKneeInsufficient { get; set; } // bit, null

    public double? LGSVBelowKneeSize { get; set; } // int, null
    public bool? LGSVBelowKneeIntact { get; set; } // bit, null
    public bool? LGSVBelowKneeInsufficient { get; set; } // bit, null

    public double? LGSVAboveKneeSize { get; set; } // int, null
    public bool? LGSVAboveKneeIntact { get; set; } // bit, null
    public bool? LGSVAboveKneeInsufficient { get; set; } // bit, null

    public double? LAAGSVSize { get; set; } // int, null
    public bool? LAAGSVIntact { get; set; } // bit, null
    public bool? LAAGSVInsufficient { get; set; } // bit, null

    public double? LPAGSVSize { get; set; } // int, null
    public bool? LPAGSVIntact { get; set; } // bit, null
    public bool? LPAGSVInsufficient { get; set; } // bit, null

    public double? LSPJSize { get; set; } // int, null
    public bool? LSPJIntact { get; set; } // bit, null
    public bool? LSPJInsufficient { get; set; } // bit, null


    public double? LSSVLowerKneeSize { get; set; } // int, null
    public bool? LSSVLowerKneeIntact { get; set; } // bit, null
    public bool? LSSVLowerKneeInsufficient { get; set; } // bit, null
    public double? LSSVUpperAnkleSize { get; set; } // int, null
    public bool? LSSVUpperAnkleIntact { get; set; } // bit, null
    public bool? LSSVUpperAnkleInsufficient { get; set; } // bit, null
    public double? LPerforatorsSize { get; set; } // int, null
    public bool? LPerforatorsIntact { get; set; } // bit, null
    public bool? LPerforatorsInsufficient { get; set; } // bit, null
    public string LNumber { get; set; }
    public string LLocation { get; set; }

    public double? LTributaryVeinsSize { get; set; } // int, null
    public bool? LTributaryVeinsIntact { get; set; } // bit, null
    public bool? LTributaryVeinsInsufficient { get; set; } // bit, null

    public string LTributaryVeinsLocation { get; set; }

    public string LNote { get; set; }


    public bool? RSFJIntact { get; set; } // bit, null
    public bool? RSFJInsufficient { get; set; } // bit, null

    public double? RGSVUpperKneeSize { get; set; } // int, null
    public bool? RGSVUpperKneeIntact { get; set; } // bit, null
    public bool? RGSVUpperKneeInsufficient { get; set; } // bit, null

    public double? RGSVMidKneeSize { get; set; } // int, null
    public bool? RGSVMidKneeIntact { get; set; } // bit, null
    public bool? RGSVMidKneeInsufficient { get; set; } // bit, null

    public double? RGSVLowerKneeSize { get; set; } // int, null
    public bool? RGSVLowerKneeIntact { get; set; } // bit, null
    public bool? RGSVLowerKneeInsufficient { get; set; } // bit, null

    public double? RGSVBelowKneeSize { get; set; } // int, null
    public bool? RGSVBelowKneeIntact { get; set; } // bit, null
    public bool? RGSVBelowKneeInsufficient { get; set; } // bit, null

    public double? RGSVAboveKneeSize { get; set; } // int, null
    public bool? RGSVAboveKneeIntact { get; set; } // bit, null
    public bool? RGSVAboveKneeInsufficient { get; set; } // bit, null


    public double? RAAGSVSize { get; set; } // int, null
    public bool? RAAGSVIntact { get; set; } // bit, null
    public bool? RAAGSVInsufficient { get; set; } // bit, null

    public double? RPAGSVSize { get; set; } // int, null
    public bool? RPAGSVIntact { get; set; } // bit, null
    public bool? RPAGSVInsufficient { get; set; } // bit, null

    public double? RSPJSize { get; set; } // int, null
    public bool? RSPJIntact { get; set; } // bit, null
    public bool? RSPJInsufficient { get; set; } // bit, null

    public double? RSSVLowerKneeSize { get; set; } // int, null
    public bool? RSSVLowerKneeIntact { get; set; } // bit, null
    public bool? RSSVLowerKneeInsufficient { get; set; } // bit, null


    public double? RSSVUpperAnkleSize { get; set; } // int, null
    public bool? RSSVUpperAnkleIntact { get; set; } // bit, null
    public bool? RSSVUpperAnkleInsufficient { get; set; } // bit, null
    public double? RPerforatorsSize { get; set; } // int, null
    public bool? RPerforatorsIntact { get; set; } // bit, null
    public bool? RPerforatorsInsufficient { get; set; } // bit, null
    public string RNumber { get; set; }
    public string RLocation { get; set; }
    public double? RTributaryVeinsSize { get; set; } // int, null
    public bool? RTributaryVeinsIntact { get; set; } // bit, null
    public bool? RTributaryVeinsInsufficient { get; set; } // bit, null

    public string RTributaryVeinsLocation { get; set; }

    public string RNote { get; set; }

    public bool? ThrombusVisualized { get; set; } // bit, null
    public bool? DeepVeinObstruction { get; set; } // bit, null
    public bool? DeepVeinInsufficiency { get; set; } // bit, null

    public string VaricoseVeinsPlan { get; set; }

    public int UserPersID { get; set; } // int, not null
}