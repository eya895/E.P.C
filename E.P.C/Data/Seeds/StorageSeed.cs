using E.P.C.Models;
using Microsoft.EntityFrameworkCore;

namespace E.P.C.Data.Seeds
{
    public class StorageSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Storage>().HasData(
                new Storage
                {
                    Id = 28,
                    Brand = "Samsung",
                    Model = "970 EVO Plus",
                    Capacity = 1000,
                    Type = "NVMe",
                    FormFactor = "M.2 Gen 3.0",
                    connectionInterface = "PCIe",
                    Price = 855,
                    Description = "Samsung 970 EVO Plus 1TB NVMe M.2 Gen 3",
                    ImageUrl = "https://computerlounge.co.nz/cdn/shop/files/b7cbb4b89b9aebffd4ffc0f5403298372463901d_32488_3.jpg?v=1720997560&width=1214"
                },
                new Storage
                {
                    Id = 29,
                    Brand = "Western Digital",
                    Model = "Blue 3D NAND",
                    Capacity = 4000,
                    Type = "SSD",
                    FormFactor = "2.5 and M.2 2280",
                    connectionInterface = "SATA",
                    Price = 3447,
                    Description = "WD Blue 3D NAND 4TB SSD 2.5\" and M.2 2280",
                    ImageUrl = "https://ksp.co.il/shop/items/512/328843.jpg"
                },
                new Storage
                {
                    Id = 30,
                    Brand = "Seagate",
                    Model = "Barracuda",
                    Capacity = 24000,
                    Type = "HDD",
                    FormFactor = "3.5",
                    connectionInterface = "SATA",
                    Price = 2989,
                    Description = "Seagate Barracuda 24TB HDD 3.5\" with SATA interface",
                    ImageUrl = "https://www.seagate.com/content/dam/seagate/assets/products/hard-drives/barracuda-3-5-hdd/images/barracuda-24TB-right.png/_jcr_content/renditions/1-1-large-640x640.png"
                }
            );
        }
    }
}
