using System;
using System.Collections.Generic;
using Domain;

namespace Persistence
{
    public class DataSeeder
    {
        private readonly DataContext context;

        public DataSeeder(DataContext context)
        {
            this.context = context;
        }

        public void SeedProducts()
        {
            var products = new List<Product>();
            
            products.Add(new Product(){ Id  = Guid.NewGuid(), Name = "Samsung 34 Monitor inches", Price = 25_000});
            products.Add(new Product(){ Id  = Guid.NewGuid(), Name = "iPhone 12 Pro Max", Price = 85_000});
            products.Add(new Product(){ Id  = Guid.NewGuid(), Name = "Macbook Pro 2019", Price = 165_000});
            products.Add(new Product(){ Id  = Guid.NewGuid(), Name = "LG 27 4k Monitor", Price = 30_000});
            products.Add(new Product(){ Id  = Guid.NewGuid(), Name = "Seagate External SSD", Price = 5000});
            
            products.ForEach(p => this.context.Add(p));
            this.context.SaveChanges();
        }
        
        public void SeedCustomers()
        {
            var customers = new List<Customer>();
            customers.Add(new Customer(){ Name = "Randel Ramirez", Address = "Muntinlupa"});
            customers.Add(new Customer(){ Name = "Gem Montemayor", Address = "Manila"});
            customers.Add(new Customer(){ Name = "Lexi the Pug", Address = "Muntinlupa"});
       
            customers.ForEach(c => this.context.Customers.Add(c));
            this.context.SaveChanges();
        }
    }
}