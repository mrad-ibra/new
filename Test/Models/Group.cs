using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}
