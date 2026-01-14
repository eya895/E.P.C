namespace E.P.C.Models
{
    public class GPU : Product
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int MemorySize { get; set; } // in MB
        public string MemoryType { get; set; } = string.Empty; // e.g., GDDR6
        public int CoreClock { get; set; } // in MHz
        public int BoostClock { get; set; } // in MHz
        public int TDP { get; set; } // in Watts
        public string Interface { get; set; } = string.Empty; // e.g., PCIe 4.0
        public string dimensions { get; set; } = string.Empty; // e.g., Length x Width x Height in mm
        public string Ports { get; set; } = string.Empty; // e.g., HDMI, DisplayPort
    }
}
