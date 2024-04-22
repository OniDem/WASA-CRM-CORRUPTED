using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table(name: "loyaltyCards")]
    public class LoyaltyCardEntity
    {
        [Key]
        public int Id { get; set; } 

        public string HolderName { get; set; }

        public double Balance { get; set; }

        public List<int>? ReceiptIDs { get; set; }

        public List<double>? BonusHistory { get; set; }
    }
}
