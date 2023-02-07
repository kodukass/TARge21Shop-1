﻿namespace TARge21Shop.Models.Car
{
    public class CarDeleteViewModel
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
        public List<ImageViewModelCar> Image { get; set; } = new List<ImageViewModelCar>();
        //database
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
