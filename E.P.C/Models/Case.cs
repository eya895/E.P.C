namespace E.P.C.Models
{
    public class Case : Product
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string FormFactor { get; set; } = string.Empty; // e.g., ATX, Micro-ATX, Mini-ITX
        public int MaxGPULength { get; set; } // in mm
        public int MaxCPUCoolerHeight { get; set; } // in mm
        public int DriveBays { get; set; } // Number of drive bays
        public int FanSlots { get; set; } // Number of fan slots
    }
}
