using Core.Const;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table(name:"receipts")]
    public class ReceiptEntity
    {
        [Key]
        public int Id { get; set; }

        public int? LoyaltyCardID { get; set; }

        public double? LoyaltyBonusAdded { get; set; }

        public List<string>? Products { get; set; }

        public PayMethodEnum? PayMethod { get; set; }

        public bool AgeLimitConfirmed { get; set; }

        public double Total { get; set; }

        public bool Canceled { get; set; }

        public CancelReasonEnum CancelReason { get; set; }

        public bool Closed { get; set; }

        public string Seller {  get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime CancelDate { get; set; }

        public DateTime ClosedDate { get; set; }

        public DateTime PaymentDate { get; set; }

    }
}
