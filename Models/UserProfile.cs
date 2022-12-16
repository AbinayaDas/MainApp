using Microsoft.SqlServer.Server;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MainApp.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string Name { get; set; }
        public int Age { get; set; }
        public string EmailId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public string State { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public decimal LandSize { get; set; }
        public DateTime? RecordCreatedOn { get; set; }
        //public string UserType { get; set; } 
        


    }
}
