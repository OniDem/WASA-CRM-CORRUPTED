using Core.Const;

namespace DTO.Receipt
{
    public class AddReceiptRequest
    {
        public List<string>? Products { get; set; }

        public PayMethodEnum PayMethod { get; set; }

        public double Total { get; set; }

        public string Seller { get; set; }
    }
}
