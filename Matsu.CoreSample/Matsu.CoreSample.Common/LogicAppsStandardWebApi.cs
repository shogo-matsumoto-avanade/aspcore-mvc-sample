using System.Net;

namespace Matsu.CoreSample.Common
{
    public class LogicAppsStandardWebApi
    {
        public async Task<string> CallHttpTrigger(string url, string signature)
        {
            var client = new HttpClient();

            var request = $"{url}&sig={signature}";
            var response = await client.GetAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

    }
}