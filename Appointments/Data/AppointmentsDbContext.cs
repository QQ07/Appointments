using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.domain;

namespace NZWalks.API.Data
{
    public class AppointmentsDbContext: DbContext
    {
        public AppointmentsDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

            
        }
        public DbSet<Difficulty> Difficulties{ get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

    }
}
