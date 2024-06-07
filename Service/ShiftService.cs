using Core.Entity;
using DTO.Shift;
using Infrastructure.Repositories;

namespace Services
{
    public class ShiftService
    {
        private readonly ShiftRepository _shiftRepository;

        public ShiftService(ShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        public async Task<ShiftEntity> OpenShift(OpenShiftRequest request)
        {
            return _shiftRepository.OpenShift(request);
        }

        public async Task<ShiftEntity> CloseShift(CloseShiftRequest request)
        {
            return _shiftRepository.CloseShift(request);
        }

        public async Task<ShiftEntity> AddReceiptToShift(AddReceiptToShiftRequest request)
        {
            return _shiftRepository.AddReceiptToShift(request);
        }

        public async Task<ShiftEntity> InsertCash(CashOperationRequest request)
        {
            return _shiftRepository.InsertCash(request);
        }

        public async Task<ShiftEntity> ExtractCash(CashOperationRequest request)
        {
            return _shiftRepository.ExtractCash(request);
        }

        public async Task<ShiftEntity> AcquiringApprove(AcquiringApproveRequest request)
        {
            return _shiftRepository.AcquiringApprove(request);
        }
    }
}
