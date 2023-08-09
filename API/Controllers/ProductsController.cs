using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController] //marking controller class
    [Route("api/[controller]")]
    //[controller] will replaced controller which we define below
    public class ProductsController : ControllerBase
    //inheritng .Net.Core.MVC     
    // http://localhost:5001/api/products
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "Single product";
        }



    }
}