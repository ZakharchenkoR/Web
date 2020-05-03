using Data.Domain.Entities;
using System.Linq;

namespace Data.Domain.DataContext
{
    public static class InitialData
    {
        public static void Initial(AppDbContext context)
        {
            if (!context.Manufacturers.Any())
            {
                context.Manufacturers.Add(new Manufacturer { Id = new System.Guid("c35be0f5-53b5-477c-9bc8-b54c639e6995"), Name = "Apple" });
                context.Manufacturers.Add(new Manufacturer { Id = new System.Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"), Name = "Google" });
                context.SaveChanges();

                context.Phones.Add(new Phone
                {
                    Id = new System.Guid("a4cee576-8f90-4dbf-b1b4-9e9761a5976f"),
                    Name = "Pixel 2XL",
                    ManufacturerId = new System.Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"),
                    Count = 100
                });
                context.Phones.Add(new Phone
                {
                    Id = new System.Guid("755d18ca-2cb5-435c-82b8-60c2639f59df"),
                    Name = "Pixel 4",
                    ManufacturerId = new System.Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"),
                    Count = 100
                });
                context.Phones.Add(new Phone
                {
                    Id = new System.Guid("c35be0f5-53b5-477c-9bc8-b54c639e6995"),
                    Name = "Iphone 6",
                    ManufacturerId = new System.Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"),
                    Count = 100
                });
                context.SaveChanges();
            }
        }
    }
}
