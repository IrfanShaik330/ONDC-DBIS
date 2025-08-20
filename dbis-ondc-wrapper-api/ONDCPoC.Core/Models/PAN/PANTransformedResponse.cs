namespace ONDCPoC.Core.Models.PAN;

public class PANTransformedResponse
{
    public List<PANCred> creds { get; set; }

}

public class PANCred
{
    public string? id { get; set; }
    public PANDescriptor descriptor { get; set; }
    public string url { get; set; } = "";
    public List<PANTag> tags { get; set; }

    public StatusMessage statusMessage { get; set; }
}

public class PANDescriptor
{
    public string code { get; set; } = "Identifier";
    public string short_desc { get; set; } = "PAN";
}

public class PANTag
{
    public string code { get; set; } = "verification";
    public List<PANTagDetail> list { get; set; }
}

public class PANTagDetail
{
    public string code { get; set; }
    public string? value { get; set; }
}