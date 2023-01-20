using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database; 

namespace Infrastructre.Services
{
    public class OrderService
    {
        private readonly DataContext _context;
        public OrderService(DataContext context) 
        {   
            _context = context;
        }
        public List<OrderDto> GetOrders() 
        {
            return _context.Orders.Select(x => new OrderDto()
            {
                Id= x.Id,
                CustomerId= x.CustomerId,
                FullName = string.Concat(x.Customer.FirstName, "" , x.Customer.LastName )
            }).ToList(); 
        }

        public List<OrderDto> GetOrderByDate(DateTime date)
        {
           var orders = _context.Orders.Where(x => x.OrderPlaced == date).ToList();

            if (orders.Count == 0)return new List<OrderDto>();

            var orderDto = orders.Select(x => new OrderDto
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                OrderFullFilled = x.OrderFullFilled,
                OrderPlaced = x.OrderPlaced,
            }).ToList();
            return orderDto;

        }
        public OrderDto GetOrderById(int id)
        {
            var order = _context.Orders.FirstOrDefault(x=>x.Id.Equals(id));
            if (order == null) return null;
            var orderDto =new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderFullFilled = order.OrderFullFilled,
                OrderPlaced = order.OrderPlaced,
            };
            return orderDto;
        }
        public Order GetOrder(int id)
        {
            return _context.Orders.FirstOrDefault(x=>x.Id == id);
        }
       public OrderrDto AddOrder(OrderrDto orderDto)
        {
             var order = new Order(orderDto.Id, orderDto.OrderPlaced, orderDto.OrderFullFilled, orderDto.CustomerId);
            _context.Orders.Add(order);
            var x = _context.SaveChanges();
            if (x == 0) return null;
            return orderDto; 
        }
        public OrderrDto Update(OrderrDto orderDto)
        {
            var order = _context.Orders.Find(orderDto.Id);
            if (order == null) return null; 
            order.OrderPlaced = orderDto.OrderPlaced;
            order.OrderFullFilled = orderDto.OrderFullFilled;
            order.CustomerId = orderDto.CustomerId;
            var x = _context.SaveChanges();
            if (x == 0) return null;
            return orderDto;
        }

        public bool Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return false;
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return true; 
        }
    }
}
