namespace E.P.C.Models
{
    public class CPU : Product
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Cores { get; set; }
        public int Threads { get; set; }
        public float BaseClock { get; set; } // in GHz
        public float BoostClock { get; set; } // in GHz
        public string SocketType { get; set; } = string.Empty;
        public bool IntegratedGraphics { get; set; }
    }
}
