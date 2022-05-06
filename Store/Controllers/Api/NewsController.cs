using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Business.Interfaces;
using Store.Contracts;
using Store.Contracts.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Controllers.Api
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly IProductService _productService;
        public NewsController(IProductService newsService)
        {
            _productService = newsService; 
        }
        // GET: api/<NewsController>
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAllNewsAsync()
        {
            return await _productService.GetAllAsync();
        }
        [HttpGet("find")]
        public async Task<PagedResponseModel<ProductDto>> PageQueryAsync([FromRoute]PageFilter filter) 
        {
            return await _productService.PagedQueryAsync(filter);
        }
        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public async Task<ProductDto> Get(Guid id)
        {
            return await _productService.GetByIdAsync(id);
        }
    }
}
