using CatStore.Entities;

namespace CatStore.Services
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomer(int id);
        IEnumerable<Customer?> GetCustomerByEmail(string email);
        void NewCustomer(Customer customer);
        Task<Customer?> UpdateCustomer(Customer customer);
        Task AddProductToCustomer(int customerId, int productId);
        /*Task<Customer?> GetCustomerWithProductsAsync(int id);*/
    }
}
