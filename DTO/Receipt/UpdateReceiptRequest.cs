using Core.Const;

namespace DTO.Receipt
{
    public class UpdateReceiptRequest
    {
        public List<string> Products { get; set; }
        public PayMethodEnum? PayMethod { get; set; }

        public double Total { get; set; }

        public bool Canceled { get; set; }

        public bool Closed { get; set; }

        public DateTime CloseDate { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
