using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_LoadingDemo.Models
{
    public class VillaEminity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Villa")]
        public int VillaId { get; set; }
        public Villa Villa { get; set; }
        public required string name { get; set; }

    }
}
