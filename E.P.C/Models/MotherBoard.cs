namespace E.P.C.Models
{
    public class MotherBoard : Product
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string SocketType { get; set; } = string.Empty;
        public int RAMSlots { get; set; }
        public int MaxRAMCapacity { get; set; } // in GB
        public string FormFactor { get; set; } = string.Empty;// e.g., ATX, Micro-ATX, Mini-ITX
    }
}
