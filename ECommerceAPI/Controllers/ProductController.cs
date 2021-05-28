using Domain;
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
    public class ProductController : ControllerBase
    {
        private IUnitOfWork _unitOfWork { get; }
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Product> Get([FromRoute]int id)
        {
            return await _unitOfWork.Product.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.Product.GetAll().ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            Product product = new Product(model.CostPerItem, model.StockCount, model.Name, model.MetaData);

            await _unitOfWork.Product.Add(product);
            await _unitOfWork.CommitChanges();

            return Ok();
        }
    }
}
