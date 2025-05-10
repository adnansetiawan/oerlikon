namespace Oerlikon.BlazorWebApp.Models
{
    public class VehicleViewModel
    {
        public Guid Uid { get; set; }

        public string PlateNo { get; set; }

        public string Brand { get; set; }


    }
    public class VehicleDetailViewModel : VehicleViewModel
    {
        public string Color { get; set; }

        
    }

    public class SubmitVehicleViewModel
    {
        public Guid? Uid { get; set; }
        public string PlateNo { get; set; }
        public string Brand { get; set; }

        public string Color { get; set; }
    }
}
