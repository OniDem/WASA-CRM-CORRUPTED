using Core.Entity;
using DTO.Receipt;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class ReceiptController : ControllerBase
    {

        private readonly ReceiptService _receiptService;

        public ReceiptController(ReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpPost]
        public async Task<ReceiptEntity> Add([FromBody] AddReceiptRequest request)
        {
            if (ModelState.IsValid)
            {
                var receipt = await _receiptService.Add(request);
                return receipt;
            }
            return null;
        }

        [HttpPut]
        public async Task<ReceiptEntity> Update([FromBody] int id, UpdateReceiptRequest request)
        {
            if(ModelState.IsValid)
            {
                var receipt = await _receiptService.Update(id, request);
                return receipt;
            }
            return null;
        }
    }
}
