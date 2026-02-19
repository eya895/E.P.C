using E.P.C.Models;
using Microsoft.EntityFrameworkCore;

namespace E.P.C.Data.Seeds
{
    public class MotherBoardSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MotherBoard>().HasData(
                new MotherBoard
                {
                    Id = 19,
                    Brand = "ASUS",
                    Model = "ROG Strix B550-F Gaming",
                    SocketType = "AM4",
                    RAMSlots = 4,
                    MaxRAMCapacity = 128,
                    RAMType = "DDR4",
                    FormFactor = "ATX",
                    Price = 803,
                    Description = "ASUS ROG Strix B550-F Gaming MotherBoard AM4 ATX DDR4",
                    ImageUrl = "https://tms.co.il/image/catalog/products/90MB19V0-M0EAY0/M2VOw178Qc.jpg",
                },
                new MotherBoard
                {
                    Id = 20,
                    Brand = "MSI",
                    Model = "MAG B660M Mortar WiFi DDR4",
                    SocketType = "LGA1700",
                    RAMSlots = 4,
                    MaxRAMCapacity = 128,
                    RAMType = "DDR4",
                    FormFactor = "Micro-ATX",
                    Price = 910,
                    Description = "MSI MAG B660M Mortar WiFi DDR4 MotherBoard LGA1700 Micro-ATX",
                    ImageUrl = "https://media.ldlc.com/r1600/ld/products/00/05/94/22/LD0005942218.jpg"
                },
                new MotherBoard
                {
                    Id = 21,
                    Brand = "Gigabyte",
                    Model = "Z790 AORUS ELITE AX",
                    SocketType = "LGA1700",
                    RAMSlots = 4,
                    MaxRAMCapacity = 128,
                    RAMType = "DDR5",
                    FormFactor = "ATX",
                    Price = 1200,
                    Description = "Gigabyte Z790 AORUS ELITE AX MotherBoard LGA1700 ATX DDR5",
                    ImageUrl = "https://tms.co.il/image/catalog/products/GZ790AORUSELITEAX/lJVeEI0BTp.png"
                }
            );
        }
    }
}
