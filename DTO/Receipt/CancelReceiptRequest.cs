using Core.Const;

namespace DTO.Receipt
{
    public class CancelReceiptRequest
    {
        public int Id { get; set; }

        public CancelReasonEnum CancelReason { get; set; }
    }
}
