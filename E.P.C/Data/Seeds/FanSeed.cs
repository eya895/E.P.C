using E.P.C.Models;
using Microsoft.EntityFrameworkCore;

namespace E.P.C.Data.Seeds
{
    public class FanSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fan>().HasData(
                new Fan
                {
                    Id = 13,
                    Brand = "Arctic",
                    Model = "P12 Pro A-RGB 120mm",
                    Size = 120,
                    RPM = 3000,
                    Airflow = 77,
                    NoiseLevel = 25,
                    ConnectorType = "4-pin PWM + 3-pin A-RGB",
                    Price = 59,
                    Description = "Arctic P12 Pro 120mm 4-pin PWM + 3-pin A-RGB Fan - black",
                    ImageUrl = "https://www.arctic.de/media/a2/cd/82/1750770613/P12_Pro_ARGB_black_rainbow_g00_(1).png"
                },
                new Fan
                {
                    Id = 14,
                    Brand = "Lian Li",
                    Model = "UNI FAN P28",
                    Size = 120,
                    RPM = 2600,
                    Airflow = 92,
                    NoiseLevel = 32,
                    ConnectorType = "4-pin PWM + 3-pin A-RGB",
                    Price = 136,
                    Description = "Lian Li UNI FAN P28 4-pin PWM + 3-pin A-RGB Fan - white",
                    ImageUrl = "https://lian-li.com/wp-content/uploads/2023/05/p28-00.jpg"
                },
                new Fan
                {
                    Id = 15,
                    Brand = "Cooler Master",
                    Model = "SickleFlow Edge 120 ARGB",
                    Size = 120,
                    RPM = 2500,
                    Airflow = 71,
                    NoiseLevel = 33,
                    ConnectorType = "3-pin A-RGB",
                    Price = 136,
                    Description = "Cooler Master SickleFlow Edge 120mm 3-pin A-RGB Fan - black",
                    ImageUrl = "https://a.storyblok.com/f/281110/960x960/c7669a7ee9/sickleflow-edge-3pack-01-01.png/m/960x0/smart"
                }
            );
        }
    }
}
