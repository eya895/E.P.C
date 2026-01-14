namespace E.P.C.Models
{
    public class PSU : Product
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Wattage { get; set; } // in Watts
        public string EfficiencyRating { get; set; } = string.Empty; // e.g., 80 Plus Bronze, Gold, Platinum
        public string FormFactor { get; set; } = string.Empty; // e.g., ATX, SFX
        public bool Modular { get; set; } // true if modular, false otherwise
        public string Connectors { get; set; } = string.Empty; // e.g., 24-pin ATX, 8-pin CPU, PCIe connectors
    }
}
