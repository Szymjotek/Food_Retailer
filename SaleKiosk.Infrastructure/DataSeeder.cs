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
            {
                Id = 1,
                SupplierName = "Polska Logistyka",
                Address = "ul. Klonowa 10, 00-001 Warszawa",
                PhoneNumber = "500123456"
            },
            new Supplier
            {
                Id = 2,
                SupplierName = "Warszawskie Dostawy",
                Address = "ul. Dębowa 5, 00-002 Warszawa",
                PhoneNumber = "500234567"
            },
            new Supplier
            {
                Id = 3,
                SupplierName = "Szybki Transport",
                Address = "ul. Sosnowa 15, 00-003 Warszawa",
                PhoneNumber = "500345678"
            },
            new Supplier
            {
                Id = 4,
                SupplierName = "Dostawy Express",
                Address = "ul. Brzozowa 20, 00-004 Warszawa",
                PhoneNumber = "500456789"
            },
            new Supplier
            {
                Id = 5,
                SupplierName = "TransLogistics",
                Address = "ul. Świerkowa 25, 00-005 Warszawa",
                PhoneNumber = "500567890"
            },
            new Supplier
            {
                Id = 6,
                SupplierName = "Logistyka Polska-Czechy",
                Address = "ul. Lipowa 30, 00-006 Warszawa",
                PhoneNumber = "500678901"
            },
            new Supplier
            {
                Id = 7,
                SupplierName = "Dostawcy Północ",
                Address = "ul. Jesionowa 35, 00-007 Warszawa",
                PhoneNumber = "500789012"
            },
            new Supplier
            {
                Id = 8,
                SupplierName = "Przesyłki Wrocław",
                Address = "ul. Kasztanowa 40, 00-008 Warszawa",
                PhoneNumber = "500890123"
            },
            new Supplier
            {
                Id = 9,
                SupplierName = "Ekspresowy Kraków",
                Address = "ul. Modrzewiowa 45, 00-009 Warszawa",
                PhoneNumber = "500901234"
            },
            new Supplier
            {
                Id = 10,
                SupplierName = "PolTrans",
                Address = "ul. Grabowa 50, 00-010 Warszawa",
                PhoneNumber = "500012345"
            },
            new Supplier
            {
                Id = 11,
                SupplierName = "Dostawy 24",
                Address = "ul. Akacjowa 55, 00-011 Warszawa",
                PhoneNumber = "500123457"
            },
            new Supplier
            {
                Id = 12,
                SupplierName = "LogisTransportAGH",
                Address = "ul. Bukowa 60, 00-012 Warszawa",
                PhoneNumber = "500234568"
            },
            new Supplier
            {
                Id = 13,
                SupplierName = "Szybko i Tanio",
                Address = "ul. Topolowa 65, 00-013 Warszawa",
                PhoneNumber = "500345679"
            },
            new Supplier
            {
                Id = 14,
                SupplierName = "Najlepsze Dostawy",
                Address = "ul. Wierzbowa 70, 00-014 Warszawa",
                PhoneNumber = "500456780"
            },
            new Supplier
            {
                Id = 15,
                SupplierName = "30 Minut",
                Address = "ul. Jodłowa 75, 00-015 Warszawa",
                PhoneNumber = "500567891"
            },
            new Supplier
            {
                Id = 16,
                SupplierName = "BudTrans",
                Address = "ul. Jaworowa 80, 00-016 Warszawa",
                PhoneNumber = "500678902"
            },
            new Supplier
            {
                Id = 17,
                SupplierName = "PoloniaTrans",
                Address = "ul. Jesionowa 85, 00-017 Warszawa",
                PhoneNumber = "500789013"
            },
            new Supplier
            {
                Id = 18,
                SupplierName = "TravelFast",
                Address = "ul. Cedrowa 90, 00-018 Warszawa",
                PhoneNumber = "500890124"
            },
            new Supplier
            {
                Id = 19,
                SupplierName = "TransPolska",
                Address = "ul. Osikowa 95, 00-019 Warszawa",
                PhoneNumber = "500901235"
            },
            new Supplier
            {
                Id = 20,
                SupplierName = "Dostawcy - Katowice",
                Address = "ul. Olszowa 100, 00-020 Warszawa",
                PhoneNumber = "500012346"
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
                Name = "Jacobs Cronung",
                Description = "Świeżo palone ziarna kawy",
                UnitPrice = 10.99m,
                ImageUrl = "/images/product/coffee.jpg",
                SupplierId = 1
            },
            new Product
            {   Id = 2,
                Name = "Muszynianka",
                Description = "Woda mineralna",
                UnitPrice = 7.99m,
                ImageUrl = "/images/product/water1.jpg",
                SupplierId = 1
            },
            new Product
            {   Id = 3,
                Name = "Paluszki",
                Description = "Słone przekąski",
                UnitPrice = 7.99m,
                ImageUrl = "/images/product/paluszki.jpg",
                SupplierId = 1
            },
            new Product
            {   Id = 4,
                Name = "Draże Korsarze",
                Description = "Słodkie draże",
                UnitPrice = 7.99m,
                ImageUrl = "/images/product/draze.jpg",
                SupplierId = 2
            },
            new Product
            {   Id = 5,
                Name = "Marsjanki",
                Description = "Suplementy dla dzieci",
                UnitPrice = 7.99m,
                ImageUrl = "/images/product/marsjanki.jpg",
                SupplierId = 3
            },
            new Product
            {   Id = 6,
                Name = "Wedel Czekolada",
                Description = "Pyszna czekolada gorzka",
                UnitPrice = 4.99m,
                ImageUrl = "/images/product/chocolate.jpg",
                SupplierId = 5
            },
            new Product
            {   Id = 7,
                Name = "Żywiec Zdrój",
                Description = "Woda mineralna",
                UnitPrice = 1.99m,
                ImageUrl = "/images/product/water2.jpg",
                SupplierId = 1
            },
            new Product
            {   Id = 8,
                Name = "Tyskie Piwo",
                Description = "Polskie piwo",
                UnitPrice = 2.99m,
                ImageUrl = "/images/product/beer.jpg",
                SupplierId = 6
            },
            new Product
            {   Id = 9,
                Name = "Prince Polo",
                Description = "Baton waflowy",
                UnitPrice = 1.49m,
                ImageUrl = "/images/product/wafer.jpg",
                SupplierId = 1
            },
            new Product
            {   Id = 10,
                Name = "Ogórki Krakus",
                Description = "Tradycyjne polskie ogórki kiszone",
                UnitPrice = 3.99m,
                ImageUrl = "/images/product/pickles.jpg",
                SupplierId = 10
            },
            new Product
            {   Id = 11,
                Name = "Sok Hortex",
                Description = "Naturalny sok owocowy",
                UnitPrice = 2.99m,
                ImageUrl = "/images/product/juice.jpg",
                SupplierId = 1
            },
            new Product
            {   Id = 12,
                Name = "Majonez Winiary",
                Description = "Majonez",
                UnitPrice = 2.49m,
                ImageUrl = "/images/product/mayo.jpg",
                SupplierId = 11
            },
            new Product
            {   Id = 13,
                Name = "Makaron Lubella",
                Description = "Wysokiej jakości makaron",
                UnitPrice = 1.99m,
                ImageUrl = "/images/product/pasta.jpg",
                SupplierId = 11
            },
            new Product
            {   Id = 14,
                Name = "Kubuś",
                Description = "Napój owocowy",
                UnitPrice = 1.29m,
                ImageUrl = "/images/product/drink.jpg",
                SupplierId = 11
            },
            new Product
            {   Id = 15,
                Name = "Mleko",
                Description = "Świeże mleko",
                UnitPrice = 0.99m,
                ImageUrl = "/images/product/milk.jpg",
                SupplierId = 16
            },
            new Product
            {   Id = 16,
                Name = "Żubrówka Wódka",
                Description = "Polska wódka",
                UnitPrice = 12.99m,
                ImageUrl = "/images/product/vodka.jpg",
                SupplierId = 15
            },
            new Product
            {   Id = 17,
                Name = "Dżem Łowicz",
                Description = "Dżem truskawkowy",
                UnitPrice = 3.49m,
                ImageUrl = "/images/product/jam.jpg",
                SupplierId = 12
            },
            new Product
            {   Id = 18,
                Name = "Tymbark",
                Description = "Sok jabłkowy",
                UnitPrice = 2.19m,
                ImageUrl = "/images/product/apple_juice.jpg",
                SupplierId = 11
            },
            new Product
            {   Id = 19,
                Name = "Grześki",
                Description = "Baton waflowy w czekoladzie",
                UnitPrice = 1.19m,
                ImageUrl = "/images/product/wafer_chocolate.jpg",
                SupplierId = 12
            },
            new Product
            {   Id = 20,
                Name = "Wawel Cukierki",
                Description = "Mieszane cukierki",
                UnitPrice = 3.99m,
                ImageUrl = "/images/product/candy.jpg",
                SupplierId = 18
            }
        };

                _dbContext.Products.AddRange(products);
                _dbContext.SaveChanges();
            }
        }
    }
}
