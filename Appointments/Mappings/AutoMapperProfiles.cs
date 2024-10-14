using AutoMapper;
using Appointments.Models.domain;
using Appointments.Models.DTOs;

namespace Appointments.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() {
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();  
            CreateMap<Customer, CustomerDTO>().ReverseMap();  
        }
    }
}
