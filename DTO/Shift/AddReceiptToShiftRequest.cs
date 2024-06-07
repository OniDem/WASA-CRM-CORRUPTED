namespace DTO.Shift
{
    public class AddReceiptToShiftRequest
    {
        public int Id { get; set; }
        public double Cash { get; set; }

        public double Acquiring { get; set; }

        public double Total { get; set; }

        public int ReceiptId { get; set; }
    }
}
