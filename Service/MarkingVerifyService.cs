using Core.Const;
using System.Net.Http.Json;

namespace WASA_API.Service
{
    public static class MarkingVerifyService
    {
        /// <summary>
        /// Function to check unique product label for alcohol/cigarette/milk in MarkingVerifyAPI
        /// </summary>
        /// <param name="label">Input a string with label or productCode</param>
        /// <param name="category">Input a product category(alcohol = 0, cigarette = 1, milk = 2)</param>
        /// <returns>Return a boolean; true - if product exist/can be sold/not expired; false - if product don`t exist/already sold/expired</returns>
        public static async Task<bool> VerifyProductWithLabel(string label, CategoryEnum category)
        {
            JsonContent content = JsonContent.Create("");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = new();
            switch (category)
            {
                case CategoryEnum.Alcohol:
                    response = await httpClient.PostAsync($"http://localhost:5200/AlcoholLabel/VerifyLabel?label={label}", content);
                    break;
                case CategoryEnum.Cigarette:
                    response = await httpClient.PostAsync($"http://localhost:5200/CigaretteLabel/VerifyLabel?label={label}", content);
                    break;
                case CategoryEnum.Milk:
                    response = await httpClient.PostAsync($"http://localhost:5200/MilkLabel/VerifyLabel?label={label}", content);
                    break;
            }
            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
