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

        public ReceiptEntity Add(ReceiptEntity entity)
        {
            _applicationContext.Receipts.Add(entity);
            _applicationContext.SaveChanges();
            return entity;
        }

        public ReceiptEntity Update(int id, UpdateReceiptRequest request)
        {
            var receipt = _applicationContext.Receipts.FirstOrDefault(x => x.Id == id);
            receipt.Products = request.Products;
            receipt.PayMethod = request.PayMethod;
            receipt.AgeLimitConfirmed = request.AgeLimitConfirmed;
            receipt.Total = request.Total;
            receipt.Canceled = request.Canceled;
            receipt.Closed = request.Closed;
            receipt.ClosedDate = request.CloseDate;
            receipt.PaymentDate = request.PaymentDate;

            _applicationContext.Receipts.Update(receipt);
            _applicationContext.SaveChanges();
            return receipt;
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
