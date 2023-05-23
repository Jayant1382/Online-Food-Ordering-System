using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineFoodOrderingSystem.OrderMicroservice.Services;
using OnlineFoodOrderingSystem.OrderMicroservice.Exceptions;

using OnlineFoodOrderingSystem.OrderMicroservice.DataAccessLayer;
using OnlineFoodOrderingSystem.OrderMicroservice.Models;
namespace OnlineFoodOrderingSystem.OrderMicroservice.Services
{

    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task DeleteOrder(int id);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                return await _orderRepository.GetOrderById(id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new ServiceException("An error occurred while retrieving the order.", ex);
            }
        }


        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                return await _orderRepository.GetAllOrders();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new ServiceException("An error occurred while retrieving the orders.", ex);
            }
        }


        public async Task<Order> CreateOrder(Order order)
        {
            try
            {
                
                return order;

            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new ServiceException("An error occurred while creating the order.", ex);
            }
        }


        public async Task<Order> UpdateOrder(Order order)
        {
            try
            {
                await _orderRepository.UpdateOrder(order);
                return order;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new ServiceException("An error occurred while updating the order.", ex);
            }
        }




        public async Task DeleteOrder(int id)
        {
            try
            {
                await _orderRepository.DeleteOrder(id);
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                throw new ServiceException("Failed to delete the order.", ex);
            }
        }

        private OrderModel MapToModel(Order entity)
        {
            return new OrderModel
            {
                Id = entity.Id,
                UserId = entity.UserId,
                OrderDate = entity.OrderDate,
                TotalAmount = entity.TotalAmount,
                Status = entity.Status
            };
        }

        private IEnumerable<OrderModel> MapToModels(IEnumerable<Order> entities)
        {
            var models = new List<OrderModel>();
            foreach (var entity in entities)
            {
                models.Add(MapToModel(entity));
            }
            return models;
        }

        private Order MapToEntity(OrderModel model)
        {
            return new Order
            {
                Id = model.Id,
                UserId = model.UserId,
                OrderDate = model.OrderDate,
                TotalAmount = model.TotalAmount,
                Status = model.Status
            };
        }

        
    }
}
