using Core.Entity;

namespace WASA_Mobile.Service
{
    public static class ProductService
    {
        public static async Task<ProductEntity?> SearchProduct(string productCode)
        {
            //Some code to search product in database by productCode
            if (productCode != null)
                return new() { ProductCode = productCode, Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 };
            else
                return null;
        }

        public static async Task<List<ProductEntity>> GetAllProducts()
        {
            return new()
            {
                new() { ProductCode = "123456789", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "234567891", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "345678912", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "456789123", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "123456789", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "234567891", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "345678912", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "456789123", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "123456789", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "234567891", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "345678912", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "456789123", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "123456789", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "234567891", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "345678912", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "456789123", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "123456789", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "234567891", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 },
                new() { ProductCode = "345678912", Category = Core.Const.CategoryEnum.Cable, ProductName = "Кабель Sky Dolphin S59T Type-C 1M магнитный чёрный", Price = 350, Count = 15 }
            };
        }
    }
}
