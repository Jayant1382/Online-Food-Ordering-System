using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.OrderMicroservice.DataAccessLayer;


namespace OnlineFoodOrderingSystem.OrderMicroservice.DataAccessLayer
{

    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int id);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrderRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _dbContext.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId)
        {
            return await _dbContext.Orders.Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrder(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
