namespace TARge21Shop.Models.Car
{
    public class CarEditViewModel
    {
        public Guid? Id { get; set; }
        public string Mark { get; set; }
        public string Type { get; set; }
        public int Passangers { get; set; }
        public int CargoSpace { get; set; }
        public int MaintenanceCount { get; set; }
        public DateTime LastMaintenance { get; set; }
        public int EnginePower { get; set; }
        public DateTime BuiltDate { get; set; }
        //database
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
