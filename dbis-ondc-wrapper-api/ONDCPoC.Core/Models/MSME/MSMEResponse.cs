namespace ONDCPoC.Core.Models.MSME;

public class MSMEResponse
{
    public MSMEData data { get; set; }
    public string referenceId { get; set; }
    public string responseMessage { get; set; }
    public string responseCode { get; set; }
}

public class MSMEData
{
    public List<MSMEUnitDetail> unitDetails { get; set; }
    public string typeOfEnterprise { get; set; }
    public string msmeDi { get; set; }
    public string socialCategory { get; set; }
    public string majorActivity { get; set; }
    public MSMEOfficialAddress MSMEOfficialAddressOfEnterprise { get; set; }
    public string dateOfUdyamRregistration { get; set; }
    public string organisationType { get; set; }
    public string dateOfIncorporation { get; set; }
    public string udyamRegistrationNumber { get; set; }
    public string dateOfCommencement { get; set; }
    public string nameOfEnterprise { get; set; }
    public string fileUrl { get; set; }
    public List<NationalIndustryClassificationCode> nationalIndustryClassificationCodes { get; set; }
    public string dic { get; set; }
}


public class NationalIndustryClassificationCode
{
    public string nicFiveDigit { get; set; }
    public string date { get; set; }
    public string activity { get; set; }
    public string nicFourDigit { get; set; }
    public string nicTwoDigit { get; set; }
}