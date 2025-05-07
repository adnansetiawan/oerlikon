namespace Oerlikon.BlazorWebApp.Models
{
    public class VehicleViewModel
    {
        public Guid Uid { get; set; }

        public string PlateNo { get; set; }

       
    }
    public class VehicleDetailViewModel : VehicleViewModel
    {
        public string Color { get; set; }

        public string Brand { get; set; }
    }
}
