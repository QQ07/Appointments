using Appointments.Data;
using Appointments.Models.domain;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Repositories
{
    public class SQLVehicleRepository(AppointmentsDbContext context) : IVehicleRepository
    {
        private readonly AppointmentsDbContext _db = context;
        public async Task<Vehicle> CreateAsync(Vehicle vehicle)
        {
            await _db.Vehicles.AddAsync(vehicle);
            await _db.SaveChangesAsync();
            return vehicle;
        }


        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _db.Vehicles.ToListAsync();
        }

        public async Task<Vehicle?> GetByIDAsync(int id)
        {
            return await _db.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == id);
        }

        public async Task<Vehicle?> UpdateAsync(int id, Vehicle vehicle)
        {
            var existingVehicle = await _db.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == id);
            if (existingVehicle == null) { return null; }
            existingVehicle.Make = vehicle.Make;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.Year = vehicle.Year;
            existingVehicle.VIN = vehicle.VIN;
            existingVehicle.CustomerId = vehicle.CustomerId;
            await _db.SaveChangesAsync();
            return existingVehicle;
        }

        public async Task<Vehicle?> DeleteAsync(int id)
        {
            var existingVehicle = await _db.Vehicles.FindAsync(id);
            if (existingVehicle == null)
            {
                return null;
            }
            existingVehicle.IsDeleted = true;
            return existingVehicle;
        }
    }
}
