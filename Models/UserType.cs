using System.ComponentModel.DataAnnotations;

namespace MainApp.Models
{
    public class UserTypes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserType { get; set; }
    }
}
