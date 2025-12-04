namespace E.P.C.Models
{
    public class Fan : Product
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Size { get; set; } // in mm
        public int RPM { get; set; } // Revolutions per minute
        public int Airflow { get; set; } // in CFM (Cubic Feet per Minute)
        public int NoiseLevel { get; set; } // in dBA
        public string ConnectorType { get; set; } = string.Empty; // e.g., 3-pin, 4-pin PWM
    }
}
