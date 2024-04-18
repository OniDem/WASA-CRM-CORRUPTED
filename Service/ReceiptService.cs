using Core.Entity;
using DTO.Receipt;
using Infrastructure.Repositories;

namespace Services
{
    public class ReceiptService
    {
        private readonly ReceiptRepository _receiptRepository;

        public ReceiptService(ReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<ReceiptEntity> Add(AddReceiptRequest request)
        {
            return _receiptRepository.Add(new()
            {
                Products = request.Products,
                PayMethod = request.PayMethod,
                AgeLimitConfirmed = request.AgeLimitConfirmed,
                Total = request.Total,
                Canceled = request.Canceled,
                Closed = request.Closed,
                CreationDate = request.CreationDate
            });
        }

        public async Task<ReceiptEntity> Update(int id, UpdateReceiptRequest request)
        {
            return _receiptRepository.Update(id, request);
        }

        public async Task<ReceiptEntity> ShowById(int id)
        {
            return _receiptRepository.ShowById(id);
        }

        public async Task<List<ReceiptEntity>> ShowCreatedByDate(DateTime date)
        {
            return _receiptRepository.ShowCreatedByDate(date);
        }

        public async Task<List<ReceiptEntity>> ShowClosedByDate(DateTime date)
        {
            return _receiptRepository.ShowClosedByDate(date);
        }

        public async Task<List<ReceiptEntity>> ShowPaymentByDate(DateTime date)
        {
            return _receiptRepository.ShowPaymentByDate(date);
        }
    }
}
