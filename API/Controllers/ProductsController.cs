using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{    
    public class ProductsController : BaseApiController
    {
        private readonly IProductRepository _repo;
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            this._productsRepo = productsRepo;
            this._productBrandRepo = productBrandRepo;
            this._productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            ProductsWithTypesAndBrandsSpecification spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await _productsRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _productsRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }
        //TODO: Separar em outra Controller
        //TODO: Converter para DTOs e AutoMapper
        [HttpGet("brands")]
        public async Task<ActionResult<List<Product>>> GetProductBrands()
        {
            var productBrands = await _productBrandRepo.ListAllAsync();

            return Ok(productBrands);
        }
        
        //TODO: Separar em outra Controller
        //TODO: Converter para DTOs e AutoMapper
        [HttpGet("types")]
        public async Task<ActionResult<List<Product>>> GetProductTypes()
        {
            var productTypes = await _productTypeRepo.ListAllAsync();

            return Ok(productTypes);
        }
    }
}