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
        public async Task<IActionResult> Get()
        {
            return Ok("Merhaba");
        }
        
    }
}
