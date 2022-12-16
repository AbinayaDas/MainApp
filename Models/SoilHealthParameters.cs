using System.ComponentModel.DataAnnotations;

namespace MainApp.Models
{
    public class SoilHealthParameters
    {
        [Key]
        public int SoilId { get; set; }
        public string SoilName { get; set; }
        public decimal pH { get; set; }
        public decimal EC { get; set; }
        public decimal OC { get; set; }
        public decimal OM { get; set; }
        public decimal N { get; set; }
        public decimal P { get; set; }
        public decimal K { get; set; }
        public decimal Zn { get; set; }
        public decimal Fe { get; set; }
        public decimal Cu { get; set; }
        public decimal Mn { get; set; }
        public decimal CaCO3 { get; set; }
        public SoilNature? SoilNature { get; set; }
        public int UserId { get; set; }


    }
}
