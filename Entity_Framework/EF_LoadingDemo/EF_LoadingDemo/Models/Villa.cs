using System.ComponentModel.DataAnnotations;

namespace EF_LoadingDemo.Models
{
    public class Villa
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public double price { get; set; }
        
        public ICollection<VillaEminity> eminity { get; set; }
    }
}
