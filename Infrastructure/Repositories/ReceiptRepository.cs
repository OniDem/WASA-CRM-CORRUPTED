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
                Products = request.Products,
                PayMethod = request.PayMethod,
                AgeLimitConfirmed = false,
                Total = request.Total,
                Canceled = false,
                Closed = false,
                CreationDate = DateTime.UtcNow,
                Seller = request.Seller
            };
            _applicationContext.Receipts.Add(entity);
            _applicationContext.SaveChanges();
            return entity;
        }

        public ReceiptEntity Close(int id)
        {
            var receipt = ShowById(id);
            if (!receipt.Closed)
            {
                receipt.ClosedDate = DateTime.UtcNow;
                receipt.Closed = true;
                _applicationContext.Receipts.Update(receipt);
                _applicationContext.SaveChanges();
                return receipt;
            }
                return null;
            
        }

        public ReceiptEntity Payment(int id, PaymentReceiptRequest request)
        {
            var receipt = ShowById(id);
            if(!receipt.Closed)
            {
                receipt.PayMethod = request.PayMethod;
                receipt.Total = request.Total;
                receipt.PaymentDate = DateTime.UtcNow;

                _applicationContext.Receipts.Update(receipt);
                _applicationContext.SaveChanges();
                return receipt;
            }
            return null;
        }

        public ReceiptEntity Cancel(int id, CancelReasonEnum cancelReason)
        {
            var receipt = ShowById(id);
            receipt.CancelReason = cancelReason;
            receipt.Canceled = true;
            receipt.CancelDate = DateTime.UtcNow;

            _applicationContext.Receipts.Update(receipt);
            _applicationContext.SaveChanges();
            return receipt;
        }

        public ReceiptEntity AgeConfirm(int id)
        {
            var receipt = ShowById(id);
            receipt.AgeLimitConfirmed = true;

            _applicationContext.Receipts.Update(receipt);
            _applicationContext.SaveChanges();
            return receipt;
        }

        public ReceiptEntity AddProducts(int id, List<string> products)
        {
            var receipt = ShowById(id);
            if(!receipt.Closed || !receipt.Canceled)
            {
                foreach (var product in products)
                {
                    receipt.Products.Add(product);
                }
                _applicationContext.Receipts.Update(receipt);
                _applicationContext.SaveChanges();
                return receipt;
            }
            return null;
        }

        public ReceiptEntity ShowById(int id)
        {
            return _applicationContext.Receipts.FirstOrDefault(x => x.Id == id);
        }

        public List<ReceiptEntity> ShowCreatedByDate(DateTime date)
        {
            var receipts = _applicationContext.Receipts.ToList();
            List<ReceiptEntity> listToReturn = new();
            foreach(var receipt in receipts)
            {
                if(receipt.CreationDate.Date == date.Date)
                    listToReturn.Add(receipt);
            }
            return listToReturn;
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
    }
}
