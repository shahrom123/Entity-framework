
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; }

        public Customer() { }
        public Customer(int id, string firstName, string lastName, string address, string phone, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
            Email = email;
        }
    } 
}
