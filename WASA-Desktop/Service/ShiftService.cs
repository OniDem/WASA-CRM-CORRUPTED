using Core.Const;
using Core.Entity;
using DTO.Shift;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using WASA_CoreLib.Entity;

namespace WASA_Desktop.Service
{
    public static class ShiftService
    {
        /*
        public static bool ShiftOpen()
        {
            var result = Task.Run(async () => await SecureStorage.GetAsync(SecureStoragePathConst.ShiftID)).Result;
            if (result == null)
                return false;
            else
                return true;
        }
        */
        public async static Task<ShiftEntity> Open(OpenShiftRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("https://onidem-wasa-api-c94a.twc1.net/Shift/OpenShift", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ShiftEntity>();
                    if (result!.Id > 0)
                    {
                        AuthorizedUserDataEntity.ShiftId = result.Id;
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

        public static async Task<ShiftEntity> ShowById(ShowByIdRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("https://onidem-wasa-api-c94a.twc1.net/Shift/ShowById", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ShiftEntity>();
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

        public static async Task<IEnumerable<ShiftEntity>> ShowAll()
        {
            try
            {
                JsonContent content = JsonContent.Create("");
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("https://onidem-wasa-api-c94a.twc1.net/Shift/ShowAll", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<IEnumerable<ShiftEntity>>();
                    if (result!.Count() > 0)
                    {
                        return result!;
                    }
                }
                return [];
            }
            catch (Exception )
            {
                return [];
            }
        }

        public static async Task<List<int>> ShowAllIds()
        {
           var shifts = await ShowAll();
            List<int> listToReturn = [];
            foreach (var shift in shifts)
                listToReturn.Add(shift.Id);
            listToReturn.Sort();
            return listToReturn;
                

        }

        public static async Task<ShiftEntity> InsertCash(CashOperationRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PutAsync("https://onidem-wasa-api-c94a.twc1.net/Shift/InsertCash", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ShiftEntity>();
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

        public static async Task<ShiftEntity> ExtractCash(CashOperationRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PutAsync("https://onidem-wasa-api-c94a.twc1.net/Shift/ExtractCash", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ShiftEntity>();
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

        public static async Task<ShiftEntity> AcquiringApprove(AcquiringApproveRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PutAsync("https://onidem-wasa-api-c94a.twc1.net/Shift/AcquiringApprove", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ShiftEntity>();
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

        public static async Task<ShiftEntity> Close(CloseShiftRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PutAsync("https://onidem-wasa-api-c94a.twc1.net/Shift/CloseShift", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ShiftEntity>();
                    if (result!.Id > 0)
                    {
                        AuthorizedUserDataEntity.ShiftId = -1;
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

        public static async Task<ShiftEntity> AddReceiptToShift(AddReceiptToShiftRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PutAsync("https://onidem-wasa-api-c94a.twc1.net/Shift/AddReceiptToShift", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ShiftEntity>();
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
