using Core.Const;

namespace DTO.Receipt
{
    public class PaymentReceiptRequest
    {
        public PayMethodEnum PayMethod { get; set; }

        public double Total {  get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
