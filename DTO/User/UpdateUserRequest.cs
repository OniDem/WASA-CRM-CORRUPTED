namespace DTO.User
{
    public class UpdateUserRequest
    {

        public string FIO { get; set; }

        public string Password { get; set; }

        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
    }
}
