using ONDCPoC.Core.Helper;

namespace ONDCPoC.Core.Models.PAN;

public class PANTransformer
{
    public static PANTransformedResponse Transform(dynamic? input)
    {
        if (input?.data == null)
        {
            return new PANTransformedResponse
            {
                creds = new List<PANCred>
            {
                new PANCred
                {
                    id = null,
                    descriptor = new PANDescriptor(),
                    tags = new List<PANTag>(),
                    statusMessage = new StatusMessage
                    {
                        referenceId = input?.referenceId,
                        responseMessage = input?.responseMessage,
                        responseCode = HttpStatusMapper.MapToHttpStatusCodeString((string?)input?.responseCode)
                    }
                }
            }
               
            };
        }

        var pan = input?.data.pan;
        var response = new PANTransformedResponse
        {
            creds =
            [
                new PANCred
                {
                    id = pan,
                    descriptor = new PANDescriptor(),
                    tags =
                    [
                        new PANTag
                        {
                            list =
                            [
                                new PANTagDetail { code = "verify_url", value = "https://www.incometaxindiaefiling.gov.in" },
                                new PANTagDetail { code = "verifier", value = "CSP-Dun & Bradstreet" },
                                new PANTagDetail { code = "issuer", value = "Income Tax Department" },
                                new PANTagDetail { code = "valid_from", value = "" },
                                new PANTagDetail { code = "valid_to", value = "" },
                                new PANTagDetail { code = "first_name", value = input?.data.firstName },
                                new PANTagDetail { code = "last_name", value = input?.data.lastName },
                                new PANTagDetail { code = "gender", value = input ?.data.gender },
                                new PANTagDetail { code = "date_of_birth", value = input ?.data.dob },
                                new PANTagDetail { code = "full_name", value = input ?.data.fullName },
                                new PANTagDetail { code = "category", value = input ?.data.category },
                                new PANTagDetail { code = "aadhar_linked", value = input?.data.aadhaarLinked.ToString().ToLower() },
                                new PANTagDetail { code = "masked_aadhar", value = input?.data.maskedAadhaarNumber },
                                new PANTagDetail { code = "timestamp", value = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") }
                            ]
                        }
                    ],
                    statusMessage = new StatusMessage {
                    referenceId = input ?.referenceId,
                    responseMessage = input ?.responseMessage,
                    responseCode = HttpStatusMapper.MapToHttpStatusCodeString((string?)input?.responseCode) }
                }
            ]           
        };

        return response;
    }
}