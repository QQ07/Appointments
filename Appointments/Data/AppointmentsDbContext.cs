using Microsoft.EntityFrameworkCore;
using Appointments.Models.domain;

namespace Appointments.Data
{
    public class AppointmentsDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Appointment> Appointments{ get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
