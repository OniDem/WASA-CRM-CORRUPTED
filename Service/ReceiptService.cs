using Core.Const;
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
            return _receiptRepository.Add(request);
        }

        public async Task<ReceiptEntity> Close(int id)
        {
            return _receiptRepository.Close(id);
        }

        public async Task<ReceiptEntity> Payment(int id, PaymentReceiptRequest request)
        {
            return _receiptRepository.Payment(id, request);
        }

        public async Task<ReceiptEntity> Cancel(int id, CancelReasonEnum cancelReason)
        {
            return _receiptRepository.Cancel(id, cancelReason);
        }

        public async Task<ReceiptEntity> AddProducts(AddProductToReceiptRequest request)
        {
            return _receiptRepository.AddProducts(request);
        }

        public async Task<ReceiptEntity> ShowById(int id)
        {
            return _receiptRepository.ShowById(id);
        }

        public async Task<IEnumerable<ReceiptEntity>> ShowCreatedByDate(DateTime date)
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
