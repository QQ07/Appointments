namespace Appointments.Models.DTOs
{ 
    public class VehicleDTO
    {
        public required string Make { get; set; }
        public required string Model { get; set; }
        public required int Year { get; set; }
        public required string VIN { get; set; }
        public required int CustomerId { get; set; }
    }
}
