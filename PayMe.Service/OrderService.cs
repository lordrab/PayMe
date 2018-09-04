using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayMe.Service.Contract;
using PayMe.Service.Models;
using PayMe.Repository.Contract;
using PayMe.Repository;
using PayMe.Model;

namespace PayMe.Service
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        private IRepository<OrderItem> _orderItemRepository;
        private IRepository<Product> _productRepository;
        private IErrorLogService _errorLogService;

        public OrderService(IRepository<Order> orderRepository, IRepository<OrderItem> orderItemRepository,
            IErrorLogService errorLogService, IRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _errorLogService = errorLogService;
            _productRepository = productRepository;
        }

        public ProductServiceAddEditModel AddOrder(OrderServiceAddEditModel model)
        {
            ProductServiceAddEditModel rModel = new ProductServiceAddEditModel();
            try
            {
                Order addOrder = new Order();
               
                if ( model.OrderId == 0)
                {                   
                    _orderRepository.Add(addOrder);
                }
                else
                {
                    addOrder = _orderRepository.GetById(model.OrderId);
                }

                var productData = _productRepository.GetById(model.OrderItemId);
                OrderItem addItem = new OrderItem()
                {
                    ProductId = model.OrderItemId,
                    OrderId = addOrder.Id,
                    Qty = 1,
                     Price = productData.Price
                };
                _orderItemRepository.Add(addItem);
                rModel.Success = true;
                rModel.Update = false;
                rModel.OrderId = addOrder.Id;
                rModel.Id = addItem.ProductId;
                rModel.Price = productData.Price;
                rModel.Qty = 1;
                return rModel;
            }
            catch(Exception error)
            {
                _errorLogService.AddError(new ErrorLogServiceModel
                {
                    error = error,
                    Location = "OrderService",
                    Method = "AddOrder",
                    OtherInfo = ""
                });
                rModel.Success = false;
                rModel.Update = false;
                rModel.Id = 0;
                return rModel;
            }
        }
    }
}
