using Core.Const;

namespace DTO.Receipt
{
    public class AddReceiptRequest
    {
        public List<string> ProductCodes { get; set; }

        public List<double> ProductCounts { get; set; }

        public bool AgeLimitConfirmed { get; set; } = false;

        public PayMethodEnum PayMethod { get; set; }

        public double Total { get; set; }

        public string Seller { get; set; }
    }
}
