using E.P.C.Models;
using Microsoft.EntityFrameworkCore;

namespace E.P.C.Data.Seeds
{
    public class AIOSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AIO>().HasData(
                new AIO
                {
                    Id = 1,
                    Brand = "Corsair",
                    Model = "iCUE H100i RGB PRO XT",
                    RadiatorSize = 240,
                    PumpSpeed = 2800,
                    FanSize = 120,
                    FanRPM = 2400,
                    NoiseLevel = 36,
                    SupportedSockets = "LGA1200, LGA1150, LGA1151, LGA1155, LGA1156, LGA1366, LGA2011, LGA2066, AM4, AM5, AM3, AM2, sTR4, sTRX4",
                    Price = 569.00,
                    ImageUrl = "https://nanotroniconline.com/wp-content/uploads/2020/09/enfriamiento-liquido-corsair-h100i-elite-capllix-nanotroniconline.png",
                    Description = "Corsair iCUE H100i RGB PRO XT AIO"
                },
                new AIO
                {
                    Id = 2,
                    Brand = "NZXT",
                    Model = "Kraken X63",
                    RadiatorSize = 280,
                    PumpSpeed = 2800,
                    FanSize = 140,
                    FanRPM = 2000,
                    NoiseLevel = 38,
                    SupportedSockets = "LGA1700, LGA1200, LGA1150, LGA1151, LGA1155, LGA1156, LGA1366, LGA2011, LGA2011-3, LGA2066, LGA1851, AM4, AM5",
                    Price = 880.00,
                    Description = "NZXT Kraken X63 AIO",
                    ImageUrl = "https://www.topmarket.co.il/images/detailed/88/GoRTpzh37R.png",
                },
                new AIO
                {
                    Id = 3,
                    Brand = "Cooler Master",
                    Model = "MasterLiquid ML240L V2 RGB",
                    RadiatorSize = 240,
                    PumpSpeed = 2400,
                    FanSize = 120,
                    FanRPM = 2000,
                    NoiseLevel = 30,
                    SupportedSockets = "LGA1851, LGA1700, LGA1200, LGA1156, LGA1155, LGA1151, LGA1150, LGA2066, LGA2011, AM5, AM4, AM3+, AM3, AM2+, AM2, FM2+, FM2, and FM1",
                    Description = "Cooler Master MasterLiquid ML240L V2 RGB AIO",
                    ImageUrl = "https://tms.co.il/image/catalog/products/MLW-D24M-A18PC-R2/yZCRgRdRhR.jpg",   
                    Price = 295.00
                }
            );
        }
    }
}