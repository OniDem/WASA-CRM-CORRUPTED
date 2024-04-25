using Core.Entity;
using System.Net.Http;

namespace WASA_API.Service
{
    public static class MarkingVerifyService
    {
        public static async Task<bool> VerifyProductWithLable(string label)
        {
            JsonContent content = JsonContent.Create("");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync($"http://localhost:5200/AlcoholLabel/VerifyLabel?label={label}", content);
            var result = await response.Content.ReadFromJsonAsync<bool>();
            return result;
        }
    }
}
