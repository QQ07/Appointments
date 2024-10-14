using Appointments.Data;
using Appointments.Models.domain;

namespace Appointments.Repositories
{
    public class SQLCustomerRepository(AppointmentsDbContext context) : ICustomerRepository
    {
        private readonly AppointmentsDbContext _db = context;
        public Task<Customer> CreateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetByIDAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> UpdateAsync(Guid id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
