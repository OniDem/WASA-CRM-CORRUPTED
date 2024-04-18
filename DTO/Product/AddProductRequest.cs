using Core.Const;

namespace DTO.Product
{
    public class AddProductRequest
    {
        public string ProductCode { get; set; }

        public CategoryEnum Category { get; set; }

        public string ProductName { get; set; }

        public double? Price { get; set; }

        public double? Count { get; set; }

        public bool AgeLimit {  get; set; } = false;

        public DateTime? ExpirationDate { get; set; }
    }
}
