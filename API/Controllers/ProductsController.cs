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
    }



    }
