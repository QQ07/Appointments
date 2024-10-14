using System;

namespace Appointments.Models.DTOs
{
    public class AppointmentDTO
    {
        public DateTime AppointmentDate { get; set; }
        public required string ServiceType { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
    }
}
