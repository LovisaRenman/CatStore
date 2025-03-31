using CatStore.Entities;
using CatStore.Models;
using CatStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatStore.Controllers;

[ApiController]
[Route("api/customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        var productEntity = await _customerRepository.GetAllCustomersAsync();
        var results = new List<CustomerDto>();
        foreach (var entity in productEntity)
        {
            results.Add(new CustomerDto(entity));
        }
        return Ok(results);
    }
    [HttpGet("get/{email}")]
    public ActionResult<IEnumerable<CustomerDto>> GetCustomerByEmail(string email)
    {
        var customersToReturn = _customerRepository.GetCustomerByEmail(email);
        return customersToReturn == null 
            ? NotFound() 
            : Ok(customersToReturn);
    }
    [HttpGet("{id}")]
    public ActionResult<CustomerDto> GetCostumerById(int id)
    {
        var customerToReturn = _customerRepository.GetCustomer(id);
        return customerToReturn == null 
            ? NotFound() 
            : Ok(customerToReturn);
    }
    [HttpPost]
    public ActionResult CreateCustomer(CustomerDto customer)
    {
        _customerRepository.NewCustomer(new Customer(customer));
        return Created();
    }
    [HttpPut("{id}")]
    public ActionResult UpdateCustomer(CustomerDto customer)
    {
        var customerUpdate = _customerRepository.UpdateCustomer(new Customer(customer));
        return customerUpdate == null 
            ? NotFound() 
            : NoContent();
    }
}
