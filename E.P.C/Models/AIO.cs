namespace E.P.C.Models
{
    public class AIO : Product
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int RadiatorSize { get; set; } // in mm (e.g., 120, 240, 360)
        public int PumpSpeed { get; set; } // in RPM
        public int FanSize { get; set; } // in mm
        public int FanRPM { get; set; } // Revolutions per minute
        public int NoiseLevel { get; set; } // in dBA
        public string SupportedSockets { get; set; } = string.Empty; // e.g., LGA1200, AM4
    }
}
