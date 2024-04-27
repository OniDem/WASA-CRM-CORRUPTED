using Core.Const;

namespace DTO.Receipt
{
    public class AddProductToReceiptRequest
    {
        public int Id { get; set; }

       public List<string?> ProductCodes { get; set; }

        public List<double> ProductCounts { get; set; }
    }
}
