using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{

    //DbContext provided by entity framwork
    public class StoreContext : DbContext
    {
        //parameterzed Constructor for StoreContext

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        //parameter in the constructor is used to configure the context.
        {
        }

        //DbSet is an Entity Framework Core feature that represents a table or a collection in the database.
        public DbSet<Product> Products { get; set; }
        //Product is a entity class Product.cs

    }


}