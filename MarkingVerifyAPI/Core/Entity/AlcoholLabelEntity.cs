using MarkingVerifyAPI.Core.Const;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarkingVerifyAPI.Core.Entity
{
    [Table(name: "alcohollabels")]
    public class AlcoholLabelEntity
    {
        [Key]
        public string Label { get; set; }

        public AlcoholCodeEnum AlcoholCode { get; set; }

        public string Name { get; set; }

        public double Volume { get; set; }

        public double Price { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
