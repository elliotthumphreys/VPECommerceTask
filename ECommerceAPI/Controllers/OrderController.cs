using Domain;
using Domain.OrderAggregate;
using ECommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private IUnitOfWork _unitOfWork { get; }
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Order> Get([FromRoute] int id)
        {
            return await _unitOfWork.Order.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _unitOfWork.Order.GetAll().ToListAsync();
        }
    }
}
