using ETicaret.Application.Abstactions;
using ETicaret.Application.Repositories.ICustomerRepository;
using ETicaret.Application.Repositories.IOrderRepository;
using ETicaret.Application.Repositories.IProductRepository;
using ETicaret.Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductService _productService;

        readonly private IOrderWriteRepository _aa;
        readonly private IOrderReadRepository _aaRead;
        readonly private ICustomerWriteRepository _aaReadRepository;
        public ProductsController(IProductService productService, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository aa, ICustomerWriteRepository aaReadRepository, IOrderReadRepository aaRead)
        {
            _productService = productService;
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _aa = aa;
            _aaReadRepository = aaReadRepository;
            _aaRead = aaRead;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("get")]
        public async Task Get()
        {
           Order order =await  _aaRead.GetByIdAsync("5141ef1d-96f9-42d8-a1b7-3ceb9f07943c");
            order.Address = "Kars";
            await _aa.SaveAsync();

            //var customerId = Guid.NewGuid();
            //await _aaReadRepository.AddAsync(new() { Id = customerId, Name = "Kadir" });
            //await _aa.AddAsync(new() { Description = "vfafa", Address = "Ankara" ,CustomerId=customerId});
            //await _aa.AddAsync(new() { Description = "blabalbal", Address = "Çorum", CustomerId = customerId });
            //await _aa.SaveAsync();
           //await _productWriteRepository.AddAsync(new() { Name = "C Product", Price = 1.588F, Stock = 10, CreatedDate = DateTime.UtcNow });
           // await _productWriteRepository.SaveAsync();
        }
        [HttpGet("getid")]
        public async Task<IActionResult> Get(string id)
        {
           //Product product= await _productReadRepository.GetByIdAsync(id);
            return Ok();
        }
        [HttpGet("getsıngle")]
        public async Task<IActionResult> GetSingleAsync(Guid id)
        {
           
            //Product product = await _productReadRepository.GetSingleAsync(x=>x.Id==id);
            return Ok();
            
        }
    }
}
