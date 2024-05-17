using Core.Const;
using Core.Entity;
using DTO.Product;
using Infrastructure.Repositories;

namespace Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductEntity?> AddProduct(AddProductRequest request)
        {
            return _productRepository.Add(new()
            {
                ProductCode = request.ProductCode,
                Category = request.Category,
                ProductName = request.ProductName,
                Price = request.Price,
                Count = request.Count,
            });
        }

        public async Task<ProductEntity> UpdateProduct(string productCode, UpdateProductRequest request)
        {
            return _productRepository.Update(productCode, request);
        }

        public async Task<ProductEntity> ShowByProductCode(string productCode)
        {
            return _productRepository.ShowByProductCode(productCode);
        }

        public async Task<List<ProductEntity>> ShowAll()
        {
            return _productRepository.ShowAll();
        }

        public async Task<List<ProductEntity>> ShowAllByCategory(CategoryEnum category)
        {
            return _productRepository.ShowAllByCategory(category);
        }

        public void Delete(string productCode)
        {
            _productRepository.Delete(productCode);
        }
    }
}
