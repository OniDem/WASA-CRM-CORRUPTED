using Core.Entity;
using DTO.Shift;

namespace Infrastructure.Repositories
{
    public class ShiftRepository
    {
        private ApplicationContext _applicationContext;

        public ShiftRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public ShiftEntity OpenShift(OpenShiftRequest request)
        {
            ShiftEntity shiftEntity = new()
            {
                Closed = false,
                OpenBy = request.OpenBy,
                OpenDate = request.OpenDate,
                Cash = request.Cash,
                CashBox = request.CashBox,
                Acquiring = request.Acquiring,
                AcquiringApproved = false,
                Total = request.Total
            };
            _applicationContext.Shifts.Add(shiftEntity);
            _applicationContext.SaveChanges();
            return shiftEntity;
        }

        public ShiftEntity CloseShift(CloseShiftRequest request)
        {
            ShiftEntity shiftEntity = ShowById(new() { Id = request.Id });
            shiftEntity.Closed = true;
            shiftEntity.ClosedBy = request.ClosedBy;
            shiftEntity.CloseDate = DateTime.UtcNow;
            _applicationContext.Shifts.Update(shiftEntity);
            _applicationContext.SaveChanges();
            return shiftEntity;
        }

        public ShiftEntity ShowById(ShowByIdRequest request)
        {
            return _applicationContext.Shifts.FirstOrDefault(x => x.Id == request.Id)!;
        }

        public ShiftEntity AddReceiptToShift(AddReceiptToShiftRequest request)
        {
            ShiftEntity shiftEntity = ShowById(new() { Id = request.Id });
            if (shiftEntity == null)
                return null;
            if (shiftEntity.Closed == false)
            {
                shiftEntity.Cash += request.Cash;
                if (request.Cash > 0)
                {
                    shiftEntity = InsertCash(new() { CashAmount = request.Cash }, shiftEntity);
                }
                shiftEntity.Acquiring += request.Acquiring;
                shiftEntity.Total = shiftEntity.Cash + shiftEntity.Acquiring;
                if (shiftEntity.ReceiptsList == null)
                    shiftEntity.ReceiptsList = [request.ReceiptId];
                else
                    shiftEntity.ReceiptsList.Add(request.ReceiptId);
                _applicationContext.Update(shiftEntity);
                _applicationContext.SaveChanges();
                return shiftEntity;
            }
            else
                return null;
        }
        private ShiftEntity InsertCash(CashOperationRequest request, ShiftEntity shiftEntity)
        {
            if (shiftEntity.CashBoxOperations == null)
                shiftEntity.CashBoxOperations = ["+" + request.CashAmount];
            else
                shiftEntity.CashBoxOperations.Add("+" + request.CashAmount);
            shiftEntity.CashBox += request.CashAmount;
            return shiftEntity;
        }

        public ShiftEntity InsertCash(CashOperationRequest request)
        {
            ShiftEntity shiftEntity = ShowById(new() { Id = request.Id });
            if (shiftEntity == null)
                return null;
            if (shiftEntity.Closed == false)
            {
                _applicationContext.Shifts.Update(InsertCash(request, shiftEntity));
                _applicationContext.SaveChanges();
                return shiftEntity;
            }
            return null;
        }

        public ShiftEntity ExtractCash(CashOperationRequest request)
        {
            ShiftEntity shiftEntity = ShowById(new() { Id = request.Id });
            if (shiftEntity == null)
                return null;
            if (shiftEntity.Closed == false)
            {
                if (shiftEntity.CashBoxOperations == null)
                    shiftEntity.CashBoxOperations = ["-" + request.CashAmount];
                else
                    shiftEntity.CashBoxOperations.Add("-" + request.CashAmount);
                shiftEntity.CashBox -= request.CashAmount;
                _applicationContext.Shifts.Update(shiftEntity);
                _applicationContext.SaveChanges();
                return shiftEntity;
            }
            return null;
        }
        
        public ShiftEntity AcquiringApprove(AcquiringApproveRequest request)
        {
            ShiftEntity shiftEntity = ShowById(new() { Id = request.Id });
            if (shiftEntity == null)
                return null;
            if ( shiftEntity.Closed == false)
            {
                shiftEntity.AcquiringApproved = true;
                _applicationContext.Shifts.Update(shiftEntity);
                _applicationContext.SaveChanges();
                return shiftEntity;
            }
            return null;
        }
    }
}
