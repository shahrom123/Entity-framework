using Domain.Dtos;
using Domain.Entities;
using Infrastructre.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private OrderService _orderService;
    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("GetOrders")]
    public List<OrderDto> Get()
    {
        return _orderService.GetOrders();
    }

    [HttpGet("GetOrderById")]
    public OrderDto GetById(int id) => _orderService.GetOrderById(id);

    [HttpPost("Add")]
    public OrderrDto AddOrder([FromBody]OrderrDto orderDto)
    {
        return _orderService.AddOrder(orderDto);  
    }

    [HttpPut("Update")]
    public OrderrDto Put([FromBody] OrderrDto order) => _orderService.Update(order);

    [HttpDelete("Delete")]
    public bool Delete(int id) => _orderService.Delete(id);
}
