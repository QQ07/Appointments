using Appointments.Models.domain;

namespace Appointments.Models.domain
{

    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public required string ServiceType { get; set; }

        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public bool? IsDeleted { get; set; } 

        public int VehicleId { get; set; }

        public  Vehicle? Vehicle { get; set; }

    }
}
