namespace E.P.C.Models
{
    public class Storage : Product
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; } // in GB
        public string Type { get; set; } = string.Empty; // e.g., SSD, HDD, NVMe
        public string FormFactor { get; set; } = string.Empty; // e.g., 2.5", 3.5", M.2
        public string connectionInterface { get; set; } = string.Empty; // e.g., SATA, PCIe
    }
}
