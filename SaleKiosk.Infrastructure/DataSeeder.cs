using SaleKiosk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaleKiosk.Infrastructure
{
    public class DataSeeder
    {
        private readonly KioskDbContext _dbContext;

        public DataSeeder(KioskDbContext context)
        {
            _dbContext = context;
        }

        public void Seed()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Database.CanConnect())
            {
                SeedCustomers();
                SeedSuppliers();
                SeedProducts();
            }
        }

        private void SeedCustomers()
        {
            if (!_dbContext.Customers.Any())
            {
                var customers = new List<Customer>
                {
                    new Customer
                    {   Id = 1,
                        CustomerName = "John Doe",
                        PhoneNumber = "123456789",
                        Address = "123 Main St"
                    },
                    new Customer
                    {   Id = 2,
                        CustomerName = "Jane Smith",
                        PhoneNumber = "987654321",
                        Address = "456 Elm St"
                    }
                    // Add more customers as needed
                };

                _dbContext.Customers.AddRange(customers);
                _dbContext.SaveChanges();
            }
        }

        private void SeedSuppliers()
        {
            if (!_dbContext.Suppliers.Any())
            {
                var suppliers = new List<Supplier>
                {
                    new Supplier
                    {   Id = 1,
                        SupplierName = "XYZ Distributors",
                        Address = "321 Pine St",
                        PhoneNumber = "555-5678"
                    },
                    new Supplier
                    {   Id = 2,
                        SupplierName = "XYZ Distributors",
                        Address = "321 Pine St",
                        PhoneNumber = "555-5678"                
                    }
             
                };

                _dbContext.Suppliers.AddRange(suppliers);
                _dbContext.SaveChanges();
            }
        }

        private void SeedProducts()
        {
            if (!_dbContext.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {   Id = 1,
                        Name = "Jabobs Cronung",
                        Description = "Freshly roasted coffee beans",
                        UnitPrice = 10.99m,
                        ImageUrl = "/images/product/coffee.jpg"
                    },
                    new Product
                    {   Id=2,
                        Name = "Muszynianka",
                        Description = "Woda",
                        UnitPrice = 7.99m,
                        ImageUrl = "/images/product/tea.jpg"
                    },
                   new Product
                    {   Id=3,
                        Name = "Paluszki",
                        Description = "Spożywcze",
                        UnitPrice = 7.99m,
                        ImageUrl = "/images/product/paluszki.jpg"
                    },
                    new Product
                    {   Id=4,
                        Name = "Draze Korsaze",
                        Description = "Spożywcze draze",
                        UnitPrice = 7.99m,
                        ImageUrl = "/images/product/draze.jpg"
                    },
                     new Product
                    {   Id=5,
                        Name = "Marsjanki",
                        Description = "Suplementy",
                        UnitPrice = 7.99m,
                        ImageUrl = "/images/product/marsjanki.jpg"
                    }
                };

                _dbContext.Products.AddRange(products);
                _dbContext.SaveChanges();
            }
        }
    }
}
