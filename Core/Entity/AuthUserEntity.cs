using Core.Const;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    [Table(name: "users")]
    public class AuthUserEntity
    {
        [Key]
        public int Id { get; set; }

        public RoleEnum Role { get; set; }

        public string FIO { get; set; }

        public string Username { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
