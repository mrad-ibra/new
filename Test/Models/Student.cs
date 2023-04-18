using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad məcburidir")]
        [MaxLength(50,ErrorMessage ="Ad maksimum 50 simvol ola bilər")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad məcburidir")]
        [MaxLength(50, ErrorMessage = "Soyad maksimum 50 simvol ola bilər")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Qrup məcburidir")]
        public int GroupId { get; set; }
        public  Group Group { get; set; }
    }
}
