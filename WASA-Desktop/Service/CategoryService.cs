using Core.Entity;
using System.Net.Http.Json;
using System.Net;
using System.Net.Http;
using WASA_CoreLib.ShowEntity;

namespace WASA_Desktop.Service
{
    public static class CategoryService
    {
        public static async Task<List<CategoryShowEntity>?> GetAll()
        {
            try
            {
                JsonContent content = JsonContent.Create("");
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("https://onidem-wasa-api-c94a.twc1.net/Category/GetAll", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<List<CategoryShowEntity>>();
                    if (result!.Count() > 0)
                    {
                        return result;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
