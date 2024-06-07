namespace DTO.Shift
{
    public class OpenShiftRequest
    {
        public string OpenBy { get; set; }

        public DateTime OpenDate { get; set; } = DateTime.UtcNow;

        public double? Cash { get; set; } = 0.0;

        public double? CashBox { get; set; }

        public double? Acquiring { get; set; } = 0.0;

        public double? Total { get; set; } = 0.0;
    }
}
