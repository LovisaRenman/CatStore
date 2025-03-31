using CatStore.Context;
using CatStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatStore.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CatContext _context;

        public CustomerRepository(CatContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer?> GetCustomer(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }
        public IEnumerable<Customer?> GetCustomerByEmail(string email)
        {
            return _context.Customers.Where(c => c.Email == email);
        }

        public void NewCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChangesAsync();
        }

        public Customer? UpdateCustomer(Customer customer)
        {
            var oldcustomer = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (oldcustomer != null)
            {
                _context.Customers.Update(oldcustomer);
                oldcustomer = customer;
                _context.SaveChangesAsync();
                return customer;
            }
            else return customer;
        }
    }
}
