using Appointments.Models.domain;


namespace Appointments.Models.domain
{
    public class Customer
    {
        public int CustomerId { get; set; }


        public required string FirstName { get; set; }


        public string? LastName { get; set; }


        public required string Email { get; set; }


        public string? PhoneNumber { get; set; }


        public bool? IsDeleted { get; set; }  

        public ICollection<Vehicle>? Vehicles { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
