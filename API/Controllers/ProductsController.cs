using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("[controller]")]
    public class Products : Controller
    {
        private readonly StoreContext _storeContext;
        public Products(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _storeContext.Products.FindAsync(id);
        }


        [HttpGet]

        public ActionResult<List<Product>> GetProduct()
        {
            var products = _storeContext.Products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Product>> CreateProducts([FromBody] List<Product> products)
        {
            if (products == null || products.Count == 0)
            {
                return BadRequest("Product data is null or empty.");
            }

            // Add the products to your data store (_storeContext)
            _storeContext.Products.AddRange(products);
            _storeContext.SaveChanges();

            return CreatedAtAction("GetProduct", products); // Returning the list of created products
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _storeContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound(); // Return a 404 Not Found response if the product is not found
            }

            _storeContext.Products.Remove(product);
            await _storeContext.SaveChangesAsync();

            return Ok("Deleted");
        }





    }



}
