using System.Collections.Generic;

namespace E.P.C.Models.ViewModels
{
    public class PcBuildViewModel
    {
        public int? CpuId { get; set; }
        public int? MotherboardId { get; set; }
        public int? RamId { get; set; }
        public int? GpuId { get; set; }
        public int? PsuId { get; set; }
        public int? StorageId { get; set; }

        // CPU cooling (mutually exclusive)
        public int? CpuFanId { get; set; }
        public int? AioId { get; set; }

        // Case cooling (independent)
        public int? FanId { get; set; }

        public int? CaseId { get; set; }

        public List<CPU> CPUs { get; set; }
        public List<MotherBoard> MotherBoards { get; set; }
        public List<RAM> RAMs { get; set; }
        public List<GPU> GPUs { get; set; }
        public List<PSU> PSUs { get; set; }
        public List<Storage> Storages { get; set; }

        public List<CPUFan> CPUFans { get; set; }
        public List<AIO> AIOs { get; set; }
        public List<Fan> Fans { get; set; }

        public List<Case> Cases { get; set; }

        public double TotalPrice { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}