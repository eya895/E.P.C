using E.P.C.Models;
using Microsoft.EntityFrameworkCore;

namespace E.P.C.Data.Seeds
{
    public class RAMSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RAM>().HasData(
                new RAM
                {
                    Id = 25,
                    Brand = "Corsair",
                    Model = "Vengeance LPX",
                    Capacity = 16,
                    Type = "DDR4",
                    Speed = 3200,
                    sticks = 2,
                    Price = 406,
                    Description = "Corsair Vengeance LPX DDR4 RAM 16GB 2x8GB 3200MHz",
                    ImageUrl = "https://ksp.co.il/shop/items/512/69741.jpg"
                },
                new RAM
                {
                    Id = 26,
                    Brand = "G.Skill",
                    Model = "Trident Z RGB",
                    Capacity = 32,
                    Type = "DDR5",
                    Speed = 6000,
                    sticks = 2,
                    Price = 610,
                    Description = "G.Skill Trident Z RGB DDR5 RAM 32GB 2x16 6000MHz",
                    ImageUrl = "https://media.ldlc.com/r1600/ld/products/00/06/05/02/LD0006050270.jpg"
                },
                new RAM
                {
                    Id = 27,
                    Brand = "Kingston",
                    Model = "HyperX Fury",
                    Capacity = 128,
                    Type = "DDR4",
                    Speed = 3600,
                    sticks = 4,
                    Price = 400,
                    Description = "Kingston HyperX Fury DDR4 RAM 128GB 4x32GB 3600MHz",
                    ImageUrl = "https://media.ldlc.com/r1600/ld/products/00/05/42/76/LD0005427627_2_0005709507.jpg"
                }
            );
        }
    }
}
