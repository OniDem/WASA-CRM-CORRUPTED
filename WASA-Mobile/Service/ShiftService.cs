using Core.Const;
using Core.Entity;
using DTO.Shift;
using System.Net;
using System.Net.Http.Json;

namespace WASA_Mobile.Service
{
    public static class ShiftService
    {
        public static bool ShiftOpen()
        {
            var result = Task.Run(async () => await SecureStorage.GetAsync(SecureStoragePathConst.ShiftID)).Result;
            if (result == null)
                return false;
            else
                return true;
        }

        public async static Task<ShiftEntity> Open(OpenShiftRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("http://212.20.46.249:32769/Shift/OpenShift", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ShiftEntity>();
                    if (result!.Id > 0)
                    {
                        AddShiftToSecureStorage(new() { Id = result.Id });
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

        private static async void AddShiftToSecureStorage(SecureStorageShiftEntity entity)
        {
            await SecureStorage.SetAsync(SecureStoragePathConst.ShiftID, entity.Id.ToString());
        }

        private static void RemoveShiftFromSecureStorage()
        {
            SecureStorage.Remove(SecureStoragePathConst.ShiftID);
        }

        public static bool Close()
        {
            //Some code to call api methods
            RemoveShiftFromSecureStorage();
            return true;
        }
    }
}
