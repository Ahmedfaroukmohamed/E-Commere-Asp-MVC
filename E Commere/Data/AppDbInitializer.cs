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
                            Name = "A1",
                            Description = "A1",
                            Price = 50,
                            ImageUrl = "A1",
                            productColor = ProductColor.Red,
                            CategoryId = 1
                        },

                        new Product()
                        {
                            Name = "A2",
                            Description = "A2",
                            Price = 100,
                            ImageUrl = "A2",
                            productColor = ProductColor.Green,
                            CategoryId = 2
                        },

                        new Product()
                        {
                            Name = "A3",
                            Description = "A3",
                            Price = 150,
                            ImageUrl = "A3",
                            productColor = ProductColor.Yellow,
                            CategoryId = 3
                        }
                    };
                    context.Products.AddRange(Products);
                    context.SaveChanges();
                }
            }
        }
    }
}
