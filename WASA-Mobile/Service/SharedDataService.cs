﻿using System.Net.Http.Json;
using System.Net;
using WASA_CoreLib.Entity;
using WASA_DTOLib.SharedData;

namespace WASA_Mobile.Service
{
    public static class SharedDataService
    {
        public static async Task<SharedDataEntity> Update(SharedDataRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PutAsync("https://onidem-wasa-api-c94a.twc1.net/SharedData/Update", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<SharedDataEntity>();
                    if (result != null)
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

        public static async Task<SharedDataEntity> Get(SharedDataRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("https://onidem-wasa-api-c94a.twc1.net/SharedData/GetData", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<SharedDataEntity>();
                    if (result != null)
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

        public static async Task<int> GetShiftID(SharedDataRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("https://onidem-wasa-api-c94a.twc1.net/SharedData/GetData", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<SharedDataEntity>();
                    if (result != null)
                    {
                        return result.OpenedShiftId;
                    }
                }
                return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
