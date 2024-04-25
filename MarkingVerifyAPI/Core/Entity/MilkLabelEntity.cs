using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarkingVerifyAPI.Core.Entity
{
    [Table(name: "milklabels")]
    public class MilkLabelEntity
    {
        [Key]
        public string Label { get; set; }

        public string Name { get; set; }    

        public double Volume { get; set; }

        public DateTime ManufactureDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int  HoursToExpiration { get; set; }

        public double Price {  get; set; }
    }
}
