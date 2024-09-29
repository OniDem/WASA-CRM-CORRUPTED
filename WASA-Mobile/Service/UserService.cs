using Core.Const;
using Core.Entity;
using DTO.User;
using System.Net;
using System.Net.Http.Json;

namespace WASA_Mobile.Service
{
    public static class UserService
    {
        public static async Task<string> AuthUser(AuthUserRequest request)
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
                        AddUserToSecureStorage(
                        new()
                        {
                            Id = result!.Id,
                            Role = result.Role.ToString(),
                            FIO = result.FIO,
                            Username = result.Username
                        });

                    }
                }
                return ServerService.ResponseCodeToString(response.StatusCode)!;
            }
            catch (Exception)
            {
                return "Проверьте подключение к интернету";
            }
        }
        public static bool UserAutorized()
        {
            var id = GetUserId();
            if (id > 0)
                return true;
            return false;
        }

        public static int GetUserId()
        {
            return Convert.ToInt32(Task.Run(async () => await SecureStorage.GetAsync(SecureStoragePathConst.Id)).Result);//If Exception has been thrown by the target of an invocation, set backup in AndroidManifest to false
        }

        public static SecureStorageUserEntity GetUserInfoFromSecureStorage()
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

        public static async Task<bool> SecureStorageHaveValue(string key)
        {
            if (await SecureStorage.GetAsync(key) != null)
                return true;
            return false;
        }
    }
}


