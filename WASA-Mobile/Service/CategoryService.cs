using Core.Entity;
using System.Net.Http.Json;
using System.Net;

namespace WASA_Mobile.Service
{
    public static class CategoryService
    {
        public static async Task<IEnumerable<CategoryShowEntity>?> GetAll()
        {
            try
            {
                JsonContent content = JsonContent.Create("");
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("https://onidem-wasa-api-c94a.twc1.net/Category/GetAll", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<IEnumerable<CategoryShowEntity>>();
                    if (result!.Count() > 0)
                    {
                        return result;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
