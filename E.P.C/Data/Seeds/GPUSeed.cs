using E.P.C.Models;
using Microsoft.EntityFrameworkCore;

namespace E.P.C.Data.Seeds
{
    public class GPUSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GPU>().HasData(
                new GPU
                {
                    Id = 16,
                    Brand = "NVIDIA",
                    Model = "RTX 5070 Ti",
                    MemorySize = 16,
                    MemoryType = "GDDR7",
                    CoreClock = 2452,
                    BoostClock = 2588,
                    TDP = 300,
                    Interface = "PCIe 5.0 x16",
                    dimensions = "340x140x70 mm",
                    Ports = "x3 DP + x1 HDMI",
                    Price = 3990,
                    Description = "NVIDIA GIGABYTE RTX 5070Ti 16GB GDDR7 GPU",
                    ImageUrl = "https://tms.co.il/image/catalog/products/N507TGAMINGOC16GD/MFe2EFfVT7.jpg"
                },
                new GPU
                {
                    Id = 17,
                    Brand = "AMD",
                    Model = "Radeon RX 7900 XTX",
                    MemorySize = 24,
                    MemoryType = "GDDR6",
                    CoreClock = 1929,
                    BoostClock = 2500,
                    TDP = 355,
                    Interface = "PCIe 4.0 x16",
                    dimensions = "287x110x51 mm",
                    Ports = "x2 DP + x1 HDMI + x1 USB-C",
                    Price = 5329,
                    Description = "AMD Sapphire Radeon RX 7900 XTX 24GB GDDR6 GPU",
                    ImageUrl = "https://media.ldlc.com/r1600/ld/products/00/06/00/15/LD0006001513.jpg"
                },
                new GPU
                {
                    Id = 18,
                    Brand = "NVIDIA",
                    Model = "RTX 4060 Ti",
                    MemorySize = 8,
                    MemoryType = "GDDR6",
                    CoreClock = 2310,
                    BoostClock = 2535,
                    TDP = 160,
                    Interface = "PCIe 4.0 x8",
                    dimensions = "240x111x40 mm",
                    Ports = "x3 DP + x1 HDMI",
                    Price = 2305,
                    Description = "NVIDIA MSI RTX 4060Ti 8GB GDDR6 GPU",
                    ImageUrl = "https://m.media-amazon.com/images/I/71hkfByPEiL.jpg"
                }
                );
        }
    }
}
