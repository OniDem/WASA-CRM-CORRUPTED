using CommunityToolkit.Maui.Converters;
using Core.Const;
using Core.Entity;
using DTO.User;
using System.Net.Http.Json;

namespace WASA_Mobile.Service
{
    public static class UserService
    {
        public static async Task<bool> AuthUser(AuthUserRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("http://10.0.2.2:5007/User/AuthUser", content);
                var result = await response.Content.ReadFromJsonAsync<UserEntity>();
                
                if (result.Id > 0)
                {
                    AddUserToSecureStorage(
                    new()
                    {
                        Id = result!.Id,
                        Role = result.Role.ToString(),
                        FIO = result.FIO,
                        Username = result.Username
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
        public static bool UserAutorized()
        { 
            if (GetUserId() > 0)
                return true;
            return false;
        }

        public static int GetUserId()
        {
            return Convert.ToInt32(Task.Run(async () => await SecureStorage.GetAsync(SecureStoragePathConst.Id)).Result);
        }

        public static SecureStorageUserEntity GetUserInfoFromSecuteStorage()
        {
            return new()
            {
                Id = Convert.ToInt32(Task.Run(async () => await SecureStorage.GetAsync(SecureStoragePathConst.Id)).Result),
                Role = Task.Run(async () => await SecureStorage.GetAsync(SecureStoragePathConst.Role)).Result!,
                FIO = Task.Run(async () => await SecureStorage.GetAsync(SecureStoragePathConst.FIO)).Result!,
                Username = Task.Run(async () => await SecureStorage.GetAsync(SecureStoragePathConst.Username)).Result!,
            };
        }

        private static async void AddUserToSecureStorage(SecureStorageUserEntity entity)
        {
            await SecureStorage.SetAsync(SecureStoragePathConst.Id, entity.Id.ToString());
            await SecureStorage.SetAsync(SecureStoragePathConst.Role, entity.Role.ToString());
            await SecureStorage.SetAsync(SecureStoragePathConst.FIO, entity.FIO);
            await SecureStorage.SetAsync(SecureStoragePathConst.Username, entity.Username);
        }

        public static void RemoveUserFromSecureStorage()
        {
            SecureStorage.RemoveAll();
        }
    }
}


