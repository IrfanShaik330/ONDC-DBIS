using ONDCPoC.Core.Helper;

namespace ONDCPoC.Core.Models.FSSAI;

public static class Response
{
    public static FSSAITransformedResponse Transform(FSSAIResponse response)
    {
        if (response?.data == null)
        {
            return new FSSAITransformedResponse
            {
                creds = new List<FSSAICredential>
            {
                new FSSAICredential
                {
                    id = null,
                    descriptor = new FSSAIDescriptor(),
                    tags = new List<FSSAITag>(),
                    statusMessage = new StatusMessage
                    {
                        referenceId = response?.referenceId,
                        responseMessage = response?.responseMessage,
                        responseCode = HttpStatusMapper.MapToHttpStatusCodeString((string?)response?.responseCode)
                    }
                }
            }

            };
        }

        return new FSSAITransformedResponse
        {
            creds =
            [
                new FSSAICredential
                {
                    id = response.data.licenceNumber,
                    descriptor = new FSSAIDescriptor
                    {
                        code = "Identifier",
                        short_desc = "FSSAI"
                    },
                    url = "https://fssai.gov.in/knowledge-hub-logos.php?pages=2",
                    tags =
                    [
                        new FSSAITag
                        {
                            code = "verification",
                            list =
                            [
                                new FSSAITagDetail { code = "verify_url", value = "https://foscos.fssai.gov.in" },
                                new FSSAITagDetail { code = "verifier", value = "CSP-Dun & Bradstreet" },
                                new FSSAITagDetail { code = "issuer", value = "Food Safety and Standards Authority of India" },
                                new FSSAITagDetail { code = "valid_from", value = "" },
                                new FSSAITagDetail { code = "valid_to", value = response.data.expiryDate },
                                new FSSAITagDetail { code = "company_name", value = response.data.companyName },
                                new FSSAITagDetail { code = "status", value = response.data.status },
                                new FSSAITagDetail { code = "business_type", value = response.data.kindOfBusiness },
                                new FSSAITagDetail { code = "products", value = response.data.products },
                                new FSSAITagDetail { code = "premises_address", value = response.data.premisesAddress },
                                new FSSAITagDetail { code = "timestamp", value = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss:fffZ") }
                            ]
                        }
                    ],
                     statusMessage = new StatusMessage
                    {
                        referenceId = response?.referenceId,
                        responseMessage = response?.responseMessage,
                        responseCode = HttpStatusMapper.MapToHttpStatusCodeString((string?)response?.responseCode)
                    }
                }
            ]
        };
    }
}