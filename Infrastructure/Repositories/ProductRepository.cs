using Core.Const;
using Core.Entity;
using DTO.Product;

namespace Infrastructure.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationContext _applicationContext;

        public ProductRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public ProductEntity Add(ProductEntity product)
        {
            _applicationContext.Products.Add(product);
            _applicationContext.SaveChanges();
            return product;
        }

        public ProductEntity Update(string productCode, UpdateProductRequest request)
        {
            var product = ShowByProductCode(productCode);
            product.ProductName = request.ProductName;
            product.Price = request.Price;
            product.Count = request.Count;

            _applicationContext.Products.Update(product);
            _applicationContext.SaveChanges();
            return product;
        }

        public ProductEntity ShowByProductCode(string productCode)
        {
            return _applicationContext.Products.FirstOrDefault(x => x.ProductCode == productCode);
        }

        public List<ProductEntity> ShowAll()
        {
            return _applicationContext.Products.ToList();
        }

        public List<ProductEntity> ShowAllByCategory(CategoryEnum category)
        {
            List<ProductEntity> listToReturn = new();
            var products = _applicationContext.Products.ToList();
            foreach (var product in products)
            {
                if(product.Category == category)
                    listToReturn.Add(product);
            }
            return listToReturn;
        }

        public void Delete(string  productCode)
        {
            _applicationContext.Products.Remove(ShowByProductCode(productCode));
            _applicationContext.SaveChanges();
        }
    }
}
