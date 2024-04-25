using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarkingVerifyAPI.Core.Entity
{
    [Table(name: "cigarettelabels")]
    public class CigaretteLabelEntity
    {
        [Key]
        public string Label { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
