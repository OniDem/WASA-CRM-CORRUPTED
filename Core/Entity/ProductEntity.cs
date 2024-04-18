using Core.Const;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table(name: "products")]
    public class ProductEntity
    {
        [Key]
        public string ProductCode { get; set; }

        public CategoryEnum Category { get; set; }

        public string ProductName { get; set; }

        public double? Price { get; set; }

        public double? Count { get; set; }

        public bool AgeLimit { get; set; } = false;

        public DateTime? ExpirationDate { get; set; }
    }
}
