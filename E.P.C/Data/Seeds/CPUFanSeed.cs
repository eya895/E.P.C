using E.P.C.Models;
using Microsoft.EntityFrameworkCore;

namespace E.P.C.Data.Seeds
{
    public class CPUFanSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<CPUFan>().HasData(
                new CPUFan
                {
                    Id = 7,
                    Brand = "Arctic",
                    Model = "Freezer 36 A-RGB - Black",
                    Size = 159,
                    RPM = 2000,
                    Airflow = 48.8,
                    NoiseLevel = 45,
                    ConnectorType = "3-pin A-RGB",
                    SupportedSockets = "LGA1700, AM4",
                    Price = 190,
                    Description = "Arctic Freezer 36 LGA1700+AM4 3-pin A-RGB CPU Fan - black",
                    ImageUrl = "https://www.arctic.de/media/8f/6d/6c/1707835553/Freezer_36_A-RGB_Black_G01.png"
                },
                new CPUFan
                {
                    Id = 8,
                    Brand = "Arctic",
                    Model = "Freezer 50 TR",
                    Size = 165,
                    RPM = 1750,
                    Airflow = 145.16,
                    NoiseLevel = 20,
                    ConnectorType = "4-pin RGB",
                    SupportedSockets = "sTR4",
                    Price = 229,
                    Description = "Arctic Freezer 50 sTR4 4-pin RGB Cpu Fan",
                    ImageUrl = "https://www.arctic.de/media/26/d8/ab/1598259954/Freezer_50_G00.png"
                },
                new CPUFan
                {
                    Id = 9,
                    Brand = "Noctua",
                    Model = "NH-D12L",
                    Size = 145,
                    RPM = 2000,
                    Airflow = 102.1,
                    NoiseLevel = 22,
                    ConnectorType = "4-pin",
                    SupportedSockets = "LGA1700, AM4/5",
                    Price = 299,
                    Description = "Noctua NH-D12L LGA1700+AM4/5 4-pin CPU Fan",
                    ImageUrl = "https://media.ldlc.com/r1600/ld/products/00/05/96/38/LD0005963837.jpg"
                }
                );
        }
    }
}
