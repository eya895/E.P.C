using E.P.C.Models;
using Microsoft.EntityFrameworkCore;

namespace E.P.C.Data.Seeds
{
    public class GPUSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GPUSeed>().HasData(
                new GPU
                {
                    Id = 1,
                    Brand = "NVIDIA",
                    Model = "RTX 5070 Ti",
                    MemorySize = 16,
                    MemoryType = "GDDR7",
                    CoreClock = 2452,
                    BoostClock = 2588,
                    TDP = 300,
                    Interface = "PCIe 5.0 x16",
                    dimensions = "340x140x70mm",
                    Ports = "x3 DP + x1 HDMI",
                    Price = 3990,
                    Description = "NVIDIA GIGABYTE RTX 5070Ti 16GB GDDR7",
                    ImageUrl = ""
                },
                new GPU
                {

                },
                new GPU
                {

                }
                );
        }
    }
}
