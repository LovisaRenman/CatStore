using CatStore.Entities;

namespace CatStore.Services
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomer(int id);
        IEnumerable<Customer?> GetCustomerByEmail(string email);
        void NewCustomer(Customer customer);
        Customer? UpdateCustomer(Customer customer);       
    }
}
