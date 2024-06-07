using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table(name: "shifts")]
    public class ShiftEntity
    {
        [Key]
        public int Id { get; set; }

        public bool? Closed { get; set; }

        public string OpenBy { get; set; }

        public string? ClosedBy { get; set; }

        public DateTime OpenDate { get; set; } = DateTime.UtcNow;

        public DateTime? CloseDate {  get; set; }

        public double? Cash { get; set; }

        public double? CashBox { get; set; }

        public List<string>? CashBoxOperations { get; set; }

        public double? Acquiring { get; set; }

        public bool? AcquiringApproved { get; set; }

        public double? Total { get; set; }

        public List<int>? ReceiptsList { get; set; } 
    }
}
