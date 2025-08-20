namespace ONDCPoC.Api.Models
{
    public class GstExportModel
    {
        public string GSTIN { get; set; }
        public string PAN { get; set; }
        public string LegalName { get; set; }
        public string TradeName { get; set; }
        public string RegistrationStatus { get; set; }
        public string TaxpayerType { get; set; }
        public string BusinessConstitution { get; set; }
        public string PrincipalAddress { get; set; }
        public string StateJurisdiction { get; set; }
        public string CentralJurisdiction { get; set; }
        public string Verifier { get; set; } = "CSP-Dun & Bradstreet";
        public string Issuer { get; set; } = "Government of India";
        public string VerificationURL { get; set; } = "https://services.gst.gov.in/services/searchtp";
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string Timestamp { get; set; }
    }
}