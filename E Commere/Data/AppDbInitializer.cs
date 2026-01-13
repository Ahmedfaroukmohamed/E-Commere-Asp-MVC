using E_Commere.Data.Enums;
using E_Commere.Models;

namespace E_Commere.Data
{
    public class AppDbInitializer  
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var ApplicationServices = builder.ApplicationServices.CreateScope())
            {
                var context = ApplicationServices.ServiceProvider.GetService<EcommerceDbContext>();
                context.Database.EnsureCreated();

                if (!context.Categories.Any())
                {
                    var categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = "A1",
                            Description = "A1"
                        },

                        new Category()
                        {
                            Name = "A2",
                            Description = "A2"
                        },

                        new Category()
                        {
                            Name = "A3",
                            Description = "A3"
                        },
                        new Category()
                        {
                            Name = "A4",
                            Description = "A4"
                        },
                    };
                    context.Categories.AddRange(categories);
                    context.SaveChanges();
                }
        
                if (!context.Products.Any())
                {
                    var Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "P1",
                            Description = "P1",
                            Price = 50,
                            ImageUrl = "P1",
                            productColor = ProductColor.Red,
                            CategoryId = 1
                        },

                        new Product()
                        {
                            Name = "P2",
                            Description = "P2",
                            Price = 100,
                            ImageUrl = "P2",
                            productColor = ProductColor.Green,
                            CategoryId = 2
                        },

                        new Product()
                        {
                            Name = "P3",
                            Description = "P3",
                            Price = 150,
                            ImageUrl = "P3",
                            productColor = ProductColor.Yellow,
                            CategoryId = 3
                        },
                        new Product()
                        {
                            Name = "P4",
                            Description = "P4",
                            Price = 200,
                            ImageUrl = "P4",
                            productColor = ProductColor.blue,
                            CategoryId = 4
                        }
                    };
                    context.Products.AddRange(Products);
                    context.SaveChanges();
                }
            }
        }
    }
}
