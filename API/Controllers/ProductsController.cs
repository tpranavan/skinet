using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private readonly StoreContext _storeContext;
        public IProductRepository _repo { get; }
        public ProductsController(StoreContext storeContext, IProductRepository repo)
        {
            _storeContext = storeContext;
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            
            return Ok(await _repo.GetProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
        // [HttpPost]
        // public ActionResult<IEnumerable<Product>> CreateProducts([FromBody] List<Product> products)
        // {
        //     if (products == null || products.Count == 0)
        //     {
        //         return BadRequest("Product data is null or empty.");
        //     }

        //     // Add the products to your data store (_storeContext)
        //     _storeContext.Products.AddRange(products);
        //     _storeContext.SaveChanges();

        //     return CreatedAtAction("GetProduct", products); // Returning the list of created products
        // }


        // [HttpDelete("{id}")]
        // public async Task<ActionResult> DeleteProduct(int id)
        // {
        //     var product = await _storeContext.ProductTypes.FindAsync(id);

        //     if (product == null)
        //     {
        //         return NotFound(); // Return a 404 Not Found response if the product is not found
        //     }

        //     _storeContext.ProductTypes.Remove(product);
        //     await _storeContext.SaveChangesAsync();

        //     return Ok("Deleted");
        // }





    }



}
