using Appointments.Models.domain;

namespace Appointments.Repositories
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetAllAsync();
        Task<Vehicle> CreateAsync(Vehicle vehicle);
        Task<Vehicle?> GetByIDAsync(int id);
        Task<Vehicle?> UpdateAsync(int id, Vehicle vehicle);
        Task<Vehicle?> DeleteAsync(int id);
    }
}
