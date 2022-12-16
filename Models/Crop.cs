namespace MainApp.Models
{
    public class Crop
    {
        public int CropId { get; set; }
        public string CropName { get; set; }
        public decimal CropValue { get; set; }
        public CropType CropType { get; set; }
        public decimal MinReqLandSize { get; set; }
        public decimal MaxReqLandSize { get; set; }
        public decimal ReqSoilPh { get; set; }
        public WeatherType PreferredWeatherCondition { get; set; }

    }
}
