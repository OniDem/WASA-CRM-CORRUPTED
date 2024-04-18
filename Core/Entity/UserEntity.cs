using Core.Const;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table(name: "users")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        public RoleEnum Role { get; set; }

        public string FIO { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastModifiedDate { get; set;}

        public string? Token { get; set; }
    }
}
