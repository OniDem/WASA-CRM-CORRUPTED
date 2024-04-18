using Core.Const;

namespace DTO.User
{
    public class RegUserRequest
    {
        public RoleEnum Role { get; set; } = RoleEnum.Seller;

        public string FIO { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime LastModifiedDate { get; set; } = DateTime.Now;

    }
}
