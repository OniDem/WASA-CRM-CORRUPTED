using Core.Const;
using Core.Entity;
using DTO.Receipt;

namespace Infrastructure.Repositories
{
    public class ReceiptRepository
    {
        private ApplicationContext _applicationContext;

        public ReceiptRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public ReceiptEntity Add(AddReceiptRequest request)
        {
            ReceiptEntity entity = new()
            {
                PayMethod = request.PayMethod,
                Canceled = false,
                Closed = false,
                CreationDate = DateTime.UtcNow,
                Seller = request.Seller,
                ProductCodes = [],
                ProductCategories = [],
                ProductNames = [],
                ProductPrices = [],
                ProductCount = []
            };
            _applicationContext.Receipts.Add(AddProductToEntity(entity, request.ProductCodes!, request.ProductCounts));
            _applicationContext.SaveChanges();
            return entity;
        }

        public ReceiptEntity Close(GetReceiptByIdRequest request)
        {
            var receipt = ShowById(request.Id);
            if (!receipt!.Closed)
            {
                receipt.ClosedDate = DateTime.UtcNow;
                receipt.Closed = true;
                _applicationContext.Receipts.Update(receipt);
                _applicationContext.SaveChanges();
                return receipt;
            }
                return null!;
            
        }

        public ReceiptEntity Payment(PaymentReceiptRequest request)
        {
            var receipt = ShowById(request.Id);
            if(!receipt!.Closed)
            {
                receipt.PayMethod = request.PayMethod;
                receipt.Total = request.Total;
                receipt.PaymentDate = DateTime.UtcNow;

                _applicationContext.Receipts.Update(receipt);
                _applicationContext.SaveChanges();
                return receipt;
            }
            return null!;
        }

        public ReceiptEntity Cancel(CancelReceiptRequest request)
        {
            var receipt = ShowById(request.Id);
            receipt!.CancelReason = request.CancelReason;
            receipt.Canceled = true;
            receipt.CancelDate = DateTime.UtcNow;

            _applicationContext.Receipts.Update(receipt);
            _applicationContext.SaveChanges();
            return receipt;
        }

        public ReceiptEntity AddProducts(AddProductToReceiptRequest request)
        {
            var receipt = ShowById(request.Id);
            
            if(receipt != null)
            {
                if (!receipt!.Closed || !receipt.Canceled)
                {
                    _applicationContext.Receipts.Update(AddProductToEntity(receipt, request.ProductCodes!, request.ProductCounts));
                    _applicationContext.SaveChanges();
                    return receipt;
                }
            }
            return null!;
        }

        public ReceiptEntity? ShowById(int id)
        {
            return _applicationContext.Receipts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ReceiptEntity> ShowCreatedByDate(DateTime date)
        {
            var receipts = _applicationContext.Receipts.ToList();
            foreach(var receipt in receipts)
            {
                if (receipt.CreationDate.Date == date.Date)
                    yield return receipt;
            }
        }

        public List<ReceiptEntity> ShowClosedByDate(DateTime date)
        {
            var receipts = _applicationContext.Receipts.ToList();
            List<ReceiptEntity> listToReturn = new();
            foreach (var receipt in receipts)
            {
                if (receipt.ClosedDate.Date == date.Date)
                    listToReturn.Add(receipt);
            }
            return listToReturn;
        }

        public List<ReceiptEntity> ShowPaymentByDate(DateTime date)
        {
            var receipts = _applicationContext.Receipts.ToList();
            List<ReceiptEntity> listToReturn = new();
            foreach (var receipt in receipts)
            {
                if (receipt.PaymentDate.Date == date.Date)
                    listToReturn.Add(receipt);
            }
            return listToReturn;
        }

        private ReceiptEntity AddProductToEntity(ReceiptEntity receipt, List<string> productCodes, List<double> productCounts)
        {
            for (int i = 0; i < productCodes.Count; i++)
            {
                var product = _applicationContext.Products.FirstOrDefault(x => x.ProductCode == productCodes[i]);
                if (product != null)
                {
                    if (receipt.ProductCodes!.Count > 0)
                    {
                        foreach (var productCode in receipt.ProductCodes.ToList())
                        {

                            if(receipt.ProductCodes.Contains(productCodes[i]))
                            {
                                if (productCode == productCodes[i])
                                {
                                    int index = receipt.ProductCodes.IndexOf(productCode);
                                    receipt.ProductCount![index] += productCounts[i];
                                    receipt.Total += product.Price * productCounts[i];
                                }
                            }
                            else
                            {
                                receipt.ProductCodes!.Add(product.ProductCode);
                                receipt.ProductCategories!.Add(product.Category);
                                receipt.ProductNames!.Add(product.ProductName);
                                receipt.ProductPrices!.Add(product.Price);
                                receipt.ProductCount!.Add(productCounts[i]);
                                receipt.Total += product.Price * productCounts[i];
                            }
                                
                        }
                        return receipt;
                    }
                    else
                    {
                        receipt.ProductCodes!.Add(product.ProductCode);
                        receipt.ProductCategories!.Add(product.Category);
                        receipt.ProductNames!.Add(product.ProductName);
                        receipt.ProductPrices!.Add(product.Price);
                        receipt.ProductCount!.Add(productCounts[i]);
                        receipt.Total += product.Price * productCounts[i];
                    }
                }
            }
            return receipt;
        }

        private bool IsNotUniqueCode(ReceiptEntity receipt, List<string> productCodes)
        {
            foreach(var productCode in productCodes)
            {
                if (receipt.ProductCodes!.Contains(productCode))
                    return true;
            }
            return false;
        }
    }
}
