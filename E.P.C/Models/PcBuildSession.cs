namespace E.P.C.Models.ViewModels
{
    public class PcBuildSession
    {
        public int? CpuId { get; set; }
        public int? GpuId { get; set; }
        public int? RamId { get; set; }
        public int? MotherboardId { get; set; }
        public int? PsuId { get; set; }
        public int? StorageId { get; set; }

        public int? CpuFanId { get; set; }
        public int? AioId { get; set; }

        public int? FanId { get; set; }
        public int? CaseId { get; set; }

        public CPU Cpu { get; set; }
        public GPU Gpu { get; set; }
        public RAM Ram { get; set; }
        public MotherBoard Motherboard { get; set; }
        public PSU Psu { get; set; }
        public Storage Storage { get; set; }
        public Fan Fan { get; set; }
        public Case Case { get; set; }
        public CPUFan CpuFan { get; set; }
        public AIO Aio { get; set; }
    }
}