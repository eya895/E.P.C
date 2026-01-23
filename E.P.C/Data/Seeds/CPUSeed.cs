using E.P.C.Models;
using Microsoft.EntityFrameworkCore;

namespace E.P.C.Data.Seeds
{
    public class CPUSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<CPU>().HasData(
                new CPU
                {
                    Id = 10,
                    Brand = "Intel",
                    Model = "Core i7-13700K",
                    SocketType = "LGA1700",
                    Cores = 16,
                    Threads = 24,
                    BaseClock = 3.4,
                    BoostClock = 5.4,
                    IntegratedGraphics = true,
                    Price = 1250,
                    Description = "Intel Core i7-13700K LGA1700 CPU Integrated Graphics",
                    ImageUrl= "https://tms.co.il/image/catalog/products/C13700KB/Kzi45lJeg9.jpg"
                },
                new CPU
                {
                    Id = 11,
                    Brand = "AMD",
                    Model = "Ryzen 9 7900X",
                    SocketType = "AM5",
                    Cores = 12,
                    Threads = 24,
                    BaseClock = 4.7,
                    BoostClock = 5.6,
                    IntegratedGraphics = false,
                    Price = 1743,
                    Description = "AMD Ryzen 9 7900X AM5 CPU",
                    ImageUrl = "https://ksp.co.il/shop/items/512/228616.jpg"
                },
                new CPU
                {
                    Id = 12,
                    Brand = "AMD",
                    Model = "Ryzen Threadripper 9980X",
                    SocketType = "sTR5",
                    Cores = 64,
                    Threads = 128,
                    BaseClock = 3.2,
                    BoostClock = 5.4,
                    IntegratedGraphics = false,
                    Price = 21268.25,
                    Description = "AMD Ryzen Threadripper 9980X sTR5 CPU",
                    ImageUrl = "https://media.ldlc.com/r1600/ld/products/00/06/26/04/LD0006260489_0006260509_0006260512.jpg"
                }
            );
        }
    }
}
