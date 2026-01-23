using E.P.C.Models;
using Microsoft.EntityFrameworkCore;


namespace E.P.C.Data.Seeds
{
    public class PSUSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PSU>().HasData(
                new PSU
                {
                    Id = 22,
                    Brand = "Corsair",
                    Model = "RM750x",
                    Wattage = 750,
                    EfficiencyRating = "80 Plus Gold",
                    FormFactor = "ATX",
                    Modular = true,
                    Connectors = "24-pin ATX, 8-pin EPS/ATX 12V (4+4 pin), PCIe (6+2 pin), 12V-2x6 (12+4 pin), SATA, PATA (4-pin)",
                    Price = 738,
                    Description = "Corsair RM750x ATX 750 Watt 80 Plus Gold Certified Modular PSU",
                    ImageUrl = "https://media.ldlc.com/r1600/ld/products/00/06/19/18/LD0006191829.jpg"
                },
                new PSU
                {
                    Id = 23,
                    Brand = "EVGA",
                    Model = "SuperNOVA 650 G5",
                    Wattage = 650,
                    EfficiencyRating = "80 Plus Gold",
                    FormFactor = "ATX",
                    Modular = true,
                    Connectors = "24-pin ATX, 8-pin EPS/ATX 12V (4+4 pin), PCIe (6+2 pin), SATA, PATA (4-pin), Floppy Adapter",
                    Price = 620,
                    Description = "EVGA SuperNOVA 650 G5 ATX 650 Watt 80 Plus Gold Certified Modular PSU",
                    ImageUrl = "https://images.evga.com/products/gallery/png/220-G5-0650-X1_XL_1.png"
                },
                new PSU
                {
                    Id = 24,
                    Brand = "Seasonic",
                    Model = "Focus GX-850",
                    Wattage = 850,
                    EfficiencyRating = "80 Plus Gold",
                    FormFactor = "ATX",
                    Modular = true,
                    Connectors = "24-pin ATX, 8-pin EPS/ATX 12V (4+4 pin), PCIe (6+2 pin), 12V-2x6 (12+4 pin), SATA, PATA (4-pin)",
                    Price = 770,
                    Description = "Seasonic Focus GX-850 ATX 850 Watt 80 Plus Gold Certified Modular PSU",
                    ImageUrl = "https://datatronic.fi/1137008-large_default/seasonic-focus-gx-virtalahdeyksikko-750-w-20-4-pin-atx-atx-musta-seasonic-focus-gx-750-v4.jpg"
                }
            );
        }
    }
}
