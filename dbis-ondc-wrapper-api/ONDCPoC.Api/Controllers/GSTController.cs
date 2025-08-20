using Microsoft.AspNetCore.Mvc;
using ONDCPoC.Api.Models;
using ClosedXML.Excel;
using System.IO;

namespace ONDCPoC.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GSTController : ControllerBase
    {
        // Single GSTIN endpoint (hardcoded response)
        [HttpPost(Name = "GetGSTDetails")]
        public ActionResult<GstExportModel?> GetGSTDetails([FromBody] string gstin)
        {
            var gstDetails = GetHardcodedGSTDetails().FirstOrDefault(g => g.GSTIN == gstin);
            if (gstDetails == null)
                return NotFound("GSTIN not found.");
            return gstDetails;
        }

        

        [HttpPost("batch")]
        public ActionResult<List<GstExportModel>> GetGSTDetailsBatch([FromBody] List<string> gstinList)
        {
            var allDetails = GetHardcodedGSTDetails();
            var matchedDetails = allDetails.Where(g => gstinList.Contains(g.GSTIN)).ToList();

            if (!matchedDetails.Any())
                return NotFound("No matching GSTINs found.");

            return matchedDetails;
        }





        [HttpPost("export")]
        public IActionResult ExportGSTDetailsToExcel([FromBody] List<string> gstinList)
        {
            var gstDetails = GetHardcodedGSTDetails()
                             .Where(g => gstinList.Contains(g.GSTIN))
                             .ToList();

            if (!gstDetails.Any())
                return NotFound("No matching GSTINs found.");

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("GST Details");

            worksheet.Cell(1, 1).InsertTable(gstDetails);

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "FilteredGSTDetails.xlsx");
        }

        // Hardcoded GST data
        private List<GstExportModel> GetHardcodedGSTDetails()
        {
            return new List<GstExportModel>
            {
                new GstExportModel
                {
                    GSTIN = "22AAAAA0000A1Z5",
                    PAN = "AAAAA0000A",
                    LegalName = "ABC Pvt Ltd",
                    TradeName = "ABC Traders",
                    RegistrationStatus = "Active",
                    TaxpayerType = "Regular",
                    BusinessConstitution = "Private Limited Company",
                    PrincipalAddress = "123, MG Road, Raipur",
                    StateJurisdiction = "Raipur Zone",
                    CentralJurisdiction = "CGST Raipur",
                    ValidFrom = "01-07-2017",
                    ValidTo = "N/A",
                    Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                },
                new GstExportModel
                {
                    GSTIN = "27AAECS1234F1Z2",
                    PAN = "AAECS1234F",
                    LegalName = "XYZ Enterprises",
                    TradeName = "XYZ Mart",
                    RegistrationStatus = "Active",
                    TaxpayerType = "Composition",
                    BusinessConstitution = "Partnership",
                    PrincipalAddress = "456, Bandra West, Mumbai",
                    StateJurisdiction = "Mumbai Zone",
                    CentralJurisdiction = "CGST Mumbai",
                    ValidFrom = "01-04-2018",
                    ValidTo = "N/A",
                    Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                },

                new GstExportModel
                {
                    GSTIN = "27AAECS1234F1Z3",
                    PAN = "AAECS1234F",
                    LegalName = "XYZ Enterprises",
                    TradeName = "XYZ Mart",
                    RegistrationStatus = "Active",
                    TaxpayerType = "Composition",
                    BusinessConstitution = "Partnership",
                    PrincipalAddress = "456, Bandra West, Mumbai",
                    StateJurisdiction = "Mumbai Zone",
                    CentralJurisdiction = "CGST Mumbai",
                    ValidFrom = "01-04-2018",
                    ValidTo = "N/A",
                    Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                },

                new GstExportModel
                {
                    GSTIN = "27AAECS1234F1Z4",
                    PAN = "AAECS1234F",
                    LegalName = "XYZ Enterprises",
                    TradeName = "XYZ Mart",
                    RegistrationStatus = "Active",
                    TaxpayerType = "Composition",
                    BusinessConstitution = "Partnership",
                    PrincipalAddress = "456, Bandra West, Mumbai",
                    StateJurisdiction = "Mumbai Zone",
                    CentralJurisdiction = "CGST Mumbai",
                    ValidFrom = "01-04-2018",
                    ValidTo = "N/A",
                    Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                },

                new GstExportModel
                {
                    GSTIN = "27AAECS1234F1Z5",
                    PAN = "AAECS1234F",
                    LegalName = "XYZ Enterprises",
                    TradeName = "XYZ Mart",
                    RegistrationStatus = "Active",
                    TaxpayerType = "Composition",
                    BusinessConstitution = "Partnership",
                    PrincipalAddress = "456, Bandra West, Mumbai",
                    StateJurisdiction = "Mumbai Zone",
                    CentralJurisdiction = "CGST Mumbai",
                    ValidFrom = "01-04-2018",
                    ValidTo = "N/A",
                    Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                },

                new GstExportModel
                {
                    GSTIN = "27AAECS1234F1Z6",
                    PAN = "AAECS1234F",
                    LegalName = "XYZ Enterprises",
                    TradeName = "XYZ Mart",
                    RegistrationStatus = "Active",
                    TaxpayerType = "Composition",
                    BusinessConstitution = "Partnership",
                    PrincipalAddress = "456, Bandra West, Mumbai",
                    StateJurisdiction = "Mumbai Zone",
                    CentralJurisdiction = "CGST Mumbai",
                    ValidFrom = "01-04-2018",
                    ValidTo = "N/A",
                    Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                },

                new GstExportModel
                {
                    GSTIN = "27AAECS1234F1Z7",
                    PAN = "AAECS1234F",
                    LegalName = "XYZ Enterprises",
                    TradeName = "XYZ Mart",
                    RegistrationStatus = "Active",
                    TaxpayerType = "Composition",
                    BusinessConstitution = "Partnership",
                    PrincipalAddress = "456, Bandra West, Mumbai",
                    StateJurisdiction = "Mumbai Zone",
                    CentralJurisdiction = "CGST Mumbai",
                    ValidFrom = "01-04-2018",
                    ValidTo = "N/A",
                    Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                },

                new GstExportModel
                {
                    GSTIN = "27AAECS1234F1Z8",
                    PAN = "AAECS1234F",
                    LegalName = "XYZ Enterprises",
                    TradeName = "XYZ Mart",
                    RegistrationStatus = "Active",
                    TaxpayerType = "Composition",
                    BusinessConstitution = "Partnership",
                    PrincipalAddress = "456, Bandra West, Mumbai",
                    StateJurisdiction = "Mumbai Zone",
                    CentralJurisdiction = "CGST Mumbai",
                    ValidFrom = "01-04-2018",
                    ValidTo = "N/A",
                    Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                },

                new GstExportModel
                {
                    GSTIN = "27AAECS1234F1Z9",
                    PAN = "AAECS1234F",
                    LegalName = "XYZ Enterprises",
                    TradeName = "XYZ Mart",
                    RegistrationStatus = "Active",
                    TaxpayerType = "Composition",
                    BusinessConstitution = "Partnership",
                    PrincipalAddress = "456, Bandra West, Mumbai",
                    StateJurisdiction = "Mumbai Zone",
                    CentralJurisdiction = "CGST Mumbai",
                    ValidFrom = "01-04-2018",
                    ValidTo = "N/A",
                    Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                }
            };
        }
    }
}
