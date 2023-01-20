using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTimeOffset OrderPlaced { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset OrderFullFilled { get; set; } = DateTimeOffset.UtcNow;
        public int CustomerId { get; set;} 
        public Customer Customer { get; set;}
        public OrderDetail OrderDetail { get; set;} 


        public Order()
        {

        }
        public Order(int id, DateTimeOffset orderPlaced, DateTimeOffset orderFullFilled, int customerId)
        {
            Id = id;
            OrderPlaced = orderPlaced;
            OrderFullFilled = orderFullFilled;
            CustomerId = customerId;
        }
    }
}

