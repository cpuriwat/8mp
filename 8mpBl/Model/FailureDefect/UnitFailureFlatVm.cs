using System.ComponentModel;

public class UnitFailureFlatVm
{
    [Description("Fail Code")]
    public string fail_code { get; set; }
    [Description("Defect Code")]
    public string defect_code { get; set; }
    [Description("Rework Code")]
    public string rework_code { get; set; }
    [Description("RD")]
    public string rd { get; set; }
    [Description("PN")]
    public string pn { get; set; }
    [Description("Rework Action")]
    public string rework_action { get; set; }
    [Description("Root Cause")]
    public string rootcause { get; set; }
}

