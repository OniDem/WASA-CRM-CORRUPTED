using Core.Const;

namespace DTO.User
{
    public  class GrantAccessUserRequest
    {
        public string Username { get; set; }

        public RoleEnum Role { get; set; }
    }
}
