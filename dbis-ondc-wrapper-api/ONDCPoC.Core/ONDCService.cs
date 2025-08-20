using Newtonsoft.Json;
using System.Text;
using ONDCPoC.Core.Models.GST;
using ONDCPoC.Core.Models.MSME;
using ONDCPoC.Core.Models.PAN;

namespace ONDCPoC.Core;

public class ONDCService(IHttpClientFactory httpClientFactory, Config ondcConfig) : IONDCService
{
    private async Task<string?> PostToScoreMeApiAsync<TRequest>(string endpoint, TRequest payload)
    {
        if (payload == null) return null;

        using var httpClient = httpClientFactory.CreateClient();
        var url = $"{ondcConfig.ScoreMeApiBaseUrl}/{endpoint}";
        var request = new HttpRequestMessage(HttpMethod.Post, url);

        request.Headers.Add("clientId", ondcConfig.ScoreMeClientId);
        request.Headers.Add("clientSecret", ondcConfig.ScoreMeClientSecret);
        request.Headers.Add("Accept", "application/json");

        var jsonPayload = JsonConvert.SerializeObject(payload);
        request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        var response = await httpClient.SendAsync(request).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    }

    public async Task<PANTransformedResponse?> GetPANDetailsAsync(string pan)
    {
        //ToDo: Validate Pan
        if (string.IsNullOrEmpty(pan)) return null;

        var responseContent = """{"data":{"firstName":"RAMESHKUMAR","lastName":"GUDALA","address":"1-86/3 TALVEDA NANDIPET TELANGANA TALVEDA B.O 503212","gender":"MALE","aadhaarLinked":"true","dob":"1986-02-10","fullName":"RAMESHKUMAR GUDALA","maskedAadhaarNumber":"XXXXXXXX3619","category":"P","pan":"BFAPR6548N"},"referenceId":"18321841-f3cf-4ddb-86e2-ea4cc9daa4e3","responseMessage":"Successfully Completed.","responseCode":"SRC001"}""";
        //await PostToScoreMeApiAsync("panDetailInfo", new PANDetailRequest { pan = pan });

        var input = JsonConvert.DeserializeObject(responseContent);
        return PANTransformer.Transform(input);
    }

    public async Task<GstTransformedResponse?> GetGSTDetailsAsync(string gstin)
    {
        if (string.IsNullOrEmpty(gstin)) return null;

        var responseContent = await PostToScoreMeApiAsync("gstBasicInfo", new GSTDetailRequest { gstin = gstin }).ConfigureAwait(false);
        
        var transformed = GstTransformer.Transform(responseContent);
        return transformed;
    }

    public async Task<Models.FSSAI.FSSAITransformedResponse?> GetFSSAIDetailsAsync(string licenceNumber)
    {
        if (string.IsNullOrEmpty(licenceNumber)) return null;

        //Please be aware of the spelling in payload
        var responseContent = await PostToScoreMeApiAsync("fssai", new FSSAIDetailRequest { licenceNumber = licenceNumber }).ConfigureAwait(false);
        
        var input = JsonConvert.DeserializeObject<Models.FSSAI.FSSAIResponse>(responseContent);

        if (input == null) return null;

        var transformed = Models.FSSAI.Response.Transform(input);
        
        return transformed;
    }

    public async Task<MSMETransformedResponse?> GetMSMEDetailsAsync(string registrationnumber)
    {
        if (string.IsNullOrEmpty(registrationnumber)) return null;

        var responseContent = await PostToScoreMeApiAsync("udyamRegistration", new MSMEDetailRequest { registrationnumber = registrationnumber });
        var input = JsonConvert.DeserializeObject<MSMEResponse>(responseContent);

        if (input == null) return null;
        
        var transformed = MSMETransformer.Transform(input);

        return  transformed;
    }
}

public class PANDetailRequest { public string pan { get; set; } }
public class GSTDetailRequest { public string gstin { get; set; } }
public class FSSAIDetailRequest { public string licenceNumber { get; set; } }
public class MSMEDetailRequest { public string registrationnumber { get; set; } }
