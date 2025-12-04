namespace E.P.C.Models
{
    public class RAM : Product
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; } // in GB
        public string Type { get; set; } = string.Empty; // e.g., DDR4, DDR5
        public int Speed { get; set; } // in MHz
        public int sticks { get; set; } // Number of sticks in the kit
    }
}
