using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data;
using Core.Interfaces;
using Core.Spesifications;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        private readonly IGenericRepository<ProductType> _productType;

        public ProductsController(IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductBrand> productBrand, IGenericRepository<ProductType> productType)
        {
            _productType = productType;
            _productBrand = productBrand;
            _productsRepo = productsRepo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var spec = new ProductWithTypesAndBrandsSpesification();
            var products = await _productsRepo.ListAsync(spec);
            
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpesification(id);

            return await _productsRepo.GetEntityWithSpec(spec);

        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrand.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productType.ListAllAsync());
        }
    }
}