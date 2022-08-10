﻿using ETicaret.Application.Abstactions;
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

        public ProductsController(IProductService productService, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productService = productService;
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
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
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() {Id=Guid.NewGuid(),Name="Product1",Price=100,CreatedDate=DateTime.UtcNow,Stock=10},
            //    new() {Id=Guid.NewGuid(),Name="Product2",Price=200,CreatedDate=DateTime.UtcNow,Stock=20},
            //    new() {Id=Guid.NewGuid(),Name="Product3",Price=300,CreatedDate=DateTime.UtcNow,Stock=130},
            //});
            //await _productWriteRepository.SaveAsync();

          Product product=  await _productReadRepository.GetByIdAsync("8d7cdccd-d78b-4e59-9785-f42e52234ada");
            product.Name = "Kadir";
           await _productWriteRepository.SaveAsync();
        }
        [HttpGet("getid")]
        public async Task<IActionResult> Get(string id)
        {
           Product product= await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
        [HttpGet("getsıngle")]
        public async Task<IActionResult> GetSingleAsync(Guid id)
        {
           
            Product product = await _productReadRepository.GetSingleAsync(x=>x.Id==id);
            return Ok(product);
            
        }
    }
}
