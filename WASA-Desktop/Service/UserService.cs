using Core.Const;
using Core.Entity;
using DTO.User;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace WASA_Mobile.Service
{
    public static class UserService
    {
        public static async Task<UserEntity?> AuthUser(AuthUserRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("https://onidem-wasa-api-c94a.twc1.net/User/AuthUser", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<UserEntity>();
                    if (result!.Id > 0)
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


