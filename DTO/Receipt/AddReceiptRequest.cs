using Core.Const;

namespace DTO.Receipt
{
    public class AddReceiptRequest
    {
        public List<string> Products { get; set; }

        public PayMethodEnum PayMethod { get; set; }

        public bool AgeLimitConfirmed { get; set; }

        public double Total { get; set; }

        public bool Canceled { get; set; } = false;

        public bool Closed { get; set; } = true;

        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
