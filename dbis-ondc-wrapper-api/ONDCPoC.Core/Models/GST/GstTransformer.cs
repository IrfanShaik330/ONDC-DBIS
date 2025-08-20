using Newtonsoft.Json.Linq;
using ONDCPoC.Core.Helper;

namespace ONDCPoC.Core.Models.GST;

public static class GstTransformer
{
    public static GstTransformedResponse Transform(string json)
    {

        var apiResponse = JObject.Parse(json);

        if (apiResponse["data"] == null)
        {
            return new GstTransformedResponse
            {
                creds = new List<GstCred>
            {
                new GstCred
                {
                    id = null,
                    descriptor = new GstDescriptor(),
                    tags = new List<GstTag>(),
                    statusMessage = new StatusMessage
                    {

                        referenceId = apiResponse["referenceId"]?.ToString(),
                        responseMessage = apiResponse["responseMessage"]?.ToString(),
                        responseCode = HttpStatusMapper.MapToHttpStatusCodeString(apiResponse["responseCode"]?.ToString())


                    }
                }
            }

            };
        }

        //var apiResponse = JObject.Parse(json);
        var gstInfo = apiResponse["data"]?["gstinDetailedInformartion"];
        var reportDate = apiResponse["data"]?["reportDateGeneration"]?.ToString();

        var timestamp = DateTime.TryParse(reportDate, out var dt)
            ? dt.ToString("yyyy-MM-ddTHH:mm:ss:000Z")
            : "";

        var tagDetails = new List<GstTagDetail>
    {
        new() { code = "verify_url", value = "https://services.gst.gov.in/services/searchtp" },
        new() { code = "verifier", value = "CSP-Dun & Bradstreet" },
        new() { code = "issuer", value = "Government of India" },
        new() { code = "valid_from", value = "2017-07-01T00:00:00:000Z" },
        new() { code = "valid_to", value = gstInfo?["registerCancellationDate"]?.ToString() ?? "" },
        new() { code = "legal_name", value = gstInfo?["legalName"]?.ToString() ?? "" },
        new() { code = "registration_status", value = gstInfo?["currentRegistrationStatus"]?.ToString() ?? "" },
        new() { code = "taxpayer_type", value = gstInfo?["taxpayerType"]?.ToString() ?? "" },
        new() { code = "business_constituton", value = gstInfo?["businessConstitution"]?.ToString() ?? "" },
        new() { code = "principal_address", value = gstInfo?["businessAddress"]?["primaryBusinessRegisteredAddress"]?.ToString() ?? "" },
        new() { code = "state_jurisdiction", value = gstInfo?["stateJurisdiction"]?.ToString() ?? "" },
        new() { code = "central_jurisdiction", value = gstInfo?["centralJurisdiction"]?.ToString() ?? "" },
        new() { code = "trade_name", value = gstInfo?["tradeName"]?.ToString() ?? "" },
        new() { code = "pan", value = gstInfo?["pan"]?.ToString() ?? "" },
        new() { code = "state", value = "" },
        new() { code = "timestamp", value = timestamp }
    };

        return new GstTransformedResponse
        {
            creds =
            [
                new GstCred
                {
                    id = gstInfo?["gstin"]?.ToString() ?? "",
                    descriptor = new GstDescriptor
                    {
                        code = "Identifier",
                        short_desc = "GSTIN"
                    },
                    url = "",
                    tags =
                    [
                        new GstTag
                        {
                            code = "verification",
                            list = tagDetails
                        }
                    ],
                    statusMessage = new StatusMessage{
                         referenceId = apiResponse["referenceId"]?.ToString(),
                        responseMessage = apiResponse["responseMessage"]?.ToString(),
                        responseCode = HttpStatusMapper.MapToHttpStatusCodeString(apiResponse["responseCode"]?.ToString())
                    }
                }
            ]
        };
    }

}

