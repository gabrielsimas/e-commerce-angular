using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo)
        {
            this._productsRepo = productsRepo;
            this._productBrandRepo = productBrandRepo;
            this._productTypeRepo = productTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productsRepo.ListAllAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productsRepo.GetByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<Product>>> GetProductBrands()
        {
            var productBrands = await _productBrandRepo.ListAllAsync();

            return Ok(productBrands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<Product>>> GetProductTypes()
        {
            var productTypes = await _productTypeRepo.ListAllAsync();

            return Ok(productTypes);
        }
    }
}