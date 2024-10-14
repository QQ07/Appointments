namespace Appointments.Models.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }


        public required string FirstName { get; set; }


        public string? LastName { get; set; }


        public required string Email { get; set; }


        public string? PhoneNumber { get; set; }
    }
}
