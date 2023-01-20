using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTimeOffset OrderPlaced { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset OrderFullFilled { get; set; } = DateTimeOffset.UtcNow;
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        public string FullName { get; set; }
       

        public OrderDto()
        {

        }
        public OrderDto(int id, string fullName, DateTimeOffset orderPlaced, DateTimeOffset orderFullFilled, int customerId)
        {
            Id = id;
            OrderPlaced = orderPlaced;
            OrderFullFilled = orderFullFilled;
            CustomerId = customerId;
            FullName= fullName;   
        } 
    }
}
