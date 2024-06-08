using Core.Const;
using Core.Entity;
using DTO.Receipt;
using DTO.User;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReceiptController : ControllerBase
    {

        private readonly ReceiptService _receiptService;

        public ReceiptController(ReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpPost]
        public async Task<ReceiptEntity?> Add(AddReceiptRequest request)
        {
            if (ModelState.IsValid)
            {
                var receipt = await _receiptService.Add(request);
                return receipt;
            }
            return null;
        }

        [HttpPut]
        public async Task<ReceiptEntity?> Close([FromBody] int id)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.Close(id);
            }
            return null;
        }

        [HttpPut]
        public async Task<ReceiptEntity?> Payment(int id, PaymentReceiptRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.Payment(id, request);
            }
            return null;
        }

        [HttpPut]
        public async Task<ReceiptEntity?> Cancel(int id, CancelReasonEnum cancelReason)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.Cancel(id, cancelReason);
            }
            return null;
        }

        [HttpPut]
        public async Task<ReceiptEntity?> AddProducts(AddProductToReceiptRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.AddProducts(request);
            }
            return null;
        }

        [HttpPost]
        public async Task<ReceiptEntity?> ShowById([FromBody] GetReceiptByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.ShowById(request.Id);
            }
            return null;    
        }

        [HttpPost]
        public async Task<List<ReceiptEntity>?> ShowCreatedByDate([FromBody] DateTime date)
        {
            if (ModelState.IsValid)
            {
                return (List<ReceiptEntity>?)await _receiptService.ShowCreatedByDate(date);
            }
            return null;
        }

        [HttpPost]
        public async Task<List<ReceiptEntity>?> ShowClosedByDate([FromBody] DateTime date)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.ShowClosedByDate(date);
            }
            return null;
        }

        [HttpPost]
        public async Task<List<ReceiptEntity>?> ShowPaymentByDate([FromBody] DateTime date)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.ShowPaymentByDate(date);
            }
            return null;
        }
    }
}
