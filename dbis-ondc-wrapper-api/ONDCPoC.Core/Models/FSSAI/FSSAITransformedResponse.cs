namespace ONDCPoC.Core.Models.FSSAI;

public class FSSAITransformedResponse
{
    public List<FSSAICredential> creds { get; set; }
}

public class FSSAICredential
{
    public string id { get; set; }
    public FSSAIDescriptor descriptor { get; set; }
    public string url { get; set; }
    public List<FSSAITag> tags { get; set; }
    public StatusMessage statusMessage { get; set; }

}

public class FSSAIDescriptor
{
    public string code { get; set; } = "Identifier";
    public string short_desc { get; set; } = "FSSAI";
}

public class FSSAITag
{
    public string code { get; set; } = "verification";
    public List<FSSAITagDetail> list { get; set; }
}

public class FSSAITagDetail
{
    public string code { get; set; }
    public string value { get; set; }
}