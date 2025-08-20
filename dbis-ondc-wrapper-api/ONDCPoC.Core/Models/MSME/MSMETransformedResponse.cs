namespace ONDCPoC.Core.Models.MSME;

public class MSMETransformedResponse
{
    public List<MSMECred> creds { get; set; }
}


public class MSMECred
{
    public string id { get; set; }
    public MSMEDescriptor descriptor { get; set; }
    public string url { get; set; }
    public List<MSMETag> tags { get; set; }
    public StatusMessage statusMessage { get; set; }

}

public class MSMEDescriptor
{
    public string code { get; set; }
    public string short_desc { get; set; }
}

public class MSMETag
{
    public string code { get; set; }
    public List<MSMETagItem> list { get; set; }
    public List<MSMEUnitDetail> unitdetails { get; set; }
    public List<MSMEOfficialAddress> officialaddressdetails { get; set; }
}

public class MSMETagItem
{
    public string code { get; set; }
    public string value { get; set; }
}

public class MSMEUnitDetail
{
    public string villageTown { get; set; }
    public string unitName { get; set; }
    public string pin { get; set; }
    public string road { get; set; }
    public string city { get; set; }
    public string flat { get; set; }
    public string district { get; set; }
    public string block { get; set; }
    public string state { get; set; }
    public string building { get; set; }
}

public class MSMEOfficialAddress
{
    public string villageTown { get; set; }
    public string nameOfPremisesBuilding { get; set; }
    public string pin { get; set; }
    public string city { get; set; }
    public string district { get; set; }
    public string mobile { get; set; }
    public string roadStreetLane { get; set; }
    public string block { get; set; }
    public string flatDoorBlockno { get; set; }
    public string state { get; set; }
    public string email { get; set; }
}