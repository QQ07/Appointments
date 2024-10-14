using Appointments.Models.domain;

namespace Appointments.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer?> GetByIDAsync(int id);
        Task<Customer?> UpdateAsync(int id, Customer customer);
        Task<Customer?> DeleteAsync(int id);
    }
}
