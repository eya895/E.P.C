namespace E.P.C.Models
{
    public class CPU : Product
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Cores { get; set; }
        public int Threads { get; set; }
        public double BaseClock { get; set; } // in GHz
        public double BoostClock { get; set; } // in GHz
        public string SocketType { get; set; } = string.Empty;
        public bool IntegratedGraphics { get; set; }
    }
}
