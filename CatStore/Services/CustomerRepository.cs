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

        public async Task<Customer?> UpdateCustomer(Customer customer)
        {
            var oldcustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);

            if (oldcustomer != null)
            {
                oldcustomer.FirstName = customer.FirstName;
                oldcustomer.LastName = customer.LastName;
                oldcustomer.Email = customer.Email;
                oldcustomer.MobilNumber = customer.MobilNumber;
                oldcustomer.Adress = customer.Adress;

                await _context.SaveChangesAsync();
                return oldcustomer;
            }
            else
            {
                return null;
            }
        }
        public async Task AddProductToCustomer(int customerId, int productId)
        {
            var customer = await _context.Customers
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == customerId);

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (customer == null)
            {
                throw new ArgumentException("Customer not found.");
            }

            if (product == null)
            {
                throw new ArgumentException("Product not found.");
            }

            if (!customer.Products.Contains(product))
            {
                customer.Products.Add(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}

