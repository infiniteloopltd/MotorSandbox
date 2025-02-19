
using System.Net;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main()
    {
        var publicKey = "izlXzLYxY4";
        var privateKey = "AhmBYEXENuEdrr9s-yG-UeqG9";
        var verb = "GET";
        var uri = "https://api.motor.com/v1/Information/YMME/Years";

        var validAuthUri = GenerateUriWithValidAuth(uri, verb, publicKey, privateKey);

        Console.WriteLine(validAuthUri);

        var web = new WebClient();
        var response = web.DownloadString(validAuthUri);
        Console.WriteLine(response);

    }


    private static string GenerateUriWithValidAuth(string uri, string verb, string publicKey, string privateKey)
    {
        // Get the epoch seconds
        var requestDate = DateTime.UtcNow;
        var epochDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var epoch = Convert.ToInt64((requestDate - epochDate).TotalSeconds);

        var uriToHash = GetRelativePath(uri);
        var rawSignature = string.Format("{0}\n{1}\n{2}\n{3}", publicKey, verb, epoch, uriToHash);

        var encoding = new ASCIIEncoding();
        var bytesToHash = encoding.GetBytes(rawSignature);
        var key = encoding.GetBytes(privateKey);
        byte[] hashedSignature;
        using (var hmac = new HMACSHA256(key))
        {
            hashedSignature = hmac.ComputeHash(bytesToHash);
        }

        var base64Signature = Convert.ToBase64String(hashedSignature);

        // Note: At this point, we could use this information to create headers, but this example uses query string authentication
        var queryString = string.Format("{0}={1}&{2}={3}&{4}={5}&{6}={7}",
            "Scheme", "Shared",
            "XDate", epoch,
            "ApiKey", publicKey,
            "Sig", Uri.EscapeDataString(base64Signature));

        // Append the proper character based on if there are already query string parameters or not.
        var uriWithAuth = uri.Contains("?") ? uri + "&" : uri + "?";
        uriWithAuth += queryString;

        return uriWithAuth;
    }

    private static string GetRelativePath(string uri)
    {
        // Check for query string and remove it
        var returnUri = uri.Contains("?") ? uri.Substring(0, uri.IndexOf("?")) : uri;

        // Find the end of the protocol and hostname
        var firstSlash = returnUri.Contains("://")
            ? returnUri.IndexOf('/', returnUri.IndexOf("://") + 3)
            : returnUri.IndexOf('/');

        // Return just the path portion of the uri
        returnUri = returnUri.Substring(firstSlash, returnUri.Length - firstSlash);
        return returnUri;
    }
}