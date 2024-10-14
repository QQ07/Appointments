using Appointments.Models.domain;

namespace Appointments.Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllAsync();
        Task<Appointment> CreateAsync(Appointment appointment);
        Task<Appointment?> GetByIDAsync(int id);
        Task<Appointment?> UpdateAsync(int id, Appointment appointment);
        Task<Appointment?> DeleteAsync(int id);
    }
}
