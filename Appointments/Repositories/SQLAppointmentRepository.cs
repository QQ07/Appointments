using Appointments.Data;
using Appointments.Models.domain;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Repositories
{
    public class SQLAppointmentRepository(AppointmentsDbContext context) : IAppointmentRepository
    {
        private readonly AppointmentsDbContext _db = context;
        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            await _db.Appointments.AddAsync(appointment);
            await _db.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment?> DeleteAsync(int id)
        {
            var existingAppointment = await _db.Appointments.FindAsync(id);
            if (existingAppointment == null)
            {
                return null;
            }
            existingAppointment.IsDeleted = true;
            return existingAppointment;
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _db.Appointments.ToListAsync();
        }

        public async Task<Appointment?> GetByIDAsync(int id)
        {
            return await _db.Appointments.FirstOrDefaultAsync(x => x.AppointmentId == id);
        }

        public async Task<Appointment?> UpdateAsync(int id, Appointment appointment)
        {
            var existingAppointment = await _db.Appointments.FirstOrDefaultAsync(x => x.AppointmentId == id);
            if (existingAppointment == null) { return null; }
            existingAppointment.AppointmentDate = appointment.AppointmentDate;
            await _db.SaveChangesAsync();
            return existingAppointment;
        }
    }
}
