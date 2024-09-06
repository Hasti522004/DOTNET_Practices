using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo.Model
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

    }
}
