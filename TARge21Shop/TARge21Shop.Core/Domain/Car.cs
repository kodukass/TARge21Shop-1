using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARge21Shop.Core.Domain.Car
{
    public class Car
    {
        [Key]
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
