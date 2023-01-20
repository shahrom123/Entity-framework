using Domain.Dtos;
using Domain.Entities;
using Infrastructre.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private CustomerService _customerService;
    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("GetCustomers")]
    public List<CustomerrDto> Get()
    {
        return _customerService.GetCustomers();
    }
    [HttpGet("GetCustomersByName")]
    public List<CustomerDto> GetCustomersByName(string name)
    {
        return _customerService.GetCustomerByName(name);
    }

    [HttpGet("GetCustomerById")]
    public CustomerDto GetById(int id) => _customerService.GetCustomerById(id);

   
    [HttpPost("Add")]
    public CustomerDto AddCustomer([FromBody] CustomerDto customerDto)
    {
        return _customerService.AddCustomer(customerDto);
    }

    [HttpPut("Update")]
    public CustomerDto Put([FromBody] CustomerDto customer) => _customerService.Update(customer);

    [HttpDelete("Delete")]
    public bool Delete(int id) => _customerService.Delete(id);
}
