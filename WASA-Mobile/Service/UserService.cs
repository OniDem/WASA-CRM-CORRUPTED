using Core.Const;
using Core.Entity;
using DTO.User;
using System.Net.Http.Json;
using WASA_Mobile.Const;

namespace WASA_Mobile.Service
{
    public static class UserService
    {
        static ApplicationContext context = new();
        public static async Task<bool> AuthUser(AuthUserRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("http://10.0.2.2:5007/User/AuthUser", content);
                var result = await response.Content.ReadFromJsonAsync<UserEntity>();
                
                if (result!.Id > 0)
                {
                    await context.AddAuthUser(
                    new()
                    {
                        Id = result!.Id,
                        Role = result.Role,
                        FIO = result.FIO,
                        Username = result.Username,
                        CreateDate = result.CreateDate,
                        LastModifiedDate = result.LastModifiedDate
                    });
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool UserAuthorized()
        {
            try
            {
                var user = Task.Run(context.GetUserInfo).Result;
                if (user != null && user.Id > 0)
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}


