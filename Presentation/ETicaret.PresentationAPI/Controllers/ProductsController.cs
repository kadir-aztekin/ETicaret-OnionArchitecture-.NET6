using ETicaret.Persistence.Repositories;
using ETicaret.Persistence.Repositories.ProductRepositry;
using Microsoft.AspNetCore.Mvc;
using ETicaret.Application.VİewModels.Product;
using ETicaret.Domain.Entites;
using System.Net;
using ETicaret.Application.Repositories.IProductRepository;

namespace ETicaret.PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductReadRepository _readRepository;
        private IProductWriteRepository _writeRepository;
        public ProductsController(IProductReadRepository readRepository, IProductWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_readRepository.GetAll());
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByİd(string id)
        {
            return Ok( await _readRepository.GetByIdAsync(id,false));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _readRepository.GetByIdAsync(model.Id);
            product.Stock= model.Stock;
            product.Price= model.Price;
            product.Name=model.Name;
           var x = await _writeRepository.SaveAsync();
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            await _writeRepository.AddAsync(new()
            {
                Name=model.Name,
                Price =model.Price,
                Stock=model.Stock
            });
            await _writeRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);

        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await _writeRepository.RemoveAsync(id);
            await _writeRepository.SaveAsync();
            return Ok();

        }
    }
   

}
