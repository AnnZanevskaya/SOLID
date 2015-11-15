using System.IO;
using System.Net;

namespace BecomeSolid.Day1.Helpers
{
    public static class RestHelper
    {
        public static string GetResponse(string url)
        {
            string response;

            WebRequest request = WebRequest.Create(url);
            WebResponse webResponse = request.GetResponse();
            using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
                response = streamReader.ReadToEnd();

            return response;
        }
    }
}
