using Domain;
using Domain.CustomerAggregate;
using Domain.OrderAggregate;
using Domain.ProductAggregate;
using ECommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private IUnitOfWork _unitOfWork { get; }
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{customerId}")]
        public async Task<Customer> Get([FromRoute] int customerId)
        {
            return await _unitOfWork.Customer.Get(customerId);
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _unitOfWork.Customer.GetAll().ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            Customer customer = new Customer(model.FirstName, model.LastName, model.Email);

            await _unitOfWork.Customer.Add(customer);
            await _unitOfWork.CommitChanges();

            return Ok();
        }

        [HttpGet]
        [Route("{customerId}/order")]
        public async Task<IEnumerable<Order>> GetCustomerOrders([FromRoute] int customerId)
        {
            return (await _unitOfWork.Customer.Get(customerId)).Orders;
        }

        [HttpGet]
        [Route("{customerId}/order/{orderId}")]
        public async Task<Order> GetCustomerOrder([FromRoute] int customerId, [FromRoute] int orderId)
        {
            return (await _unitOfWork.Customer.Get(customerId)).GetOrder(orderId);
        }

        [HttpPost]
        [Route("{customerId}/order")]
        public async Task<IActionResult> CreateOrder([FromRoute] int customerId, OrderModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            // check customer exists
            Customer customer = await _unitOfWork.Customer.Get(customerId);
            if (customer is null)
                return BadRequest("Customer not found");

            // check products exists
            Dictionary<Product, int> productsAndQuantities = new Dictionary<Product, int>();
            foreach (var orderItem in model.OrderItem)
            {
                Product foundProduct = await _unitOfWork.Product.Get(orderItem.ProductId);
                if (foundProduct is null)
                    return BadRequest($"Product with id {orderItem.ProductId} not found");

                productsAndQuantities.Add(foundProduct, orderItem.Quantity);
            }

            // create and save order
            Order order = (await _unitOfWork.Customer.Get(customerId)).CreateOrder(productsAndQuantities);
            await _unitOfWork.Order.Add(order);
            await _unitOfWork.CommitChanges();

            return Ok();
        }
    }
}
