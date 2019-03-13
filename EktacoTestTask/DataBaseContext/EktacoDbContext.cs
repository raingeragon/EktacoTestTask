using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EktacoTestTask.Entities;

namespace EktacoTestTask.DataBaseContext
{
    public class EktacoDbContext : System.Data.Entity.DbContext
    {
        public EktacoDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Stores)
                .WithMany(s => s.Products);
        }

        public class Initializer : DropCreateDatabaseIfModelChanges<EktacoDbContext>
        {
            protected override void Seed(EktacoDbContext context)
            {
                List<Group> groups = new List<Group>
                {
                    new Group { Id = 1, Name = "Electronics"},
                    new Group { Id = 2, Name = "Components"},
                    new Group { Id = 3, Name = "Mobile Phones", ParentId = 1},
                    new Group { Id = 4, Name = "Tablets", ParentId = 1},
                    new Group { Id = 5, Name = "Proccesors", ParentId = 2},
                    new Group { Id = 6, Name = "Motherboards", ParentId = 2}
                };

                foreach (var group in groups)
                {
                    context.Groups.Add(group);
                }

                List<Product> products = new List<Product>
                {
                    new Product { Id = 1, Name = "Asus Prime Z390-A", Price = (decimal)176.99, VATPrice = (decimal)210.62, VATRate = 19,
                        GroupId = 6, Stores = new List<Store>{new Store{Id = 1, Name = "Amazon"}, new Store { Id = 2, Name = "Newegg" }}, CreatedTime = DateTime.Now},
                    new Product { Id = 2, Name = "ASRock X99 Extreme11", Price = (decimal)392.99, VATPrice = (decimal)467.66, VATRate = 19,
                        GroupId = 6, Stores = new List<Store>{ new Store { Id = 2, Name = "Newegg"}, new Store {Id = 3, Name = "Alternate"}}, CreatedTime = DateTime.Now},
                    new Product { Id = 3, Name = "Intel Core i9-9900K", Price = (decimal)462.99, VATPrice = (decimal)550.96, VATRate = 19,
                        GroupId = 5, Stores = new List<Store>{ new Store { Id = 1, Name = "Amazon"}, new Store { Id = 3, Name = "Alternate" }}, CreatedTime = DateTime.Now},
                    new Product { Id = 4, Name = "AMD RYZEN 7 2700X", Price = (decimal)258.99, VATPrice = (decimal)308.20, VATRate = 19,
                        GroupId = 5, Stores = new List<Store>{ new Store { Id = 1, Name = "Amazon"}, new Store { Id = 2, Name = "Newegg" }}, CreatedTime = DateTime.Now},
                    new Product { Id = 5, Name = "Apple iPad 9.7\"", Price = (decimal)346.98, VATPrice = (decimal)412.91, VATRate = 19,
                        GroupId = 4, Stores = new List<Store>{ new Store { Id = 1, Name = "Amazon"}, new Store { Id = 3, Name = "Alternate" }}, CreatedTime = DateTime.Now},
                    new Product { Id = 6, Name = "Samsung Galaxy Note 8", Price = (decimal)757.99, VATPrice = (decimal)902.01, VATRate = 19,
                        GroupId = 3, Stores = new List<Store>{ new Store { Id = 2, Name = "Newegg"}, new Store { Id = 3, Name = "Alternate"} }, CreatedTime = DateTime.Now}

                };

                foreach (var product in products)
                {
                    context.Products.Add(product);
                }

                List<Store> stores = new List<Store>
                {
                    new Store {Id = 1, Name = "Amazon", Products = new List<Product>{products[0], products[2], products[3], products[4]}},
                    new Store {Id = 2, Name = "Newegg", Products = new List<Product>{ products[0], products[1], products[3], products[5]}},
                    new Store {Id = 3, Name = "Alternate", Products = new List<Product>{ products[1], products[2], products[4], products[5]}}
                };

                foreach (var store in stores)
                {
                    context.Stores.Add(store);
                }

                context.SaveChanges();
                base.Seed(context);
            }
        }
    }
}