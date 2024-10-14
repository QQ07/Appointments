using Appointments.Models.domain;
using System.Text.Json.Serialization;

namespace Appointments.Models.domain
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public required string Make { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
        public required string VIN { get; set; }
        public bool? IsDeleted { get; set; } 
        public int CustomerId { get; set; }
        [JsonIgnore]
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
