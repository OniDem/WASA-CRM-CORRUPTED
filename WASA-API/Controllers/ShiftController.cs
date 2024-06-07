using Core.Entity;
using DTO.Shift;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ShiftController : ControllerBase
    {
        private readonly ShiftService _shiftService;

        public ShiftController(ShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpPost]
        public async Task<ShiftEntity?> OpenShift(OpenShiftRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _shiftService.OpenShift(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<ShiftEntity?> CloseShift(CloseShiftRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _shiftService.CloseShift(request);
            }
            return null;
        }

        [HttpPost]
        public async Task<ShiftEntity?> ShowById(ShowByIdRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _shiftService.ShowById(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<ShiftEntity?> AddReceiptToShift(AddReceiptToShiftRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _shiftService.AddReceiptToShift(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<ShiftEntity?> InsertCash(CashOperationRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _shiftService.InsertCash(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<ShiftEntity?> ExtractCash(CashOperationRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _shiftService.ExtractCash(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<ShiftEntity?> AcquiringApprove(AcquiringApproveRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _shiftService.AcquiringApprove(request);
            }
            return null;
        }
    }
}
