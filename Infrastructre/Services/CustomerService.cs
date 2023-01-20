using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructre.Services
{
    public class CustomerService
    {
        private readonly DataContext _context;
        public CustomerService(DataContext context)
        {
            _context = context;
        }
        public List<CustomerrDto> GetCustomers()
        {
            var customer = _context.Customers.Select(x => new CustomerrDto
            {
                Id = x.Id,
                Address = x.Address,
                FullName= string.Concat(x.FirstName + " "+ x.LastName),
                Phone = x.Phone,
                Email= x.Email,
             
            }).ToList();

            return customer;
        }
        public CustomerDto GetCustomerById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id.Equals(id));
            if (customer == null) return null;
            var customerDto = new CustomerDto()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Phone = customer.Phone,
                Email = customer.Email,
            };
            return customerDto;
        }
        public List<CustomerDto> GetCustomerByName(string name)
        {
            var customers = _context.Customers.Where(x => x.FirstName == name).ToList();
            if (customers.Count == 0) return new List<CustomerDto>();
             var customerDto = customers.Select(x => new CustomerDto
            {
               Id= x.Id,
               FirstName= x.FirstName,
               LastName= x.LastName,
               Address = x.Address,
               Phone = x.Phone,
               Email = x.Email,      
            }).ToList();
            return customerDto;
        }
        public CustomerDto AddCustomer(CustomerDto customerDto)
        {
            var customer = new Customer(customerDto.Id, customerDto.FirstName, customerDto.LastName, customerDto.Address, customerDto.Phone, customerDto.Email);
            _context.Customers.Add(customer);
            var x = _context.SaveChanges();
            if (x == 0) return null;
            return customerDto;
        }

        public CustomerDto Update(CustomerDto customerDto)
        {
            var customer = _context.Customers.Find(customerDto.Id);
            if (customer == null) return null;
            customer.Id= customerDto.Id;
            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.Address = customerDto.Address;
            customer.Phone = customerDto.Phone;
            customer.Email = customerDto.Email;
            var x = _context.SaveChanges();
            if (x == 0) return null;
            return customerDto;
        }
        public bool Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return false;
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return true;
        }
    }
}
