using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderingSystem.OrderMicroservice.DataAccessLayer;
using OnlineFoodOrderingSystem.OrderMicroservice.Models;
using OnlineFoodOrderingSystem.OrderMicroservice.Services;

namespace OnlineFoodOrderingSystem.OrderMicroservice.Controllers
{

    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int id);
    }


    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                // Log the exception or perform additional error handling
                return StatusCode(500, "An error occurred while retrieving the orders.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            try
            {
                var order = await _orderService.GetOrderById(id);
                if (order == null)
                    return NotFound();

                return Ok(order);
            }
            catch (Exception ex)
            {
                // Log the exception or perform additional error handling
                return StatusCode(500, "An error occurred while retrieving the order.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            try
            {
                await _orderService.CreateOrder(order);
                return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                // Log the exception or perform additional error handling
                return StatusCode(500, "An error occurred while creating the order.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            try
            {
                if (id != order.Id)
                    return BadRequest();

                await _orderService.UpdateOrder(order);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or perform additional error handling
                return StatusCode(500, "An error occurred while updating the order.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                await _orderService.DeleteOrder(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or perform additional error handling
                return StatusCode(500, "An error occurred while deleting the order.");
            }
        }
    }
}
