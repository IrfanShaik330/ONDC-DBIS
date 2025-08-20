namespace ONDCPoC.Core.Models.GST;

public class GstTransformedResponse
{
    public List<GstCred> creds { get; set; }
}

public class GstCred
{
    public string id { get; set; }
    public GstDescriptor descriptor { get; set; }
    public string url { get; set; }
    public List<GstTag> tags { get; set; }
    public StatusMessage statusMessage { get; set; }
}


public class GstDescriptor
{
    public string code { get; set; }
    public string short_desc { get; set; }
}

public class GstTag
{
    public string code { get; set; }
    public List<GstTagDetail> list { get; set; }
}

public class GstTagDetail
{
    public string code { get; set; }
    public string value { get; set; }
}