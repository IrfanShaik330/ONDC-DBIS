namespace ONDCPoC.Core.Models.FSSAI;

public class FSSAIResponse
{
    public Data data { get; set; }
    public string referenceId { get; set; }
    public string responseMessage { get; set; }
    public string responseCode { get; set; }
}

public class Data
{
    public string expiryDate { get; set; }
    public string kindOfBusiness { get; set; }
    public string companyName { get; set; }
    public string licenceNumber { get; set; }
    public string premisesAddress { get; set; }
    public string products { get; set; }
    public string status { get; set; }
}