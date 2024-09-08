using Core.Const;
using Core.Entity;
using DTO.Receipt;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace WASA_Desktop.Service
{
    public static class ReceiptService
    {
        public async static Task<ReceiptEntity> AddReceipt(AddReceiptRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("https://onidem-wasa-api-c94a.twc1.net/Receipt/Add", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadFromJsonAsync<ReceiptEntity>();
                    if (result!.Id > 0)
                    {
                        //AddReceiptToSecureStorage(new() { Id = result.Id });
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
                var response = await httpClient.PostAsync("https://onidem-wasa-api-c94a.twc1.net/Receipt/ShowById", content);
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
                var response = await httpClient.PutAsync("https://onidem-wasa-api-c94a.twc1.net/Receipt/AddProducts", content);
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
                var response = await httpClient.PutAsync("https://onidem-wasa-api-c94a.twc1.net/Receipt/Payment", content);
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
                var response = await httpClient.PutAsync("https://onidem-wasa-api-c94a.twc1.net/Receipt/Close", content);
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
                var response = await httpClient.PutAsync("https://onidem-wasa-api-c94a.twc1.net/Receipt/Cancel", content);
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
    }
}
