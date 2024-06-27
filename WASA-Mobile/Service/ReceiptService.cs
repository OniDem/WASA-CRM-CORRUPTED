using Core.Const;
using Core.Entity;
using DTO.Receipt;
using System.Net;
using System.Net.Http.Json;

namespace WASA_Mobile.Service
{
    public static class ReceiptService
    {
        public async static Task<ReceiptEntity> AddReceipt(AddReceiptRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("http://212.20.46.249:32777/Receipt/Add", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ReceiptEntity>();
                    if (result!.Id > 0)
                    {
                        AddReceiptToSecureStorage(new() { Id = result.Id });
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

        public async static Task<ReceiptEntity> GetReceiptById(GetReceiptByIdRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("http://212.20.46.249:32777/Receipt/ShowById", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ReceiptEntity>();
                    if (result!.Id > 0)
                    {
                        return result;
                    }
                }
                return new() { Id = -1 };
            }
            catch (Exception ex)
            {
                return new() { Id = -1 };
            }
        }

        public async static Task<ReceiptEntity> AddProductToReceipt(AddProductToReceiptRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PutAsync("http://212.20.46.249:32777/Receipt/AddProducts", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ReceiptEntity>();
                    if (result!.Id > 0)
                    {
                        return result;
                    }
                }
                return new() { Id = -1 };
            }
            catch (Exception ex)
            {
                return new() { Id = -1 };
            }
        }

        public async static Task<ReceiptEntity> Payment(PaymentReceiptRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PutAsync("http://212.20.46.249:32777/Receipt/Payment", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ReceiptEntity>();
                    if (result!.Id > 0)
                    {
                        return result;
                    }
                }
                return new() { Id = -1 };
            }
            catch (Exception ex)
            {
                return new() { Id = -1 };
            }
        }

        public async static Task<ReceiptEntity> Close(GetReceiptByIdRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PutAsync("http://212.20.46.249:32777/Receipt/Close", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ReceiptEntity>();
                    if (result!.Id > 0)
                    {
                        return result;
                    }
                }
                return new() { Id = -1 };
            }
            catch (Exception ex)
            {
                return new() { Id = -1 };
            }
        }

        public async static Task<ReceiptEntity> Cancel(CancelReceiptRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PutAsync("http://212.20.46.249:32777/Receipt/Cancel", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ReceiptEntity>();
                    if (result!.Id > 0)
                    {
                        return result;
                    }
                }
                return new() { Id = -1 };
            }
            catch (Exception ex)
            {
                return new() { Id = -1 };
            }
        }

        private static async void AddReceiptToSecureStorage(GetReceiptByIdRequest request)
        {
            await SecureStorage.SetAsync(SecureStoragePathConst.ReceiptID, request.Id.ToString());
        }
    }
}
