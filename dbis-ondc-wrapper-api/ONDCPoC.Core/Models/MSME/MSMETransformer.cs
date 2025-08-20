using ONDCPoC.Core.Helper;

namespace ONDCPoC.Core.Models.MSME;

public static class MSMETransformer
{
    public static MSMETransformedResponse Transform(MSMEResponse response)
    {

        if (response?.data == null)
        {
            return new MSMETransformedResponse
            {
                creds = new List<MSMECred>
            {
                new MSMECred
                {
                    id = null,
                    descriptor = new MSMEDescriptor(),
                    tags = new List<MSMETag>(),
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

        var transformed = new MSMETransformedResponse
        {
            creds = []
        };

        var cred = new MSMECred
        {
            id = response.referenceId,
            url = response.data.fileUrl,
            descriptor = new MSMEDescriptor
            {
                code = response.data.udyamRegistrationNumber,
                short_desc = response.data.nameOfEnterprise
            },
            tags = []
        };

        var tagItems = new List<MSMETagItem>
        {
            new() { code = "typeOfEnterprise", value = response.data.typeOfEnterprise },
            new() { code = "msmeDi", value = response.data.msmeDi },
            new() { code = "socialCategory", value = response.data.socialCategory },
            new() { code = "majorActivity", value = response.data.majorActivity },
            new() { code = "dateOfUdyamRregistration", value = response.data.dateOfUdyamRregistration },
            new() { code = "organisationType", value = response.data.organisationType },
            new() { code = "dateOfIncorporation", value = response.data.dateOfIncorporation },
            new() { code = "dateOfCommencement", value = response.data.dateOfCommencement },
            new() { code = "dic", value = response.data.dic }
        };

        var tag = new MSMETag
        {
            code = "enterprise_info",
            list = tagItems,
            unitdetails = response.data.unitDetails,
            officialaddressdetails = [response.data.MSMEOfficialAddressOfEnterprise]
        };

        var statusMessage = new StatusMessage
        {
            referenceId = response?.referenceId,
            responseMessage = response?.responseMessage,
            responseCode = HttpStatusMapper.MapToHttpStatusCodeString((string?)response?.responseCode)

        };
        cred.tags.Add(tag);
        transformed.creds.Add(cred);
        cred.statusMessage = statusMessage;

        return transformed;
    }
}