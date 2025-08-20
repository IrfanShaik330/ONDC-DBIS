namespace ONDCPoC.Core.Helper;

public static class HttpStatusMapper
{      
    public static string MapToHttpStatusCodeString(string? responseCode)
    {
        return responseCode switch
        {
            "SRC001" => "200", // Success
            "EBF017" => "400", // Blank Input
            "EIP018" => "400", // Incorrect Input
            "EPI022" => "400", // Incorrect Payload
            "ENI004" => "404", // No Information Found
            "ERT788" => "408", // Request Timed Out
            "EIS042" => "503", // Info Source Not Working
            "EUP007" => "500", // Technical Issue
            "EUN1183" => "422", // Technical Issue
            "EUN1182" => "409", // Technical Issue

            _ => "500"         // Default fallback
        };
    }
}